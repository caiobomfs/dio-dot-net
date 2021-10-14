using System;
using System.Collections.Generic;
using dio_dotnet_poo_lab_2.Interfaces;

namespace dio_dotnet_poo_lab_2.Classes
{
    public class animeRepositorio : IRepositorio<anime>
	{
        private List<anime> listaanime = new List<anime>();
		public void Atualiza(int id, anime objeto)
		{
			listaanime[id] = objeto;
		}

		public void Exclui(int id)
		{
			listaanime[id].Excluir();
		}

		public void Insere(anime objeto)
		{
			listaanime.Add(objeto);
		}

		public List<anime> Lista()
		{
			return listaanime;
		}

		public int ProximoId()
		{
			return listaanime.Count;
		}

		public anime RetornaPorId(int id)
		{
			return listaanime[id];
		}
	}
}