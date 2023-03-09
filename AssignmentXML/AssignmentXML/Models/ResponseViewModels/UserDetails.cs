using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace AssignmentXML.Models.ResponseViewModels
{
    public class Information
    {
        [XmlElement("INFORMATION")]
        [JsonProperty("INFORMATION")]
        public Users Info { get; set;}
    }

    public class Users
    {
        [XmlElement("ADDITIONAL_FIELDS")]
        [JsonProperty("ADDITIONAL_FIELDS")]
        List<UserDetails> userDetails;
    }

    public class UserDetails
    {
        [XmlElement("ZPRDTYP")]
        [JsonProperty("ZPRDTYP")]
        public string? ProductType { get; set; }

        [XmlElement("RSTERM")]
        [JsonProperty("RSTERM")]
        public string? RiskTerm{ get; set; }

        [XmlElement("RSTERM")]
        [JsonProperty("PMTERM")]
        public string? PremiumTerm { get; set; }

        [XmlElement("PAYMMETH")]
        [JsonProperty("PAYMMETH")]
        public string? PaymentMethod { get; set; }

        [XmlElement("PAYFREQ")]
        [JsonProperty("PAYFREQ")]
        public string? PaymentFrequency { get; set; }

        [XmlElement("RCDDATE")]
        [JsonProperty("RCDDATE")]
        public string? RiskCommencementDate { get; set; }

        [XmlElement("LASEX")]
        [JsonProperty("LASEX")]
        public string? LifeAssuredGender { get; set; }

        [XmlElement("LADOB")]
        [JsonProperty("LADOB")]
        public string? LifeAssuredDateOfBirth { get; set; }

        [XmlElement("LACRTBL")]
        [JsonProperty("LACRTBL")]
        public string? LifeAssuredComponentCode { get; set; }

        [XmlElement("LAINSPR")]
        [JsonProperty("LAINSPR")]
        public string? LifeAssuredInstallmentPremium { get; set; }


    }
}
