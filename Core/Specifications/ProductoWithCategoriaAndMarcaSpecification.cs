using Core.Entities;

namespace Core.Specifications
{
    public class ProductoWithCategoriaAndMarcaSpecification : BaseSpecification<Producto>
    {
        public ProductoWithCategoriaAndMarcaSpecification(string sort, int? marca, int? categoria)
            : base(x => (!marca.HasValue || x.MarcaId == marca) &&
            (!categoria.HasValue || x.CategoriaId == categoria))
        {
            AddInclude(p => p.Categoria);
            AddInclude(P => P.Marca);

            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "NombreAsc":
                        AddOrderBy(p => p.Nombre);
                        break;
                    case "NombreDesc":
                        AddOrderByDescending(p => p.Nombre);
                        break;
                    case "precioAsc":
                        AddOrderBy(p => p.Precio);
                        break;
                    case "precioDesc":
                        AddOrderByDescending(p => p.Precio);
                        break;
                    case "descripcionAsc":
                        AddOrderBy(p => p.Descripcion);
                        break;
                    case "descripcionDesc":
                        AddOrderByDescending(p => p.Descripcion);
                        break;
                    case "stockAsc":
                        AddOrderBy(p => p.Stock);
                        break;
                    case "stockDesc":
                        AddOrderByDescending(p => p.Stock);
                        break;
                    default:
                        AddOrderBy(p => p.Nombre);
                        break;
                }
            }
        }

        public ProductoWithCategoriaAndMarcaSpecification(int id) : base(p => p.Id == id)
        {
            AddInclude(p => p.Categoria);
            AddInclude(P => P.Marca);
        }
    }
}