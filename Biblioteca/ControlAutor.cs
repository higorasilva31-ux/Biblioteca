using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
     class ControlAutor
    {
        DAOAutor autor;
        public int opcao;
        public ControlAutor()
        {
            this.autor = new DAOAutor();//Abrindo a conexão com o BD

        }//fim do construtor

        //Mostrar o menu

        public void MostrarMenu()
        {
            Console.WriteLine("------ MENU -----\n\n"+
                             "\n0. Sair"            +
                              "\n1. Cadastrar"      +                 
                                "\n2. listar"       +
                                "\n3. Excluir"      +
                                "\n4. Atualizar"    +
                                "\n Escolha uma das opções acima: ");  
            this.opcao = Convert.ToInt32(Console.ReadLine());
        }//fim do método

        public void ExecutarOperacao()
        {
            do
            {
                this.MostrarMenu();//Mostrar as opções dispóniveis
                switch (this.opcao)
                {
                    case 0:
                        Console.WriteLine("Obrigado...");
                        break;
                    case 1:
                        Console.WriteLine("Cadastrar");
                        //Formulário de cadastro
                        Console.WriteLine("Informe o nome do livro: ");
                        string nome = Console.ReadLine();

                        Console.WriteLine("Informe o genero do livro: ");
                        string genero = Console.ReadLine();

                        Console.WriteLine("Informe o tema do livro");
                        string tema = Console.ReadLine();

                        //inserir os dados no banco
                       this.autor.Inserir(nome, genero, tema);






                        break;
                    case 2:
                        Console.WriteLine("Listar");

                         this.autor.Listar();


                        break;
                    case 3:
                        Console.WriteLine("Excluir");
                        break;
                    case 4:
                        Console.WriteLine("Atualizar");
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;

                }
            } while (this.opcao != 0);

        }




    }//fim da controlAutor
}//fim da classe
