using System;
using System.Collections;

namespace ObjectOrientedCRUD
{
    public class Equipamentos
    {
        private string nomeEq;
        private double precoEq;
        private string numSerieEq;
        private DateTime dataFabEq;
        private string fabEq;

        public static Equipamentos[] equipamentos = new Equipamentos[0];

        public Equipamentos()
        {

        }

        public Equipamentos(string nomeEq, double precoEq, string numSerieEq, DateTime dataFabEq, string fabEq)
        {
            this.nomeEq = nomeEq;
            this.precoEq = precoEq;
            this.numSerieEq = numSerieEq;
            this.dataFabEq = dataFabEq;
            this.fabEq = fabEq;
        }

        #region Setters and Getters
        public string NomeEq { get => nomeEq; set => nomeEq = value; }
        public double PrecoEq { get => precoEq; set => precoEq = value; }
        public string NumSerieEq { get => numSerieEq; set => numSerieEq = value; }
        public DateTime DataFabEq { get => dataFabEq; set => dataFabEq = value; }
        public string FabricanteEq { get => fabEq; set => fabEq = value; }
        #endregion

        public void MostrarInformacoes()
        {
            Console.Write("{0,-20} | {1,-55} | {2,-35}", nomeEq, numSerieEq, fabEq);

            Console.WriteLine();
        }

        public static Equipamentos RegistrarEquipamento()
        {
            Console.Clear();

            string nome = "";
            bool nomeInvalido;
            do
            {
                nomeInvalido = false;
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
            double preco = Convert.ToDouble(Console.ReadLine());

            Console.Write("Digite o número do equipamento: ");
            string numSerie = Console.ReadLine();

            Console.Write("Digite a data de fabricação do equipamento: ");
            DateTime dataFab = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Digite o fabricante do equipamento: ");
            string fab = Console.ReadLine();

            Equipamentos equipamento = new Equipamentos(nome, preco, numSerie, dataFab, fab);
            Console.Clear();
            return equipamento;
        }

        public static void EditarEquipamento()
        {
            Console.Clear();

            VisualizarEquipamentos();

            Console.WriteLine();

            Console.Write("Digite o número de série do equipamento que deseja editar: ");
            string numSerieEqSelecionado = Console.ReadLine();

            for (int i = 0; i < equipamentos.Length; i++)
            {
                if (equipamentos[i].numSerieEq == numSerieEqSelecionado)
                {
                    equipamentos[i] = RegistrarEquipamento();
                }
            }
        }

        public static void ExcluirEquipamento()
        {
            Console.Clear();

            VisualizarEquipamentos();

            Console.WriteLine();

            Console.Write("Digite o número de série do equipamento que deseja excluir: ");
            string numSerieEqSelecionado = Console.ReadLine();
            int equipamentosIndice = 0;

            for (int i = 0; i < equipamentos.Length; i++)
            {
                if (equipamentos[i].numSerieEq == numSerieEqSelecionado)
                {
                    equipamentosIndice = i;
                    break;
                }
            }

            if (equipamentosIndice < equipamentos.Length && equipamentosIndice >= 0)
            {
                for (int i = equipamentosIndice + 1; i < equipamentos.Length; i++)
                {
                    equipamentos[i - 1] = equipamentos[i];

                }
                Array.Resize(ref equipamentos, equipamentos.Length - 1);
            }
        }

        public static void VisualizarEquipamentos()
        {
            Console.Clear();

            //pesquisa no google: align text horizontally in console application c#

            //https://www.csharp-examples.net/align-string-with-spaces/

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("{0,-20} | {1,-55} | {2,-35}", "Nome", "Numero de Série", "Fabricante");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();

            int numeroEquipamentosCadastrados = 0;

            for (int i = 0; i < equipamentos.Length; i++)
            {
                equipamentos[i].MostrarInformacoes();
                Console.WriteLine();

                numeroEquipamentosCadastrados++;

            }

            if (numeroEquipamentosCadastrados == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Nenhum equipamento cadastrado!");
                Console.ResetColor();
            }

            Console.ReadLine();
        }
    }
}