using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RezidaslarMVCkatman.Models
{
    public class mvcGorevlerModel
    {
        public int GorevNo { get; set; }
        [Required (ErrorMessage = "Zorunlu Alan!")]
        public string GorevAdi { get; set; }
        public int GorevSuresi { get; set; }
        public string aciklama { get; set; }

    }
}