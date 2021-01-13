using System;

namespace WcfService.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;

    [DataContract]
    public class User
    {
        [DataMember]
        [Required]
        public int Id { get; set; }

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