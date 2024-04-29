namespace PetShopCRM.Infrastructure.DTOs.Report;

public record PetDTO(int Id, string Name, string Guardian, string Identifier, string Specie);

public record PetSpecieDTO(string Name, int Index);
