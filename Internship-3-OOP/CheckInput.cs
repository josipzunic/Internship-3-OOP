using System.Globalization;

namespace Internship_3_OOP;

public class CheckInput
{
    public static string CheckMenuInput()
    {
        do
        {
            Console.Write("Odaberite opciju na izborniku upisivanjem broja uz željenu opciju: ");
            string input = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(input))
                Console.WriteLine("Ovo polje ne može biti prazno");
            else if (int.TryParse(input, out int result) && result < 0)
                Console.WriteLine("Unos smije biti jedan od brojeva uz opcije na izborniku");
            else if (!int.TryParse(input, out int result2))
                Console.WriteLine("Unos smije biti jedan od brojeva uz opcije na izborniku");
            else return input;
        } while (true);
    }

    public static string checkPassword()
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
            password = Passanger.WritePasswordToConsole();
            if (string.IsNullOrEmpty(password))
                Console.WriteLine("Ovo polje ne može biti prazno");
            else if (password.Length < 8)
                Console.WriteLine("Lozinka ne smije imati manje od 8 znakova");
            else if (!password.Any(specialSymbol => specialSymbols.Contains(specialSymbol)))
                Console.WriteLine("Lozinka mora sadržavati barem jedan od specijalnih simbola, npr. @, !, ?");
            else if (!password.Any(digit => digits.Contains(digit)))
                Console.WriteLine("Lozinka mora sadržavati barem jednu znamenku");
            else break;
        } while (true);

        do
        {
            Console.Write("Ponovite lozinku: ");
            repeatPassword = Passanger.WritePasswordToConsole();
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

    public static string checkEMail(string message)
    {
        List<string> allowedDomains = new List<string>
        {
            "gmail.com", "yahoo.com", "pmfst.hr",
            "fesb.hr", "outlook.com", "dump.hr"
        };
        do
        {
            //provjerit postoji li user vec s tim mailom
            Console.Write(message);
            string input = Console.ReadLine().Trim();
            var inputSplit = input.Split('@');
            if(string.IsNullOrEmpty(input))
                Console.WriteLine("Ovo polje ne smije biti prazno");
            else if (!input.Contains('@'))
                Console.WriteLine("Niste unijeli pravilnu adresu");
            else if(!allowedDomains.Contains(inputSplit[1]))
                Console.WriteLine("Nedozvoljena domena");
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
}