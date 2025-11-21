namespace Internship_3_OOP;

public class Passanger : AirportPersonnel
{
    private string _password;
    private int _idCounter = 1;
    public int id { get; private set; }
    /*public string name { get; set; }
    public string surname { get; set; }
    public DateTime dateOfBirth { get; set; }
    public string sex { get; set; }*/
    public string email { get; set; }
    public List<Flight> flights { get; set; }

    public Passanger(string name, string surname, DateTime dateOfBirth, string sex, string email, string passwordMethod,
        List<Flight> flights) : base(name,  surname, dateOfBirth, sex)
    {
        id = _idCounter;
        /*this.name = name;
        this.surname = surname;
        this.dateOfBirth = dateOfBirth;
        this.sex = sex;*/
        this.email = email;
        this.flights = flights;
        if (passwordMethod == "hardCodedPassword") GeneratePasswordByInput();
        _idCounter++;
    }
    
    public void GeneratePasswordByInput()
    {
        _password = CheckInput.checkPasswordCreation();
    }

    public void GeneratePasswordHardCoded(string password)
    {
        _password = password;
    }

    public string GetPassword()
    {
        return _password;
    }
    
    public void WritePassanger()
    {
        Console.WriteLine($"{id}-{name}-{surname}-{dateOfBirth}-{sex}-{email}");
    }
    
    
}