
namespace WcfService.ModelsDto
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;
    //

    public class UserProductCreateDto
    {

        [DataMember]
        [Required]
        public DateTime DateIssued { get; set; }

        [DataMember]
        [Required]
        public int Quantity { get; set; }

        [DataMember]
        [Required]
        public int UserId { get; set; }

        [DataMember]
        [Required]
        public int ProductId { get; set; }
    }
}