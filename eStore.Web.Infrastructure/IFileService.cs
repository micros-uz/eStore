using System;
using System.Web;

namespace eStore.Web.Infrastructure
{
    public interface IFileService
    {
        Guid? SaveImage(HttpPostedFileBase file);

        Tuple<byte[], string> GetImage(string fileName);
    }
}
