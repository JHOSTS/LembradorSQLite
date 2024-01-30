using Lembrador.Model;
using Lembrador.Services;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;
using System.Collections.ObjectModel;
using System.Runtime.Intrinsics.X86;
using System.Windows.Input;
namespace Lembrador.Views;

public partial class Lembrador : ContentPage
{
    List<string> lembradores = new List<string>();
    List<Lembrete> lembradoresCache = new List<Lembrete>();

    LembradorService _lembradorService = new();

    public Lembrador(LembradorService lembradorService)
    {
        _lembradorService = lembradorService;
    }

    public Lembrador()
    {
        InitializeComponent();

        lstlembradores.ItemsSource = lembradoresCache;

        if (lembradoresCache != null)
        {
            if (lembradoresCache.Count > 0)
                framelembrador.IsVisible = true;
        }

        btnExcluirlembrador.IsEnabled = framelembrador.IsVisible ? true : false;
    }

    private void btnAdicionarlembradorClicked(object sender, EventArgs e)
    {
        Lembrete lembrador = new Lembrete { TxtLembrete = txtlembrador.Text };

        if (!String.IsNullOrEmpty(lembrador.TxtLembrete))
        {
            lembrador.TxtLembrete = Environment.NewLine + DateTime.Now.ToString("dd-MM-yyy HH:mm") + ":  " + Environment.NewLine + lembrador.TxtLembrete;
            lembradores.Add(lembrador.TxtLembrete);
            lstlembradores.ItemsSource = null;
            lstlembradores.ItemsSource = lembradores;
            txtlembrador.Text = "";
            framelembrador.IsVisible = true;

            _lembradorService.AdicionaLembrete(lembrador);
        }
        else
            DisplayAlert("", "Adicione um lembrador!", "Fechar");

        btnExcluirlembrador.IsEnabled = framelembrador.IsVisible ? true : false;
    }

    private void DeleteSelectedItem_Click(object sender, EventArgs e)
    {
        string msgExclusao = lstlembradores.SelectedItems.Count > 1 ? "Lembradores excluídos!" : "Lembrador excluído!";


        if (lstlembradores.SelectedItems.Count >= 0)
        {
            foreach (string itemSelecionado in lstlembradores.SelectedItems)
            {
                lembradores.Remove(itemSelecionado.ToString());
                lstlembradores.ItemsSource = null;
                lstlembradores.ItemsSource = lembradores;
                Lembrete lembreteSelecionado =  (Lembrete)itemSelecionado;
                _lembradorService.DeletaLembrete(lembreteSelecionado);
            }

            if (lembradores.Count <= 0)
            {
                framelembrador.IsVisible = false; btnExcluirlembrador.IsEnabled = false;
            }

            lstlembradores.SelectedItem = null;
            DisplayAlert("", msgExclusao, "Fechar");
        }
    }

    private void lstlembradores_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        btnExcluirlembrador.Text = lstlembradores.SelectedItems.Count > 1 ? "Excluir Selecionados" : "Excluir Selecionado";
    }
}
