using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1_Vagas.Modelos;
using App1_Vagas.Banco;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_Vagas.Paginas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CadastroVaga : ContentPage
	{
        //PARAMETRO É OPCIONAL
		public CadastroVaga ( Vagas vaga = null)
		{
			InitializeComponent ();

            if (vaga != null)
            {
                //TODO: Eddição
            }
		}

        public void SalvarAction(object sender, EventArgs args)
        {
            //TODO - Obter dados da tela
            Vagas vaga = new Vagas();
            vaga.NomeVaga = NameVaga.Text;
            vaga.Quantidade = short.Parse(NameQuantidade.Text);
            vaga.Salario = double.Parse(NameSalario.Text);
            vaga.Empresa = NameEmpresa.Text;
            vaga.Cidade = NameCidade.Text;
            vaga.Descricao = NameDescricao.Text;
            vaga.TipoContratacao = (NameTipoContratacao.IsToggled) ? "PJ" : "CLT";
            vaga.Telefone = NameTelefone.Text;
            vaga.Email = NameEmail.Text;

            //TODO - salvar informações no banco
            AcessoBanco database = new AcessoBanco();
            database.Cadastro(vaga);


            App.Current.MainPage = new NavigationPage(new ConsultaVagas());
        }

    }
}