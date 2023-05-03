using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RezidaslarMVCkatman.Models
{
    public class mvcPersonellerModel
    {
        public int PersonelNo { get; set; }
        [Required (ErrorMessage = "Zorunlu Alan!")]
        public string PersonelAdi { get; set; }
        public string telefon { get; set; }
        public string email { get; set; }

    }
}