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

        [DisplayName("Numéro de dossier :")]
        public int MedecinID { get; set; }

        [DisplayName("Nom :")]
        public string Nom { get; set; }

        [DisplayName("Prénom :")]
        public string Prenom { get; set; }

        [DisplayName("Adresse :")]
        public string Adresse { get; set; }

        [DisplayName("Numéro de Téléphone :")]
        public string Telephone { get; set; }

        [DisplayName("Code Postal")]
        public string CodePostal { get; set; }

        [DisplayName("Sexe :")]
        public string Sexe { get; set; }

        [DataType(DataType.EmailAddress)]
        [DisplayName("Adresse de courriel")]
        public string Email { get; set; }

        [DisplayName("Note sur le dossier :")]
        public string Note { get; set; }


    }
}
