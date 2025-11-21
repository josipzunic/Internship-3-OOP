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

    private static void onSuccesfullLogin(Passanger user, List<Menu> usersFlightMenu, PassangerService passangerService)
    {
        if (user != null)
        {
            Console.Clear();
            Console.WriteLine($"Trenutni korisnik:  {user.name} {user.surname}");
            WriteMenu(usersFlightMenu);
            string choice = CheckInput.CheckMenuInput();
            UsersFlightMenuFunctionality(choice, passangerService, user);
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

    private static void UsersFlightMenuFunctionality(string choice, PassangerService passangerService, Passanger passanger)
    {
        switch (choice)
        {
            case "1":
            {
                //prikaz svih letova
                passangerService.listOfUsersFlights(passanger);
                waitOnKeyPress();
                break;
            }
            case "2":
            {
                //odabir leta
                break;
            }
            case "3":
            {
                //Pretraživanje letova
                break;
            }
            case "4":
            {
                //otkazivanje leta“
                break;
            }
            case "5":
            {
                break;
            }
        }
    }
}