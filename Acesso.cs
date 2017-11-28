using System;
using System.IO;

namespace Syslog
{
    public class Acesso
    {
        public string Nome { get; set; }
        public string Senha { get; set; }


        public void Login()
        {
            int tentativas = 3, loginValido = 0;
            do
            {
                string[] clientes, findcliente = null;
                clientes = File.ReadAllLines("cadUsuario.txt");
                System.Console.Write("Digite o Nome do Usuário:");
                this.Nome = Console.ReadLine();
                System.Console.Write("Digite a senha:");
                this.Senha = Console.ReadLine();

                Util encriptar = new Util();
                this.Senha = encriptar.encripSenha(this.Senha);

                foreach (string usuario in clientes)
                {
                    if (usuario.Contains(this.Nome + ";"))
                    {
                        findcliente = usuario.Split(';');
                        if (findcliente[1] == this.Senha)
                        {
                            loginValido = 1;
                        }
                    }
                }

                if (loginValido == 1)
                {
                    System.Console.WriteLine("Login Realizado com sucesso!");
                }
                else
                {
                    System.Console.WriteLine("Usuário e Senha incorretos!");
                    tentativas--;
                    if (tentativas == 0)
                    {
                        System.Console.WriteLine("TCHAU!!!!");
                    }
                    else
                    {
                        System.Console.WriteLine("Você ainda pode tentar " + tentativas + " vez(es)!!");
                    }

                }

            } while (loginValido == 0 && tentativas > 0);
        }


        public void Logout()
        {
            System.Console.WriteLine("FLW MLK DOIDO!!");
        }

        public delegate void LoginLogs(string usuario, int tipo);

        public event LoginLogs EscreverLogs;

    }

}