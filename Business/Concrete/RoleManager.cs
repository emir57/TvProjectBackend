using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Entities.Concrete;
using Core.Utilities.Business;
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
        [SecuredOperation("Admin")]
        [CacheRemoveAspect("IRoleService.Get")]
        public async Task<IResult> Add(Role entity)
        {
            await _roleDal.Add(entity);
            return new SuccessResult(Messages.SuccessAdd);
        }
        [SecuredOperation("Admin")]
        [CacheRemoveAspect("IRoleService.Get")]
        public async Task<IResult> Delete(Role entity)
        {
            var result = BusinessRules.Run(
                CheckAdminRole(entity)
                );
            if (result != null)
            {
                return result;
            }
            await _roleDal.Delete(entity);
            return new SuccessResult(Messages.SuccessDelete);
        }
        [SecuredOperation("Admin")]
        [CacheAspect(20)]
        public async Task<IDataResult<Role>> GetById(int roleId)
        {
            var result = await _roleDal.Get(x=>x.Id==roleId);
            return new SuccessDataResult<Role>(result, Messages.SuccessGet);
        }
        [SecuredOperation("Admin")]
        [CacheAspect(20)]
        public async Task<IDataResult<List<Role>>> GetAll()
        {
            var result = await _roleDal.GetAll();
            return new SuccessDataResult<List<Role>>(result, Messages.SuccessGet);
        }
        [SecuredOperation("Admin")]
        [CacheRemoveAspect("IRoleService.Get")]
        public async Task<IResult> Update(Role entity)
        {
            var result = BusinessRules.Run(
                CheckAdminRole(entity)
                );
            if (result != null)
            {
                return result;
            }
            await _roleDal.Update(entity);
            return new SuccessResult(Messages.SuccessUpdate);
        }

        private IResult CheckAdminRole(Role entity)
        {
            if (entity.Name == "Admin")
            {
                return new ErrorResult(Messages.DontChangeAdminRole);
            }
            return new SuccessResult();
        }
    }
}
