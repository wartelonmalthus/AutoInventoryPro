using System.ComponentModel.DataAnnotations;

namespace AutoInventoryPro.Views.Fabricator.Requests;

public class FabricatorCreateRequest
{
    [Required(ErrorMessage = "O nome do fabricante é obrigatório.")]
    [StringLength(100, ErrorMessage = "O nome do fabricante deve ter no máximo 100 caracteres.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "O país de origem é obrigatório.")]
    [StringLength(50, ErrorMessage = "O país de origem deve ter no máximo 50 caracteres.")]
    public string Country { get; set; }

    [Required(ErrorMessage = "O ano da fundação é obrigatório.")]
    [Range(1800, 2024, ErrorMessage = "O ano de fundação deve estar entre 1800 e 2024.")]
    public int YearFoundation { get; set; }

    [Required(ErrorMessage = "O website é obrigatório.")]
    [StringLength(255, ErrorMessage = "O site deve ter no máximo 255 caracteres.")]
    public string WebSite { get; set; }
}
