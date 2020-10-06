/* 
 * url: https://github.com/anderson-serra/validations-data 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using Validations.Data.Common;
using static System.Convert;

namespace Validations.Data
{
    public static class CNPJ
    {
        /// <summary>
        /// Validate whether a CNPJ is valid or not
        /// </summary>
        /// <param name="cnpj">xx.xxx.xxx/xxxx-xx or xxxxxxxxxxxxxx</param>
        /// <typeparam name="string"></typeparam>
        /// <returns>true or false</returns>
        public static bool IsCNPJValid(this string cnpj)
        {
            cnpj = CharacterChanges.RemovePointsDashesBarsAndSpaces(cnpj);
            if (cnpj.Length != 14)
                return false;

            var isNumberOnly = long.TryParse(cnpj, out _);
            if (!isNumberOnly)
                return false;

            if (CnpjListWithRepeatedNumbers().Contains(cnpj))
                return false;

            var cnpjWithoutDigit = cnpj.Substring(0, 12);

            int[] multiplierNumbers01 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplierNumbers02 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            var sum01 = 0;
            for (int i = 0; i < multiplierNumbers01.Length; i += 1)
                sum01 += ToInt32(cnpjWithoutDigit[i].ToString()) * multiplierNumbers01[i];

            var restfDivision01 = sum01 % 11;
            var firstCheckDigit = restfDivision01 < 2 ? 0 : 11 - restfDivision01;

            cnpjWithoutDigit += firstCheckDigit;

            var sum02 = 0;
            for (int i = 0; i < multiplierNumbers02.Length; i += 1)
                sum02 += ToInt32(cnpjWithoutDigit[i].ToString()) * multiplierNumbers02[i];

            var restfDivision02 = sum02 % 11;
            var secondDigitChecker = restfDivision02 < 2 ? 0 : 11 - restfDivision02;

            var verifyingDigit = $"{firstCheckDigit}{secondDigitChecker}";

            return cnpj.EndsWith(verifyingDigit);
        }

        /// <summary>
        /// Formats a CNPJ by adding points, slashes and dashes. This method does not check if the CNPJ is a valid CNPJ, it only formats.
        /// </summary>
        /// <param name="cnpj">xx.xxx.xxx/xxxx-xx or xxxxxxxxxxxxxx</param>
        /// <typeparam name="string"></typeparam>
        /// <returns>xx.xxx.xxx/xxxx-xx</returns>
        public static string FormatCNPJ(this string cnpj)
        {
            if (string.IsNullOrWhiteSpace(cnpj))
                return string.Empty;

            if (cnpj.Length != 14)
                return cnpj;

            return $"{cnpj.Substring(0, 2)}.{cnpj.Substring(2, 3)}.{cnpj.Substring(5, 3)}/{cnpj.Substring(8, 4)}-{cnpj.Substring(12)}";
        }

        private static string[] CnpjListWithRepeatedNumbers()
        {
            var numbers = new List<string>();

            var baseString = "xxxxxxxxxxxxxx";
            for (int i = 0; i < 10; i += 1)
                numbers.Add(baseString.Replace("x", $"{i}"));

            return numbers.ToArray();
        }
    }
}
