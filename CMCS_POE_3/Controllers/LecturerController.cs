using Microsoft.AspNetCore.Mvc;
using ContractClaimsSystem.Data;
using ContractClaimsSystem.Models;
using Microsoft.AspNetCore.Http;

namespace ContractClaimsSystem.Controllers
{
    public class LecturerController : Controller
    {
        private readonly ApplicationDbContext _db;
        public LecturerController(ApplicationDbContext db) => _db = db;

        public IActionResult SubmitClaim() => View();

        [HttpPost]
        public IActionResult SubmitClaim(Claim claim, IFormFile? supportingDocument)
        {
            if (supportingDocument != null)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                if (!Directory.Exists(uploadsFolder)) Directory.CreateDirectory(uploadsFolder);

                var filePath = Path.Combine(uploadsFolder, supportingDocument.FileName);
                using var stream = new FileStream(filePath, FileMode.Create);
                supportingDocument.CopyTo(stream);

                claim.supportingDocumentPath = "/uploads/" + supportingDocument.FileName;
            }

            claim.totalAmount = claim.hoursWorked * claim.hourRate;
            claim.status = "Pending";

            _db.Claims.Add(claim);
            _db.SaveChanges();

            ViewBag.Message = "Claim submitted successfully!";
            return View();
        }

        public IActionResult MyClaims()
        {
            var claims = _db.Claims.ToList();
            return View(claims);
        }
    }
}
