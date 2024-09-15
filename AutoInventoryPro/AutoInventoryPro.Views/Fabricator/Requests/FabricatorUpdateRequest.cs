using System.ComponentModel.DataAnnotations;

namespace AutoInventoryPro.Views.Fabricator.Requests;

public class FabricatorUpdateRequest
{
    [StringLength(100, ErrorMessage = "O nome do fabricante deve ter no máximo 100 caracteres.")]
    public string? Name { get; set; }
    [StringLength(50, ErrorMessage = "O país de origem deve ter no máximo 50 caracteres.")]
    public string? Country { get; set; }
    [Range(1800, 2024, ErrorMessage = "O ano de fundação deve estar entre 1800 e 2024.")]
    public int? YearFoundation { get; set; }
    [Url(ErrorMessage = "O site deve ser uma URL válida.")]
    [StringLength(255, ErrorMessage = "O site deve ter no máximo 255 caracteres.")]
    public string? WebSite { get; set; }
}
