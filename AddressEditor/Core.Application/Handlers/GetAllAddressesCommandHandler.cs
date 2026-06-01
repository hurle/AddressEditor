using Core.Application.Commands;
using Core.Application.Exceptions;
using Core.Application.Interfaces;
using Core.Domain.Entities;
using MediatR;

namespace Core.Application.Handlers
{
    public class GetAllAddressesCommandHandler : IRequestHandler<GetAllAddressesCommand, List<Address>>
    {
        private readonly IAddressRepository _addressRepository;
        public GetAllAddressesCommandHandler(IAddressRepository addressRepository) 
        {
            _addressRepository = addressRepository;
        }

        public async Task<List<Address>> Handle(GetAllAddressesCommand request, CancellationToken cancellationToken)
        {
            try 
            {
                var addresses = await _addressRepository.GetAllAsync();
                return addresses.ToList();
            }
            catch (Exception ex)
            {
                // log pendiente
                throw new GetAllAddressException(string.Concat("There was an error calling the Addresses: ", ex.Message), ex);
            }
        }
    }
}
