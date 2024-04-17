namespace PetShopCRM.Web.Services.Interfaces;

public interface IUpload
{    
    void SavePhotoProfile(IFormFile file, int id);
    void Save(string directory, IFormFile file, int id);
    string GetNameFile(IFormFile file);
}