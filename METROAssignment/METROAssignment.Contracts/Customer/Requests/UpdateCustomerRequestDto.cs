using System.ComponentModel.DataAnnotations;

namespace METROAssignment.Contracts.Customer.Requests
{
    public class UpdateCustomerRequestDto
    {
        [Required(ErrorMessage = "Last Name is required")]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
