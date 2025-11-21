namespace Internship_3_OOP;

public class Crew : AirportPersonnel
{
    public string position { get; set; }

    public Crew(string name, string surname, DateTime dateOfBirth, string sex, string position)
        : base(name, surname, dateOfBirth, sex)
    {
        this.position = position;
    }
}