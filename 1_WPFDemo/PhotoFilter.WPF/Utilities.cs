using System;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Net;

namespace PhotoFilter.WPF
{
    public static class Utilities
    {
        static string PhotoPathForUser = @"\Pictures";
        static string ServerUrl = "http://photoimageserver.azurewebsites.net";

        public static string[] ValidFileExtensions = new string[] { "jpg", "png" };

        public static string[] GetPictureList()
        {
            return Directory.GetFiles(PhotoPath);
        }

        public static async Task GetImagesFromCloud()
        {
            //Get images list from server
            var client = new WebClient();
            var response = await client.DownloadStringTaskAsync(ServerUrl + "/api/Images");
            dynamic[] pictureList = JsonConvert.DeserializeObject<dynamic[]>(response);

            if (!Directory.Exists(PhotoPath))
            {
                Directory.CreateDirectory(PhotoPath);
            }

            //Download thumbnails
            //var downloadTasks = new List<Task>();
            foreach (var img in pictureList)
            {
                string filename = img.Thumbnail;
                string imageUrl = ServerUrl + "/Images/" + filename;
                await DownloadImageAsync(new Uri(imageUrl), PhotoPath, "cloud_" + filename);
                //downloadTasks.Add(DownloadImageAsync(new Uri(imageUrl), PhotoPath, "async_" + filename));
            }
            //await Task.WhenAll(downloadTasks);
        }

        private static async Task DownloadImageAsync(Uri uri, string cloudPhotoPath, string filename)
        {
            var folderInfo = new DirectoryInfo(cloudPhotoPath);
            var webclient = new WebClient();
            await webclient.DownloadFileTaskAsync(uri, cloudPhotoPath + @"\" + filename);
        }

        public static bool IsValidImageFile(string file)
        {

            var fileParts = file.Split('.');
            if (fileParts.Length < 2)
            {
                return false;
            }

            var extension = fileParts[fileParts.Length - 1];

            if (ValidFileExtensions.Contains(extension))
            {
                return true;
            }

            return false;
        }

        #region PrivateAPIs
        static string CurrentUser
        {
            get
            {
                string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                if (userName.Contains("\\"))
                {
                    string[] strs = userName.Split('\\');
                    userName = strs[1];
                }
                return userName;
            }
        }

        static string PhotoPath
        {
            get
            {
                string photoPath = @"C:\users\" + Utilities.CurrentUser + PhotoPathForUser;

                return photoPath;
            }
        }
        #endregion

    }
}
