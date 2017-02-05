using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogWeb.Models
{
    public class Tag
    {
        public virtual int Id { get; set; }
       
        [Required]
        public virtual String Nome { get; set; }
    }
}