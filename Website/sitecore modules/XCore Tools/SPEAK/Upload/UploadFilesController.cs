using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Sitecore;
using Sitecore.Configuration;
using Sitecore.Controllers;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Resources.Media;
using Sitecore.SecurityModel;

namespace XCore.FileUploader.SPEAK.Upload
{
    public class UploadFilesController : Controller
    {
        public JsonResult Upload(string database = "master", string mediaFolderPath = "/sitecore/media library/Uploaded Files")
        {
            SitecoreViewModelResult result = new SitecoreViewModelResult();
            try
            {
                Database db = Factory.GetDatabase(database);
                if (db == null)
                    return result;
                foreach (string file in Request.Files)
                {
                    HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;

                    if (hpf.ContentLength == 0 || !ValidateFile(hpf, result))
                        continue;
                    string fileName = ItemUtil.ProposeValidItemName(Path.GetFileName(hpf.FileName));
                    MediaCreatorOptions md = new MediaCreatorOptions();
                    md.Destination = StringUtil.EnsurePostfix('/', StringUtil.EnsurePrefix('/', mediaFolderPath)) +
                                     fileName;
                    md.Database = db;
                    using (new SecurityDisabler())
                    {
                        Item mediaItem = MediaManager.Creator.CreateFromStream(hpf.InputStream, fileName, md);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("could not upload", ex, this);
            }

            return result;
        }

        public static bool ValidateFile(HttpPostedFileBase file, SitecoreViewModelResult result)
        {
            // add some validation
            if (true)
                return true;
        }

    }
}