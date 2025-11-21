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

    public Passanger(string name, string surname, DateTime dateOfBirth, string gender, string email, string passwordMethod)
    {
        _id = Guid.NewGuid();
        this.name = name;
        this.surname = surname;
        this.dateOfBirth = dateOfBirth;
        this.gender = gender;
        this.email = email;
        if (passwordMethod == "hardCodedPassword") GeneratePasswordByInput();
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
        Console.WriteLine($"{_id}-{name}-{surname}-{dateOfBirth}-{gender}-{email}");
    }
    
    
}