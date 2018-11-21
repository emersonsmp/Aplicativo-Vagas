using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using App1_Vagas.Banco;
using Xamarin.Forms;
using System.IO;
using App1_Vagas.iOS.Banco;


[assembly:Dependency(typeof(Caminho))]
namespace App1_Vagas.iOS.Banco
{
    class Caminho : ICaminho
    {
        public string ObterCaminho(string NomeArquivoBanco)
        {
            string CaminhoDaPasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            string CaminhoBiblioteca = Path.Combine(CaminhoDaPasta, "..", "library");
            string CaminhoBanco = Path.Combine(CaminhoBiblioteca, NomeArquivoBanco);
            return CaminhoBanco;
        }
    }
}