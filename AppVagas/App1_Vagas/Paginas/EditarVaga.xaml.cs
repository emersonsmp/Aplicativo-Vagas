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
	public partial class EditarVaga : ContentPage
	{
        private Vagas vaga { get; set; }
        public EditarVaga (Vagas vaga)
		{
			InitializeComponent ();
            this.vaga = vaga;

            //Colocação dados na tela
            NameVaga.Text = vaga.NomeVaga;
            NameEmpresa.Text = vaga.Empresa;
            NameQuantidade.Text = vaga.Quantidade.ToString();
            NameCidade.Text = vaga.Cidade;
            NameSalario.Text = vaga.Salario.ToString();

            NameDescricao.Text = vaga.Descricao;
            NameTipoContratacao.IsToggled = (vaga.TipoContratacao == "CLT") ? false : true;
            NameTelefone.Text = vaga.Telefone;
            NameEmail.Text = vaga.Email;

        }

        public void SalvarAction(object sender, EventArgs args)
        {
            //Obter dados da tela
            vaga.NomeVaga = NameVaga.Text;
            vaga.Quantidade = short.Parse(NameQuantidade.Text);
            vaga.Salario = double.Parse(NameSalario.Text);
            vaga.Empresa = NameEmpresa.Text;
            vaga.Cidade = NameCidade.Text;
            vaga.Descricao = NameDescricao.Text;
            vaga.TipoContratacao = (NameTipoContratacao.IsToggled) ? "PJ" : "CLT";
            vaga.Telefone = NameTelefone.Text;
            vaga.Email = NameEmail.Text;

            //Atualizar o banco de dados
            AcessoBanco database = new AcessoBanco();
            database.Atualizacao(vaga);

            //Redirecionar para tela minhasvagas cadastradas
            App.Current.MainPage = new NavigationPage(new ConsultaVagas());
            //App.Current.MainPage = new NavigationPage(new MinhasVagasCadastradas());

        }

    }
}