using System;
using System.IO;
using System.Security;
using System.Web;

namespace eStore.Web.Infrastructure
{
    internal class FileService : IFileService
    {
        private const string SERVER_Path = @"uploads";

        private void WrapExceptions(Action action)
        {
            try
            {
                action();
            }
            catch (IOException)
            {
            }
            catch (UnauthorizedAccessException)
            {
            }
            catch (NotSupportedException)
            {
            }
            catch (SecurityException)
            {
            }
        }

        private void DeleteFile(string oldFileName, string path)
        {
            WrapExceptions(() =>
                {
                    if (!string.IsNullOrEmpty(oldFileName))
                    {
                        var imagePath = Path.Combine(path, SERVER_Path, oldFileName);
                        File.Delete(imagePath);
                    }
                });
        }

        private Guid? SaveFile(byte[] fileData, string path)
        {
            Guid? res = null;
            var name = Guid.NewGuid();

            WrapExceptions(() =>
                {
                    var imageDirPath = Path.Combine(path, SERVER_Path);

                    if (!Directory.Exists(imageDirPath))
                    {
                        Directory.CreateDirectory(imageDirPath);
                    }

                    File.WriteAllBytes(Path.Combine(imageDirPath, name.ToString()), fileData);
                    res = name;
                });

            return res;
        }

        private byte[] GetFile(string fileName, string path)
        {
            byte[] res = null;

            var imagePath = Path.Combine(path, SERVER_Path, fileName);

            WrapExceptions(() =>
                {
                    res = File.ReadAllBytes(imagePath);
                });

            return res;
        }

        #region IFileService

        public Guid? SaveImage(System.Web.HttpPostedFileBase file, string oldFileName, bool isImageChanged)
        {
            Guid? res = null;

            if (file != null && file.ContentLength > 0 &&
                file.ContentType == "image/jpeg")
            {
                var data = new byte[file.ContentLength];
                file.InputStream.Read(data, 0, file.ContentLength);

                DeleteFile(oldFileName, HttpContext.Current.Request.PhysicalApplicationPath);
                res = SaveFile(data, HttpContext.Current.Request.PhysicalApplicationPath);
            }

            return res;
        }

        public Tuple<byte[], string> GetImage(string fileName)
        {
            Tuple<byte[], string> res = null;

            if (!string.IsNullOrEmpty(fileName))
            {
                var data = GetFile(fileName, HttpContext.Current.Request.PhysicalApplicationPath);

                if (data != null)
                {
                    res = Tuple.Create(data, "image/jpeg");
                }
            }

            return res;
        }

        #endregion
    }
}
