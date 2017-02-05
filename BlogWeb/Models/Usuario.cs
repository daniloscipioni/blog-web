using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogWeb.Models
{
    public class Usuario
    {
        public virtual int? Id { get; set; }
        [Required]
        [StringLength(20)]
        public virtual String Nome { get; set; }
        [Required]
        public virtual String Login { get; set; }
        [Required]
        public virtual String Password { get; set; }
        [EmailAddress]
        public virtual String Email { get; set; }
    }
}