using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RoleManager : IRoleService
    {
        private readonly IRoleDal _roleDal;
        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }
        public async Task<IResult> Add(Role entity)
        {
            await _roleDal.Add(entity);
            return new SuccessResult(Messages.SuccessAdd);
        }

        public async Task<IResult> Delete(Role entity)
        {
            await _roleDal.Delete(entity);
            return new SuccessResult(Messages.SuccessDelete);
        }

        public async Task<IDataResult<Role>> Get(Expression<Func<Role, bool>> filter)
        {
            var result = await _roleDal.Get(filter);
            return new SuccessDataResult<Role>(result, Messages.SuccessGet);
        }

        public async Task<IDataResult<List<Role>>> GetAll(Expression<Func<Role, bool>> filter = null)
        {
            var result = filter == null ?
                await _roleDal.GetAll() :
                await _roleDal.GetAll(filter);
            return new SuccessDataResult<List<Role>>(result, Messages.SuccessGet);
        }

        public async Task<IResult> Update(Role entity)
        {
            await _roleDal.Update(entity);
            return new SuccessResult(Messages.SuccessUpdate);
        }
    }
}
