using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
    public class _GaleriPartial:ViewComponent
    {
        private readonly IImageService _imageService;

        public _GaleriPartial(IImageService imageService)
        {
            _imageService = imageService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _imageService.GetListAll();
            return View(values);
        }
    }
}
