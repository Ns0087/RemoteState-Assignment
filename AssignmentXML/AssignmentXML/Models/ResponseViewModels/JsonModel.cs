using System.Text.Json;


namespace AssignmentXML.Models.ResponseViewModels
{
    public class JsonModel
    {
        public DateTime? TimeStamp { get; set; }

        public string? Message { get; set; }

        public string? Code { get; set; }

        public JsonElement Body { get; set; }
    }
}
