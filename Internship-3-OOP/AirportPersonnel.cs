namespace Internship_3_OOP;

public class AirportPersonnel
{
    public string name { get; set; }
    public string surname { get; set; }
    public DateTime dateOfBirth { get; set; }
    public string sex { get; set; }

    public AirportPersonnel(string name, string surname, DateTime dateOfBirth, string sex)
    {
        this.name = name;
        this.surname = surname;
        this.dateOfBirth = dateOfBirth;
        this.sex = sex;
    }
}