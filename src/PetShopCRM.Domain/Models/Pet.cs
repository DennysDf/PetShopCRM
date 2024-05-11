using System.ComponentModel;

namespace PetShopCRM.Domain.Models;

public class Pet : EntityBase
{
    public string Name { get; set; }
    public int GuardianId { get; set; }
    public string Identifier { get; set; }
    public int SpecieId { get; set; }
    public string Sexy { get; set; }   
    public string Color { get; set; }  
    public string Weight { get; set; }
    public string Age { get; set; }
    public string Breed { get; set; }
    public string Obs { get; set; }
    public bool? Spayed { get; set; }
    public string UrlPhoto { get; set; }
    public DateTime? UpdatedDateImg { get; set; }

    public virtual Guardian Guardian { get; set; }
    public virtual Specie Specie { get; set; }

    public virtual ICollection<Payment> Payments { get; set; }
}
