using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GfuQotd.Shared.Validations;

namespace GfuQotd.Shared.Model
{
    public class AuthorForCreateViewModel
    {
        [Required(ErrorMessage = "Bitte geben Sie einen Namen ein!")]
        [Length(2, 100, ErrorMessage = "Name ist zu lang/kurz")]
        [DeniedValues(["administrator","admin","root","god"], ErrorMessage = "Der Name ist nicht erlaubt!")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Bitte geben Sie eine Beschreibung ein!")]
        [MinLength(2, ErrorMessage = "Bitte geben Sie eine Beschreibung mit mind. 2 Zeichen ein")]
        public string Description { get; set; } = string.Empty;

        [NoFutureDate(ErrorMessage = "Geburtsdatum ungültig!")]
        [DataType(DataType.Date)]
        public DateOnly? BirthDate { get; set; }

        public IBrowserFile? Photo { get; set; }
    }
}
