using Microsoft.Identity.Client;
using PetShopCRM.Web.Services.Interfaces;

namespace PetShopCRM.Web.Services;

public class Upload :IUpload
{
    public void SavePhotoProfile( IFormFile file, int id)
    {
        if (file != null)
        {
            var directory = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\Upload\\Profile\\{id}");

            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

            using (var stream = new FileStream(Path.Combine(directory, Path.GetFileName(file.FileName)), FileMode.Create))
            {
                file.CopyTo(stream);
            }
        }       
    }

    public void SavePhotoPet(IFormFile file, int id)
    {
        if (file != null)
        {
            var directory = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\Upload\\Pet\\{id}");

            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

            using (var stream = new FileStream(Path.Combine(directory, Path.GetFileName(file.FileName)), FileMode.Create))
            {
                file.CopyTo(stream);
            }
        }
    }

    public void Save(string directory, IFormFile file, int id)
    {
        if (file != null)

            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

            using (var stream = new FileStream(Path.Combine(directory, Path.GetFileName(file.FileName)), FileMode.Create))
            {
                file.CopyTo(stream);
            }
        }
    public string GetNameFile(IFormFile file) => file != null ? Path.GetFileName(file.FileName) : string.Empty;
}
