using System.Collections.Generic;
using System.Web.Mvc;
using eStore.Domain;
using eStore.Interfaces.Services;
using eStore.Web.Infrastructure.ObjectMapper;
using eStore.Web.UI.Areas.Store.ViewModels;

namespace eStore.Web.UI.Areas.Store.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IObjectMapper _objMapper;

        public CartController(ICartService cartservice, IObjectMapper objMapper)
        {
            _cartService = cartservice;
            _objMapper = objMapper;
        }

        public ActionResult Index()
        {
            var cart = _cartService.GetCart();

            var model = _objMapper.Map<IEnumerable<CartItem>, IEnumerable<CartItemModel>>(cart.Items);

            return View(model);
        }

        public JsonResult Add(int id)
        {
            if (Session.SessionID != null)
            {

            }

            return Json(new { count = 3 }, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            return Json(new { success = true });
        }
    }
}
