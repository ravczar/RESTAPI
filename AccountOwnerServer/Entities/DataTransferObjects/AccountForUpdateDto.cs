using Entities.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.DataTransferObjects
{
    public class AccountForUpdateDto
    {
        [Column("DateCreated")]
        [Required(ErrorMessage = "Date created is required")]
        public DateTime Date { get; set; }

        [Column("AccountType")]
        [Required(ErrorMessage = "Account type is required")]
        [StringLength(45, ErrorMessage = "Address cannot be loner then 100 characters")]
        public string AccountType { get; set; }

        [Column("OwnerId")]
        [Required(ErrorMessage = "OwnerId is required")]
        public Guid OwnerId { get; set; }
    }
}
