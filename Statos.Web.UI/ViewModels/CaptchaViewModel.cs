using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Statos.Web.UI.ViewModels
{
    public class CaptchaViewModel
    {
        [Display(Name = "Captcha", Order = 20)]
        [Remote("ValidateCaptcha", "Captcha", "", ErrorMessage = "Wrong value")]
        [Required(ErrorMessage = "Required")]
        public virtual string CaptchaValue { get; set; }
    }
}