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

        Menu.WriteMenu(mainMenu);
        bool exit = false;
        var passangerService = new PassangerService();
        var passanger = new Passanger("ante", "antic", new DateTime(1111, 11, 11),
            "M", "anteantic@gmail.com", "");
        passanger.GeneratePasswordHardCoded("anteantic123!");
        passangerService.passangers.Add(passanger);
        string input = CheckInput.CheckMenuInput();
        while (!exit)
        {
            switch (input)
            {
                case "1":
                {
                    Console.Clear();
                    Menu.WriteMenu(usersMenu);
                    string choice = CheckInput.CheckMenuInput();
                    Menu.UsersMenuFunctionality(choice, passangerService, ref input);
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
                    input = CheckInput.CheckMenuInput();
                    break;
                }
            }
        }


    }
}