using Core.Entities;

namespace ConsoleUI
{
    class Product : IMapEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class ProductReadDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
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
