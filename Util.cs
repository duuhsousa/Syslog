using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Syslog
{
    public class Util
    {

        public void logando(string usuario, int tipo){
            Acesso acessando = new Acesso();
            acessando.EscreverLogs += Acesso.LoginLogs(LogSuperior(usuario,tipo));
            acessando.EscreverLogs += Acesso.LoginLogs(LogSistema(usuario,tipo));
        }

        public string encripSenha(string senha){
            byte[] senhaOriginal;
            byte[] senhaModificada;
            MD5 md5;
            senhaOriginal = Encoding.Default.GetBytes(senha);
            md5 = MD5.Create();
            senhaModificada = md5.ComputeHash(senhaOriginal);

            return Convert.ToBase64String(senhaModificada);            
        }
        public void LogSuperior(string usuario, int tipo){
            StreamWriter sw = new StreamWriter("Superior.txt",true);
            if(tipo==1){
                sw.WriteLine(usuario+" realizou logon "+DateTime.Now.ToShortDateString());
            }else if(tipo==0){
                sw.WriteLine(usuario+" realizou logout "+DateTime.Now.ToShortDateString());
            }else{
                sw.WriteLine(usuario+" fez merda "+DateTime.Now.ToShortDateString());
            }
            sw.Close();
        }

        public void LogSistema(string usuario, int tipo){
            StreamWriter sw = new StreamWriter("LogSistema.txt",true);
            if(tipo==1){
                sw.WriteLine(usuario+" realizou logon "+DateTime.Now.ToShortDateString());
            }else if(tipo==0){
                sw.WriteLine(usuario+" realizou logout "+DateTime.Now.ToShortDateString());
            }else{
                sw.WriteLine(usuario+" fez merda "+DateTime.Now.ToShortDateString());
            }
            sw.Close();
        }

    }
        
}