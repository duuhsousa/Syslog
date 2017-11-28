using System;
using System.Security.Cryptography;
using System.Text;

namespace Syslog
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        public void Menu(){
            string op2;
            Cadastro cadastros = new Cadastro();
            Acesso porta = new Acesso();
            do
            {
                Console.WriteLine("\nEscolha uma das opções abaixo\n1 - Cadastrar\n2 - LogIn\n3 - LogOut\n\n0 - Sair");
                do
                {
                    op2 = Console.ReadLine();
                } while (op2 != "1" && op2 != "2" && op2 != "3" && op2 != "0");

                switch (op2)
                {
                    case "0": Environment.Exit(0); break;
                    case "1": cadastros.Cadastrar();break;
                    case "2": porta.Login();break;
                    case "3": porta.Logout();break;
                }
            } while (op2 != "0");
        }
    }
}
