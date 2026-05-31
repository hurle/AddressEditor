using System.Runtime.CompilerServices;

namespace Core.Domain.Entities
{
    public class Address
    {
        public int AddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
	    public string City { get;set; }
        public string StateProvince { get; set; }
        public string CountryRegion { get; set; }
        public string PostalCode { get;set; }
        public Guid RowGuid { get; set; }
        public DateTime ModifiedDate{ get; set; }

        public Address(int addressId, string addressLine1, string addressLine2, string city, string stateProvidence, string countryRegion, string postalCode, Guid rowGuid, DateTime modifiedDate) 
        {
            AddressId = addressId;
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            City = city;
            StateProvince = stateProvidence;
            CountryRegion = countryRegion;
            PostalCode = postalCode;
            RowGuid = rowGuid;
            ModifiedDate = modifiedDate;
        }

        public void UpdateAddress(string city, string stateProvidence)
        {
            if (string.IsNullOrWhiteSpace(city)) 
            {
                throw new ArgumentException("The City value is required");
            }
            if (string.IsNullOrWhiteSpace(stateProvidence))
            {
                throw new ArgumentException("The State values is required");
            }
            City = city;
            StateProvince = stateProvidence;
            ModifiedDate = DateTime.Now;

        }
    }
}
