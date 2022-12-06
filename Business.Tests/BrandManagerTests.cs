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
    public class BrandManagerTests
    {
        Mock<ITvBrandDal> _mockTvBrandDal;
        List<TvBrand> _dbBrand;
        public BrandManagerTests()
        {
            _mockTvBrandDal = new Mock<ITvBrandDal>();
            _dbBrand = getBrands().ToList();
        }

        [Fact]
        public async Task Get_all_brand_count_4()
        {
            _mockTvBrandDal.Setup(x => x.GetAllAsync()).ReturnsAsync(_dbBrand);

            TvBrandManager tvBrandManager = new TvBrandManager(_mockTvBrandDal.Object);
            IDataResult<List<TvBrand>> result = await tvBrandManager.GetListAsync();

            Assert.Equal(4, result.Data.Count);
        }

        [Theory]
        [InlineData(1, true)]
        [InlineData(2, true)]
        [InlineData(5, false)]
        public async Task Get_by_id_brand_success(int id, bool success)
        {
            _mockTvBrandDal.Setup(x => x.GetAsync(It.IsAny<Expression<Func<TvBrand, bool>>>())).ReturnsAsync(_dbBrand.SingleOrDefault(x => x.Id == id));

            TvBrandManager tvBrandManager = new TvBrandManager(_mockTvBrandDal.Object);
            IDataResult<TvBrand> result = await tvBrandManager.GetByIdAsync(id);

            Assert.Equal(result.IsSuccess, success);
        }

        [Theory]
        [InlineData(4, true)]
        [InlineData(5, false)]
        [InlineData(6, false)]
        public async Task Get_by_id_brand_error(int id, bool success)
        {
            _mockTvBrandDal.Setup(x => x.GetAsync(It.IsAny<Expression<Func<TvBrand, bool>>>())).ReturnsAsync(_dbBrand.SingleOrDefault(x => x.Id == id));

            TvBrandManager tvBrandManager = new TvBrandManager(_mockTvBrandDal.Object);
            IDataResult<TvBrand> result = await tvBrandManager.GetByIdAsync(id);

            Assert.Equal(result.IsSuccess, success);
        }

        [Fact]
        public async Task Add_brand()
        {
            _mockTvBrandDal.Setup(x => x.AddAsync(It.IsAny<TvBrand>()));

            TvBrandManager tvBrandManager = new TvBrandManager(_mockTvBrandDal.Object);
            TvBrand tvBrand = new TvBrand() { Id = 1, Address = "Address", Name = "Name", PhoneNumber = "" };
            IResult result = await tvBrandManager.AddAsync(tvBrand);

            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task Update_brand()
        {
            _mockTvBrandDal.Setup(x => x.UpdateAsync(It.IsAny<TvBrand>()));

            TvBrandManager tvBrandManager = new TvBrandManager(_mockTvBrandDal.Object);
            TvBrand tvBrand = new TvBrand() { Id = 1, Address = "New Address", Name = "New Name", PhoneNumber = "" };
            IResult result = await tvBrandManager.UpdateAsync(tvBrand);

            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task Delete_brand()
        {
            _mockTvBrandDal.Setup(x => x.DeleteAsync(It.IsAny<TvBrand>()));

            TvBrandManager tvBrandManager = new TvBrandManager(_mockTvBrandDal.Object);
            TvBrand tvBrand = new TvBrand() { Id = 1 };
            IResult result = await tvBrandManager.DeleteAsync(tvBrand);

            Assert.True(result.IsSuccess);
        }

        private IEnumerable<TvBrand> getBrands()
        {
            yield return new TvBrand { Id = 1, Name = "Samsung", Address = "", PhoneNumber = "" };
            yield return new TvBrand { Id = 2, Name = "Philips", Address = "", PhoneNumber = "" };
            yield return new TvBrand { Id = 3, Name = "TCL", Address = "", PhoneNumber = "" };
            yield return new TvBrand { Id = 4, Name = "LG", Address = "", PhoneNumber = "" };
        }
    }
}
