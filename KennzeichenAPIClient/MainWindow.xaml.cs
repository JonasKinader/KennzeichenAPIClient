using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KennzeichenAPIClient;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void gridApi_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        KennzeichenData? k = gridApi.SelectedItem as KennzeichenData;
        if (k == null) return;

        KennzeichenDetailsAnzeigen(k);
    }

    private void KennzeichenDetailsAnzeigen(KennzeichenData k)
    {
        txtId.Text = k.id.ToString();
        txtKen.Text = k.kennzeichen;
        txtOrt.Text = k.ort;
        txtKreis.Text = k.kreis;
        txtBund.Text = k.bundesland;
        txtlink.Text = k.wappenLink;
    }

    private void ListBoxWriteLine(string message)
    {
        lstApi.Items.Add($"[{DateTime.Now.ToShortTimeString()}] {message}");
    }

    private async void btnHin_Click(object sender, RoutedEventArgs e)
    {
        KennzeichenData k = new KennzeichenData(0,
                                                txtKen.Text,
                                                txtOrt.Text,
                                                txtKreis.Text,
                                                txtBund.Text,
                                                txtlink.Text);

        //Task<HttpResponseMessage> t = client.PostAsJsonAsync<KennzeichenData>(uri, k, cancellationToken);
        HttpResponseMessage response = await client.PostAsJsonAsync<KennzeichenData>(uri, k, cancellationToken);
        ListBoxWriteLine("Hinzufügen Response Post: (" + (int)response.StatusCode + ") " + response.StatusCode);

        await KennzeichenAktualisieren();
    }

    private async void btnÄ_Click(object sender, RoutedEventArgs e)
    {
        int id = Convert.ToInt32(txtId.Text);
        KennzeichenData k = new KennzeichenData(id,
                                                txtKen.Text,
                                                txtOrt.Text,
                                                txtKreis.Text,
                                                txtBund.Text,
                                                txtlink.Text);

        Uri uriWithId = new Uri(uri.ToString() + $"/{id}");
        HttpResponseMessage response = await client.PutAsJsonAsync<KennzeichenData>(uriWithId, k, cancellationToken);
        ListBoxWriteLine("Änzufügen Ändern Post: (" + (int)response.StatusCode + ") " + response.StatusCode);

        await KennzeichenAktualisieren();
    }

    private async void btnLö_Click(object sender, RoutedEventArgs e)
    {
        int id = Convert.ToInt32(txtId.Text);
        KennzeichenData k = new KennzeichenData(id,
                                                txtKen.Text,
                                                txtOrt.Text,
                                                txtKreis.Text,
                                                txtBund.Text,
                                                txtlink.Text);

        Uri uriWithId = new Uri(uri.ToString() + $"/{id}");
        HttpResponseMessage response = await client.DeleteAsync(uriWithId, cancellationToken);
        ListBoxWriteLine("Hinzufügen Delete Response Post: (" + (int)response.StatusCode + ") " + response.StatusCode);

        await KennzeichenAktualisieren();
    }

    private void btnNew_Click(object sender, RoutedEventArgs e)
    {
        KennzeichenDetailsAnzeigen(new KennzeichenData());
    }

    private void btnBe_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        await KennzeichenAktualisieren();
       
    }

    private async void btnAkt_Click(object sender, RoutedEventArgs e)
    {
        await KennzeichenAktualisieren();
    }

    private async Task KennzeichenAktualisieren()
    {
        string KennzeichenString = await KennzeichenStringsAbfragen();
        KennzeichenStringsAnzeigen(KennzeichenString);

        List<KennzeichenData> lst = await KennzeichenAbfragen();
        KennzeichenAnzeigen(lst);
    }

    HttpClient client = new HttpClient();
    Uri uri = new Uri("http://localhost:5294/api/KennzeichenInfos");
    CancellationToken cancellationToken;

    private async Task<List<KennzeichenData>> KennzeichenAbfragen()
    {
        List<KennzeichenData> lst = new List<KennzeichenData>();

        try
        {
            KennzeichenData[]? data = await client.GetFromJsonAsync<KennzeichenData[]>(uri);
            if (data == null) return lst;
            lst.AddRange(data);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }

        return lst;
    }

    private async Task<string> KennzeichenStringsAbfragen()
    {
        string jsonString = "";

        try
        {
            jsonString = await client.GetStringAsync(uri);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }

        return jsonString;
    }

    private void KennzeichenAnzeigen(List<KennzeichenData> lst)
    {
        gridApi.ItemsSource = null;
        gridApi.ItemsSource = lst;
    }

    private void KennzeichenStringsAnzeigen(string KennzeichenString)
    {
        ListBoxWriteLine(KennzeichenString);
    }

    public class KennzeichenData
    {
        public int id { get; set; }
        public string kennzeichen { get; set; }
        public string ort { get; set; }
        public string kreis { get; set; }
        public string bundesland { get; set; }
        public string wappenLink { get; set; }

        public KennzeichenData()
        {
            id = 0;
            kennzeichen = "";
            ort = "";
            kreis = "";
            bundesland = "";
            wappenLink = "";
        }

        public KennzeichenData(int id, string kennzeichen, string ort, string kreis, string bundesland, string wappenLink)
        {
            this.id = id;
            this.kennzeichen = kennzeichen;
            this.ort = ort;
            this.kreis = kreis;
            this.bundesland = bundesland;
            this.wappenLink = wappenLink;
        }
    }
}