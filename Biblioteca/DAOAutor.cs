using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;//Importando os comandos de conexão com o banco
    


namespace Biblioteca
{
    
     class DAOAutor
    {
        public MySqlConnection conexao;//Criando a variável que representa o banco
        public string dados;
        public string comando;
        public int[] codigo;
        public string[] nome;
        public string[] autor;
        public string[] tema;
        public int i = 0;
        public DAOAutor() 
        {
            //conexão com o banco de dados
            conexao = new MySqlConnection("server=localhost;Database=biblioteca;Uid=root;Password=;Convert zero DateTime=True");
            try
            {
                this.conexao.Open();//Abrindo a conexão
                Console.WriteLine("Conectado com sucesso!");
            }
            catch (Exception erro)
            {
                Console.WriteLine($"Algo deu errado!\n\n {erro}");
                this.conexao.Close();//Fechar a conexão com o BD 
            }//fim do try-catch
        }//fim do construtor

        //Inserir o dado no banco
        public void Inserir(string nome, string autor, string tema)
        {
            try
            {
                this.dados = $"('','{nome}','{autor}','{tema}')";
                this.comando = $"INSERT INTO `livro`(`idlivro`,`nome`,`autor`,`tema`) VALUES {this.dados}";
            //Inserir o comando no banco
            MySqlCommand sql = new MySqlCommand(this.comando, this.conexao);
           string resultado = sql.ExecuteNonQuery().ToString();
                Console.WriteLine($"Inserindo com sucesso! \n\n{resultado}");
            }catch (Exception erro) 
            {
            Console.WriteLine($"Algo deu errado!\n\n {erro}");
            }
        }//fim do método



        //preencher vetor --> Coletar os dados do banco e preencher os vetores

        public void Listar()
        {
            this.comando = "SELECT * FROM `livros`";
            MySqlCommand sql = new MySqlCommand(this.comando, this.conexao);
            MySqlDataReader resultado = sql.ExecuteReader();
            while (resultado.Read())
            {
                this.codigo[i] = resultado.GetInt32("id");
                this.nome[i] = resultado.GetString("nome");
                this.autor[i] = resultado.GetString("autor");
                this.tema[i] = resultado.GetString("tema");
                i++;
            }
        }//fim do método



    }//fim da classe
}//fim do projeto
