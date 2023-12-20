using System.ComponentModel.DataAnnotations;

namespace Desafio.Api.Entities;

public class CityModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo cidade é obriatório!")]
    [StringLength(50, ErrorMessage = "Número máximo de caracteres ultrapassado!")]
    [Display(Name = "Cidade")]
    public string City { get; set; } = "";

    [Required(ErrorMessage = "O campo Estado é obriatório!")]
    [StringLength(2, ErrorMessage = "Número máximo de caracteres ultrapassado!")]
    [Display(Name = "Estado")]
    public string State { get; set; } = "";

    public CityModel()
    {

    }
}