using System;
namespace dio_dotnet_poo_lab_2
{
    class Program
    {
        static animeRepositorio repositorio = new animeRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						Listaranime();
						break;
					case "2":
						Inseriranime();
						break;
					case "3":
						Atualizaranime();
						break;
					case "4":
						Excluiranime();
						break;
					case "5":
						Visualizaranime();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void Excluiranime()
		{
			Console.Write("Digite o id do anime: ");
			int indiceanime = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceanime);
		}

        private static void Visualizaranime()
		{
			Console.Write("Digite o id do anime: ");
			int indiceanime = int.Parse(Console.ReadLine());

			var anime = repositorio.RetornaPorId(indiceanime);

			Console.WriteLine(anime);
		}

        private static void Atualizaranime()
		{
			Console.Write("Digite o id do anime: ");
			int indiceanime = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Títulodo anime: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início do anime: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do anime: ");
			string entradaDescricao = Console.ReadLine();

			anime atualizaanime = new anime(id: indiceanime,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceanime, atualizaanime);
		}
        private static void Listaranimes()
		{
			Console.WriteLine("Listar animes");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum animes cadastrados.");
				return;
			}

			foreach (var anime in lista)
			{
                var excluido = anime.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", anime.retornaId(), anime.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void Inseriranime()
		{
			Console.WriteLine("Inserir novo anime");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do anime: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início do anime: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do anime: ");
			string entradaDescricao = Console.ReadLine();

			anime novoanime = new anime(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novoanime);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("caio animes a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar animes");
			Console.WriteLine("2- Inserir novo anime");
			Console.WriteLine("3- Atualizar anime");
			Console.WriteLine("4- Excluir anime");
			Console.WriteLine("5- Visualizar anime");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
