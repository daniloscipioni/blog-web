using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogWeb.ViewModels
{
    public class LoginModel
    {
        [Required]
        [StringLength(9)]
        public virtual string Login { get; set; }
        [Required]
        public virtual string Senha { get; set; }    

    }
}