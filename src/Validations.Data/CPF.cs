using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Validations.Data.Common;

namespace Validations.Data
{
    public static class CPF
    {
        public static bool IsCPFValid(this string cpf)
        {
            cpf = CharacterChanges.RemovePointsDashesBarsAndSpaces(cpf);

            if (cpf.Length != 11)
                return false;

            var isNumberOnly = long.TryParse(cpf, out _);
            if (!isNumberOnly)
                return false;

            if (CpfListWithRepeatedNumbers().Contains(cpf))
                return false;

            var cpfWithoutDigit = cpf.Substring(0, 9);

            int[] multiplierNumbers01 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplierNumbers02 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            var sum01 = 0;
            for (int i = 0; i < 9; i++)
                sum01 += int.Parse(cpfWithoutDigit[i].ToString()) * multiplierNumbers01[i];

            var restfDivision01 = sum01 % 11;
            var firstCheckDigit = restfDivision01 < 2 ? 0 : 11 - restfDivision01;

            cpfWithoutDigit += firstCheckDigit;

            var sum02 = 0;
            for (int i = 0; i < 10; i++)
                sum02 += int.Parse(cpfWithoutDigit[i].ToString()) * multiplierNumbers02[i];

            var restfDivision02 = sum02 % 11;
            var secondDigitChecker = restfDivision02 < 2 ? 0 : 11 - restfDivision02;

            var verifyingDigit = $"{firstCheckDigit}{secondDigitChecker}";

            return cpf.EndsWith(verifyingDigit);
        }

        private static string[] CpfListWithRepeatedNumbers()
        {
            var numbers = new List<string>();

            var baseString = "xxxxxxxxxxx";
            for (int i = 0; i < 10; i += 1)
                numbers.Add(baseString.Replace("x", $"{i}"));

            return numbers.ToArray();
        }
    }
}
