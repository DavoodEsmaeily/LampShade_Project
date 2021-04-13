using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Application.Contracts.Slide;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.Shop.Slides
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }

        public List<SlideViewModel> Slides;
        private readonly ISlideApplication _SlideApplication;

        public IndexModel(ISlideApplication slideApplication)
        {
            _SlideApplication = slideApplication;
        }

        public void OnGet()
        {
            Slides = _SlideApplication.GetAll();
        }

        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateSlide());
        }

        public JsonResult OnPostCreate(CreateSlide command)
        {
            var result = _SlideApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        { 
            return Partial("./Edit", _SlideApplication.GetDetails(id));
        }

        public JsonResult OnPostEdit(EditSlide command)
        {
            var result = _SlideApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetRemove(long id)
        {
            var result = _SlideApplication.Remove(id);
            if (result.IsSucceded)
                return RedirectToPage("./Index");

            Message = result.Message;
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetRestore(long id)
        {
            var result = _SlideApplication.Restore(id);
            if (result.IsSucceded)
                return RedirectToPage("./Index");

            Message = result.Message;
            return RedirectToPage("./Index");
        }
    }
}
