using _0_Framework.Application;
using _0_Framework.InfraStructure;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Domain.SlideAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopManagement.InfraStructure.EFCore.Repository
{
    public class SlidesRepository : RepositoryBase<long, Slide>, ISlideRepository
    {
        private readonly ShopContext _context;

        public SlidesRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public List<SlideViewModel> GetAll()
        {
            return _context.Slidess.Select(x => new SlideViewModel
            {
                Id = x.Id,
                Picture = x.Picture,
                CreationDate = x.CreationDate.ToFarsi(),
                Title = x.Title,
                Text = x.Text,
                Heading = x.Heading,
                IsRemovd = x.IsRemoved,
            }).OrderByDescending(x => x.Id).ToList();
        }

        public EditSlide GetDetails(long id)
        {
            return _context.Slidess.Select(x => new EditSlide
            {
                Id = x.Id,
                Picture = x.Picture,
                Title = x.Title,
                Text = x.Text,
                Heading = x.Heading,
                BtnText = x.BtnText,
                Link = x.Link,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle
            }).FirstOrDefault(x => x.Id == id);
        }
    }
}
