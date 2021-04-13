using _0_Framework.Domain;
using ShopManagement.Application.Contracts.ProductCategory;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ShopManagement.Domain.ProductCategoryAgg
{
  public  interface IProductCategoryRepository  : IRepository<long , ProductCategory> 
    {
        List<ProductCategoryViewModel> GetProductCategories();
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel);
        EditProductCategory GetDetails(long id);
    }
}
