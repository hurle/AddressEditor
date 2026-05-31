using Core.Application.Commands;
using Core.Application.Handlers;
using Core.Application.Interfaces;
using Core.Domain.Entities;
using Moq;

namespace Test.UnitTests
{
    public class UpdateAddressesTests
    {
        public readonly Mock<IAddressRepository> _addressRepositoryMock;
        public readonly UpdateAddressCommandHanlder _handler;
        public Address _currentAddress;
        public List<Address> _mockedDb;
        public UpdateAddressCommand _updateAddressCommand;

        public UpdateAddressesTests()
        {
            _addressRepositoryMock = new Mock<IAddressRepository>();
            _handler = new UpdateAddressCommandHanlder(_addressRepositoryMock.Object);
        }

        private void commonArrange(int id, string custom_param)
        {
            string defaultValue = "Test";
            _currentAddress = new Address(1, defaultValue, defaultValue, defaultValue, defaultValue, defaultValue, defaultValue, Guid.NewGuid(), DateTime.Now);
            _mockedDb = new List<Address> { _currentAddress };
            _addressRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(_mockedDb);
            
            defaultValue += custom_param;
            _updateAddressCommand = new UpdateAddressCommand();
            _updateAddressCommand.addressId = id;
            _updateAddressCommand.city = defaultValue;
            _updateAddressCommand.stateProvidence = defaultValue;
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // ARRANGE 
            commonArrange(1, "_update");// To find the mockedDb
            // ACT
            var result = await _handler.Handle(_updateAddressCommand, CancellationToken.None);
            // ASSERT
            Assert.Equal("Test_command", _currentAddress.City);
            Assert.True(_currentAddress.ModifiedDate > DateTime.Now);
        }

        [Fact]
        public async Task DoNotExistsAsync()
        {
            // ARRANGE
            commonArrange(2,"_error");
            // ASSERT
            await Assert.ThrowsAsync<KeyNotFoundException>(async () =>
            {
                // ACT
                var result = await _handler.Handle(_updateAddressCommand, CancellationToken.None);
            });
        }

        [Fact]
        public async Task InvalidValuesAsync() 
        {
            // ARRANGE
            commonArrange(1,"_Invalid_Value_01234567891011121314151617181920212223242526272829303132333435363738394041424344454647484950515253545556575859");
            // ASSERT
            await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                // ACT
                var result = await _handler.Handle(_updateAddressCommand, CancellationToken.None);
            });
        }
    }
}