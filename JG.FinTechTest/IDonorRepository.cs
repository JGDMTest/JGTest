namespace JG.FinTechTest
{
    public interface IDonorRepository
    {
        PersistInformationResponse PersistDonorInformation(string name, string postcode, decimal amount);
    }
}