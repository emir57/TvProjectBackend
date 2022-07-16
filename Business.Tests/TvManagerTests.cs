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
        Mock<ITvDal> _mockTvDal;
        List<Tv> _dbTv;
        IDataResult<List<Tv>> _result;
        public TvManagerTests()
        {
            _mockTvDal = new Mock<ITvDal>();
            _dbTv = new List<Tv>()
            {
                new Tv{Id=1,ProductName="Samsung",BrandId=1,ScreenInch="49",ScreenType="QLED"},
                new Tv{Id=2,ProductName="Philips",BrandId=1,ScreenInch="49",ScreenType="QLED"},
                new Tv{Id=3,ProductName="Lg",BrandId=2,ScreenInch="49",ScreenType="QLED"},
                new Tv{Id=4,ProductName="TCL",BrandId=1,ScreenInch="49",ScreenType="QLED"},
            };
        }
        [Fact]
        public async void Get_all_tvs()
        {
            _result = new SuccessDataResult<List<Tv>>(_dbTv);
            _mockTvDal.Setup(m => m.GetAllAsync()).ReturnsAsync(_dbTv);

            var tvService = new TvManager(_mockTvDal.Object);
            Assert.Equal(tvService.GetListAsync().Result.Data.Count, 4);
        }

        [Fact]
        public async void Get_tvs_by_brand_id()
        {
            var tvService = new TvManager(new EfTvDal());
            int count = tvService.GetListByBrandAsync(2).Result.Data.Count;
            Assert.Equal(count, 2);
        }
    }
}
