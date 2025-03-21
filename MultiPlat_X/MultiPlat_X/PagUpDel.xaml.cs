using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MultiPlat_X.Controllers;
using MultiPlat_X.Models;

namespace MultiPlat_X
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagUpDel : ContentPage
    {
        public ModPessoa pessoa { get; set; }

        public PagUpDel()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            BindingContext = this.pessoa;
        }

        private void btnAtualizar_Clicked(object sender, EventArgs e)
        {
            ConMySql.Atualizar(pessoa);

            Navigation.PopAsync();
        }

        private async void btnApagar_Clicked(object sender, EventArgs e)
        {
            if (pessoa.id_pessoa != 0)
            {
                if (!await DisplayAlert("Exclusão", "Deseja realmente apagar este registro?", "Sim", "Não"))
                    return;

                ConMySql.Excluir(pessoa);

                await DisplayAlert("Exclusão", "Pessoa excluída com sucesso!", "OK");
                Navigation.PopAsync();
            }
        }
    }
}