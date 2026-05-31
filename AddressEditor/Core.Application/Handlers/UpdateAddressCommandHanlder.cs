using Core.Application.Commands;
using Core.Application.Interfaces;
using MediatR;
using System.Linq;

namespace Core.Application.Handlers
{
    public class UpdateAddressCommandHanlder : IRequestHandler<UpdateAddressCommand, bool>
    {
        private readonly IAddressRepository _addressRepository;

        public UpdateAddressCommandHanlder(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<bool> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            var addresses = await _addressRepository.GetAllAsync();
            var currentAddress = addresses.FirstOrDefault(x => x.AddressId == request.addressId);
            if (currentAddress == null)
            {
                throw new KeyNotFoundException("The address do not exists.");
            }
            currentAddress.UpdateAddress(request.city, request.stateProvidence);
            return true;
        }

        
    }
}
