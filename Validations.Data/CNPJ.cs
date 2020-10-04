using System;
using System.Collections.Generic;
using System.Linq;
using static System.Convert;

namespace Validations.Data
{
    public static class CNPJ
    {
        public static bool IsCNPJValid(this string cnpj)
        {
            if (string.IsNullOrWhiteSpace(cnpj))
                return false;

            cnpj = RemovePointsDashesBarsAndSpaces(cnpj);
            if (cnpj.Length != 14)
                return false;

            long numberConverter;
            var isNumberOnly = long.TryParse(cnpj, out numberConverter);
            if (!isNumberOnly)
                return false;

            var repeatedNumbersList = RepeatedNumbers();
            var hasRepeatedNumbers = repeatedNumbersList.Contains(cnpj);
            if (hasRepeatedNumbers)
                return false;

            var cnpjSemDigito = cnpj.Substring(0, 12);

            int[] multiplierNumbers01 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplierNumbers02 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int sum01 = 0;
            for (int i = 0; i < multiplierNumbers01.Length; i += 1)
                sum01 += ToInt32(cnpjSemDigito[i].ToString()) * multiplierNumbers01[i];

            var restfDivision01 = sum01 % 11;
            int firstCheckDigit = restfDivision01 < 2 ? 0 : 11 - restfDivision01;

            cnpjSemDigito = $"{cnpjSemDigito}{firstCheckDigit}";

            int sum02 = 0;
            for (int i = 0; i < multiplierNumbers02.Length; i += 1)
                sum02 += ToInt32(cnpjSemDigito[i].ToString()) * multiplierNumbers02[i];

            var restfDivision02 = sum02 % 11;
            int secondDigitChecker = restfDivision02 < 2 ? 0 : 11 - restfDivision02;

            var verifyingDigit = $"{firstCheckDigit}{secondDigitChecker}";

            return cnpj.EndsWith(verifyingDigit);
        }

        private static string[] RepeatedNumbers()
        {
            var numbers = new List<string>();

            var baseString = "xxxxxxxxxxxxxx";
            for (int i = 0; i < 10; i += 1)
                numbers.Add(baseString.Replace("x", $"{i}"));

            return numbers.ToArray();
        }

        private static string RemovePointsDashesBarsAndSpaces(string text)
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
