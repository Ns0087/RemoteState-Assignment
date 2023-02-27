using System.ComponentModel.DataAnnotations;

namespace Assignment.Models.RequestViewModels
{
    public class HtmlTemplateRequestModel
    {
        int Id { get; set; }

        public string? DocumentCode { get; set; }

        public string? Filename { get; set; }

        public string? ContentType { get; set; }

        public string? Content { get; set; }

        public ByteArrayContent? ContentBinary { get; set; }

        public int IsDeleted { get; set; }

        public string? CreatedUser { get; }

        public DateTime? CreatedDateTime { get; set; }

        public string? ModifiedUser { get; set; }

        public DateTime? ModifiedDateTime { get; set; }
    }
}
