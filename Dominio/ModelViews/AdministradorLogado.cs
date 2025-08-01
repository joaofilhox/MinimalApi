using System.ComponentModel.DataAnnotations;

namespace Minimal_Api.Dominio.ModelViews;

public class AdministradorLogado
{
    public string Email { get; set; } = default!;
    public string Perfil { get; set; } = default!;
    public string Token { get; set; } = default!;
}
