using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Xamarin.Forms;
using App1_Vagas.Banco;
using System.IO;//para usar path.combine
using App1_Vagas.Droid.Banco;

//Assinatura de assembly, passando o tipo do caminho
[assembly:Dependency(typeof(Caminho))]

namespace App1_Vagas.Droid.Banco
{
    public class Caminho : ICaminho
    {
        public string ObterCaminho(string NomeArquivoBanco)
        {
            string CaminhoDaPasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            //CONCATENA ENDERECO PASTA COM CAMINHO
            string CaminhoBanco = Path.Combine(CaminhoDaPasta, NomeArquivoBanco);

            return CaminhoBanco;
        }
    }
}