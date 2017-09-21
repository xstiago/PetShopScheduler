using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PetShopScheduler.Domain.Validators
{
    public class CpfValidator : IDocumentValidator
    {
        public bool Validate(string document)
        {
            int[] mt1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] mt2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tmpCpf;
            string digit;
            int sum;
            int rest;

            document = document.Trim();
            document = document.Replace(".", "").Replace("-", "");

            if (document.Length != 11)
                return false;

            tmpCpf = document.Substring(0, 9);
            sum = 0;
            for (int i = 0; i < 9; i++)
                sum += int.Parse(tmpCpf[i].ToString()) * mt1[i];

            rest = sum % 11;
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digit = rest.ToString();
            tmpCpf = tmpCpf + digit;
            sum = 0;

            for (int i = 0; i < 10; i++)
                sum += int.Parse(tmpCpf[i].ToString()) * mt2[i];

            rest = sum % 11;
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digit = digit + rest.ToString();

            return document.EndsWith(digit);
        }
    }
}
