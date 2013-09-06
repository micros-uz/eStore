﻿using System;
using System.IO;
using System.Security;
using System.Web;

namespace eStore.Web.Infrastructure
{
    internal class FileService : IFileService
    {
        private const string SERVER_Path = @"App_Data\uploads";

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

        private Guid? SaveFile(byte[] fileData, string path)
        {
            Guid? res = null;
            var name = Guid.NewGuid();

            WrapExceptions(() =>
                {
                    var imagePath = Path.Combine(path, SERVER_Path, name.ToString());
                    File.WriteAllBytes(imagePath, fileData);
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

        public Guid? SaveImage(System.Web.HttpPostedFileBase file)
        {
            Guid? res = null;

            if (file != null && file.ContentLength > 0 &&
                file.ContentType == "image/jpeg")
            {
                var data = new byte[file.ContentLength];
                file.InputStream.Read(data, 0, file.ContentLength);

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