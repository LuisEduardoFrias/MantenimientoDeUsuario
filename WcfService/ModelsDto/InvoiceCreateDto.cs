
namespace WcfService.ModelsDto
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;
    //
    using WcfService.Models;
    //

    public class InvoiceCreateDto
    {
        [DataMember]
        [Required]
        public DateTime DateIssued { get; set; }

        [DataMember]
        [Required]
        public User User { get; set; }
    }
}