using KC.UnitTestInterview.Enums;

namespace KC.UnitTestInterview
{
    public class Calculator
    {
        private readonly INumberStringHandler _stringHandler;

        public Calculator(INumberStringHandler stringHandler)
        {
            _stringHandler = stringHandler;
        }

        public int ProcessNumbers(string numbersToProcess, NumberOperation operation)
        {
            if (string.IsNullOrEmpty(numbersToProcess))
            {
                throw new ArgumentNullException(nameof(numbersToProcess));
            }

            var convertedNumbers = _stringHandler.GetNumbersFromString(numbersToProcess);

            return operation switch
            {
                NumberOperation.Add => convertedNumbers.Sum(),
                NumberOperation.Subtract => convertedNumbers.Sum() * -1,
                _ => throw new ArgumentException("Pass number operation not configured")
            };
        }

        public int GetPercentageDifferenceBetweenNumbers(int numberOne, int numberTwo)
        {
            var differenceBetweenNumbers = Math.Abs(numberOne - numberTwo);
            var averageOfTwoNumbers = (numberOne + numberTwo) / 2;

            var percentageDifference = differenceBetweenNumbers / averageOfTwoNumbers * 100;

            return percentageDifference;
        }

        public int CalculateTotalMinutesForTime(string timeString)
        {
            if (string.IsNullOrEmpty(timeString))
            {
                return 0;
            }

            (int hours, int minutes) = _stringHandler.GetHoursAndMinutesFromTimeString(timeString);

            var minutesFromHours = hours * 60;

            return minutesFromHours + minutes;
        }

        public int GetLargestEvenNumber(string numbersToCheck)
        {
            var convertedNumbers = _stringHandler.GetNumbersFromString(numbersToCheck);

            var largestEvenNumber = 0;

            foreach (var number in convertedNumbers)
            {
                if (number % 2 == 0)
                {
                    if (number > largestEvenNumber)
                    {
                        largestEvenNumber = number;
                    }
                }
            }

            return largestEvenNumber;
        }
    }
}
