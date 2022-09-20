using DataAccess.Abstract;
using Entities.Concrete;
using Moq;
using System.Collections.Generic;

namespace Business.Tests
{
    public class UserAddressManagerTests
    {
        Mock<IUserAddressDal> _mockUserAddressDal;
        public UserAddressManagerTests()
        {

        }



        private IEnumerable<UserAddress> userAddresses()
        {
            for (int i = 0; i < 5; i++)
            {
                yield return new UserAddress();
            }
        }
    }
}
