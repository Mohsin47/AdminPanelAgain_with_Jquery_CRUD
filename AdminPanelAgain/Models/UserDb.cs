using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminPanelAgain.Models
{
    public  class UserDb
    {
        [Key]
        public int Id { get; set; }

        public string UserName { get; set; }

        public string FullName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Address { get; set; }


        //Country RelationShip
        public int CountryIds { get; set; }

        [ForeignKey("CountryIds")]
        public virtual Country Country { get; set; }


        //ChecnkBoxes
        public bool IsCsharp { get; set; }
        public bool IsPython { get; set; }
        public bool IsJava { get; set; }


        //New 5 fields
        //DateTime

        public DateTime UpdatedOn { get; set; }

        public DateTime CreatedOn { get; set; }


        //String 
        public string UpdatedBY { get; set; }
        public string CreatedBy { get; set; }

        //bool
        public bool IsActive { get; set; }


        public string Image { get; set; }
    }
}
