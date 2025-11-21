using Microsoft.AspNetCore.Mvc;
using ContractClaimsSystem.Data;
using System.Linq;

namespace ContractClaimsSystem.Controllers
{
    public class HRController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HRController(ApplicationDbContext db)
        {
            _db = db;
        }

        // HR Dashboard
        public IActionResult HRDashboard()
        {
            var claims = _db.Claims.ToList();
            return View("HRDashboard", claims); // explicitly points to HRDashboard.cshtml
        }

        // Optional: If you want an Index action
        public IActionResult Index()
        {
            return View("HRDashboard"); // will load the same dashboard
        }

        // Update claim status
        [HttpPost]
        public IActionResult UpdateStatus(int claimId, string status)
        {
            var claim = _db.Claims.FirstOrDefault(c => c.claimID == claimId);
            if (claim != null)
            {
                claim.status = status;
                _db.SaveChanges();
            }

            // Redirect back to the referring page
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
