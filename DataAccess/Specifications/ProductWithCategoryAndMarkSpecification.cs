using Entities;

namespace DataAccess.Specifications
{
    public class ProductWithCategoryaAndMarkSpecification : BaseSpecification<Product>
    {
        public ProductWithCategoryaAndMarkSpecification(ProductSpecificationParams productParams)
           : base(x =>
          (string.IsNullOrEmpty(productParams.Search) || x.Name.Contains(productParams.Search)) &&
          (!productParams.Mark.HasValue || x.MarkId == productParams.Mark) &&
          (!productParams.Category.HasValue || x.CategoryId == productParams.Category)
           )
        {
            AddInclude(p => p.Category);
            AddInclude(p => p.Mark);

            //ApplyPaging(0 ,5)
            ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1), productParams.PageSize);


            if (!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
                {
                    case "nameAsc":
                        AddOrderBy(p => p.Name);
                        break;
                    case "nameDesc":
                        AddOrderByDescending(p => p.Name);
                        break;
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    case "descriptionAsc":
                        AddOrderBy(p => p.Description);
                        break;
                    case "descriptionDesc":
                        AddOrderBy(p => p.Description);
                        break;
                    case "stockAsc":
                        AddOrderBy(p => p.Stock);
                        break;
                    case "stockDesc":
                        AddOrderByDescending(p => p.Stock);
                        break;
                    default:
                        AddOrderBy(p => p.Name);
                        break;

                }
            }
        }

        public ProductWithCategoryaAndMarkSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(p => p.Category);
            AddInclude(p => p.Mark);
        }
    }
}