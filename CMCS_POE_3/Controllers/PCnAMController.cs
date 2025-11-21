using Microsoft.AspNetCore.Mvc;
using ContractClaimsSystem.Data;
using Microsoft.AspNetCore.Http;

namespace ContractClaimsSystem.Controllers
{
    public class PCNAMController : Controller
    {
        private readonly ApplicationDbContext _db;
        public PCNAMController(ApplicationDbContext db) => _db = db;

        public IActionResult PCDashboard()
        {
            var role = HttpContext.Session.GetString("UserRole");
            if (role != "ProgramCoordinator") return RedirectToAction("Login", "Account");

            var claims = _db.Claims.ToList();
            return View(claims);
        }

        public IActionResult AMDashboard()
        {
            var role = HttpContext.Session.GetString("UserRole");
            if (role != "AcademicManager") return RedirectToAction("Login", "Account");

            var claims = _db.Claims.ToList();
            return View(claims);
        }

        [HttpPost]
        public IActionResult UpdateStatus(int claimId, string status)
        {
            var claim = _db.Claims.FirstOrDefault(c => c.claimID == claimId);
            if (claim != null)
            {
                claim.status = status;
                _db.SaveChanges();
            }
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
