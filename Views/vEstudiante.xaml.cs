using Newtonsoft.Json;
using rsanchezT6.Models;
using System.Collections.ObjectModel;

namespace rsanchezT6.Views;

public partial class vEstudiante : ContentPage
{
	private const string url = "http://192.168.56.1/Moviles/wsestudiantes.php";
	private readonly HttpClient cliente=new HttpClient();
	private ObservableCollection<Estudiante> est;
    public vEstudiante()
	{
		InitializeComponent();
		ObtenerDatos();

    }
	public async void ObtenerDatos()
    {
     var content= await cliente.GetStringAsync(url);
        List<Estudiante> mostrar= JsonConvert.DeserializeObject<List<Estudiante>>(content);
		est=new ObservableCollection<Estudiante>(mostrar);
		ListaEstudiante.ItemsSource= est;
    }
}