namespace OOP
{
    internal class Validator
    {
        public bool ValidateEmail(string email)
        {
            if (!email.Contains("@"))
                return false;
            else
                return true;
        }

        public bool ValidatedUsername(string username)
        {
            foreach (var c in username)
            {
                if (!Char.IsLetterOrDigit(c))
                    return false;
            }

            return true;
        }
    }
}