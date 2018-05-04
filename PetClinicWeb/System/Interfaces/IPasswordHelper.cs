namespace PetClinicWeb.System.Interfaces
{
    public interface IPasswordHelper
    {
        string Protect(string rawPassword, string salt);
    }
}