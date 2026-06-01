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
            try
            {
                var currentAddress = await _addressRepository.GetById(request.addressId);
                if (currentAddress == null)
                {
                    throw new KeyNotFoundException("The address do not exists.");
                }
                currentAddress.UpdateAddress(request.city, request.stateProvidence);
                await _addressRepository.UpdateAsync(currentAddress);
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        
    }
}
