using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Business.Tests
{
    public class BrandManagerTests
    {
        Mock<ITvBrandService> _mockBrandService;
        List<TvBrand> _dbBrand;
        public BrandManagerTests()
        {
            _mockBrandService = new Mock<ITvBrandService>();
            _dbBrand = new List<TvBrand>
            {
                new TvBrand{Id=1,Name="Samsung",Address="",PhoneNumber=""},
                new TvBrand{Id=2,Name="Philips",Address="",PhoneNumber=""},
                new TvBrand{Id=3,Name="TCL",Address="",PhoneNumber=""},
                new TvBrand{Id=4,Name="LG",Address="",PhoneNumber=""},
            };
            _mockBrandService.Setup(x => x.GetListAsync()).ReturnsAsync(new SuccessDataResult<List<TvBrand>>(_dbBrand));
        }

        [Fact]
        public async void Get_all_brands()
        {
            var brands = await _mockBrandService.Object.GetListAsync();
            Assert.Equal(brands.Data.Count, 4);
        }
    }
}
