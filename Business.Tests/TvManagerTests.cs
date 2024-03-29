﻿using Business.Concrete;
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
    public class TvManagerTests
    {
        Mock<ITvDal> _mockTvDal;
        List<Tv> _dbTv;
        public TvManagerTests()
        {
            _mockTvDal = new Mock<ITvDal>();
            _dbTv = getTvs().ToList();
        }

        [Fact]
        public async void Get_all_tv_count_4()
        {
            _mockTvDal.Setup(x => x.GetAllAsync()).ReturnsAsync(_dbTv);

            TvManager tvManager = new TvManager(_mockTvDal.Object);
            IDataResult<List<Tv>> result = await tvManager.GetListAsync();

            Assert.Equal(4, result.Data.Count);
        }

        [Theory, InlineData(1)]
        public async Task Get_by_id_tv(int id)
        {
            _mockTvDal.Setup(x => x.GetAsync(It.IsAny<Expression<Func<Tv, bool>>>())).ReturnsAsync(_dbTv.SingleOrDefault(x => x.Id == id));

            TvManager tvManager = new TvManager(_mockTvDal.Object);
            IDataResult<Tv> result = await tvManager.GetByIdAsync(id);

            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task Add_tv_success()
        {
            _mockTvDal.Setup(x => x.AddAsync(It.IsAny<Tv>()));
            _mockTvDal.Setup(x => x.GetAllAsync()).ReturnsAsync(_dbTv);

            TvManager tvManager = new TvManager(_mockTvDal.Object);
            Tv tv = new Tv { Id = 1, ProductName = "Tv Name", Discount = 1, ScreenInch = "49\"", Stock = 2, UnitPrice = 5999, ProductCode = "Code", IsDiscount = true, ScreenType = "LED", Extras = "Extras", BrandId = 1 };
            IResult result = await tvManager.AddAsync(tv);

            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task Add_tv_name_already_exists_error()
        {
            _mockTvDal.Setup(x => x.AddAsync(It.IsAny<Tv>()));
            _mockTvDal.Setup(x => x.GetAllAsync()).ReturnsAsync(_dbTv);

            TvManager tvManager = new TvManager(_mockTvDal.Object);
            Tv tv = new Tv { Id = 1, ProductName = "Samsung", Discount = 1, ScreenInch = "49\"", Stock = 2, UnitPrice = 5999, ProductCode = "Code", IsDiscount = true, ScreenType = "LED", Extras = "Extras", BrandId = 1 };
            IResult result = await tvManager.AddAsync(tv);

            Assert.False(result.IsSuccess);
        }

        [Fact]
        public async Task Update_tv_success()
        {
            _mockTvDal.Setup(x => x.UpdateAsync(It.IsAny<Tv>()));

            TvManager tvManager = new TvManager(_mockTvDal.Object);
            Tv tv = new Tv { Id = 1, ProductName = "Samsung", Discount = 1, ScreenInch = "49\"", Stock = 2, UnitPrice = 5999, ProductCode = "Code", IsDiscount = true, ScreenType = "LED", Extras = "Extras", BrandId = 1 };
            IResult result = await tvManager.UpdateAsync(tv);

            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task Delete_tv_success()
        {
            _mockTvDal.Setup(x => x.DeleteAsync(It.IsAny<Tv>()));

            TvManager tvManager = new TvManager(_mockTvDal.Object);
            Tv tv = new Tv { Id = 1 };
            IResult result = await tvManager.DeleteAsync(tv);

            Assert.True(result.IsSuccess);
        }

        private IEnumerable<Tv> getTvs()
        {
            yield return new Tv { Id = 1, ProductName = "Samsung", BrandId = 1, ScreenInch = "49", ScreenType = "QLED" };
            yield return new Tv { Id = 2, ProductName = "Philips", BrandId = 1, ScreenInch = "49", ScreenType = "QLED" };
            yield return new Tv { Id = 3, ProductName = "Lg", BrandId = 2, ScreenInch = "49", ScreenType = "QLED" };
            yield return new Tv { Id = 4, ProductName = "TCL", BrandId = 1, ScreenInch = "49", ScreenType = "QLED" };
        }
    }
}
