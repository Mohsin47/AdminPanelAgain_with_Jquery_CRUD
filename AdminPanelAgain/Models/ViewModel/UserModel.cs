using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanelAgain.Models.ViewModel
{
 
    public class UserModel
    {

        public int Id { get; set; }
        public string UserName { get; set; }

        public string FullName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Address { get; set; }

        public int Country { get; set; }

        public string  Image { get; set; }

        public bool IsCsharp { get; set; }
        public bool IsPython { get; set; }
        public bool IsJava { get; set; }


        public bool IsActive { get; set; }
    }
}
