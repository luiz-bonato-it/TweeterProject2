using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TwitterProject.Models
{
    public class VinculoUsuario
    {
        public int ID { get; set; }
        public bool Ativo {get; set;}

        public string User1ID { get; set; }
        public string User2ID { get; set; }

        [ForeignKey("User1ID")]
        public virtual ApplicationUser Usuario1 { get; set; }

        [ForeignKey("User2ID")]
        public virtual ApplicationUser Usuario2 { get; set; }
    }
}