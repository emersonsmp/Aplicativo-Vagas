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
	public partial class MinhasVagasCadastradas : ContentPage
	{

        List<Vagas> Lista { get; set; }
        public MinhasVagasCadastradas ()
		{
			InitializeComponent ();
            ConsultarVagas();
        }

        private void ConsultarVagas()
        {
            AcessoBanco database = new AcessoBanco();
            Lista = database.Consultar();
            ListaVagas.ItemsSource = Lista;
            LblCount.Text = Lista.Count.ToString();
        }

        public void EditarAction(object sender, EventArgs args)
        {

            Label LblEditar = (Label)sender;
            TapGestureRecognizer tapgest = (TapGestureRecognizer)LblEditar.GestureRecognizers[0];
            Vagas vaga = tapgest.CommandParameter as Vagas;
            Navigation.PushAsync(new EditarVaga(vaga));

        }

        public void ExcluirAction(object sender, EventArgs args)
        {
            Label LblExcluir = (Label)sender;
            TapGestureRecognizer tapgest = (TapGestureRecognizer)LblExcluir.GestureRecognizers[0];
            Vagas vaga = tapgest.CommandParameter as Vagas;

            AcessoBanco database = new AcessoBanco();
            database.Exclusao(vaga);

            //PARA GARANTIR UMA LISTA ATUALIZADA
            ConsultarVagas();
        }

        public void PesquisarAction(object sender, TextChangedEventArgs args)
        {
            ListaVagas.ItemsSource = Lista.Where(a => a.NomeVaga.Contains(args.NewTextValue)).ToList();
        }

    }
}