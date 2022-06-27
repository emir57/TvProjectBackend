using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
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
            IResult result = BusinessRules.Run(
                await CheckRoleIsAdd(user, role));
            if (result == null)
            {
                await _roleDal.AddUserRoleAsync(user, role);
            }
            return new SuccessResult();
        }

        private async Task<IResult> CheckRoleIsAdd(User user, Role role)
        {
            UserRole userRole = await _roleDal.GetUserRoleAsync(x => x.UserId == user.Id && x.RoleId == role.Id);
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
            IResult result = BusinessRules.Run(
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
            Role role = await _roleDal.GetAsync(x => x.Id == roleId);
            if (role == null)
                return new ErrorDataResult<Role>(Messages.RoleNotFound);
            return new SuccessDataResult<Role>(role, Messages.SuccessGet);
        }
        [SecuredOperation("Admin")]
        [CacheAspect(20)]
        public async Task<IDataResult<List<Role>>> GetListAsync()
        {
            List<Role> roles = await _roleDal.GetAllAsync();
            return new SuccessDataResult<List<Role>>(roles, Messages.SuccessGet);
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
            IResult result = BusinessRules.Run(
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
