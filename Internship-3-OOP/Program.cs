using System;
using Internship_3_OOP;

class Program
{
    static void Main(string[] args)
    {
        var mainMenu = new List<Menu>
        {
            new Menu("Putnici"),
            new Menu("Letovi"),
            new Menu("Avioni"),
            new Menu("Posada"),
            new Menu("Izlaz iz programa")
        };

        var usersMenu = new List<Menu>
        {
            new Menu("Registracija"),
            new Menu("Prijava"),
            new Menu("Povratak"),
        };

        var usersFlightMenu = new List<Menu>
        {
            new Menu("Prikaz svih letova"),
            new Menu("Odabir leta"),
            new Menu("Pretraživanje letova"),
            new Menu("Otkazivanje leta"),
            new Menu("Odjava")
        };

        var flightMenu = new List<Menu>()
        {
            new Menu("Prikaz svih letova"),
            new Menu("Dodavanje leta"),
            new Menu("Pretraživanje letova"),
            new Menu("Uređivanje leta"),
            new Menu("Brisanje leta"),
            new Menu("Povratak"),
        };

        var planeMenu = new List<Menu>()
        {
            new Menu("Prikaz svih aviona"),
            new Menu("Dodavanje novog aviona"),
            new Menu("Pretraživanje aviona"),
            new Menu("Brisanje aviona"),
            new Menu("Povratak"),
        };

        Menu.WriteMenu(mainMenu);
        bool exit = false;
        var passangerService = new PassangerService();

        var pilot = new Crew("mate", "matic", new DateTime(2002, 04, 12),
            "M", Positions.pilot.ToString());
        var copilot = new Crew("maria", "maric", new DateTime(2002, 07, 09),
            "F", Positions.kopilot.ToString());
        var flightAttendant1 = new Crew("ivo", "ivic",  new DateTime(2002, 12, 25),
            "M",  Positions.stjuard.ToString());
        var flightAttendant2 = new Crew("rajka", "matovilac", new DateTime(2001, 11, 05),
            "F",   Positions.stjuardesa.ToString());
        
        var crew = new List<Crew>{pilot,  copilot, flightAttendant1, flightAttendant2};
        var plane = new Plane("Boeing-747", new DateTime(2012, 12, 25), 10, 
            10, 10);

        
        var flight = new Flight("floptropica", 
            new DateTime(1111, 11, 11, 12, 30, 0),
            new DateTime(1111, 11, 11, 15, 0, 0),
            1234, "hardCoded", crew, plane);
        flight.SetTimeOfFlightInCode(new DateTime(1111, 11, 11, 12, 30, 0),
            new DateTime(1111, 11, 11, 15, 0, 0));
        passangerService.flights.Add(flight);
        passangerService.planes.Add(plane);
        
        
        var passanger = new Passanger("ante", "antic", new DateTime(1111, 11, 11),
            "M", "anteantic@gmail.com", "", new List<Flight>());
        passanger.GeneratePasswordHardCoded("anteantic123!");
        passangerService.passangers.Add(passanger);
        
        string input = CheckInput.CheckMenuInput(usersMenu.Count);
        while (!exit)
        {
            switch (input)
            {
                case "1":
                {
                    Console.Clear();
                    Menu.WriteMenu(usersMenu);
                    string choice = CheckInput.CheckMenuInput(usersMenu.Count);
                    Menu.UsersMenuFunctionality(choice, passangerService, ref input,  usersFlightMenu);
                    break;
                }
                case "2":
                {
                    Console.Clear();
                    Menu.WriteMenu(flightMenu);
                    string  choice = CheckInput.CheckMenuInput(flightMenu.Count);
                    Menu.FlightMenuFunctionality(choice, passangerService, ref input, flightMenu);
                    break;
                }
                case "3":
                {
                    Console.Clear();
                    Menu.WriteMenu(planeMenu);
                    string choice = CheckInput.CheckMenuInput(planeMenu.Count);
                    Menu.PlaneMenuFunctionality(choice, passangerService, ref input, planeMenu);
                    break;
                }
                case "5":
                {
                    exit = true;
                    break;
                }
                case "6":
                {
                    Console.Clear();
                    Menu.WriteMenu(mainMenu);
                    input = CheckInput.CheckMenuInput(mainMenu.Count);
                    break;
                }
            }
        }


    }
}