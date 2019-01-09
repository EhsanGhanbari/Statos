using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Statos.Service.Accounts
{
    public class AccountViewModel
    {
        public int AccountId { get; set; }

        [Required(ErrorMessage = "First Name is Empty")]
        public string FirstName { get; set; }


        [Required(ErrorMessage="Last Name is Empty")]
        public string LastName { get; set; }


        [Required(ErrorMessage="Email is Empty")]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Must be a valid email")]
        public string Email { get; set; }
        

        [Required(ErrorMessage="User Name is Empty")]
        public string UserName { get; set; }


        [Required(ErrorMessage="Password is Empty")]
        [DataType(DataType.Password)]
        [StringLength(6, ErrorMessage = "Must be between 6 and 12 characters", MinimumLength = 6)]
        public string Password { get; set; }


        [Required(ErrorMessage ="Password Confirmation is Empty")]
      //  [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email is Empty")]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Must be a valid email")]
        public string SecurityEmail { get; set; }
       

        public string Sex { get; set; }
      
        public string Role { get; set; }

        public string MobileNumber { get; set; }
       

        [Required(ErrorMessage="Telephone Number Required")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]
        public string PhoneNumber { get; set; }






        //Stuff about SelectList 
        public List<SelectListItem> SelectedItemForRole { get; set; }
        public List<SelectListItem> SelectedItemForGender { get; set; }
        public string SelectedValue { get; set; }




        public static AccountViewModel GetGender()
        {
            var model = new AccountViewModel { SelectedItemForGender = new List<SelectListItem>() };
            model.SelectedItemForGender.Add(new SelectListItem() { Text = "Male", Value = "1" });
            model.SelectedItemForGender.Add(new SelectListItem() { Text = "Female", Value = "2" });
            return model;
        }


        public static AccountViewModel GetRole()
        {
            var model = new AccountViewModel { SelectedItemForRole = new List<SelectListItem>() };
            model.SelectedItemForRole.Add(new SelectListItem() { Text = "Administrator", Value = "1" });
            model.SelectedItemForRole.Add(new SelectListItem() { Text = "Operator", Value = "2" });
            return model;
        }

    }
}
