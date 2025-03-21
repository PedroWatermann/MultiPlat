using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MultiPlat_X.Controllers;

namespace MultiPlat_X
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagCadastrar : ContentPage
    {
        public PagCadastrar()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Clicked(object sender, EventArgs e)
        {
            ConMySql.Inserir(entNome.Text, entCidade.Text, entCelular.Text);

            DisplayAlert("Cadastro", "Pessoa cadastrada com sucesso!", "OK");
            
            Navigation.PushAsync(new PagListar());
        }
    }
}