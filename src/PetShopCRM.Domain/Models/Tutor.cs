namespace PetShopCRM.Domain.Models;

public  class Tutor : EntityBase
{
    public string Nome { get; set; }
    public string DataNasc { get; set; }
    public string CPF { get; set; }
    public string Telefone { get; set; }
    public string Endereco { get; set; }
}