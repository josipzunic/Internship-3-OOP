namespace Internship_3_OOP;

public class PassangerService
{
    public List<Passanger> passangers = new List<Passanger>();
    private const string passwordMethod = "input";
    
    public void generatePassanger(PassangerService passangerService)
    {
        Console.WriteLine("Forma za registraciju korisnika");
        string name = CheckInput.CheckGeneralInput("Unesite ime: ");
        string surname = CheckInput.CheckGeneralInput("Unesite prezime: ");
        DateTime dateOfBirth = CheckInput.checkDate("Unesite datum rođenja: ");
        string email = CheckInput.checkEMail(passangerService, "registration");
        string gender = CheckInput.checkSexInput();
        var passanger = new Passanger(name, surname, dateOfBirth, email, gender, passwordMethod, new List<Flight>());
    
        Console.WriteLine($"Korisnik {name} {surname} uspješno dodan");
        passangers.Add(passanger);
        Menu.waitOnKeyPress();
        Console.Clear();
    }
    

    public Passanger userLogIn(PassangerService passangerService)
    {
        Passanger? user = null;
        Console.WriteLine("Forma za prijavu korisnika");
        string email = CheckInput.checkEMail(passangerService, "login");
        string password = CheckInput.checkPasswordInput();
        
        foreach (var passanger in passangers)
        {
            if (passanger.email == email && passanger.GetPassword() == password)
            {
                user = passanger;
            }
            else
            {
                Console.WriteLine("Netočna lozinka ili email. Odaberite Prijavu na izborniku za novi pokušaj.");
                Menu.waitOnKeyPress();
            }
        }
        return user;
    }
    
    public  bool userExistance(string email)
    {
        bool userExists = false;
        foreach (var user in passangers)
        {
            if (email == user.email)
            {
                userExists = true;
            }
        }
        return userExists;
    }

    public void listOfUsersFlights(Passanger passanger)
    {
        Console.Clear();
        Console.WriteLine($"Letovi korisnika {passanger.name} {passanger.surname}");
        foreach (var flight in passanger.flights)
        {
            Console.WriteLine($"{flight.id} - {flight.name} - {flight.dateOfDeparture.Date.ToString("yyyy-MM-dd-hh-mm")} - " +
                              $"{flight.dateOfArrival.ToString("yyyy-MM-dd-hh-mm")} - {flight.mileage} - " +
                              $"{flight.timeOfFlight.ToString(@"hh\:mm\:ss")}");
        }
    }
}