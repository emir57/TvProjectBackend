using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Business.Tests
{
    public class TvManagerTests
    {
        Mock<ITvService> _mockTvService;
        List<Tv> _dbTv;
        IDataResult<List<Tv>> _result;
        public TvManagerTests()
        {
            _mockTvService = new Mock<ITvService>();
            _dbTv = new List<Tv>()
            {
                new Tv{Id=1,ProductName="Samsung",BrandId=1,ScreenInch="49",ScreenType="QLED"},
                new Tv{Id=2,ProductName="Philips",BrandId=1,ScreenInch="49",ScreenType="QLED"},
                new Tv{Id=3,ProductName="Lg",BrandId=2,ScreenInch="49",ScreenType="QLED"},
                new Tv{Id=4,ProductName="TCL",BrandId=1,ScreenInch="49",ScreenType="QLED"},
            };
            _mockTvService.Setup(m => m.GetListAsync()).ReturnsAsync(new SuccessDataResult<List<Tv>>(_dbTv));
            _mockTvService.Setup(m => m.GetListByBrandAsync(It.IsAny<int>())).ReturnsAsync((int i) => new SuccessDataResult<List<Tv>>(_dbTv.Where(x => x.BrandId == i).ToList()));
            _mockTvService.Setup(m => m.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((int i) => new SuccessDataResult<Tv>(_dbTv.Single(x => x.Id == i)));
        }
        [Fact]
        public async void Get_all_tvs()
        {
            var list = await _mockTvService.Object.GetListAsync();
            Assert.Equal(list.Data.Count, 4);
        }
        [Theory]
        [InlineData(2)]
        public async void Get_tvs_by_brand_id(int brandId)
        {
            var list = await _mockTvService.Object.GetListByBrandAsync(brandId);
            Assert.Equal(list.Data.Count, 1);
        }

        [Theory]
        [InlineData(1)]
        public async void Get_tv_by_id(int id)
        {
            var tv = await _mockTvService.Object.GetByIdAsync(id);
            Assert.NotEqual(tv, null);
        }
    }
}
