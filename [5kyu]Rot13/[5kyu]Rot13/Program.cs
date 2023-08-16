using System.Text;

public class Kata
{
    public static string Rot13(string message)
    {
        StringBuilder encodedMessage = new();

        foreach (char symbol in message)
        {
            if (!char.IsLetter(symbol))
            {
                encodedMessage.Append(symbol);
                continue;
            }

            char encodedSymbol = (char)(symbol + 13);

            if (symbol <= 'Z' && encodedSymbol > 'Z')
            {
                encodedSymbol = (char)('A' + encodedSymbol - 'Z' - 1);
            }
            else if (encodedSymbol > 'z')
            {
                encodedSymbol = (char)('a' + encodedSymbol - 'z' - 1);
            }

            encodedMessage.Append(encodedSymbol);
        }

        return encodedMessage.ToString();
    }
}