using System.ComponentModel.DataAnnotations;

namespace BloodBankWebAPI.Models
{
    public class BloodBankEntry
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Donor Name is required.")]
        [StringLength(100, ErrorMessage = "Donor Name cannot exceed 100 characters.")]
        public string DonorName { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        [Range(18, 65, ErrorMessage = "Age must be between 18 and 65.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Blood Type is required.")]
        [RegularExpression(@"^(A|B|AB|O)[+-]$", ErrorMessage = "Invalid Blood Type format. Use A+, B-, etc.")]
        public string BloodType { get; set; }

        [Required(ErrorMessage = "Contact Info is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string ContactInfo { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(50, 5000, ErrorMessage = "Quantity must be between 50 ml and 5000 ml.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Collection Date is required.")]
        public DateTime CollectionDate { get; set; }

        [Required(ErrorMessage = "Expiration Date is required.")]
        public DateTime ExpirationDate { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        [RegularExpression(@"^(Available|Requested|Expired)$", ErrorMessage = "Status must be 'Available', 'Requested', or 'Expired'.")]
        public string Status { get; set; }
    }
}