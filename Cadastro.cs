using System;
using System.IO;

namespace Syslog
{
    public class Cadastro
    {
        public string Nome { get; set; }
        public string Senha { get; set; }

        public void Cadastrar(){
            System.Console.Write("Cadastrando novo usuário...\n\nDigite o Nome do Usuário:");
            this.Nome = Console.ReadLine();
            System.Console.Write("Digite a senha:");
            this.Senha = Console.ReadLine();

            Util encriptar = new Util();
            this.Senha = encriptar.encripSenha(this.Senha);

            StreamWriter sw = new StreamWriter("cadUsuario.txt",true);
            sw.WriteLine(this.Nome+";"+this.Senha);
            sw.Close();
            System.Console.WriteLine("Cadastro Realizado com sucesso!");
        }
    }
}