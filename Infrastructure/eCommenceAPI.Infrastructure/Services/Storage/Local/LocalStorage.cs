using eCommenceAPI.Application.Abstractions.Storage.Local;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace eCommenceAPI.Infrastructure.Services.Storage.Local
{
    public class LocalStorage : Storage, ILocalStorage
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public LocalStorage(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task DeleteAsync(string path, string fileName)
            => File.Delete($"{path}\\{fileName}");

        public List<string> GetFiles(string path)
        {
            DirectoryInfo directory = new(path);
            return directory.GetFiles().Select(f => f.Name).ToList();
        }

        public bool HasFile(string path, string fileName)
            => File.Exists($"{path}\\{fileName}");

        public async Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string path, IFormFileCollection files)
        {
            var uploadedPath = Path.Combine(_webHostEnvironment.WebRootPath, path);

            if (!Directory.Exists(uploadedPath))
                Directory.CreateDirectory(uploadedPath);

            List<(string fileName, string path)> datas = new();
            foreach (IFormFile file in files)
            {
                string fileNewName = await FileRenameAsync(path, file.Name, HasFile);

                await CopyFileAsync($"{uploadedPath}\\{fileNewName}", file);
                datas.Add((fileNewName, $"{path}\\{fileNewName}"));
            }

            //todo if there is any false result we should throw an Exception
            return datas;
        }

        async Task<bool> CopyFileAsync(string path, IFormFile file)
        {
            try
            {
                await using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();

                return true;
            }
            catch (Exception ex)
            {
                //todo log the Exception
                throw ex;
            }

        }
    }
}
