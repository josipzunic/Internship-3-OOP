namespace Internship_3_OOP;

public class Menu
{
    private const string _menuNavigation = "menu";

    private void PlaceholderFunction()
    {
        Console.Write("");
    }
    public string userInput(string typeOfInput) // odi dodat parametre tkd moze bit opcenita funckija kad budes provjerava unos
    {
        string input = "";
        if (typeOfInput == "menu") input = CheckInput.CheckMenuInput();
        return input;
    }
    public void WriteMainMenu()
    {
        Console.Clear();
        Console.WriteLine(
            "1 - Putnici\n" +
            "2 - Letovi\n" +
            "3 - Avioni\n" +
            "4 - Posada\n" +
            "5 - Izlaz iz programa"
        );
        int input = int.Parse(userInput(_menuNavigation));
        List<Action> options = new List<Action>
        {
            WriteUserMenu,
            PlaceholderFunction,
            PlaceholderFunction,
            PlaceholderFunction,
            PlaceholderFunction
        };
        MenuNavigation(input, options);
    }

    public void WriteUserMenu()
    {
        Console.Clear();
        Console.WriteLine(
            "1 - Registracija\n" + 
            "2 - Prijava\n" +
            "3 - Povratak"
        );
        int input = int.Parse(userInput(_menuNavigation));
        List<Action> options = new List<Action>
        {
            PlaceholderFunction,
            PlaceholderFunction,
            WriteMainMenu
        };
        MenuNavigation(input, options);
    }

    // private void WriteFlightMenu()
    // {
    //     Console.Clear();
    //     Console.WriteLine(
    //         "1 - Prikaz svih letova\n" + 
    //         "2 - Dodavanje Leta\n" +
    //         "3 - Pretraživanje letova\n" +
    //         "4 - Uređivanje leta\n" +
    //         "5 - Brisanje leta\n" +
    //         "6 - Povratak"
    //     );
    //     string input = userInput(_menuNavigation);
    //     List<Action> options = new List<Action>
    //     {
    //         
    //     };
    // }
    
    private void MenuNavigation(int input, List<Action> options)
    {
        Console.Clear();
        var wantedMenu = options[input-1];
        wantedMenu();
    }
}