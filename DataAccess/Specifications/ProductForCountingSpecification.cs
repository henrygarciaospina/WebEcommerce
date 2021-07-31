using Entities;

namespace DataAccess.Specifications
{
    public class ProductForCountingSpecification : BaseSpecification<Product>
    {
        public ProductForCountingSpecification(ProductSpecificationParams productParams)
           : base(x =>
               (string.IsNullOrEmpty(productParams.Search) || x.Name.Contains(productParams.Search)) &&
               (!productParams.Mark.HasValue || x.MarkId == productParams.Mark) &&
               (!productParams.Category.HasValue || x.CategoryId == productParams.Category)
           )
        { }

    }
}
