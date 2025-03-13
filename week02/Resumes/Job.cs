public class Job
{
    // Member variables (attributes)
    public string _company;
    public string _jobTitle;
    public int _startYear;
    public int _endYear;

    // Method to display job details
    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}
