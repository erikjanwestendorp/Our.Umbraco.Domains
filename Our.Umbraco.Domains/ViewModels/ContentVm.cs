using System.Runtime.Serialization;

namespace Our.Umbraco.Domains.ViewModels
{
    [DataContract(Name = "content", Namespace = "")]
    public class ContentVm
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}
