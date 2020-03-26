using System;

namespace CreditCardChecker
{
    public class CreditCardChecker
    {
        /// <summary>
        /// Diese Methode überprüft eine Kreditkartenummer, ob diese gültig ist.
        /// Regeln entsprechend der Angabe.
        /// </summary>
        public static bool IsCreditCardValid(string creditCardNumber)
        {
            bool result = false;

            if (creditCardNumber.Length == 16)
            {
                bool swap = false;
                int evenNumber = 0;
                int oddNumber = 0;

                for (int i = 0; i < creditCardNumber.Length - 1; i++)
                {
                    if (!swap)
                    {
                        int tmp = ConvertToInt(creditCardNumber[i]) * 2;
                        if (tmp > 9)
                        {
                            tmp = tmp - 9;
                        }
                        evenNumber = (evenNumber * 10) + tmp;
                        swap = true;
                    }
                    else
                    {
                        int tmp = ConvertToInt(creditCardNumber[i]);
                        oddNumber = (oddNumber * 10) + tmp;
                        swap = false;
                    }
                }

                evenNumber = CalculateDigitSum(evenNumber);
                oddNumber = CalculateDigitSum(oddNumber);
                int checkDigit = CalculateCheckDigit(oddNumber, evenNumber);

                if (checkDigit == creditCardNumber[15] - '0')
                {
                    result = true;
                }
            }
            return result;
        }

        /// <summary>
        /// Berechnet aus der Summe der geraden Stellen (bereits verdoppelt) und
        /// der Summe der ungeraden Stellen die Checkziffer.
        /// </summary>
        private static int CalculateCheckDigit(int oddSum, int evenSum)
        {
            int sum = oddSum + evenSum;
            int result = 0;

            while((sum + result) % 10 != 0)
            {
                result++;
            }

            return result;
        }

        /// <summary>
        /// Berechnet die Ziffernsumme einer Zahl.
        /// </summary>
        private static int CalculateDigitSum(int number)
        {
            int result = 0;

            //42424873
            while(number != 0)
            {
                result += (number % 10);
                number = number / 10;
            }

            return result;
        }

        private static int ConvertToInt(char ch)
        {
            int result = ch - '0';

            return result;
        }
    }
}
