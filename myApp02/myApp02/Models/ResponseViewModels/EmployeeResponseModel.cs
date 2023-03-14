using System.ComponentModel.DataAnnotations;

namespace myApp02.Models.RequestViewModels
{
    public class EmployeeResponseModel
    {
        public int Id { get; set; }
      
        public string? FirstName { get; set; }

        public string? LastName { get; set; }
       
        public string? Address { get; set; }
    }
}
