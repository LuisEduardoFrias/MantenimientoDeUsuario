
namespace WcfService.ModelsDto
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;
    //
    using WcfService.Models;
    //

    public class InvoiceDetailCreateDto
    {

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
        public ICollection<Product> Product { get; set; }
    }
}