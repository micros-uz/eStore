using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using eStore.Domain;
using eStore.Interfaces.Services;
using eStore.Web.Infrastructure.ObjectMapper;
using eStore.Web.UI.Areas.Store.ViewModels;

namespace eStore.Web.UI.Areas.Store.Controllers.Api
{
    public class CartController : ApiController
    {
        private readonly ICartService _cartService;
        private readonly IObjectMapper _objMapper;

        public CartController(ICartService cartservice, IObjectMapper objMapper)
        {
            _cartService = cartservice;
            _objMapper = objMapper;
        }

        [HttpPost]
        public object Get()
        {
            var cart = _cartService.GetCart();

            var model = _objMapper.Map<IEnumerable<CartItem>, IEnumerable<CartItemModel>>(cart.Items);

            return model;
        }

        [HttpPost]
        public object Add([FromBody]int id)
        {
            if (HttpContext.Current.Session.SessionID != null)
            {
                //http://www.strathweb.com/2012/11/adding-session-support-to-asp-net-web-api/
                //http://jamiekurtz.com/2013/01/14/asp-net-web-api-security-basics/
            }

            return new { count = 3 };
        }

        [HttpDelete]
        public object Delete([FromBody]int id)
        {
            return new { success = true };
        }
    }
}
