using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Moq;
using System.Collections.Generic;
using System.Linq;
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
        public async void Get_all_tv_count_4()
        {
            _mockTvDal.Setup(x => x.GetAllAsync()).ReturnsAsync(_dbTv);

            TvManager tvManager = new TvManager(_mockTvDal.Object);
            IDataResult<List<Tv>> list = await tvManager.GetListAsync();

            Assert.Equal(list.Data.Count, 4);
        }
    }
}
