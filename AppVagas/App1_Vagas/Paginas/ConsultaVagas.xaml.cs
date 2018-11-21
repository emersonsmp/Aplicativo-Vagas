using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1_Vagas.Modelos;
using App1_Vagas.Banco;
namespace App1_Vagas.Paginas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ConsultaVagas : ContentPage
	{
        List<Vagas> Lista { get; set;}

		public ConsultaVagas ()
		{
			InitializeComponent ();

            AcessoBanco database = new AcessoBanco();
            Lista = database.Consultar();
            ListaVagas.ItemsSource = Lista;
            LblCount.Text = Lista.Count.ToString();

		}

        public void GoCadastro(object sender, EventArgs args)
        {
            Navigation.PushAsync(new CadastroVaga());
        }

        public void GoMinhasVagas(object sender, EventArgs args)
        {
            Navigation.PushAsync(new MinhasVagasCadastradas());
        }

        public void MaisDetalhes(object sender, EventArgs args)
        {
            //CAST DO TIPO QUE ESTA ViNDO
            Label LblDetalhe = (Label)sender;

            //TAPGESTURERECOGNIZER É UMA LISTA
            TapGestureRecognizer tapgest = (TapGestureRecognizer)LblDetalhe.GestureRecognizers[0];

            //COMANDPARAMETER INFORMA QUE É OBJETO DO TIPO VAGA
            Vagas vaga = tapgest.CommandParameter as Vagas;

            Navigation.PushAsync(new DetalheVagas(vaga));
        }

        public void PesquisarAction(object sender, TextChangedEventArgs args)
        {
            ListaVagas.ItemsSource = Lista.Where(a => a.NomeVaga.Contains(args.NewTextValue)).ToList();
        }

    }
}