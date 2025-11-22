namespace Internship_3_OOP;

public class Plane
{
    private static int _idCounter = 1;
    public int capacity, currentCapacity;
    public int id { get; private set; }
    public string name { get; private set; }
    public DateTime manufacturingDate { get; set; }
    public int firstClassSeats { get; set; }
    public int economySeats { get; set; }
    public int businessSeats { get; set; }

    public Plane(string name, DateTime manufacturingDate, int firstClassSeats = 0, int economySeats = 0, int businessSeats = 0)
    {
        this.name = name;
        this.manufacturingDate = manufacturingDate;
        this.firstClassSeats = firstClassSeats;
        this.economySeats = economySeats;
        this.businessSeats = businessSeats;
        capacity = firstClassSeats +  economySeats + businessSeats;
        currentCapacity = capacity;
        id = _idCounter;
        _idCounter++;
    }
    
    
}