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
using System.Linq;
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
        public async Task<IResult> AddAsync(Role entity)
        {
            await _roleDal.AddAsync(entity);
            return new SuccessResult(Messages.SuccessAdd);
        }
        [SecuredOperation("Admin")]
        public async Task<IResult> AddUserRoleAsync(User user, Role role)
        {
            var result = BusinessRules.Run(
                await CheckRoleIsAdd(user, role));
            if (result == null)
            {
                await _roleDal.AddUserRoleAsync(user, role);
            }
            return new SuccessResult();
        }

        private async Task<IResult> CheckRoleIsAdd(User user, Role role)
        {
            var userRole = await _roleDal.GetUserRoleAsync(x => x.UserId == user.Id && x.RoleId == role.Id);
            if(userRole == null)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        [SecuredOperation("Admin")]
        [CacheRemoveAspect("IRoleService.Get")]
        public async Task<IResult> DeleteAsync(Role entity)
        {
            var result = BusinessRules.Run(
                CheckAdminRole(entity)
                );
            if (result != null)
            {
                return result;
            }
            await _roleDal.DeleteAsync(entity);
            return new SuccessResult(Messages.SuccessDelete);
        }
        [SecuredOperation("Admin")]
        [CacheAspect(20)]
        public async Task<IDataResult<Role>> GetByIdAsync(int roleId)
        {
            var result = await _roleDal.GetAsync(x=>x.Id==roleId);
            return new SuccessDataResult<Role>(result, Messages.SuccessGet);
        }
        [SecuredOperation("Admin")]
        [CacheAspect(20)]
        public IDataResult<IQueryable<Role>> GetList()
        {
            var result = _roleDal.GetAll();
            return new SuccessDataResult<IQueryable<Role>>(result, Messages.SuccessGet);
        }

        public async Task<IResult> RemoveUserRoleAsync(User user, Role role)
        {
            await _roleDal.RemoveUserRoleAsync(user, role);
            return new SuccessResult();
        }

        [SecuredOperation("Admin")]
        [CacheRemoveAspect("IRoleService.Get")]
        public async Task<IResult> UpdateAsync(Role entity)
        {
            var result = BusinessRules.Run(
                CheckAdminRole(entity)
                );
            if (result != null)
            {
                return result;
            }
            await _roleDal.UpdateAsync(entity);
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
