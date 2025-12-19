using _34_Front_To_BackSqlConnection.Models;
using _35_ServiceLifeTimeAppSettingProduct.Utilities.Enums;

namespace _35_ServiceLifeTimeAppSettingProduct.Utilities.Extensions
{
    public static class FileValidator
    {
        public static bool CheckFileType(this IFormFile file, string type ) 
        {
            if (file.ContentType.Contains(type))
            {
                 return true;
            }


            return false;
        }

        public static bool CheckFieSize(this IFormFile file,FileSize fileSize ,int size)
        {
            switch (fileSize)
            {
                case FileSize.KB:
                    return file.Length <= size * 1024;
                case FileSize.MB:
                    return file.Length <= size * 1024 * 1024;
                case FileSize.GB:
                    return file.Length <= size * 1024 * 1024 * 1024;
            }
             

            return false;
        }

        public async static Task<string> CreateFileAsync(this IFormFile file, params string[] root)
        {
            string fileName = string.Concat(Guid.NewGuid().ToString(), file.FileName);

            string path = string.Empty;
            for (int i = 0; i < root.Length; i++)
            {
                path = Path.Combine(path, root[i]);

            }


           path = Path.Combine(path,fileName);


            using (FileStream fileStream = new(path, FileMode.Create))
            {
                  await file.CopyToAsync(fileStream);

            }

                return fileName;
        }


        public static void DeleteFile(this string fileName,params string[] root )
        {

            string path = string.Empty;
            for (int i = 0; i < root.Length; i++)
            {
                path = Path.Combine(path, root[i]);
                
            }


            path = Path.Combine(path, fileName);

            File.Delete(path);
        }
    }
}
