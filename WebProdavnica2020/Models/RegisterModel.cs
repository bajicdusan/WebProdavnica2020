using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebProdavnica2020.Models
{
    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Unesi ime")]
        [StringLength(30, ErrorMessage = "Maksimalno 30 karaktera")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Unesi prezime")]
        [StringLength(30, ErrorMessage = "Maksimalno 30 karaktera")]
        public string Prezime { get; set; }



        [Required(ErrorMessage = "Unesi adresu")]
        [StringLength(100, ErrorMessage = "Maksimalno 100 karaktera")]
        public string Adresa { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "Najamnje 3 karaktera", MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Potvrda ne odgovara lozinci.")]
        public string ConfirmPassword { get; set; }

    }
}
