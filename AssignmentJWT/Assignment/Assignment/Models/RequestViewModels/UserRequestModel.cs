using System.ComponentModel.DataAnnotations;

namespace Assignment.Models.RequestViewModels
{
    public class UserRequestModel
    {
        int Id { get; set; }

        public string? Name { get; set; }

        public string? PolicyNumber { get; set; }

        public double Salary { get; set; }

        public string? Occupation { get; set; }

        public DateTime? PolicyExpiryDate { get; set; }

        public string? ProductCode { get; }

        public int Age { get; set; }
    }
}
