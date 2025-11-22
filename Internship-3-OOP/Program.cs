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

        
        var flight = new Flight("floptropica", 
            new DateTime(1111, 11, 11, 12, 30, 0),
            new DateTime(1111, 11, 11, 15, 0, 0),
            1234, "hardCoded", crew);
        flight.SetTimeOfFlightInCode(new DateTime(1111, 11, 11, 12, 30, 0),
            new DateTime(1111, 11, 11, 15, 0, 0));
        passangerService.flights.Add(flight);
        
        
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