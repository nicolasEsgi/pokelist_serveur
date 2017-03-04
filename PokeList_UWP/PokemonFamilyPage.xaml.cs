using PokeList_Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace PokeList_UWP
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class PokemonFamilyPage : Page
    {
        private List<Pokemon> currentPokemons;
        public Pokemon currentPokemon { get; set; }
        public PokemonFamilyPage()
        {
            this.InitializeComponent();
            this.currentPokemons = new List<Pokemon>();
            this.currentPokemon = new Pokemon();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            if(e.Parameter != null)
            {
                await PokeDataLayer.getPokemonFamiliy(Convert.ToInt32((e.Parameter as Pokemon).number), this.currentPokemons);
                this.pokemonFamilyPivot.Background = new SolidColorBrush(Colors.Transparent);
                // this.pokemonFamilyPivot.Foreground = new SolidColorBrush(Colors.White);
                int i = 0, n = 0;
                foreach (Pokemon pokemon in this.currentPokemons)
                {
                    var pivotItem = new PivotItem();
                    var frame = new Frame();
                    frame.Navigate(typeof(FeaturePage), pokemon);
                    frame.Margin = new Thickness(0);
                    frame.Padding = new Thickness(0);
                    pivotItem.Margin = new Thickness(0);
                    pivotItem.Padding = new Thickness(0);
                    pivotItem.Content = frame;
                    TextBlock txtbl = new TextBlock();
                    txtbl.Text = pokemon.name;
                    txtbl.Foreground = new SolidColorBrush(Colors.White);
                    pivotItem.Header = txtbl;
                    if (Convert.ToInt32((e.Parameter as Pokemon).number) == Convert.ToInt32(pokemon.number))
                    {
                        n = i;
                        this.currentPokemon = pokemon;
                        this.bgImage.Source = new BitmapImage(new Uri("ms-appx://" + currentPokemon.bgImageSource));
                        Debug.WriteLine(new Uri("ms-appx://" + currentPokemon.bgImageSource).ToString());
                    }
                    this.pokemonFamilyPivot.Items.Add(pivotItem);
                    i++;
                }
                this.pokemonFamilyPivot.SelectedIndex = n;
            }
            base.OnNavigatedTo(e);
        }
    }
}
