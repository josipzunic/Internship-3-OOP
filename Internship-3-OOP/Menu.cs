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


    public static void UsersMenuFunctionality(string choice, PassangerService passangerService, ref string input)
    {
        switch (choice)
        {
            case "1":
            {
                passangerService.generatePassanger();
                break;
            }
            case "2":
            {
                passangerService.userLogIn();
                break;
            }
            case "3":
            {
                input = "6";
                break;
            }
        }
    }
}