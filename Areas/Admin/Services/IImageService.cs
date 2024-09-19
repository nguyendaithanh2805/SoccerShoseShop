namespace SoccerShoesShop.Areas.Admin.Services
{
    public interface IImageService
    {
        Task<string> UploadImageAsync(IFormFile image);
    }
}
