using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ovning12.Data;
using Ovning12.Models;
using Ovning12.Services;
using Ovning12.ViewModels;

namespace Ovning12.Controllers
{
    public class ParkedVehiclesController : Controller
    {
        private readonly Ovning12Context _context;
        private readonly IGarageHelpers _gh;

        public ParkedVehiclesController(Ovning12Context context, IGarageHelpers gh)
        {
            _context = context;
            _gh = gh;
        }

        public async Task<IActionResult> Statistics()
        {
            var model = await _gh.GetCarageStatisticsAsync();
            return View(model);
        }

        public async Task<IActionResult> Receipt(int? id)
        {
            if (id == null || _context.ParkedVehicle == null || !ParkedVehicleExists((int)id))
            {
                return NotFound();
            }

            var currentTime = DateTimeOffset.Now;
            var vm = _context.ParkedVehicle.Where(pv => pv.ParkedVehicleId == id)
                                           .Select(pv => new ReceiptViewModel
                                           {
                                               ParkedVehicleId = pv.ParkedVehicleId,
                                               VehicleType = pv.VehicleType,
                                               RegistrationNumber = pv.RegistrationNumber,
                                               VehicleMakeAndModel = $"{pv.Make} {pv.Model}",
                                               ArrivalDateTime = pv.ArrivalDateTime,
                                               CheckoutDateTime = currentTime,
                                               Price = _gh.GetPriceForParkedDuration(pv.ArrivalDateTime, currentTime)
                                           });;
            return View(await vm.FirstAsync());
        }
        public async Task<IActionResult> Filter(string registrationNumber, int? vehicleType)
        {
            var model = string.IsNullOrWhiteSpace(registrationNumber) ?
                                    _context.ParkedVehicle :
                                    _context.ParkedVehicle.Where(pv => pv.RegistrationNumber.Contains(registrationNumber));
            model = vehicleType is null ? model : model.Where(pv => (int)pv.VehicleType == vehicleType);

            IQueryable<ParkedVehiclesIndexViewModel> vm = CreateIndexViewModel(model);

            return View(nameof(Index), await vm.ToListAsync());
        }

        private IQueryable<ParkedVehiclesIndexViewModel> CreateIndexViewModel(IQueryable<ParkedVehicle> model)
        {
            return model.Select(pv => new ParkedVehiclesIndexViewModel
            {
                ParkedVehicleId = pv.ParkedVehicleId,
                VehicleType = pv.VehicleType,
                VehicleMakeAndModel = $"{pv.Make} {pv.Model}",
                RegistrationNumber = pv.RegistrationNumber,
                TimeParked = DateTimeOffset.Now - pv.ArrivalDateTime,

            });
        }

        // GET: ParkedVehicles
        public async Task<IActionResult> Index()
        {
            var vm = CreateIndexViewModel(_context.ParkedVehicle);

            return View(await vm.ToListAsync());
        }

        // GET: ParkedVehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ParkedVehicle == null)
            {
                return NotFound();
            }

            var parkedVehicle = await _context.ParkedVehicle
                .FirstOrDefaultAsync(m => m.ParkedVehicleId == id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }

            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ParkedVehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ParkedVehicleId,VehicleType,Model,Make,Color,NumberOfWheels,RegistrationNumber")] ParkedVehicle parkedVehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parkedVehicle);
                parkedVehicle.ArrivalDateTime = DateTimeOffset.Now;

                try
                {
                    await _context.SaveChangesAsync();
                    TempData["FlashMessage"] = new Dictionary<string, string>
                    {
                        { "msg", $"Vehicle {parkedVehicle.RegistrationNumber} checked in" },
                        { "cssClass","alert-success"}
                    };
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    ModelState.AddModelError("RegistrationNumber", "Must be unique!");
                }
            }
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ParkedVehicle == null)
            {
                return NotFound();
            }

            var parkedVehicle = await _context.ParkedVehicle.FindAsync(id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }
            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ParkedVehicleId,VehicleType,Model,Make,Color,NumberOfWheels,RegistrationNumber")] ParkedVehicle parkedVehicle)
        {
            if (id != parkedVehicle.ParkedVehicleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parkedVehicle);
                    _context.Entry(parkedVehicle).Property(x => x.ArrivalDateTime).IsModified = false;
                    await _context.SaveChangesAsync();
                    TempData["FlashMessage"] = new Dictionary<string, string>
                    {
                        { "msg", $"Vehicle details for {parkedVehicle.RegistrationNumber} edited" },
                        { "cssClass","alert-success"}
                    };
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParkedVehicleExists(parkedVehicle.ParkedVehicleId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("RegistrationNumber", "Must be unique!");
                }
                // return RedirectToAction(nameof(Index));
            }
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ParkedVehicle == null)
            {
                return NotFound();
            }

            var parkedVehicle = await _context.ParkedVehicle
                .FirstOrDefaultAsync(m => m.ParkedVehicleId == id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }

            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ParkedVehicle == null)
            {
                return Problem("Entity set 'Ovning12Context.ParkedVehicle'  is null.");
            }
            var parkedVehicle = await _context.ParkedVehicle.FindAsync(id);
            if (parkedVehicle != null)
            {
                _context.ParkedVehicle.Remove(parkedVehicle);
            }

            await _context.SaveChangesAsync();

            TempData["FlashMessage"] = new Dictionary<string, string>
            {
                { "msg", $"Vehicle {parkedVehicle?.RegistrationNumber} checked out" },
                { "cssClass","alert-success"}
            };

            return RedirectToAction(nameof(Index));
        }

        private bool ParkedVehicleExists(int id)
        {
            return _context.ParkedVehicle.Any(e => e.ParkedVehicleId == id);
        }
    }
}
