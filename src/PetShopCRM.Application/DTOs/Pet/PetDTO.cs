using System.Globalization;

namespace PetShopCRM.Application.DTOs.Pet;

public record PetDTO(int Id, string Name, string Guardian, string Identifier, string Specie);
