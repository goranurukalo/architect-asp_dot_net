using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WebSiteASP.Helpers
{
    public class UploadImageDb
    {
        public bool IsUploaded { get; set; }
        public string SmallPictureUrl { get; set; }
        public string BigPictureUrl { get; set; }
        public string ErrorMessage { get; set; }
    }
    public class UploadFile
    {
        public static string UploadPath = @"~\Upload\";
        public static UploadImageDb UploadImage(FileUpload uploadField, string path, bool small = false)
        {
            UploadImageDb result = new UploadImageDb();

            if (uploadField.HasFile)
            {


                if ("image/jpeg" == uploadField.PostedFile.ContentType || "image/jpg" == uploadField.PostedFile.ContentType || "image/png" == uploadField.PostedFile.ContentType)
                {
                    string newFileName = String.Format("{0}_{1}", DateTime.Now.ToString("ddMMyyyy"), uploadField.PostedFile.FileName);
                    try
                    {
                        uploadField.SaveAs(path + newFileName);

                        if (small)
                        {
                            System.Drawing.Image image = System.Drawing.Image.FromFile(path + newFileName);
                            int newwidthimg = 200;
                            float AspectRatio = (float)image.Size.Width / (float)image.Size.Height;
                            int newHeight = Convert.ToInt32(newwidthimg / AspectRatio);
                            Bitmap thumbnailBitmap = new Bitmap(newwidthimg, newHeight);
                            Graphics thumbnailGraph = Graphics.FromImage(thumbnailBitmap);
                            thumbnailGraph.CompositingQuality = CompositingQuality.HighQuality;
                            thumbnailGraph.SmoothingMode = SmoothingMode.HighQuality;
                            thumbnailGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            var imageRectangle = new Rectangle(0, 0, newwidthimg, newHeight);
                            thumbnailGraph.DrawImage(image, imageRectangle);
                            thumbnailBitmap.Save(path + "min_" + newFileName, ImageFormat.Jpeg);
                            thumbnailGraph.Dispose();
                            thumbnailBitmap.Dispose();
                            image.Dispose();


                            result.SmallPictureUrl = UploadPath +"min_"+ newFileName;
                        }

                        result.IsUploaded = true;
                        result.BigPictureUrl = UploadPath + newFileName;
                        result.ErrorMessage = "Data is inserted";
                    }
                    catch (Exception)
                    {
                        result.IsUploaded = false;
                        result.ErrorMessage = "File is not uploaded.";
                    }
                }
                else
                {
                    result.IsUploaded = false;
                    result.ErrorMessage = "Uploaded file is not image.";
                }
            }
            else
            {
                result.IsUploaded = false;
                result.ErrorMessage = "Image is not sent to the server.";
            }

            return result;
        }
    }
}