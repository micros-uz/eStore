using System;
using System.Web;

namespace eStore.Web.Infrastructure
{
    public interface IFileService
    {
        Guid? SaveImage(HttpPostedFileBase file, string oldFileName, bool isImageChanged);

        Tuple<byte[], string> GetImage(string fileName);
    }
}
