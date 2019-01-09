using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Statos.Web.UI.Helpers
{
    public class InvisibleCaptchaHelper
    {
        [Display(Name = "InvisibleCaptcha", Order = 20)]
        [Remote("ValidateInvisibleCaptcha", "Captcha", "", ErrorMessage = "Wrong value2")]
        public virtual string InvisibleCaptchaValue { get; set; }
    }
}