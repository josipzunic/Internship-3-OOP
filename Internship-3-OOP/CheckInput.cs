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
}