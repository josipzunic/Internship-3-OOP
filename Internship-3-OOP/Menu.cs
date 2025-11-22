namespace Internship_3_OOP;

public class Menu
{
    private const string _menuNavigation = "menu";
    
    public string item {get; set;}
    //public Action Function {get; set;}

    public Menu(string item)
    {
        this.item = item;
    }

    public static void WriteMenu(List<Menu> menuItems)
    {
        for (int i = 0; i < menuItems.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {menuItems[i].item}");
        }
    }
    
    public static void waitOnKeyPress()
    {
        Console.WriteLine("Pritisnite bilo koju tipku za nastavak");
        Console.ReadKey();
    }
    
    public static string confirmationMessage(string action)
    {
        string input;
        do
        {
            Console.Write($"Želite li stvarno {action} ovaj let ili  (da/ne): ");
            input =  Console.ReadLine();
            if(input == "da" || input == "ne") return  input;
            else Console.WriteLine("Molim unesite da ili ne");
        } while (true);
    
    }

    private static void onSuccesfullLogin(Passanger user, List<Menu> usersFlightMenu, PassangerService passangerService)
    {
        if (user != null)
        {
            Console.Clear();
            Console.WriteLine($"Trenutni korisnik:  {user.name} {user.surname}");
            WriteMenu(usersFlightMenu);
            string choice = CheckInput.CheckMenuInput(usersFlightMenu.Count);
            UsersFlightMenuFunctionality(choice, passangerService, user, usersFlightMenu);
        }
        
    }
    
    public static void UsersMenuFunctionality(string choice, PassangerService passangerService, ref string input,
        List<Menu> usersFlightMenu)
    {
        switch (choice)
        {
            case "1":
            {
                passangerService.generatePassanger(passangerService);
                break;
            }
            case "2":
            {
                var user = passangerService.userLogIn(passangerService);
                onSuccesfullLogin(user, usersFlightMenu, passangerService);
                break;
            }
            case "3":
            {
                input = "6";
                break;
            }
        }
    }

    private static void UsersFlightMenuFunctionality(string choice, PassangerService passangerService, Passanger passanger,
        List<Menu> usersFlightMenu)
    {
        bool exit = false;
        while (!exit)
        {
            switch (choice)
            {
                case "1":
                {
                    passangerService.ListOfFlights(passanger, PassangerService.writeUserFlights, passanger.flights);
                    waitOnKeyPress();
                    break;
                }
                case "2":
                {
                    passangerService.ListOfFlights(passanger, PassangerService.writeGeneralFlights, passanger.availableFlights);
                    passangerService.ChooseFlight(passanger);
                    waitOnKeyPress();
                    break;
                }
                case "3":
                {
                    passangerService.FilterFlights(passanger, passangerService);
                    waitOnKeyPress();
                    break;
                }
                case "4":
                {
                    passangerService.cancelFlight(passanger.flights, passanger);
                    break;
                }
                case "5":
                {
                    exit = true;
                    break;
                }

            }

            if (!exit)
            {
                Console.Clear();
                Console.WriteLine($"Trenutni korisnik:  {passanger.name} {passanger.surname}");
                WriteMenu(usersFlightMenu);
                choice = CheckInput.CheckMenuInput(5);
            }
        }
        
            
    }
        
}
