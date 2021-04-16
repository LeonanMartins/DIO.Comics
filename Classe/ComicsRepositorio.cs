using DIO.Comics.Interface;
using System.Collections.Generic;


namespace DIO.Comics
{
    class ComicsRepositorio : IRepositorio<Comics>
    {
        private List<Comics> listaComics = new List<Comics>();
        public void Atualizar(int id, Comics objeto)
        {
         listaComics[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaComics[id].Excluir();
            //implemento envio de e-mail
        }

        public void Insere(Comics objeto)
        {
            listaComics.Add(objeto);
        }

        public List<Comics> Lista()
        {
            return listaComics;
        }

        public int ProximoId()
        {
            return listaComics.Count;
        }

        public Comics RetornaPorId(int id)
        {
            return listaComics[id];
        }
    }
}
