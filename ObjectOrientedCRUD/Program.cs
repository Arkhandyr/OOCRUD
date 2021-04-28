using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ObjectOrientedCRUD.Equipamentos;
using static ObjectOrientedCRUD.Chamados;

namespace ObjectOrientedCRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            PopularAplicacao(9);

            while (true)
            {
                string opcao = ObterOpcao();

                if (opcao.Equals("s", StringComparison.OrdinalIgnoreCase))
                    break;

                if (opcao == "1")
                {
                    string opcaoCadastroEquipamentos = ObterOpcaoCadastroEquipamentos();

                    if (opcaoCadastroEquipamentos.Equals("s", StringComparison.OrdinalIgnoreCase))
                        break;

                    if (opcaoCadastroEquipamentos == "1")
                    {
                        Array.Resize(ref equipamentos, equipamentos.Length + 1);
                        equipamentos[equipamentos.Length - 1] = RegistrarEquipamento();
                    }

                    else if (opcaoCadastroEquipamentos == "2")
                        EditarEquipamento();

                    else if (opcaoCadastroEquipamentos == "3")
                        ExcluirEquipamento();

                    else if (opcaoCadastroEquipamentos == "4")
                        VisualizarEquipamentos();

                }
                else if (opcao == "2")
                {
                    string opcaoControleChamados = ObterOpcaoControleChamados();

                    if (opcaoControleChamados.Equals("s", StringComparison.OrdinalIgnoreCase))
                        break;

                    if (opcaoControleChamados == "1")
                    {
                        Array.Resize(ref chamados, chamados.Length + 1);
                        chamados[chamados.Length - 1] = RegistrarChamado();
                    }

                    else if (opcaoControleChamados == "2")
                        EditarChamado();

                    else if (opcaoControleChamados == "3")
                        ExcluirChamado();

                    else if (opcaoControleChamados == "4")
                        VisualizarChamados();

                }
                
                Console.Clear();
            }
        }

        private static string ObterOpcao()
        {
            //CRUD (Create, Retrieve, Update, Delete)
            Console.WriteLine("Digite 1 para o Cadastro de Equipamentos");
            Console.WriteLine("Digite 2 para o Controle de Chamados");

            Console.WriteLine("Digite S para Sair\n");

            string opcao = Console.ReadLine();
            return opcao;
        }

        private static string ObterOpcaoCadastroEquipamentos()
        {
            Console.Clear();
            Console.WriteLine("Digite 1 para inserir novo equipamento");
            Console.WriteLine("Digite 2 para editar um equipamento");
            Console.WriteLine("Digite 3 para excluir um equipamento");
            Console.WriteLine("Digite 4 para visualizar equipamentos");

            Console.WriteLine("Digite S para sair\n");

            string opcao = Console.ReadLine();

            return opcao;
        }

        private static string ObterOpcaoControleChamados()
        {
            Console.Clear();
            Console.WriteLine("Digite 1 para inserir novo chamado");
            Console.WriteLine("Digite 2 para editar um chamado");
            Console.WriteLine("Digite 3 para excluir um chamado");
            Console.WriteLine("Digite 4 para visualizar chamados");

            Console.WriteLine("Digite S para sair\n");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public static void PopularAplicacao(int quantidadeRegistros)
        {
            
        }
    }
}
