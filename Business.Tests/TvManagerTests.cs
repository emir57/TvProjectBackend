using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Business.Tests
{
    public class TvManagerTests
    {
        Mock<ITvDal> _mockTvDal;
        List<Tv> _dbTv;
        public TvManagerTests()
        {
            _mockTvDal = new Mock<ITvDal>();
            _dbTv = new List<Tv>()
            {
                new Tv{Id=1,ProductName="Samsung",BrandId=1,ScreenInch="49",ScreenType="QLED"},
                new Tv{Id=2,ProductName="Philips",BrandId=1,ScreenInch="49",ScreenType="QLED"},
                new Tv{Id=3,ProductName="Lg",BrandId=1,ScreenInch="49",ScreenType="QLED"},
                new Tv{Id=4,ProductName="TCL",BrandId=1,ScreenInch="49",ScreenType="QLED"},
            };
            _mockTvDal.Setup(m => m.GetAllAsync()).ReturnsAsync(_dbTv);
        }
        [Fact]
        public async void Get_all_tvs()
        {
            var list = await _mockTvDal.Object.GetAllAsync();
            Assert.Equal(list.Count, 4);
        }

        [Fact]
        public async void Get_all_tvs_name_start_with_S()
        {
            var list = await _mockTvDal.Object.GetAllAsync(x => x.ProductName.StartsWith("S"));
            Assert.Equal(list.Count, 1);
        }
    }
}
