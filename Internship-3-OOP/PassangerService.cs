namespace Internship_3_OOP;

public class PassangerService
{
    public List<Passanger> passangers = new();
    public List<Flight> flights = new();
    public List<Plane> planes = new();
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

    public void ListOfFlights(string condition, List<Flight> flightList)
    {
        if (condition == writeUserFlights) 
            Console.WriteLine("Letovi korisnika: ");
        else if (condition == writeGeneralFlights) 
            Console.WriteLine("Svi dostupni letovi: ");
        if(flightList.Count == 0 && condition == writeUserFlights) 
            Console.WriteLine("Ovaj korisnik nema zakazanih letova");
        foreach (var flight in flightList)
        {
            Console.WriteLine($"{flight.id} - {flight.name} - {flight.dateOfDeparture.Date.ToString("yyyy-MM-dd-hh-mm")} - " +
                              $"{flight.dateOfArrival.ToString("yyyy-MM-dd-hh-mm")} - {flight.mileage} - " +
                              $"{flight.timeOfFlight.ToString(@"dd\:hh\:mm\:ss")}");
        }
    }

    public List<int> fetchFlightIds(List<Flight> flightList)
    {
        var ids = new List<int>();
        foreach (var flight in flightList) ids.Add(flight.id);
        return ids;
    }
    
    public List<int> fetchPlaneIds(List<Plane> planeList)
    {
        var ids = new List<int>();
        foreach (var plane in planeList) ids.Add(plane.id);
        return ids;
    }
    
    public List<string> FetchPlaneNames(List<Plane> planeList)
    {
        var names = new List<string>();
        foreach (var plane in planeList) names.Add(plane.name);
        return names;
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

    public void ListOfFlightsFiltered(List<Flight> flightList)
    {
        Console.WriteLine("1 - id\n" +
                          "2 - ime\n" +
                          "3 - povratak");
        string condition = CheckInput.CheckMenuInput(3);
        var matchingFlightList = new List<Flight>();
        
        if (condition == "1" && flightList.Count!= 0)
        {
            int id = CheckInput.checkFlightIdExistance(flightList);
            Flight targetFlight = flightList.Find(flight => flight.id == id);
            if (targetFlight != null)
            {
                matchingFlightList.Add(targetFlight);
                ListOfFlights(writeGeneralFlights, matchingFlightList);
            }
            
        }
        else if (condition == "2" && flightList.Count != 0)
        {
            string name = CheckInput.checkFlightNameExistance(flightList);
            var targetFlights = flightList.FindAll(flight => flight.name == name);
            foreach (var targetFlight in targetFlights)
                if (targetFlight != null)
                {
                    matchingFlightList.Add(targetFlight);
                    ListOfFlights(writeGeneralFlights, matchingFlightList);
                }
            
        }
    }
    
    public void ListOfPlanesFiltered(List<Plane> planesList)
    {
        Console.WriteLine("1 - id\n" +
                          "2 - ime\n" +
                          "3 - povratak");
        string condition = CheckInput.CheckMenuInput(3);
        var matchingPlaneList = new List<Plane>();
        
        if (condition == "1" && planesList.Count!= 0)
        {
            int id = CheckInput.CheckPlaneIdExistance(planesList);
            Plane targetPlane = planesList.Find(flight => flight.id == id);
            if (targetPlane != null)
            {
                matchingPlaneList.Add(targetPlane);
                listAllPlanes(matchingPlaneList);
            }
            
        }
        else if (condition == "2" && planesList.Count != 0)
        {
            string name = CheckInput.CheckPlaneNameExistance(planesList);
            var targetFlights = planesList.FindAll(flight => flight.name == name);
            foreach (var targetFlight in targetFlights)
                if (targetFlight != null)
                {
                    matchingPlaneList.Add(targetFlight);
                    listAllPlanes(matchingPlaneList);
                }
            
        }
    }

    public void FilterFlights(List<Flight> flightList)
    {
        if (flightList.Count != 0)
            ListOfFlightsFiltered(flightList);
        else Console.WriteLine("Ne postoji nijedan let. Unesite let/letove prije nastavljanja");
    }

    public void cancelFlight(List<Flight> flightList, Passanger passanger)
    {
        if (flightList.Count != 0)
        {
            ListOfFlights(writeUserFlights, flightList);
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

    public void AddFlight()
    {
        string name = CheckInput.CheckFlightOrPlaneName();
        DateTime dateOfDeparture;
        DateTime dateOfArrival;
        do
        {
            dateOfDeparture = CheckInput.checkDateOfDepartureAndArrival("polaska");
            dateOfArrival =  CheckInput.checkDateOfDepartureAndArrival("dolaska");
            if (dateOfArrival <= dateOfDeparture)
                Console.WriteLine("Datum dolaska ne može biti prije datuma polaska");
            else break;
        } while (true);
        
        double mileage = CheckInput.CheckGeneralNumber("udaljenost");
        
        var flight = new Flight(name, dateOfDeparture, dateOfArrival, mileage, "input",new List<Crew>(),
            planes[0]);
        var confirmation = Menu.confirmationMessage("dodati");
        if (confirmation == affirmation)
        {
            flights.Add(flight);
            Console.WriteLine("Let uspješno dodan");
        }
        else if (confirmation == negation)
        {
            Console.WriteLine("Otkazivanje akcije. Povratak na meni s opcijama");
        }
    }
    
    public void EditFlight(List<Flight> flightList)
    {
        var ids = fetchFlightIds(flightList);
        var id = CheckInput.CheckIds(ids);
        var dataToChange = CheckInput.DataToChange();
        DateTime newValue = new DateTime();
        if (dataToChange == Internship_3_OOP.EditFlight.dateOfDeparture.ToString())
            newValue = CheckInput.checkDateOfDepartureAndArrival("polaska");
        else if (dataToChange == Internship_3_OOP.EditFlight.dateOfArrival.ToString()) 
            newValue = CheckInput.checkDateOfDepartureAndArrival("dolaska");
       // else if(dataToChange == "crew") s tim cu se nosit kad napravim crew
        
        
        var confirmation = Menu.confirmationMessage("izmijeniti");
        if (confirmation == affirmation)
        {
            var targetFlight = flightList.Find(flight => flight.id == id);
            if (dataToChange == Internship_3_OOP.EditFlight.dateOfDeparture.ToString()) 
                targetFlight.dateOfDeparture = newValue; //provjeri opet da nije polazak posli dolaska
            else if (dataToChange == Internship_3_OOP.EditFlight.dateOfArrival.ToString())
                targetFlight.dateOfArrival = newValue;
            Console.WriteLine("Podatak uspješno izmijenjen");
            Menu.waitOnKeyPress();
        }
        else if (confirmation == negation)
        {
            Console.WriteLine("Otkazivanje akcije. Povratak na meni s opcijama");
            Menu.waitOnKeyPress();
        }
    }

    public void DeleteFlight(List<Flight> flightList)
    {
        if (flightList.Count != 0)
        {
            ListOfFlights(writeUserFlights, flightList);
            var ids = fetchFlightIds(flightList);
            var id = CheckInput.CheckIds(ids);
            var timeNow = DateTime.Now;
            
            var targetFlight = flightList.Find(flight => flight.id == id);
            var dateOfDeparture = targetFlight.dateOfDeparture;
            TimeSpan timeBetween = dateOfDeparture - timeNow;
            
            if (targetFlight != null && int.Abs(timeBetween.Days) > 1 && 
                targetFlight.plane.currentCapacity > targetFlight.plane.capacity/2)
            {
                string confirmation = Menu.confirmationMessage("izbrisati");
                if (confirmation == affirmation)
                {
                    flights.Remove(targetFlight);
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
            Console.WriteLine("Lista letova je prazna");
    }

    public void listAllPlanes(List<Plane> planes)
    {
        var listOfAppearances = new List<int>();
        foreach (var plane in planes)
        {
            int numberOfFlights = flights.Where(flight => flight.plane.id == plane.id).Count();
            listOfAppearances.Add(numberOfFlights);
        }

        for (int i = 0; i < planes.Count; i++)
        {
            Console.WriteLine($"{planes[i].id} - {planes[i].name} - {planes[i].manufacturingDate.ToString("yyyy-MM-dd")} - " +
                              $"{listOfAppearances[i]}");
        }
    }

    public void AddPlane()
    {
        string name = CheckInput.CheckFlightOrPlaneName();
        DateTime manufacturingDate = CheckInput.checkDate("Unesite datum proizvodnje: ");
        int firstClassSeats = (int)CheckInput.CheckGeneralNumber("broj first class sjedala");
        int economySeats = (int)CheckInput.CheckGeneralNumber("broj economy sjedala");
        int businessSeats = (int)CheckInput.CheckGeneralNumber("broj business sjedala");
        var plane = new Plane(name,  manufacturingDate, firstClassSeats, economySeats, businessSeats);
        var confirmation = Menu.confirmationMessage("dodati");
        if (confirmation == affirmation)
        {
            planes.Add(plane);
            Console.WriteLine("avion je uspješno dodan");
        }
        else if (confirmation == negation)
            Console.WriteLine("Prekidanje akcije. Povratak na meni s opcijama");
    }

    public void DeletePlane(List<Plane> planeList)
    {
        Console.WriteLine("1 - id\n" +
                          "2 - ime\n" +
                          "3 - povratak");
        string condition = CheckInput.CheckMenuInput(3);
        if (condition == "1")
        {
            var ids = fetchPlaneIds(planeList);
            var id = CheckInput.CheckIds(ids);
            
            var targetPlane =  planeList.Find(plane => plane.id == id);
            var confirmation = Menu.confirmationMessage("izbrisati");
            if (targetPlane != null && confirmation == affirmation)
            {
               planeList.Remove(targetPlane);
               Console.WriteLine("Avion je uspješno izbrisan");
            }
            else if (confirmation == negation && targetPlane != null)
                Console.WriteLine("Otkazivanje akcije. Povratak na izbornik");
        }
        else if (condition == "2")
        {
            var name = CheckInput.CheckPlaneNameExistance(planeList);
            
            var sameNamePlanes = planeList.FindAll(plane => plane.name == name);
            if (sameNamePlanes.Count > 1 && sameNamePlanes != null)
                Console.WriteLine($"Postoji/e {sameNamePlanes.Count} aviona s ovim imenom");
            if (sameNamePlanes.Count != 0)
            {
                var confirmation = Menu.confirmationMessage("izbrisati");
                if (confirmation == affirmation)
                {
                    foreach (var plane in sameNamePlanes)
                    {
                        planeList.Remove(plane);
                    }

                    Console.WriteLine("Avion je uspješno izbrisan");
                }
                else if (confirmation == negation)
                    Console.WriteLine("Prekidanje akcije. Povratak na izbornik\n" +
                                      "Ako želite izbrisati samo jedan od aviona ponavljajućeg imena, odaberite" +
                                      "brisanje po id-u");
                
            }
            
        }
    }
}