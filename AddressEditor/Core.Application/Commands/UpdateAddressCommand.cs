using MediatR;
using System.Numerics;

namespace Core.Application.Commands
{
    public class UpdateAddressCommand : IRequest<bool> 
    {
        public string city { get; set; }
        public string stateProvidence { get; set; }
        public int addressId { get; set; }

    }
}
