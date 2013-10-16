using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eStore.Domain.Admin;
using eStore.Interfaces.Services;
using eStore.Web.Infrastructure.ObjectMapper;
using eStore.Web.UI.Areas.Admin.ViewModels;

namespace eStore.Web.UI.Areas.Admin.Controllers
{
    public class LogController : Controller
    {
        private readonly IAdminService _service;
        private readonly IObjectMapper _mapper;

        public LogController(IAdminService service, IObjectMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var logentries = _service.GetLog();

            return View(new LogModel
                {
                    Entries = _mapper.Map < IEnumerable<LogEntry>,IEnumerable<LogEntryModel>>(logentries),
                    Severities = new string[] {"INFO"},
                    AppModules = new string[] { "Main Web App" },
                });
        }
    }
}
