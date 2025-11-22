using System.Globalization;

namespace Internship_3_OOP;

public class CheckInput
{
    public static string CheckMenuInput(int maxAllowedNumber)
    {
        do
        {
            Console.Write("Odaberite opciju upisivanjem broja uz željenu opciju: ");
            string input = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(input))
                Console.WriteLine("Ovo polje ne može biti prazno");
            else if (int.TryParse(input, out int result) && result < 0)
                Console.WriteLine("Unos smije biti samo jedan od brojeva uz opcije ");
            else if (maxAllowedNumber < result)
                Console.WriteLine("Unos smije biti samo jedan od brojeva uz opcije ");
            else if(!int.TryParse(input, out result))
                Console.WriteLine("Unos smije biti samo jedan od brojeva uz opcije ");
            else return input;
        } while (true);
    }
    
    private static string WritePasswordToConsole()
    {
        string password = "";
        ConsoleKeyInfo key;

        do
        {
            key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Enter)
                break;

            if (key.Key == ConsoleKey.Backspace)
            {
                if (password.Length > 0)
                {
                    password = password[0..^1];
                    Console.Write("\b \b");
                }
            }
            else
            {
                password += key.KeyChar;
                Console.Write("*");
            }

        } while (true);
        Console.WriteLine();
        return password;
    }

    public static string checkPasswordCreation()
    {
        List<char> specialSymbols = new List<char>
        {
            '!', '@', '#', '$', '%', '^', '&', '*', '(', ')',
            '-', '_', '+', '=', '{', '}', '[', ']', '|', '\\',
            ':', ';', '"', '\'', '<', '>', ',', '.', '?', '/'
        };
        List<char> digits = new List<char>
        {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
        };
        
        string password = "";
        string repeatPassword = "";
        
        do
        {
            Console.Write("Postavite lozinku: ");
            password = WritePasswordToConsole();
            if (string.IsNullOrEmpty(password))
                Console.WriteLine("Ovo polje ne može biti prazno");
            else if (password.Length < 8)
                Console.WriteLine("Lozinka ne smije imati manje od 8 znakova");
            else if (!password.Any(specialSymbol => specialSymbols.Contains(specialSymbol)))
                Console.WriteLine("Lozinka mora sadržavati barem jedan od specijalnih simbola, npr. @, !, ?");
            else if (!password.Any(digit => digits.Contains(digit)))
                Console.WriteLine("Lozinka mora sadržavati barem jednu znamenku");
            else if (password.Contains(' '))
                Console.WriteLine("Lozinka ne smije sadržavati razmake");
            else break;
        } while (true);

        do
        {
            Console.Write("Ponovite lozinku: ");
            repeatPassword = WritePasswordToConsole();
            if (repeatPassword != password)
                Console.WriteLine("Lozinke se ne podudaraju. Probajte ponovo");
            else break;
        } while (true);
        
        return password;
    }
    
    public static string CheckGeneralInput(string message)
    {
        do
        {
            Console.Write(message);
            string input = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(input))
                Console.WriteLine("Ovo polje ne smije biti prazno");
            else if (!input.All(c => char.IsLetter(c) || c == ' ' || c == '-'))
                Console.WriteLine("Ime i prezime smije sadržavati samo slova i eventualno crticu");
            else return input;
        } while (true);
    }
    
    public static DateTime checkDate(string message)
    {
        var currentDate = DateTime.Now;
        do
        {
            Console.Write(message);
            string input = Console.ReadLine();
            var dateTimeValidity = DateTime.TryParse(input, out DateTime dateTime);
            if(string.IsNullOrEmpty(input)) Console.WriteLine("Datum ne može biti prazan");
            else if (!dateTimeValidity)
                Console.WriteLine("Datum nije valjan. Unesite datum u formatu yyyy-mm-dd");
            else if(currentDate.Year < dateTime.Year)
                Console.WriteLine("Unesena godina ne može biti kasnija od trenutne");
            else return dateTime;
        } while (true);
    }
    
    public static DateTime checkDateOfDepartureAndArrival(string message)
    {
        var currentDate = DateTime.Now;
        do
        {
            Console.Write($"Unesite datum {message}: ");
            string input = Console.ReadLine();
            var dateTimeValidity = DateTime.TryParse(input, out DateTime date);
            if (string.IsNullOrEmpty(input)) Console.WriteLine("Ovo polje ne smije biti prazno");
            else if (!dateTimeValidity)
                Console.WriteLine("Datum nije valjan. Unesite datum u formatu yyyy-mm-dd");
            else if (currentDate.CompareTo(date) > 0)
                Console.WriteLine($"Datum {message} ne može biti u prošlosti");
            else return date;
        } while (true);
    }

    public static string checkEMail(PassangerService passangerService, string registationOrLogin)
    {
        List<string> allowedDomains = new List<string>
        {
            "gmail.com", "yahoo.com", "pmfst.hr",
            "fesb.hr", "outlook.com", "dump.hr"
        };
        do
        {
            Console.Write("Unesite email: ");
            string input = Console.ReadLine().Trim();
            var inputSplit = input.Split('@');
            if(string.IsNullOrEmpty(input))
                Console.WriteLine("Ovo polje ne smije biti prazno");
            else if (!input.Contains('@'))
                Console.WriteLine("Niste unijeli pravilnu adresu");
            else if(!allowedDomains.Contains(inputSplit[1]))
                Console.WriteLine("Nedozvoljena domena");
            else if(passangerService.userExistance(input) && registationOrLogin == "registration")
                Console.WriteLine("Korisnik s unesenom adresom već postoji");
            else return input;
        } while (true);
    }

    public static string checkSexInput()
    {
        do
        {
            Console.Write("Unesite spol (M/F): ");
            string input = Console.ReadLine().Trim().ToUpper();
            if (string.IsNullOrEmpty(input))
                Console.WriteLine("Ovo polje ne smije biti prazno");
            else if(input != "M" && input != "F")
                Console.WriteLine("Unesite spol odabirom slova M ili F");
            else return input;
        } while (true);
    }

    public static string checkPasswordInput()
    {
        Console.Write("Unesite lozinku: ");
        string password = WritePasswordToConsole();
        return password;
    }

    public static int checkFlightIdExistance(List<Flight> listOfFlights)
    {
        int id = -1;
        do
        {
            Console.Write("Unesite id leta (Upisati povratak za izlaz): ");
            string input = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(input))
                Console.WriteLine("Ovo polje ne smije biti prazno");
            else if (input == "povratak")
                return id;
            else if(!int.TryParse(input, out  id))
                Console.WriteLine("Id mora biti broj");
            else if (!listOfFlights.Any(flight => flight.id == id))
            {
                Console.WriteLine("Let s unesenim id-om ne postoji");
                                  //"Postojeći letovi: ");
                //passangerService.ListOfFlights(passanger, "else", listOfFlights);
                Menu.waitOnKeyPress();
            }
            else return id;
        } while (true);
    }
    
    public static int CheckPlaneIdExistance(List<Plane> listOfPlanes)
    {
        int id = -1;
        do
        {
            Console.Write("Unesite id aviona (Upisati povratak za izlaz): ");
            string input = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(input))
                Console.WriteLine("Ovo polje ne smije biti prazno");
            else if (input == "povratak")
                return id;
            else if(!int.TryParse(input, out  id))
                Console.WriteLine("Id mora biti broj");
            else if (!listOfPlanes.Any(flight => flight.id == id))
            {
                Console.WriteLine("Avion s unesenim id-om ne postoji");
                Menu.waitOnKeyPress();
            }
            else return id;
        } while (true);
    }

    public static string checkFlightNameExistance(List<Flight> listOfFlights)
    {
        string name = "";
        do
        {
           Console.Write("Unesite ime leta (Upisati povratak za izlaz): ");
           name =  Console.ReadLine().Trim();
           if(string.IsNullOrEmpty(name))
               Console.WriteLine("Ovo polje ne smije biti prazno");
           else if (name == "povratak")
               return name;
           else if (!listOfFlights.Any(flight => flight.name == name))
           {
               Console.WriteLine("Let s unesenim imenom ne postoji");
                                 //"Postojeći letovi:");
               //passangerService.ListOfFlights(passanger, PassangerService.writeUserFlights, listOfFlights);
               Menu.waitOnKeyPress();
           }
           
           else return name; 
        } while (true);
        
    }
    
    public static string CheckPlaneNameExistance(List<Plane> listOfPlanes)
    {
        string name = "";
        do
        {
            Console.Write("Unesite ime aviona (Upisati povratak za izlaz): ");
            name =  Console.ReadLine().Trim();
            if(string.IsNullOrEmpty(name))
                Console.WriteLine("Ovo polje ne smije biti prazno");
            else if (name == "povratak")
                return name;
            else if (!listOfPlanes.Any(flight => flight.name == name))
            {
                Console.WriteLine("Avion s unesenim imenom ne postoji");
                Menu.waitOnKeyPress();
            }
           
            else return name; 
        } while (true);
        
    }

    public static int CheckIds(List<int> ids)
    {
        string input;
        do
        {
            Console.Write("Unesite id: ");
            input =  Console.ReadLine().Trim();
           if(string.IsNullOrEmpty(input))
               Console.WriteLine("Ovo polje ne smije biti prazno");
           else if(!int.TryParse(input, out int id))
               Console.WriteLine("id mora biti broj");
           else if(!ids.Contains(id))
               Console.WriteLine("id nije sadržan u listi");
           else return id;
        } while (true);
    }

    public static string checkSeatingHierarchy()
    {
        string input;
        do
        {
           Console.Write("Dostupni razredi: business, economy, first class\n" +
                         "Unesite odabir (Upisati povratak za izlaz): ");
           input = Console.ReadLine().Trim();
           input = input.Replace(" ", "");
           if(string.IsNullOrEmpty(input))
               Console.WriteLine("Ovo polje ne smije biti prazno");
           else if (input == "povratak")
               return "";
           else if(!Enum.TryParse(input, true, out CabinType result))
               Console.WriteLine("Unesite jedan od ponuđenih podataka");
           else return input;
        } while (true);
    }

    public static string CheckFlightOrPlaneName()
    {
        string input;
        do
        {
            Console.Write("Unesite ime leta, aviona ili posade:  ");
            input = Console.ReadLine().Trim();
            if(string.IsNullOrEmpty(input))
                Console.WriteLine("Ovo polje ne smije biti prazno");
            else return input;
        } while (true);
    }

    public static double CheckGeneralNumber(string message)
    {
        string input;
        do
        {
            Console.Write($"Unesite {message}: ");
            input =  Console.ReadLine().Trim();
            if(string.IsNullOrEmpty(input))
                Console.WriteLine("Ovo polje ne smije biti prazno");
            else if(!double.TryParse(input, out double result))
                Console.WriteLine("Očekivani unos je broj");
            else  return result;
        } while (true);
    }
    
    public static string DataToChange()
    {
        string input;
        do
        {
            Console.Write("Podaci koji se mogu izmijeniti: date of departure, date of arrival, crew\n" +
                              "Odaberite podatak koji želite izmijeniti (Upišite povratak za izlaz): ");
            input = Console.ReadLine().Trim();
            input = input.Replace(" ", "");
            if(string.IsNullOrEmpty(input))
                Console.WriteLine("Ovo polje ne smije biti prazno");
            else if (input == "povratak")
                return "";
            else if(!Enum.TryParse(input, true, out EditFlight result))
                Console.WriteLine("Unesite jedan od ponuđenih podataka");
            else return result.ToString();
            
        } while (true);
    }
    
    public static string CheckPositionInput()
    {
        string input;
        do
        {
            Console.Write("Dostupne pozicije: pilot, kopilot, stjuardera, stjuard\n" +
                          "Odaberite podatak koji želite unijeti: ");
            input = Console.ReadLine().Trim();
            if(string.IsNullOrEmpty(input))
                Console.WriteLine("Ovo polje ne smije biti prazno");
            else if(!Enum.TryParse(input, true, out Positions result))
                Console.WriteLine("Unesite jedan od ponuđenih podataka");
            else return result.ToString();
            
        } while (true);
    }

    public static string CheckCrewNameExistance(List<Crew> crewList)
    {
        string input;
        do
        {
            Console.Write("Unesite ime posade u koju želite promijeniti: ");
            input = Console.ReadLine().Trim();
            if(string.IsNullOrEmpty(input))
                Console.WriteLine("Ovo polje ne smije biti prazno");
            else if(!crewList.Any(crew => crew.crewName == input))
                Console.WriteLine("Posada s tim imenom ne postoji");
            else return input;

        } while (true);
    }
    
}