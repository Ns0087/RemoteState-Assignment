using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Assignment.DAL.Entities
{
    [Table("tblUser")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        [Required]
        [StringLength(50)]
        public string? PolicyNumber { get; set; }

        [Required]
        public int Salary { get; set; }

        [Required]
        [StringLength(50)]
        public string? Occupation { get; set; }

        [Required]
        public DateTime? PolicyExpiryDate { get; set; }

        [Required]
        [StringLength(50)]
        public string? ProductCode { get; set; }

        [StringLength(100)]
        public string? EmailAddress { get; set; }

        [Required]
        public int Age { get; set; }

    }
}
