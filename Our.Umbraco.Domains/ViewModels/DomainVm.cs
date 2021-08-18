namespace Our.Umbraco.Domains.ViewModels
{
    public class DomainVm
    {
        public int Id { get; set; }

        public string DomainName { get; set; }

        public int? RootContentId { get; set; }

        public ContentVm Content { get; set; }

        public string LanguageIsoCode { get; set; }
    }
}
