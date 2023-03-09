using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace AssignmentXML.Models.ResponseViewModels
{
    public class User
    {
        [XmlElement("ADDITIONAL_FIELDS")]
        [JsonProperty("ADDITIONAL_FIELDS")]
        public List<UserDetails> userDetails { get; set; }
    }

    public class UserDetails
    {
        [JsonProperty("ZPRDTYP")]
        public string? ProductType { get; set; }

        [JsonProperty("RSTERM")]
        public string? RiskTerm{ get; set; }

        [JsonProperty("PMTERM")]
        public string? PremiumTerm { get; set; }

        [JsonProperty("PAYMMETH")]
        public string? PaymentMethod { get; set; }

        [JsonProperty("PAYFREQ")]
        public string? PaymentFrequency { get; set; }

        [JsonProperty("RCDDATE")]
        public string? RiskCommencementDate { get; set; }

        [JsonProperty("LASEX")]
        public string? LifeAssuredGender { get; set; }

        [JsonProperty("LADOB")]
        public string? LifeAssuredDateOfBirth { get; set; }

        [JsonProperty("LACRTBL")]
        public string? LifeAssuredComponentCode { get; set; }

        [JsonProperty("LAINSPR")]
        public string? LifeAssuredInstallmentPremium { get; set; }


    }
}
