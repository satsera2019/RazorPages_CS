namespace RazorPages.Services
{
    public interface IFileService
    {
        Tuple<int , string> SaveImage(IFormFile filePath);

        bool DeleteImage(string imageFileName);
    }
}
