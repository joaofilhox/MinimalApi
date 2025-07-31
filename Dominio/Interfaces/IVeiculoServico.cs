using Minimal_Api.Dominio.Entidades;

namespace Minimal_Api.Dominio.Interfaces;

public interface IVeiculoServico
{
    List<Veiculo> Todos(int pagina = 1, string? nome = null, string? marca = null);
    Veiculo? BuscarPorId(int id);
    void Criar(Veiculo veiculo);
    void Atualizar(Veiculo veiculo);
    void Excluir(Veiculo veiculo);

}
