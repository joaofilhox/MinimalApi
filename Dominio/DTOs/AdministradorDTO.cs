using Minimal_Api.Dominio.Enuns;

namespace Minimal_Api.Dominio.DTOs;

public class AdministradorDTO
{
    public string Email { get; set; } = default!;
    public string Senha { get; set; } = default!;
    public Perfil Perfil { get; set; } = default!;

}
