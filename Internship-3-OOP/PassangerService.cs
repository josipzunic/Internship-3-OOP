namespace Internship_3_OOP;

public class PassangerService
{
    public List<Passanger> passangers = new List<Passanger>();
    private const string passwordMethod = "input";
    
    public void generatePassanger()
    {
        Console.WriteLine("Forma za registraciju korisnika");
        string name = CheckInput.CheckGeneralInput("Unesite ime: ");
        string surname = CheckInput.CheckGeneralInput("Unesite prezime: ");
        DateTime dateOfBirth = CheckInput.checkDate("Unesite datum rođenja: ");
        string email = CheckInput.checkEMail();
        string gender = CheckInput.checkSexInput();
        var passanger = new Passanger(name, surname, dateOfBirth, email, gender, passwordMethod);
    
        Console.WriteLine($"Korisnik {name} {surname} uspješno dodan");
        passangers.Add(passanger);
        Menu.waitOnKeyPress();
        Console.Clear();
    }

    public void userLogIn()
    {
        Console.WriteLine("Forma za prijavu korisnika");
        string email = CheckInput.checkEMail();
        string password = CheckInput.checkPasswordInput();

        foreach (var passanger in passangers)
        {
            if (passanger.email == email && passanger.GetPassword() == password)
                Console.WriteLine($"Dobrodošli {passanger.name} {passanger.surname}");
            else
                Console.WriteLine("Netočna lozinka ili email. Probajte se ponovno prijaviti");
        }
        Menu.waitOnKeyPress();
    }
}