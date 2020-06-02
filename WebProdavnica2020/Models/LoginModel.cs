using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebProdavnica2020.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Unesi email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Unesi lozinku")]
        [DataType(DataType.Password)]
        [Display(Name = "Lozinka")]
        public string Password { get; set; }

        [Display(Name = "Zapamti me?")]
        public bool RememberMe { get; set; }

    }
}
