using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1_Vagas.Banco;
using Xamarin.Forms;
using System.IO;
using App1_Vagas.UWP.Banco;
using Windows.Storage;

[assembly:Dependency(typeof(Caminho))]
namespace App1_Vagas.UWP.Banco
{
    class Caminho : ICaminho
    {
        public string ObterCaminho(string NomeArquivoBanco)
        {
            string CaminhoPasta = ApplicationData.Current.LocalFolder.Path;
            string CaminhoBanco = Path.Combine(CaminhoPasta, NomeArquivoBanco);

            return CaminhoBanco;
        }
    }
}
