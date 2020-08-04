using System.Runtime.Serialization;

namespace Our.Umbraco.Domains.Core.ViewModels
{

    [DataContract(Name = "content", Namespace = "")]
    public class ContentVm
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "id")]
        public int Id { get; set; }
    }
}
