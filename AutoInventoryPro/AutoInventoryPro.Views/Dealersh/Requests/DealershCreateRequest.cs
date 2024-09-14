using System.ComponentModel.DataAnnotations;

namespace AutoInventoryPro.Views.Dealersh.Requests;

public class DealershCreateRequest
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    [StringLength(100, MinimumLength = 4, ErrorMessage = "O nome deve ter entre 4 e 100 caracteres.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "O endereço é obrigatório.")]
    [StringLength(255, ErrorMessage = "O endereço pode ter no máximo 255 caracteres.")]
    public string Address { get; set; }

    [Required(ErrorMessage = "A cidade é obrigatória.")]
    [StringLength(50, ErrorMessage = "A cidade pode ter no máximo 50 caracteres.")]
    public string City { get; set; }

    [Required(ErrorMessage = "A região é obrigatória.")]
    [StringLength(50, ErrorMessage = "A região pode ter no máximo 50 caracteres.")]
    public string Region { get; set; }

    [Required(ErrorMessage = "O CEP é obrigatório.")]
    [RegularExpression(@"^\d{5}-?\d{3}$", ErrorMessage = "O CEP deve estar no formato 00000-000 ou 00000000.")]
    public string PostalCode { get; set; }

    [Required(ErrorMessage = "O email é obrigatório.")]
    [EmailAddress(ErrorMessage = "O email deve estar em um formato válido.")]
    [StringLength(100, ErrorMessage = "O email pode ter no máximo 100 caracteres.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O telefone é obrigatório.")]
    [StringLength(15, ErrorMessage = "O telefone deve ter no máximo 15 dígitos.")]
    [RegularExpression(@"^\d{0,15}$", ErrorMessage = "O telefone deve conter apenas números.")]
    public string Phone { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "A capacidade máxima de veículos deve ser um número positivo.")]
    public int MaximumCapacityVehicles { get; set; }
}
