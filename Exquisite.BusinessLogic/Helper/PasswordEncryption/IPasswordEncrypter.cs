namespace Exquisite.BusinessLogic.Helper.StringEncryption
{
    interface IPasswordEncrypter
    {
        string Encrypt(string password, string salt);
    }
}
