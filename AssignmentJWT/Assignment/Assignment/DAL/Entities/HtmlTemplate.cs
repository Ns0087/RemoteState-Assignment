using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.DAL.Entities
{
    [Table("tblHtmlTemplate")]
    public class HtmlTemplate
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string DocumentCode { get; set; }

        [StringLength(255)]
        public string Filename { get; set; }

        [StringLength(30)]
        public string ContentType { get; set; }

        public string? Content { get; set; }

        public byte[]? ContentBinary { get; set; }

        public bool IsDeleted { get; set; }

        
        public string CreatedUser { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public string? ModifiedUser { get; set; }

        public DateTime? ModifiedDateTime { get; set;}

    }
}
