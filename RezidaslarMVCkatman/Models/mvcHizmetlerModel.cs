using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RezidaslarMVCkatman.Models
{
    public class mvcHizmetlerModel
    {
        public int HizmetNo { get; set; }
        [Required (ErrorMessage = "Zorunlu Alan!")]
        public string HizmetAdi { get; set; }
        public string aciklama { get; set; }
    }
}