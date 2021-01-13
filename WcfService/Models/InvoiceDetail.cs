
namespace WcfService.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;
    //

    [DataContract]
    public class InvoiceDetail
    {
        [DataMember]
        [Required]
        public int Id { get; set; }

        [DataMember]
        [Required]
        public int Quantity { get; set; }

        [DataMember]
        [Required]
        public Invoice Invoice { get; set; }

        [DataMember]
        [Required]
        public User User { get; set; }

        [DataMember]
        [Required]
        public Product Product { get; set; }
    }
}