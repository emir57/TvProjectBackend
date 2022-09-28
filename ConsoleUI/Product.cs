using Castle.Components.DictionaryAdapter;
using Core.Entities;
using ServiceStack.DataAnnotations;
using System;

namespace ConsoleUI
{
    class Product : IMapEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class ProductReadDto : IDto
    {
        [Deneme(1)]
        public int Id { get; set; }
        [Deneme(6)]
        public string Name { get; set; }
    }
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    class DenemeAttribute : Attribute
    {
        public int Priority { get; set; }
        public DenemeAttribute(int priority)
        {
            Priority = priority;
        }
    }

    class ProductWriteDto : IDto
    {
        public string Name { get; set; }
    }

    class ProductDto : IDto
    {

    }

    interface IMapEntity
    {

    }
}
