using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using Multicamadas.BLL;
using Multicamadas.MODEL;


namespace Multicamadas.CONSOLE
{
    internal class CONSOLE
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Aplicativo Console");
            Console.WriteLine("Gerenciamento de Projetos");


            char opcao = ' ';

            while (opcao != 'x')
            {
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("a - Adicionar");
                Console.WriteLine("b - Buscar");
                Console.WriteLine("l - Listar");
                Console.WriteLine("u - Update");
                Console.WriteLine("e - Excluir");
                Console.WriteLine("x - Sair");
                Console.Write("> ");
                opcao = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (opcao)
                {
                    case 'a':
                        Adicionar();
                        break;
                    case 'b':
                        Buscar();
                        break;
                    case 'l':
                        Listar();
                        break;
                    case 'u':
                        Update();
                        break;
                    case 'e':
                        Excluir();
                        break;
                    case 'x':
                        //exit application
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

        public static void PrintProjeto(Projetos projeto)
        {
            Console.WriteLine("ID: " + projeto.Id);
            Console.WriteLine("Nome: " + projeto.NomeProjeto);
            Console.WriteLine("Gerente: " + projeto.NomeGerente);
            Console.WriteLine("Data Inicio: " + projeto.DataInicio);
            Console.WriteLine("Data Fim: " + projeto.DataFim);
            Console.WriteLine("Resumo: " + projeto.Resumo);
            Console.WriteLine("Status: " + projeto.Status);
        }
        public static void Adicionar()
        {
            Console.WriteLine("Adcionar Novo Projeto");

            Projetos projeto = new Projetos();

            Console.Write("Nome do Projeto: ");

            projeto.NomeProjeto = Console.ReadLine();

            Console.Write("Nome do Gerente: ");

            projeto.NomeGerente = Console.ReadLine();

            Console.Write("Data de Início (YYYY-MM-DD): ");

            projeto.DataInicio = DateTime.Parse(Console.ReadLine());

            Console.Write("Data de Fim (YYYY-MM-DD): ");

            projeto.DataFim = DateTime.Parse(Console.ReadLine());

            Console.Write("Resumo: ");

            projeto.Resumo = Console.ReadLine();

            Console.Write("Status (Encerrado/Em Andamento): ");

            projeto.Status = Console.ReadLine();

            GestaoProjetos.Add(projeto);

            Console.WriteLine();
            Console.WriteLine("Projeto Adcionado com sucesso.");
            Console.WriteLine();

    }
        public static void Buscar()
        {
            Console.WriteLine("Busca por Id");
            Console.Write("Id: ");

            string id = Console.ReadLine();

            Projetos projeto = GestaoProjetos.GetById(Convert.ToInt32(id));

            Console.WriteLine();
            Console.WriteLine("-----Resultado------");
            PrintProjeto(projeto);
            
            Console.WriteLine();
        }

 
        public static void Listar()
        {
            Console.WriteLine("Lista de Projetos");
            Console.WriteLine("Id\tNome do Projeto");
            int count = 0;
            foreach (var projeto in GestaoProjetos.GetAll())
            {
                Console.WriteLine(projeto.Id + "\t" + projeto.NomeProjeto);
                count++;
            }

            Console.WriteLine();
            Console.WriteLine(count + " Projetos Salvos");
            Console.WriteLine();
            
        }

        public static void Update()
        {

            Console.WriteLine("Atualizar Status do Projeto");

            Console.Write("Id: ");

            string id = Console.ReadLine();

            Projetos _projeto = GestaoProjetos.GetById(Convert.ToInt32(id));
            
            Console.WriteLine("Novo Status do Projeto: ");

            string status = Console.ReadLine();

            _projeto.Status = status;

            GestaoProjetos.Update(_projeto);

            Console.WriteLine();
            PrintProjeto(_projeto);

            Console.WriteLine();
        }

        public static void Excluir()
        {

            Console.WriteLine("Excluir Projeto");

            Console.Write("Id: ");

            string id = Console.ReadLine();

            Projetos projeto = GestaoProjetos.GetById(Convert.ToInt32(id));
            
            GestaoProjetos.Delete(projeto);

            Console.WriteLine();
            Console.WriteLine("Projeto excluido com sucesso");
            Console.WriteLine();
        }
    }
    
}
