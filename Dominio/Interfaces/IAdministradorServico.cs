using Minimal_Api.Dominio.DTOs;
using Minimal_Api.Dominio.Entidades;

namespace Minimal_Api.Dominio.Interfaces;

public interface IAdministradorServico
{
    Administrador? Login(LoginDTO loginDTO);

    List<Administrador> Todos(int? pagina);
    Administrador Criar(Administrador administrador);
    Administrador? BuscarPorId(int? id);



}
