namespace Solution
{
    public static class Kata
    {
        public static bool IsValidIp(string ipAddress)
        {
            if (!IsValidSymbols(ipAddress))
            {
                return false;
            }

            string[] octets = ipAddress.Split('.');

            if (octets.Length != 4)
            {
                return false;
            }

            foreach (var octet in octets)
            {
                if (!IsValidOctet(octet))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsValidSymbols(string ipAddress)
        {
            foreach (var symbol in ipAddress)
            {
                if (!char.IsDigit(symbol) && symbol != '.')
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsValidOctet(string octet)
        {
            if (string.IsNullOrEmpty(octet))
            {
                return false;
            }

            if (octet.StartsWith('0') && octet.Length > 1)
            {
                return false;
            }

            int octetNumber = int.Parse(octet);

            if (octetNumber < 0 || octetNumber > 255)
            {
                return false;
            }

            return true;
        }
    }
}