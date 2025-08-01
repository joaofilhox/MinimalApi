using Microsoft.EntityFrameworkCore;
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

public List<Administrador> Todos(int? pagina)
    {
        var query = _dbContexto.Administradores.AsQueryable();
        int itensPorPagina = 10;
        if (pagina != null)
        {
            query = query.Skip(((int)pagina - 1) * itensPorPagina).Take(itensPorPagina);
        }
        return query.ToList();
    }

    public Administrador Criar(Administrador administrador)
    {
        _dbContexto.Administradores.Add(administrador);
        _dbContexto.SaveChanges();

        return administrador;
    }

    public Administrador? BuscarPorId(int? id)
    {
        return _dbContexto.Administradores.Find(id);
    }
}
