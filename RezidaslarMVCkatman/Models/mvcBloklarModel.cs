using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RezidaslarMVCkatman.Models
{
    public class mvcBloklarModel
    {
        public int BlokNo { get; set; }

        [Required (ErrorMessage = "Zorunlu Alan")]
        public string BlokAdi { get; set; }
        [Required (ErrorMessage = "Zorunlu Alan")]
        public int PlazaNo { get; set; }  
        public int KatSayi { get; set; }

    }
}