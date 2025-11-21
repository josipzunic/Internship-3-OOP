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

    public Passanger(string name, string surname, DateTime dateOfBirth, string gender, string email)
    {
        _id = Guid.NewGuid();
        this.name = name;
        this.surname = surname;
        this.dateOfBirth = dateOfBirth;
        this.gender = gender;
        this.email = email;
        this._password = GeneratePassword();
    }
    
    public string GeneratePassword()
    {
        _password = CheckInput.checkPassword();
        return _password;
    }
    
    public static string WritePasswordToConsole()
    {
        string password = "";
        ConsoleKeyInfo key;

        do
        {
            key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Enter)
                break;

            if (key.Key == ConsoleKey.Backspace)
            {
                if (password.Length > 0)
                {
                    password = password[0..^1];
                    Console.Write("\b \b");
                }
            }
            else
            {
                password += key.KeyChar;
                Console.Write("*");
            }

        } while (true);
        Console.WriteLine();
        return password;
    }

    public void WritePassanger()
    {
        Console.WriteLine($"{_id}-{name}-{surname}-{dateOfBirth}-{gender}-{email}");
    }
    
    
}