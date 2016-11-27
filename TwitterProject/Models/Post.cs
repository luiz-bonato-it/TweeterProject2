using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TwitterProject.Models
{
    public class Post
    {
        public int ID { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Deve ser respeitado o tamanho limite de 200 caracteres!")]
        public string Texto { get; set; }
        public DateTime dataPost { get; set; }
        public string ApplicationUserID { get; set; }

        public virtual ApplicationUser Usuario { get; set; }

    }
}