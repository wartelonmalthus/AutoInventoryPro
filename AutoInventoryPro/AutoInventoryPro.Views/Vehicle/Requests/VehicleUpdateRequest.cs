using AutoInventoryPro.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace AutoInventoryPro.Views.Vehicle.Requests;

public class VehicleUpdateRequest
{
    [StringLength(100, ErrorMessage = "O modelo do veículo deve ter no máximo 100 caracteres.")]
    public string? VehicleModel { get; set; }
    [Range(1886, 2024, ErrorMessage = "O ano de fabricação deve estar entre 1886 e 2024.")]
    public int? YearManufacture { get; set; }
    [Range(0, (double)decimal.MaxValue, ErrorMessage = "O preço deve ser um valor positivo.")]
    public decimal? Price { get; set; }
    public int? IdFabricator { get; set; }
    public EVehicleType? VehicleType { get; set; }
    [StringLength(250, ErrorMessage = "A descrição deve ter no máximo 250 caracteres.")]
    public string? Description { get; set; }
}
