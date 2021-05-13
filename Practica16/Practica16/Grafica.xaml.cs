using Microcharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SkiaSharp;

//Especificar que los entrys son los del nuget
using Entry = Microcharts.ChartEntry;



namespace Practica16
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class Grafica : ContentPage
    {

        int cont = 0;
        public Grafica()
        {
            InitializeComponent();
           
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
           

            

            
        }
    }
}