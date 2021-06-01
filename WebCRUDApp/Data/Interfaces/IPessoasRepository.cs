using System.Collections.Generic;
using System.Linq;
using WebCRUDApp.Models.Entidades;
using WebCRUDApp.ViewModel;

namespace WebCRUDApp.Data.Interfaces
{
    public interface IPessoasRepository
    {
        public IEnumerable<FuncViewModel> ListaFunc();
        //public IEnumerable<FuncViewModel> nomePessoa(string search);
        public void Salvar(Pessoas p);
        public Pessoas Editar(int id);
        public void Editar(Pessoas p);
        public void Deletar(int id);
        public FuncViewModel Detalhes(int id);
        public IEnumerable<Cargo> listaCargos();


    }
}
