using System.ComponentModel.DataAnnotations;

namespace AutoInventoryPro.Views.Client.Requests;

public class ClientCreateRequest
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    [StringLength(100, MinimumLength = 4, ErrorMessage = "O nome deve ter entre 4 e 100 caracteres.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "O CPF é obrigatório.")]
    [RegularExpression(@"\d{11}", ErrorMessage = "O CPF deve conter exatamente 11 dígitos.")]
    public string CPF { get; set; }

    [Required(ErrorMessage = "O telefone é obrigatório.")]
    [StringLength(15, ErrorMessage = "O telefone deve ter no máximo 15 dígitos.")]
    [RegularExpression(@"^\d{0,15}$", ErrorMessage = "O telefone deve conter apenas números e no máximo 15 dígitos.")]
    public string Phone { get; set; }
}
