
using Microsoft.AspNetCore.Hosting;
using SoccerShoesShop.Common;

namespace SoccerShoesShop.Areas.Admin.Services
{
    public class ImageService : IImageService
    {
        private readonly IWebHostEnvironment _environment;

        public ImageService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<string> UploadImageAsync(IFormFile image)
        {
            if (image == null || image.Length == 0) throw new ArgumentException("No file provided.");

            // Kiem tra file hop le
            var type = new[] { "jpg", "png", "jpeg", "gif" };
            var fileExt = Path.GetExtension(image.FileName).Substring(1).ToLower();
            if (!type.Contains(fileExt)) throw new ArgumentException("Invalid file type. Only JPG, PNG, JPEG and GIF are allowed.");

            //Tao ten file va luu duong dan file
            var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var fileName = Path.GetFileName(image.FileName);
            var filePath = Path.Combine(uploadsFolder, fileName);

            if (File.Exists(filePath))
                return $"/uploads/{fileName}";
            // Luu file vao thu muc
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }
            return $"/uploads/{fileName}";
        }
    }
}
