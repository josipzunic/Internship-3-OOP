namespace Internship_3_OOP;

public class Passanger
{
    private string _password;
    public Guid _id { get; private set; }
    public string name { get; set; }
    public string surname { get; set; }
    public DateTime dateOfBirth { get; set; }
    public string gender { get; set; }
    public string email { get; set; }

    public Passanger(string name, string surname, int age, DateTime dateOfBirth, string gender, string email)
    {
        _id = Guid.NewGuid();
        this.name = name;
        this.surname = surname;
        this.dateOfBirth = dateOfBirth;
        this.gender = gender;
        this.email = email;
    }
    
    public string GeneratePassword()
    {
        return _password;
    }
}