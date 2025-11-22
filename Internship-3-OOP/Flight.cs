namespace Internship_3_OOP;

public class Flight
{
    private static int _idCounter = 1;
    public TimeSpan timeOfFlight;
    public int id { get; private set; }
    public string name { get; set; }
    public DateTime dateOfDeparture { get; set; }
    public DateTime dateOfArrival { get; set; }
    public double mileage { get; set; }
    public List<Crew> crew { get; set; }
    public Plane plane { get; set; }
    
    public Flight(string name, DateTime dateOfDeparture, DateTime dateOfArrival, double mileage, string setTimeOfFlightMethod,
        List<Crew> crew, Plane plane)
    {
        id = _idCounter;
        this.name = name;
        this.dateOfDeparture = dateOfDeparture;
        this.dateOfArrival = dateOfArrival;
        this.mileage = mileage;
        if (setTimeOfFlightMethod == "input") timeOfFlight = GetTimeOfFlight(dateOfDeparture, dateOfArrival);
        this.crew = crew;
        this.plane = plane;
        _idCounter++;
    }

    public TimeSpan GetTimeOfFlight(DateTime dateOfDeparture, DateTime dateOfArrival)
    {
        
        TimeSpan timeSpan =  dateOfArrival - dateOfDeparture;
        
        return timeSpan;


    }

    public void SetTimeOfFlightInCode(DateTime dateOfDeparture, DateTime dateOfArrival)
    {
        timeOfFlight = dateOfArrival - dateOfDeparture;
    }
}