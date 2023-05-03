using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RezidaslarMVCkatman.Models
{
    public class mvcPlazalarModel
    {
        public int plazaNo { get; set; }

        [Required (ErrorMessage ="Zorunlu Alan!")]
        public string PlazaAdi { get; set; }
        public int BlokSayi { get; set; }
        public string Sehir { get; set; }
        public string Semt { get; set; }
        public string Adres { get; set; }
    }
}