using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace Business.Tests
{
    public class CityManagerTests
    {
        Mock<ICityDal> _cityDalMock;
        List<City> _cityDb;
        public CityManagerTests()
        {
            _cityDalMock = new Mock<ICityDal>();
            _cityDb = new List<City>()
            {
                new City{Id=1,CityName="Adana"},
                new City{Id=6,CityName="Ankara"},
                new City{Id=34,CityName="İstanbul"},
                new City{Id=35,CityName="İzmir"}
            };
        }

        [Fact]
        public async Task Get_list_city()
        {
            _cityDalMock.Setup(x => x.GetAllAsync()).ReturnsAsync(_cityDb);

            CityManager cityManager = new CityManager(_cityDalMock.Object);
            IDataResult<List<City>> dataResult = await cityManager.GetListAsync();

            Assert.True(dataResult.IsSuccess);
        }

        [Theory]
        [InlineData(1, true)]
        [InlineData(2, false)]
        [InlineData(6, true)]
        [InlineData(7, false)]
        public async Task Get_city_by_id(int id, bool isValid)
        {
            _cityDalMock.Setup(x => x.GetAsync(It.IsAny<Expression<Func<City, bool>>>())).ReturnsAsync(_cityDb.SingleOrDefault(c => c.Id == id));

            CityManager cityManager = new CityManager(_cityDalMock.Object);
            IDataResult<City> dataResult = await cityManager.GetByIdAsync(id);

            Assert.Equal(dataResult.IsSuccess, isValid);
        }

        [Fact]
        public async Task Add_city_success()
        {
            City city = new City { CityName = "Düzce" };

            _cityDalMock.Setup(x => x.AddAsync(It.IsAny<City>()));
            CityManager cityManager = new CityManager(_cityDalMock.Object);
            IResult result = await cityManager.AddAsync(city);

            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task Update_city_success()
        {
            City city = new City { Id = 81, CityName = "Düzce" };

            _cityDalMock.Setup(x => x.UpdateAsync(It.IsAny<City>()));
            CityManager cityManager = new CityManager(_cityDalMock.Object);
            IResult result = await cityManager.UpdateAsync(city);

            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task Delete_city_success()
        {
            City city = new City { Id = 1 };

            _cityDalMock.Setup(x => x.DeleteAsync(It.IsAny<City>()));
            CityManager cityManager = new CityManager(_cityDalMock.Object);
            IResult result = await cityManager.DeleteAsync(city);

            Assert.True(result.IsSuccess);
        }
    }
}
