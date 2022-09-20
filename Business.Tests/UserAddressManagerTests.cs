using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Business.Tests
{
    public class UserAddressManagerTests
    {
        Mock<IUserAddressDal> _mockUserAddressDal;
        public UserAddressManagerTests()
        {
            _mockUserAddressDal = new Mock<IUserAddressDal>();
        }

        [Fact]
        public async Task GetAll_User_address_should_count_5()
        {
            _mockUserAddressDal.Setup(x => x.GetAllAsync()).ReturnsAsync(userAddresses().ToList());

            UserAddressManager userAddressManager = new UserAddressManager(_mockUserAddressDal.Object);
            IDataResult<List<UserAddress>> result = await userAddressManager.GetListAsync();

            Assert.Equal(5, result.Data.Count);
        }


        private IEnumerable<UserAddress> userAddresses()
        {
            for (int i = 1; i < 6; i++)
            {
                yield return new UserAddress(i, $"Address Name {i}", i, $"Address Text {i}", (byte)i);
            }
        }
    }
}
