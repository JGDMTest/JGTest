using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JG.FinTechTest
{
    public class DonorRepositoryStub : IDonorRepository
    {
        public PersistInformationResponse PersistDonorInformation(string name, string postcode, decimal amount)
        {
            if (name.Equals("Duplicate"))
            {
                //simulates user already exists
                throw new UserAlreadyExistsException();
            }

            // add donor information to database

            return new PersistInformationResponse
            {
                Amount = amount,
                Id = Guid.NewGuid()
            };
        }
    }
}
