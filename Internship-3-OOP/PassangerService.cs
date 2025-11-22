namespace Internship_3_OOP;

public class PassangerService
{
    public List<Passanger> passangers = new();
    public List<Flight> flights = new();
    public const string passwordMethod = "input";
    public const string writeGeneralFlights = "general";
    public const string writeUserFlights = "userSpecific";
    public const string affirmation = "da";
    public const string negation = "ne";
    
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
                user.availableFlights = new List<Flight>(flights);
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

    public void ListOfFlights(Passanger passanger, string condition, List<Flight> flightList)
    {
        //Console.Clear();
        if (condition == writeUserFlights) 
            Console.WriteLine($"Letovi korisnika {passanger.name} {passanger.surname}: ");
        else if (condition == writeGeneralFlights) 
            Console.WriteLine("Svi dostupni letovi: ");
        if(passanger.flights.Count == 0 && condition == writeUserFlights) 
            Console.WriteLine("Ovaj korisnik nema zakazanih letova");
        foreach (var flight in flightList)
        {
            Console.WriteLine($"{flight.id} - {flight.name} - {flight.dateOfDeparture.Date.ToString("yyyy-MM-dd-hh-mm")} - " +
                              $"{flight.dateOfArrival.ToString("yyyy-MM-dd-hh-mm")} - {flight.mileage} - " +
                              $"{flight.timeOfFlight.ToString(@"hh\:mm\:ss")}");
        }
    }

    public List<int> fetchFlightIds(List<Flight> flightList)
    {
        var ids = new List<int>();
        foreach (var flight in flightList) ids.Add(flight.id);
        return ids;
    }
    
    public void ChooseFlight(Passanger passanger)
    {
        var ids = fetchFlightIds(flights);
        int choice = CheckInput.CheckIds(ids);
        string seatingHierarchy = CheckInput.checkSeatingHierarchy();
        var flightToAdd = flights.Find(flight => flight.id == choice);
        if (flightToAdd != null)
        {
            string confirmation = Menu.confirmationMessage("dodati");
            if (confirmation == affirmation)
            {
                passanger.flights.Add(flightToAdd);
                Console.WriteLine("Let dodan");
            }
            else if (confirmation == negation)
            {
                Console.WriteLine("Otkazivanje akcije. Vraćanje na meni s opcijama");
            }
        }

        passanger.availableFlights.Remove(flightToAdd);
    }

    public void ListOfFlightsFiltered(List<Flight> flightList, Passanger passanger,
        PassangerService passangerService)
    {
        Console.WriteLine("1 - id\n" +
                          "2 - ime\n" +
                          "3 - povratak");
        string condition = CheckInput.CheckMenuInput(3);
        var matchingFlightList = new List<Flight>();
        
        if (condition == "1" && passanger.flights.Count != 0)
        {
            int id = CheckInput.checkFlightIdExistance(flightList);
            Flight targetFlight = flightList.Find(flight => flight.id == id);
            if (targetFlight != null)
            {
                matchingFlightList.Add(targetFlight);
                ListOfFlights(passanger, writeUserFlights, matchingFlightList);
            }
            
        }
        else if (condition == "2" && passanger.flights.Count != 0)
        {
            string name = CheckInput.checkFlightNameExistance(flightList);
            var targetFlights = flightList.FindAll(flight => flight.name == name);
            foreach (var targetFlight in targetFlights)
                if (targetFlight != null)
                {
                    matchingFlightList.Add(targetFlight);
                    ListOfFlights(passanger, writeUserFlights, matchingFlightList);
                }
            
        }
    }

    public void FilterFlights(Passanger passanger, PassangerService passangerService)
    {
        if (passanger.flights.Count != 0)
            ListOfFlightsFiltered(passanger.flights, passanger, passangerService);
        else Console.WriteLine("Korisnik nema nijedan zakazan let. Unesite let/letove prije nastavljanja");
    }

    public void cancelFlight(List<Flight> flightList, Passanger passanger)
    {
        if (flightList.Count != 0)
        {
            ListOfFlights(passanger, writeUserFlights, flightList);
            var ids = fetchFlightIds(flightList);
            var id = CheckInput.CheckIds(ids);
            var timeNow = DateTime.Now;
            
            var targetFlight = flightList.Find(flight => flight.id == id);
            var dateOfDeparture = targetFlight.dateOfDeparture;

            TimeSpan timeBetween = dateOfDeparture - timeNow;
            if (targetFlight != null && int.Abs(timeBetween.Days) > 1)
            {
                string confirmation = Menu.confirmationMessage("otkazati");
                if (confirmation == affirmation)
                {
                    passanger.flights.Remove(targetFlight);
                    passanger.availableFlights.Add(targetFlight);
                    Console.WriteLine("Let uklonjen");
                    Menu.waitOnKeyPress();
                }
                else if (confirmation == negation)
                {
                    Console.WriteLine("Otkazivanje akcije. Vraćanje na menu s opcijama");
                    Menu.waitOnKeyPress();
                }
            }
            else
            {
                Console.WriteLine("Nije moguće otkazati let koji polijeće za manje od 24 sata");
                Menu.waitOnKeyPress();
            }
        }
        else
            Console.WriteLine("Korisnik nema nijedan zakazan let. Unesite let/letove prije nastavljanja");
    }
}