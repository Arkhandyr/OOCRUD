using System;

public class Equipamentos
{
	private int idEq;
	private string nomeEq;
	private double precoEq;
    private string numSerieEq;
	private DateTime dataFabEq;
	private string fabEq;

    //const int CAPACIDADE_REGISTROS = 100;
    //static int[] idsEquipamento = new int[CAPACIDADE_REGISTROS];
	ArrayList listaIDEq = new ArrayList();

    private static int IdEquipamento;

    public Equipamentos(int idEq, string nomeEq, double precoEq, string numSerieEq,  string fabEq, DateTime dataFabEq)
	{
		this.idEq = idEq;
		this.nomeEq = nomeEq;
		this.precoEq = precoEq;
        this.numSerieEq = numSerieEq;
		this.dataFabEq = dataFabEq
		this.fabEq = fabEq;
	}

    private static int ObterPosicaoParaEquipamentos(int idEquipamentoSelecionado)
    {
        int posicao = 0;

        for (int i = 0; i < idsEquipamento.Length; i++)
        {
            if (idEquipamentoSelecionado == 0 && listaIDEq[i] == 0) //inserindo...
            {
                IdEquipamento++;
                posicao = i;
                break;
            }
            else if (idEquipamentoSelecionado == listaIDEq[i]) //editando...
            {
                posicao = i;
                break;
            }
        }

        return posicao;
    }

    private static void RegistrarEquipamento(int idEquipamentoSelecionado)
    {
        Console.Clear();

        int posicao = ObterPosicaoParaEquipamentos(idEquipamentoSelecionado);

        string nome = "";
        bool nomeInvalido = false;
        do
        {
            Console.Write("Digite o nome do equipamento: ");
            nome = Console.ReadLine();
            if (nome.Length < 6)
            {
                nomeInvalido = true;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nome inválido. No mínimo 6 caracteres");
                Console.ResetColor(); ;
            }

        } while (nomeInvalido);


        Console.Write("Digite o preço do equipamento: ");
        this.preco = Convert.ToDouble(Console.ReadLine());

        Console.Write("Digite o número do equipamento: ");
        this.numeroSerie = Console.ReadLine();

        Console.Write("Digite a data de fabricação do equipamento: ");
        this.dataFabEq = Convert.ToDateTime(Console.ReadLine());

        Console.Write("Digite o fabricante do equipamento: ");
        this.fabEq = Console.ReadLine();

        idsEquipamento[posicao] = IdEquipamento;
        nomesEquipamento[posicao] = nome;
        precosEquipamento[posicao] = preco;
        numerosSerieEquipamento[posicao] = numeroSerie;
        datasFabricacaoEquipamento[posicao] = dataFabricacao;
        fabricantesEquipamento[posicao] = fabricante;

    }

    private static void EditarEquipamento()
    {
        Console.Clear();

        VisualizarEquipamentos();

        Console.WriteLine();

        Console.Write("Digite o número do equipamento que deseja editar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        RegistrarEquipamento(idSelecionado);
    }

    private static void ExcluirEquipamento()
    {
        Console.Clear();

        VisualizarEquipamentos();

        Console.WriteLine();

        Console.Write("Digite o número do equipamento que deseja excluir: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < idsEquipamento.Length; i++)
        {
            if (idsEquipamento[i] == idSelecionado)
            {
                idsEquipamento[i] = 0;
                nomesEquipamento[i] = null;
                precosEquipamento[i] = 0;
                numerosSerieEquipamento[i] = null;
                datasFabricacaoEquipamento[i] = DateTime.MinValue;
                fabricantesEquipamento[i] = null;

                break;
            }
        }
    }

    private static void VisualizarEquipamentos()
    {
        Console.Clear();

        //pesquisa no google: align text horizontally in console application c#

        //https://www.csharp-examples.net/align-string-with-spaces/

        Console.ForegroundColor = ConsoleColor.Red;

        Console.WriteLine("{0,-10} | {1,-55} | {2,-35}", "Id", "Nome", "Fabricante");

        Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

        Console.ResetColor();

        int numeroEquipamentosCadastrados = 0;

        for (int i = 0; i < idsEquipamento.Length; i++)
        {
            if (idsEquipamento[i] > 0)
            {
                Console.Write("{0,-10} | {1,-55} | {2,-35}",
                   idsEquipamento[i], nomesEquipamento[i], fabricantesEquipamento[i]);

                Console.WriteLine();

                numeroEquipamentosCadastrados++;
            }
        }

        if (numeroEquipamentosCadastrados == 0)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Nenhum equipmaneto cadastrado!");
            Console.ResetColor();
        }

        Console.ReadLine();
    }
}
