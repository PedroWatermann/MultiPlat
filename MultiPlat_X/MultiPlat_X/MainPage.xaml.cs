using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;

namespace MultiPlat_X
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        
        private void btnCadastrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PagCadastrar());
        }

        private void btnListar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PagListar());
        }

        private void btnSair_Clicked(object sender, EventArgs e)
        {
            try
            {
                Process.GetCurrentProcess().Kill();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
