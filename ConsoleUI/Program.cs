using AutoMapper;
using Core.Entities;
using ServiceStack;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            autoMapperScanAssembly();
            //new Foo();
        }

        private static void autoMapperScanAssembly()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();

            ProductReadDto productReadDto = mapper.Map<ProductReadDto>(new Product() { Id = 1, Name = "Foo" });

            Console.WriteLine($"{productReadDto.Id} {productReadDto.Name}");

            Console.WriteLine(String.Join("\n", productReadDto.GetType().GetProperties().Select(x => x.GetCustomAttribute<DenemeAttribute>().Priority)));
        }
    }

    public class AutoMapperProfile : BaseAssemblyProfile
    {
        public AutoMapperProfile()
        {
            DefaultAssemblyScan(Assembly.GetExecutingAssembly(), Assembly.GetExecutingAssembly());
        }
    }

    public class BaseAssemblyProfile : Profile
    {
        protected virtual void EntryAssemblyScan()
        {
            var assembly = Assembly.GetEntryAssembly();
            var mappedEntities = getMappedEntities(assembly);
            var dtos = getDtos(assembly);
            CreateMappers(mappedEntities, dtos);
        }
        protected virtual void ExecutingAssemblyScan()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var mappedEntities = getMappedEntities(assembly);
            var dtos = getDtos(assembly);
            CreateMappers(mappedEntities, dtos);
        }
        protected virtual void DefaultAssemblyScan(Assembly entityAssembly, Assembly dtoAssembly)
        {
            var mappedEntities = getMappedEntities(entityAssembly);
            var dtos = getDtos(dtoAssembly);
            CreateMappers(mappedEntities, dtos);
        }
        private IEnumerable<Type> getMappedEntities(Assembly assembly)
        {
            return assembly.GetTypes().Where(x => typeof(IMapEntity).IsAssignableFrom(x) && typeof(IMapEntity) != x);
        }
        private IEnumerable<Type> getDtos(Assembly assembly)
        {
            return assembly.GetTypes().Where(x => typeof(IDto).IsAssignableFrom(x) && typeof(IDto) != x);
        }

        private void CreateMappers(IEnumerable<Type> mappedEntities, IEnumerable<Type> dtos)
        {
            foreach (Type mappedEntity in mappedEntities)
            {
                foreach (Type dto in dtos)
                {
                    Console.WriteLine($"Entity:{mappedEntity.Name} Dto:{dto.Name}");
                    CreateMap(mappedEntity, dto).ReverseMap();
                }
            }
        }
    }

    public class EventDemo
    {
        class Foo
        {
            public event EventHandler MyEvent;
        }
        public EventDemo()
        {
            Foo foo = new Foo();
            foo.MyEvent += new EventHandler(OnMyEvent);
        }
        private void OnMyEvent(object sender, EventArgs e)
        {
            Console.WriteLine(sender.GetType());
            Console.WriteLine("triggered event");
        }
    }
}
