﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1_Vagas.Modelos;

namespace App1_Vagas.Paginas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetalheVagas : ContentPage
	{
		public DetalheVagas (Vagas vaga)
		{
			InitializeComponent ();

            BindingContext = vaga;
		}
	}
}