using PetShopCRM.Domain.Enums;

namespace PetShopCRM.Web.Models.User;
public class AddUserVM
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public UserType Type { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string CPF { get; set; }

    public static List<AddUserVM> ToList(List<Domain.Models.User> listUsers) => listUsers.Select(users => new AddUserVM {
        CPF = users.CPF,
        Name = users.Name,
        Type = users.Type,
        Email = users.Email,
        Phone = users.Phone,
        Id = users.Id,
        Login = users.Login,
        Password = users.Password        
    }).ToList();

    public AddUserVM ToVM(Domain.Models.User model) => new() { Id = model.Id, Login = model.Login, Password = model.Password, Name = model.Name, Type = model.Type, Email = model.Email, Phone = model.Phone, CPF = model.CPF };


}
