using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleManagementSystem.Models;

public class VehiclesController : Controller
{
    private readonly VehicleDbContext _context;

    public VehiclesController(VehicleDbContext context)
    {
        _context = context;
    }

    // GET: Vehicles/Create
    public IActionResult Create()
    {
        return View();
    }

    // GET: Vehicles
    public async Task<IActionResult> Index(string searchModel = "")
    {
        var vehiclesQuery = _context.Vehicles.AsQueryable();

        if (!String.IsNullOrEmpty(searchModel))
        {
            vehiclesQuery = vehiclesQuery.Where(v => v.Model.Contains(searchModel));
        }

        var vehicles = await vehiclesQuery.OrderBy(v => v.Model).ToListAsync();
        return View(vehicles);
    }


    // POST: Vehicles/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("RegNo,Model,NumberOfSeats,Colors")] Vehicle vehicle)
    {
        if (ModelState.IsValid)
        {
            _context.Add(vehicle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(vehicle);
    }

}
