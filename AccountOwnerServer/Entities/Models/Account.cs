using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("account")]
    public class Account
    {
        // Dzięki temu mapujemy kolumnę (jej nazwe w DB na nasza zmienną, którą możemy nazwać jak chcemu - i to widac w Jsonie)
        [Column("AccountId")]
        public Guid Id { get; set; }

        [Column("DateCreated")]
        [Required(ErrorMessage = "Date created is required")]
        public DateTime Date { get; set; }

        [Column("AccountType")]
        [Required(ErrorMessage = "Account type is required")]
        [StringLength(45, ErrorMessage = "Address cannot be loner then 100 characters")]
        public string AccountType { get; set; }

        [Column("OwnerId")]
        [ForeignKey(nameof(Owner))]
        [Required(ErrorMessage = "OwnerId is required")]
        public Guid OwnerId { get; set; }

        public Owner Owner { get; set; }


    }
}
