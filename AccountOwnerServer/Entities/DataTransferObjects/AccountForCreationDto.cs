using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class AccountForCreationDto
    {
        [Required(ErrorMessage = "Date Created is required")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Account Type is required")]
        [StringLength(45, ErrorMessage = "Account Type cannot be longer than 45 chars")]
        public string AccountType { get; set; }
        [Required(ErrorMessage = "OwnerId is required")]
        public Guid OwnerId { get; set; }
    }
}
