/* 
 * url: https://github.com/anderson-serra/validations-data 
 */

namespace Validations.Data.Common
{
    public class CharacterChanges
    {
        public static string RemovePointsDashesBarsAndSpaces(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            var newText = text.Replace(".", "")
                              .Replace("/", "")
                              .Replace("-", "");

            return newText.Trim();
        }
    }
}
