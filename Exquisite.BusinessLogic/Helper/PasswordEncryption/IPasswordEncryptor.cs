namespace Exquisite.BusinessLogic.Helper.PasswordEncryption
{
    interface IPasswordEncryptor
    {
        string Encrypt(string password, string salt);
    }
}
