using System.Security.Cryptography;

namespace BookSale.MVC.Utility
{
    public class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                if(password != null) {
                    byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);
                    byte[] hashedBytes = sha256.ComputeHash(passwordBytes);
                    return Convert.ToBase64String(hashedBytes);
                }

                return null;
            }
        }
    }
}
