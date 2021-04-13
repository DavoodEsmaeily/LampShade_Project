using _01_LampshadeQuery.Contracts.Slide;
using ShopManagement.InfraStructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01_LampshadeQuery.Query
{
    public class SlideQuery : ISlideQuery
    {
        private readonly ShopContext _shopContext;

        public SlideQuery(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public List<SlideQueryModel> GetSlides()
        {
            return _shopContext.Slidess.Where(x => !x.IsRemoved).Select(x => new SlideQueryModel
                {
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    Heading = x.Heading,
                    Text = x.Text,
                    Title = x.Title,
                    BtnText = x.BtnText,
                    Link = x.Link
                })
                .ToList();
        }
    }
}
