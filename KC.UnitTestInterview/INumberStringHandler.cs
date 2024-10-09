namespace KC.UnitTestInterview
{
    public interface INumberStringHandler
    {
        IEnumerable<int> GetNumbersFromString(string numbersToProcess);
        (int hours, int minutes) GetHoursAndMinutesFromTimeString(string timeString);
    }
}