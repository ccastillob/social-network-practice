using ProyectoPracticaRedSocial.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPracticaRedSocial.Models
{
    public class User
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public short Age { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime DateCreated { get; set; } = DateTime.Now;

        public bool isValid(bool validateAge = true)
        {
            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Email) || !HelperValidator.isValidEmail(Email)) return false;

            if ((Age < 0 || Age > 250) && validateAge) return false;

            return true;
        }

    }
}
