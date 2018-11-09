using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Clinique2000.Models
{
    public class medecin
    {

        [DisplayName("Numéro de dossier")]
        public int MedecinID { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 4)]
        [DisplayName("Nom")]
        public string Nom { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 4)]
        [DisplayName("Prénom")]
        public string Prenom { get; set; }

        [DisplayName("Adresse")]
        public string Adresse { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [DisplayName("Numéro de Téléphone")]
        public string Telephone { get; set; }

        [DataType(DataType.PostalCode)]
        [DisplayName("Code Postal")]
        public string CodePostal { get; set; }

        [DisplayName("Sexe")]
        public string Sexe { get; set; }

        [DataType(DataType.EmailAddress)]
        [DisplayName("Adresse de courriel")]
        public string Email { get; set; }

        [StringLength(1000, MinimumLength = 0)]
        [DisplayName("Note sur le dossier")]
        public string Note { get; set; }


    }
}
