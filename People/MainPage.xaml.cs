using People.Models;
using System.Collections.Generic;

namespace People;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    // Método para agregar una nueva persona
    public void OnNewButtonClicked(object sender, EventArgs args)
    {
        // Limpiar el mensaje de estado
        PLstatusMessage.Text = "";

        // Llamar al método para agregar una nueva persona
        App.PersonRepo.AddNewPerson(PLnewPerson.Text);

        // Mostrar el mensaje de estado
        PLstatusMessage.Text = App.PersonRepo.StatusMessage;
    }

    // Método para mostrar la lista de personas
    public void OnGetButtonClicked(object sender, EventArgs args)
    {
        // Limpiar el mensaje de estado
        PLstatusMessage.Text = "";

        // Obtener la lista de personas desde el repositorio
        List<Person> people = App.PersonRepo.GetAllPeople();

        // Asignar la lista al CollectionView
        PLpeopleList.ItemsSource = people;
    }
}


