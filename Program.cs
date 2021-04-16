using System;

namespace DIO.Comics
{
	class Program
	{
		static ComicsRepositorio repositorio = new ComicsRepositorio();
		static void Main(string[] args)
		{
			string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarComics();
						break;
					case "2":
						InserirComics();
						break;
					case "3":
						AtualizarComics();
						break;
					case "4":
						ExcluirComics();
						break;
					case "5":
						VisualizarComics();
						break;
					case "c":
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

         private static void ExcluirComics()
		{
			Console.Write("Digite o id do Comic: ");
			int indiceComics = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceComics);
		}

		private static void VisualizarComics()
		{
			Console.Write("Digite o id do Comicbook: ");
			int indiceComics = int.Parse(Console.ReadLine());

			var comics = repositorio.RetornaPorId(indiceComics);

			Console.WriteLine(comics);
		}

		private static void AtualizarComics()
		{
			Console.Write("Digite o id do Comicbook: ");
			int indiceComics = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Editora)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Editora), i));
			}
			Console.Write("Digite a editora entre as opções acima: ");
			int entradaEditora = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Comic: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início do Comic: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Comic: ");
			string entradaDescricao = Console.ReadLine();

			Comics atualizaComics = new Comics(id: indiceComics,
										editora: (Editora)entradaEditora,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualizar(indiceComics, atualizaComics);
		}
		private static void ListarComics()
		{
			Console.WriteLine("Listar Comics");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum Comic cadastrado.");
				return;
			}

			foreach (var comics in lista)
			{
				var excluido = comics.retornaExcluido();

				Console.WriteLine("#ID {0}: - {1} {2}", comics.retornaId(), comics.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

		private static void InserirComics()
		{
			Console.WriteLine("Inserir novo comic");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Editora)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Editora), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaEditora = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Comic: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início do Comic: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Comic: ");
			string entradaDescricao = Console.ReadLine();

			Comics novaComics = new Comics(id: repositorio.ProximoId(),
										editora: (Editora)entradaEditora,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novaComics);
		}

		private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Comics a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar Comics");
			Console.WriteLine("2- Inserir novo Comic");
			Console.WriteLine("3- Atualizar Comic");
			Console.WriteLine("4- Excluir Comic");
			Console.WriteLine("5- Visualizar Comic");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
	}
}
