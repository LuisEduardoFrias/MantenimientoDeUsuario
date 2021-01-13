
namespace WcfService.ModelsDto
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;

    [DataContract]
    public class UserCreateDto
    {
        [DataMember]
        [Required]
        public string FullName { get; set; }

        [DataMember]
        [Required]
        public DateTime BirtDay { get; set; }

        [DataMember]
        [Required]
        public string CardNumberId { get; set; }
    }
}