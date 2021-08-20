using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanelAgain.Models.ViewModel
{
    public class RegisterViewModel
    {

        public UserDb UserDbs { get; set; }

        public IEnumerable<Country> Countries { get; set; }
    }
}
