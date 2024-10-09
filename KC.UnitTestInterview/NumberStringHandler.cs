namespace KC.UnitTestInterview
{
    public class NumberStringHandler : INumberStringHandler
    {
        public IEnumerable<int> GetNumbersFromString(string numbersToProcess)
        {
            var splitNumbers = numbersToProcess.Split(',');

            return splitNumbers.Select(int.Parse);
        }

        public (int hours, int minutes) GetHoursAndMinutesFromTimeString(string timeString)
        {
            if (!timeString.Contains(':'))
            {
                throw new ArgumentException("Invalid time string");
            }

            var timeParts = timeString.Split(':');

            if (timeParts.Length != 2)
            {
                throw new ArgumentException("Invalid time string");
            }

            var hours = int.Parse(timeParts[0]);
            var minutes = int.Parse(timeParts[1]);

            return (hours, minutes);
        }
    }
}
