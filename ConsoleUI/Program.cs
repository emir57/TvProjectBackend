using AutoMapper;
using Core.Entities;
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
            assemblyTest();
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();

            ProductReadDto productReadDto = mapper.Map<ProductReadDto>(new Product() { Id = 1, Name = "Foo" });

            Console.WriteLine($"{productReadDto.Id} {productReadDto.Name}");
        }

        private static void assemblyTest()
        {
            var assembly = Assembly.GetEntryAssembly();
            var dtos = assembly.GetTypes().Where(x => typeof(IDto).IsAssignableFrom(x));

            foreach (Type item in dtos)
            {
                Console.WriteLine($"{item.Name}");
                foreach (PropertyInfo property in item.GetProperties())
                {
                    Console.WriteLine($"  Name:{property.Name} Type:{property.PropertyType}");
                }
            }
        }
    }

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            DefaultAssemblyScan(Assembly.GetExecutingAssembly(), Assembly.GetExecutingAssembly());
        }

        protected virtual void EntryAssemblyScan()
        {
            var assembly = Assembly.GetEntryAssembly();
            var mappedEntities = assembly.GetTypes().Where(x => typeof(IMapEntity).IsAssignableFrom(x) && typeof(IMapEntity) != x);
            var dtos = assembly.GetTypes().Where(x => typeof(IDto).IsAssignableFrom(x) && typeof(IDto) != x);
            CreateMappers(mappedEntities, dtos);
        }
        protected virtual void ExecutingAssemblyScan()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var mappedEntities = assembly.GetTypes().Where(x => typeof(IMapEntity).IsAssignableFrom(x) && typeof(IMapEntity) != x);
            var dtos = assembly.GetTypes().Where(x => typeof(IDto).IsAssignableFrom(x) && typeof(IDto) != x);
            CreateMappers(mappedEntities, dtos);
        }
        protected virtual void DefaultAssemblyScan(Assembly entityAssembly, Assembly dtoAssembly)
        {
            var mappedEntities = entityAssembly.GetTypes().Where(x => typeof(IMapEntity).IsAssignableFrom(x) && typeof(IMapEntity) != x);
            var dtos = dtoAssembly.GetTypes().Where(x => typeof(IDto).IsAssignableFrom(x) && typeof(IDto) != x);
            CreateMappers(mappedEntities, dtos);
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
}
