namespace ContractClaimsSystem.Models
{
    public class Claim
    {
        public string claimantName { get; set; }
        public int claimID { get; set; }
        public string lecturerName { get; set; }
        public int hoursWorked { get; set; }
        public decimal hourRate { get; set; }
        public decimal totalAmount { get; set; }
        public string claimDescription { get; set; }
        public DateTime claimDate { get; set; } = DateTime.Now;
        public string supportingDocumentPath { get; set; }
        public string status { get; set; } = "Pending";
    }
}
