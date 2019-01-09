using System.Text.RegularExpressions;

namespace Statos.Web.UI.Helpers
{
    public static class SlugGeneratorHelper
    {
        public static string GenerateSlug(this string phrase, int maxLength = 100)
        {
            string str = phrase.ToLower();
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
            str = Regex.Replace(str, @"[\s-]+", " ").Trim();
            str = str.Substring(0, str.Length <= maxLength ? str.Length : maxLength).Trim();
            str = Regex.Replace(str, @"\s", "-");
            return str;
        }
    }
}