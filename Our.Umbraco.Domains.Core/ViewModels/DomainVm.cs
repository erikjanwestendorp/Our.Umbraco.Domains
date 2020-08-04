using System.Runtime.Serialization;

namespace Our.Umbraco.Domains.Core.ViewModels
{
    [DataContract(Name = "domain", Namespace = "")]
    public class DomainVm
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "domainName")]
        public string DomainName { get; set; }

        [DataMember(Name = "rootContentId")]
        public int? RootContentId { get; set; }

        [DataMember(Name = "content")]
        public ContentVm Content { get; set; }

        [DataMember(Name = "languageIsoCode")]
        public string LanguageIsoCode { get; set; }

    }
}
