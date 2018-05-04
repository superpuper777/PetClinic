using System.Security.Cryptography;
using System.Text;
using PetClinicWeb.System.Interfaces;
using WebGrease.Css.Extensions;

namespace PetClinicWeb.System.Helpers
{
    public class PasswordHelper : IPasswordHelper
    {
        public string Protect(string rawPassword, string salt)
        {
            var hasher = new SHA512Managed();
            var data = hasher.ComputeHash(Encoding.Default.GetBytes(rawPassword + salt));
            var result = new StringBuilder();

            data.ForEach(t => result.Append(t.ToString("x2")));

            return result.ToString();
        }
    }
}