using _0_Framework.Domain;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopManagement.Domain.ProductAgg
{
    public class Product : EntityBase
    {
        public string Name { get; private set; }
        public string Code { get; private set; }
        public string Description { get; private set; }
        public string ShortDescription { get; private set; }
        public string Picture { get; private set; }
        public string PictureTitle { get; private set; }
        public string PictureAlt { get; private set; }
        public string Slug { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }
        public long CategoryId { get; private set; }
        public ProductCategory Category { get; private set; }

        public List<ProductPicture> ProductPictures { get; private set; }


        protected Product()
        {

        }

        public Product(string name, string description, string picture
            , string pictureAlt, string pictureTitle, long categoryId
            , string code, string keywords, string slug, string metaDescripton , string shortDescription)
        {
            Name = name;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            CategoryId = categoryId;
            Code = code;
            Keywords = keywords;
            MetaDescription = metaDescripton;
            Slug = slug;
            ShortDescription = shortDescription;
        }

        public void Edit(string name, string description,  string picture
            , string pictureAlt, string pictureTitle, long categoryId
            , string code, string keywords, string slug, string metaDescripton , string shortDescription)
        {
            Name = name;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            CategoryId = categoryId;
            Code = code;
            Keywords = keywords;
            MetaDescription = metaDescripton;
            Slug = slug;
            ShortDescription = shortDescription;
        }   
    }
}
