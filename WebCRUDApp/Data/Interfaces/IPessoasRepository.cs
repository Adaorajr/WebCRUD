using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebCRUDApp.Models.Entidades;

namespace WebCRUDApp.Data.Interfaces
{
    public interface IPessoasRepository
    {
        public IEnumerable<FuncViewModel> ListaFunc();
        public void Salvar(Pessoas p);
        public object Editar(int id);
        public void Editar(int id, Pessoas p);
        public void Deletar(int id);
        public FuncViewModel Detalhes(int id);


    }
}
