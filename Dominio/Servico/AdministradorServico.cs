using Minimal_Api.Dominio.DTOs;
using Minimal_Api.Dominio.Entidades;
using Minimal_Api.Dominio.Interfaces;
using Minimal_Api.Infraestrutura.Db;

namespace Minimal_Api.Dominio.Servico;

public class AdministradorServico : IAdministradorServico
{
    private readonly DbContexto _dbContexto;
    public AdministradorServico(DbContexto dbContexto)
    {
        _dbContexto = dbContexto;
    }
    public Administrador? Login(LoginDTO loginDTO)
    {
        var admin = _dbContexto.Administradores
            .Where(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha).FirstOrDefault();
        return admin;
    }
}
