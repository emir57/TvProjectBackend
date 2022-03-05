﻿using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Security.JWT;
using Core.Utilities.Email;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();
            //Business
            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            builder.RegisterType<CityManager>().As<ICityService>().SingleInstance();
            builder.RegisterType<PhotoManager>().As<IPhotoService>().SingleInstance();
            builder.RegisterType<TvBrandManager>().As<ITvBrandService>().SingleInstance();
            builder.RegisterType<PhotoUploadManager>().As<IPhotoUploadService>().SingleInstance();
            builder.RegisterType<OrderManager>().As<IOrderService>().SingleInstance();
            builder.RegisterType<RoleManager>().As<IRoleService>().SingleInstance();
            builder.RegisterType<TvManager>().As<ITvService>().SingleInstance();
            builder.RegisterType<UserAddressManager>().As<IUserAddressService>().SingleInstance();
            builder.RegisterType<UserCreditCardManager>().As<IUserCreditCardService>().SingleInstance();
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();

            //DataAccess
            builder.RegisterType<EfCityDal>().As<ICityDal>().SingleInstance();
            builder.RegisterType<EfPhotoDal>().As<IPhotoDal>().SingleInstance();
            builder.RegisterType<EfTvBrandDal>().As<ITvBrandDal>().SingleInstance();
            builder.RegisterType<EfTvDal>().As<ITvDal>().SingleInstance();
            builder.RegisterType<EfOrderDal>().As<IOrderDal>().SingleInstance();
            builder.RegisterType<EfUserAddressDal>().As<IUserAddressDal>().SingleInstance();
            builder.RegisterType<EfUserCreditCardDal>().As<IUserCreditCardDal>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();
            builder.RegisterType<EfRoleDal>().As<IRoleDal>().SingleInstance();

            builder.RegisterType<SmtpEmailSender>().As<IEmailService>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions
                {
                    Selector = new AspectInterceptorSelector()
                });
        }
    }
}
