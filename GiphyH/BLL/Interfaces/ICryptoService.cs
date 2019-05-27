namespace GiphyH.BLL.Interfaces
{
    public interface ICryptoService
    {
        string EncryptId(int id);

        int DecryptId(string cipheredId);

        string CreatePasswordHash(string password);
    }
}
