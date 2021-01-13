
namespace WcfService.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;
    //

    [DataContract]
    public class Product
    {
        [DataMember]
        [Required]
        public int Id { get; set; }

        [DataMember]
        [Required]
        public string Name { get; set; }

        [DataMember]
        [Required]
        public int Quantity { get; set; }

        [DataMember]
        [Required]
        public string Description { get; set; }

        [DataMember]
        [Required]
        public decimal Price { get; set; }
    }
}