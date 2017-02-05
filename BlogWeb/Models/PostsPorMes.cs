using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogWeb.Models
{
    public class PostsPorMes
    {
        public virtual int Mes { get; set; }
        public virtual int Ano { get; set; }
        public virtual long Quantidade { get; set; }

    }
}