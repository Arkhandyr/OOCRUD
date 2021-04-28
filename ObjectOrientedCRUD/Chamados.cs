using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedCRUD
{
    class Chamados
    {
        private string tituloCh;
        private string descricaoCh;
        private DateTime dataAbertCh;
        private string equipCh;

        public static Chamados[] chamados = new Chamados[0];

        public Chamados()
        {

        }

        public Chamados(string tituloCh, string descricaoCh, DateTime dataAbertCh, string equipCh)
        {
            this.tituloCh = tituloCh;
            this.descricaoCh = descricaoCh;
            this.dataAbertCh = dataAbertCh;
            this.equipCh = equipCh;
        }

        #region Setters and Getters
        public string TituloCh { get => tituloCh; set => tituloCh = value; }
        public string DescricaoCh { get => descricaoCh; set => descricaoCh = value; }
        public DateTime DataAbertCh { get => dataAbertCh; set => dataAbertCh = value; }
        public string EquipCh { get => equipCh; set => equipCh = value; }
        #endregion

        public void MostrarInformacoes()
        {
            Console.Write("{0,-20} | {1,-55} | {2,-35}", tituloCh, Math.Round(DateTime.Now.Subtract(DataAbertCh).TotalDays, 0, MidpointRounding.AwayFromZero) + " dias", equipCh);

            Console.WriteLine();
        }

        public static Chamados RegistrarChamado()
        {
            Console.Clear();

            Console.Write("Digite o titulo do chamado: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite a descrição do chamado: ");
            string descricao = Console.ReadLine();

            Console.Write("Digite a data de abertura do chamado: ");
            DateTime dataAbertura = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Digite o equipamento relacionado ao chamado: ");
            string equip = Console.ReadLine();

            Chamados chamado = new Chamados(titulo, descricao, dataAbertura, equip);
            Console.Clear();
            return chamado;
        }

        public static void EditarChamado()
        {
            Console.Clear();

            VisualizarChamados();

            Console.WriteLine();

            Console.Write("Digite o título do chamado que deseja editar: ");
            string tituloChSelecionado = Console.ReadLine();

            for (int i = 0; i < chamados.Length; i++)
            {
                if (chamados[i].tituloCh == tituloChSelecionado)
                {
                    chamados[i] = RegistrarChamado();
                }
            }
        }

        public static void ExcluirChamado()
        {
            Console.Clear();

            VisualizarChamados();

            Console.WriteLine();

            Console.Write("Digite o título do chamado que deseja editar: ");
            string tituloChSelecionado = Console.ReadLine();
            int chamadosIndice = 0;

            for (int i = 0; i < chamados.Length; i++)
            {
                if (chamados[i].tituloCh == tituloChSelecionado)
                {
                    chamadosIndice = i;
                    break;
                }
            }

            if (chamadosIndice < chamados.Length && chamadosIndice >= 0)
            {
                for (int i = chamadosIndice + 1; i < chamados.Length; i++)
                {
                    chamados[i - 1] = chamados[i];

                }
                Array.Resize(ref chamados, chamados.Length - 1);
            }
        }

        public static void VisualizarChamados()
        {
            Console.Clear();

            //pesquisa no google: align text horizontally in console application c#

            //https://www.csharp-examples.net/align-string-with-spaces/

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("{0,-20} | {1,-55} | {2,-35}", "Título", "Dias em aberto", "Equipamento");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();

            int numeroChamadosEmAberto = 0;

            for (int i = 0; i < chamados.Length; i++)
            {
                chamados[i].MostrarInformacoes();
                Console.WriteLine();

                numeroChamadosEmAberto++;

            }

            if (numeroChamadosEmAberto == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Nenhum chamado em aberto!");
                Console.ResetColor();
            }

            Console.ReadLine();
        }
    }
}