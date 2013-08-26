using System;
using System.Linq;
using System.Web.Mvc;
using eStore.Interfaces.Extensions;

namespace eStore.Web.UI.Logic
{
    public class BaseDisposeController : Controller
    {
        private readonly IDisposable[] _rsrc;

        internal BaseDisposeController(params IDisposable[] rsrc)
        {
            _rsrc = rsrc;
        }
        protected override void Dispose(bool disposing)
        {
            if (_rsrc != null && _rsrc.Any())
            {
                _rsrc.ForEach(x => x.Dispose());
            }

            base.Dispose(disposing);
        }
    }
}