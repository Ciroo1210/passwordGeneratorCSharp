using System;
using System.Text;

class Program
{
    static void Main()
    {
        int length = GetLengthFromUser();
        bool includeSpecialCharacters = AskIncludeSpecialCharacters();
        bool includeNumbers = AskIncludeNumbers();
        bool includeUppercase = AskIncludeUppercase();
        bool includeLowercase = AskIncludeLowercase();

        string generatedPassword = GeneratePassword(length, includeSpecialCharacters, includeNumbers, includeUppercase, includeLowercase);

        Console.WriteLine($"Generated Password: {generatedPassword}");
    }

    static int GetLengthFromUser()
    {
        Console.Write("Password Length: ");
        return int.Parse(Console.ReadLine());
    }

    static bool AskIncludeSpecialCharacters()
    {
        Console.Write("Include Special Characters? (Y/N): ");
        return Console.ReadLine().ToUpper() == "Y";
    }

    static bool AskIncludeNumbers()
    {
        Console.Write("Include Numbers? (Y/N): ");
        return Console.ReadLine().ToUpper() == "Y";
    }

    static bool AskIncludeUppercase()
    {
        Console.Write("Include Uppercase Letters? (Y/N): ");
        return Console.ReadLine().ToUpper() == "Y";
    }

    static bool AskIncludeLowercase()
    {
        Console.Write("Include Lowercase Letters? (Y/N): ");
        return Console.ReadLine().ToUpper() == "Y";
    }

    static string GeneratePassword(int length, bool includeSpecialCharacters, bool includeNumbers, bool includeUppercase, bool includeLowercase)
    {
        string characterSet = CreateCharacterSet(includeSpecialCharacters, includeNumbers, includeUppercase, includeLowercase);
        StringBuilder password = new StringBuilder();

        Random random = new Random();
        while (password.Length < length)
        {
            char randomCharacter = SelectRandomCharacterFrom(characterSet, random);
            password.Append(randomCharacter);
        }

        return password.ToString();
    }

    static string CreateCharacterSet(bool includeSpecialCharacters, bool includeNumbers, bool includeUppercase, bool includeLowercase)
    {
        StringBuilder characterSet = new StringBuilder();

        if (includeSpecialCharacters)
            characterSet.Append("!@#$%^&*()_+-=[]{}|;:'\",.<>/?");

        if (includeNumbers)
            characterSet.Append("0123456789");

        if (includeUppercase)
            characterSet.Append("ABCDEFGHIJKLMNOPQRSTUVWXYZ");

        if (includeLowercase)
            characterSet.Append("abcdefghijklmnopqrstuvwxyz");

        return characterSet.ToString();
    }

    static char SelectRandomCharacterFrom(string characterSet, Random random)
    {
        int randomIndex = random.Next(0, characterSet.Length);
        return characterSet[randomIndex];
    }
}

