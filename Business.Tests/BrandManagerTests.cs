using Business.Abstract;
using Entities.Concrete;
using Moq;
using System.Collections.Generic;

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
                new TvBrand{Id=3,Name="LG",Address="",PhoneNumber=""},
            };
        }
    }
}
