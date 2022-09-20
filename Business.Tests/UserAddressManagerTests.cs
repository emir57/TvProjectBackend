using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        [Theory, InlineData(1)]
        public async Task Get_by_user_id_success(int userId)
        {
            _mockUserAddressDal.Setup(x => x.GetAllAsync(It.IsAny<Expression<Func<UserAddress, bool>>>())).ReturnsAsync(
                getByUserIdUserAddresses().ToList());

            UserAddressManager userAddressManager = new UserAddressManager(_mockUserAddressDal.Object);
            IDataResult<List<UserAddress>> result = await userAddressManager.GetByUserIdAsync(userId);

            Assert.Equal(1, result.Data.Count);
        }

        [Fact]
        public async Task Add_success()
        {
            _mockUserAddressDal.Setup(x => x.GetAllAsync(It.IsAny<Expression<Func<UserAddress, bool>>>())).ReturnsAsync(
                userAddresses().ToList()
                );
            _mockUserAddressDal.Setup(x => x.AddAsync(It.IsAny<UserAddress>()));

            UserAddress userAddress = new UserAddress()
            {
                AddressName = "Address name",
                AddressText = "Address text",
                CityId = 1,
                UserId = 1
            };

            UserAddressManager userAddressManager = new UserAddressManager(_mockUserAddressDal.Object);
            IResult result = await userAddressManager.AddAsync(userAddress);

            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task Add_UserAddress_Count_6_error()
        {
            _mockUserAddressDal.Setup(x => x.GetAllAsync(It.IsAny<Expression<Func<UserAddress, bool>>>())).ReturnsAsync(
                userIdCount6UserAddresses().ToList()
                );
            _mockUserAddressDal.Setup(x => x.AddAsync(It.IsAny<UserAddress>()));

            UserAddress userAddress = new UserAddress()
            {
                AddressName = "Address name",
                AddressText = "Address text",
                CityId = 1,
                UserId = 1
            };
            UserAddressManager userAddressManager = new UserAddressManager(_mockUserAddressDal.Object);
            IResult result = await userAddressManager.AddAsync(userAddress);

            Assert.False(result.IsSuccess);
        }

        [Fact]
        public async Task Update_userAddress_success()
        {
            _mockUserAddressDal.Setup(x => x.UpdateAsync(It.IsAny<UserAddress>()));

            UserAddressManager userAddressManager = new UserAddressManager(_mockUserAddressDal.Object);
            IResult result = await userAddressManager.UpdateAsync(new UserAddress());

            Assert.True(result.IsSuccess);
        }



        private IEnumerable<UserAddress> userAddresses()
        {
            for (int i = 1; i < 6; i++)
            {
                yield return new UserAddress(i, $"Address Name {i}", i, $"Address Text {i}", (byte)i);
            }
        }
        private IEnumerable<UserAddress> userIdCount6UserAddresses()
        {
            for (int i = 1; i < 7; i++)
            {
                yield return new UserAddress(i, $"Address Name {i}", 1, $"Address Text {i}", (byte)i);
            }
        }
        private IEnumerable<UserAddress> getByUserIdUserAddresses()
        {
            yield return new UserAddress(1, $"Address Name {1}", 1, $"Address Text {1}", 1);
        }
    }
}
