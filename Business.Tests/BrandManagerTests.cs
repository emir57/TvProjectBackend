using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Moq;
using System.Collections.Generic;
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
            _dbBrand = new List<TvBrand>
            {
                new TvBrand{Id=1,Name="Samsung",Address="",PhoneNumber=""},
                new TvBrand{Id=2,Name="Philips",Address="",PhoneNumber=""},
                new TvBrand{Id=3,Name="TCL",Address="",PhoneNumber=""},
                new TvBrand{Id=4,Name="LG",Address="",PhoneNumber=""},
            };
        }

        [Fact]
        public async Task Get_all_brand_count_4()
        {
            _mockTvBrandDal.Setup(x => x.GetAllAsync()).ReturnsAsync(_dbBrand);

            TvBrandManager tvBrandManager = new TvBrandManager(_mockTvBrandDal.Object);
            IDataResult<List<TvBrand>> result = await tvBrandManager.GetListAsync();

            Assert.Equal(result.Data.Count, 4);
        }
    }
}
