using AutoMapper;
using Data.Model;
using Microsoft.Practices.Unity;
using Service.Interface;
using Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace WebApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(
                new MediaTypeHeaderValue("application/json"));

            // AutoMapper
            Mapper.Initialize(cfg => {

                cfg.CreateMap<User, UserDetailsDTO>()
                    .ForMember(dest => dest.UserRoleName, opt => opt.MapFrom(src => src.UsersRole.UserRoleName))
                    .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.UsersRole.Department))
                    .ForMember(dest => dest.UserRoleId, opt => opt.MapFrom(src => src.UsersRole.Id));
                cfg.CreateMap<UserDetailsDTO, User>()
                    .ForMember(dest => dest.UsersRole, opt => opt.MapFrom(src => new UsersRole
                    {
                        UserRoleName = src.UserRoleName,
                        Department = src.DepartmentName,
                        Id = src.UserRoleId
                    }));
                cfg.CreateMap<UserAccountDto, UserAccount>();
                cfg.CreateMap<UserAccount, UserAccountDto>();
            });

            // Unity
            var container = new UnityContainer();
            container.RegisterType<IRepository<User>, UsersRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepository<UsersRole>, UsersRoleRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserAccountRepository, UserAccountRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IFileRepository, FileRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IFilePathRepository, FilePathRepository>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new Resolver.UnityResolver(container);
        }
    }
    
}
