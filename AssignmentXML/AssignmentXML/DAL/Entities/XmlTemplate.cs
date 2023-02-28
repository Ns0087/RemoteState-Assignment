using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentXML.DAL.Entities
{
    [Table("tblXmlTemplate")]
    public class XmlTemplate
    {
        [Key]
        [Required] 
        public string Code { get; set; }

        [Required]
        public string Xml { get; set; }

        [Required]
        public bool isDeleted { get; set; }

        public int id { get; }
    }

}
