using _0_Framework.Application;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopManagement.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository productRepository;
        public ProductApplication(IProductRepository productRepository)
        {
            this.productRepository = productRepository; 
        }

        public OperationResult Create(CreateProduct command)
        {
            var operation = new OperationResult();
            if (productRepository.Exsists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            var product = new Product(command.Name, command.Description, command.Picture,
                command.PictureAlt, command.PictureTitle, command.CategoryId,
                command.Code, slug, command.Keywords, command.MetaDescription  , command.ShortDescription);

            productRepository.Create(product);
            productRepository.SaveChanges();

            return operation.Succeded();
        }

        public OperationResult Edit(EditProduct command)
        {
            var operation = new OperationResult();
            var product = productRepository.Get(command.Id);
            if(product == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (productRepository.Exsists(x => x.Name == command.Name && x.Id == command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            product.Edit(command.Name, command.Description, command.Picture,
                command.PictureAlt, command.PictureTitle, command.CategoryId,
                command.Code, slug, command.Keywords, command.MetaDescription, command.ShortDescription);

            productRepository.SaveChanges();
            return operation.Succeded();
        }

        public EditProduct GetDetails(long id)
        {
            return productRepository.GetDetails(id);
        }

        public List<ProductViewModel> GetProducts()
        {
            return productRepository.GetProducts();
        }
        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            return productRepository.Search(searchModel);
        }
    }
}
