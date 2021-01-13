
namespace WcfService.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;
    //

    public class Invoice
    {
        [DataMember]
        [Required]
        public int Id { get; set; }

        [DataMember]
        [Required]
        public DateTime DateIssued { get; set; }

        [DataMember]
        [Required]
        public User User { get; set; }
    }
}