using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.DAL.Entities
{
    [Table("tblDocument")]
    public class Document
    {
        [Required]
        public string? ObjectCode { get; set; }

        [Required]
        public string? ReferenceType { get; set; }

        [Required]
        public string? RefernceNumber { get; set; }

        public byte[]? Content { get; set;}

        [Required]
        public string? Filename { get; set; }

        [Required]
        public string? FileExtension { get; set; }

        [Required]
        public string? LanguageCode { get; set; }

        [Required]
        public string? CreatedUser { get; set; }

        [Required]
        public DateTime? CreatedDateTime { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        [Key]
        [Required]
        public int id { get; }
    }
}
