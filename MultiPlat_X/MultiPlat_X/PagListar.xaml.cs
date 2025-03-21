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
    public partial class PagListar : ContentPage
    {
        public PagListar()
        {
            InitializeComponent();
        }

        // Active indicator/progressbar
        protected override void OnAppearing()
        {
            base.OnAppearing();

            lsvPessoas.ItemsSource = ConMySql.Listar();
        }

        void navegarPessoa(ModPessoa p)
        {
            PagUpDel ud = new PagUpDel
            {
                pessoa = p
            };
            Navigation.PushAsync(ud);
        }

        private void lsvPessoas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
                navegarPessoa(e.SelectedItem as ModPessoa);
        }

        private void btnNovo_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PagCadastrar());
        }
    }
}