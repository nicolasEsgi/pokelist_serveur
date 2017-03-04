using PokeList_Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace PokeList_UWP
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        public ObservableCollection<Pokemon> pokemonList { get; set; }
        public HomePage()
        {
            this.InitializeComponent();
            pokemonList = new ObservableCollection<Pokemon>();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await PokeDataLayer.getAllPokemon(pokemonList);
        }

        private void lstvPokemon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Frame.Navigate(typeof(PokemonFamilyPage), this.lstvPokemon.SelectedItem);
        }
    }
}
