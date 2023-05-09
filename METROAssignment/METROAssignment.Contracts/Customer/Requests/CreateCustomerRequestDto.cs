using System.ComponentModel.DataAnnotations;

namespace METROAssignment.Contracts.Customer.Requests
{
    public class CreateCustomerRequestDto
    {
        [Required(ErrorMessage = "First Name is required")]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
