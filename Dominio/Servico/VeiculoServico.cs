using Microsoft.EntityFrameworkCore;
using Minimal_Api.Dominio.Entidades;
using Minimal_Api.Dominio.Interfaces;
using Minimal_Api.Infraestrutura.Db;

namespace Minimal_Api.Dominio.Servico;

public class VeiculoServico : IVeiculoServico
{
    private readonly DbContexto _dbContexto;
    public VeiculoServico(DbContexto dbContexto)
    {
        _dbContexto = dbContexto;
    }

    public List<Veiculo> Todos(int? pagina = 1, string? nome = null, string? marca = null)
    {
        var query = _dbContexto.Veiculos.AsQueryable();
        if (!string.IsNullOrEmpty(nome))
        {
            query = query.Where(v => EF.Functions.Like(v.Nome.ToLower(), $"%{nome}%"));
        }

        int itensPorPagina = 10;
        
        if(pagina != null)
        {
            query = query.Skip(((int)pagina - 1) * itensPorPagina).Take(itensPorPagina);
        }
            return query.ToList();
    }

    public Veiculo? BuscarPorId(int id)
    {
        return _dbContexto.Veiculos.Find(id);
    }

    public void Criar(Veiculo veiculo)
    {
        _dbContexto.Veiculos.Add(veiculo);
        _dbContexto.SaveChanges();
    }

    public void Atualizar(Veiculo veiculo)
    {
        _dbContexto.Veiculos.Update(veiculo);
        _dbContexto.SaveChanges();
    }

    public void Excluir(Veiculo veiculo)
    {
        _dbContexto.Veiculos.Remove(veiculo);
        _dbContexto.SaveChanges();
    }

}
