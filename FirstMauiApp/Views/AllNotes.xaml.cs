using FirstMauiApp.Models;

namespace FirstMauiApp.Views;

public partial class AllNotes : ContentPage
{
	public AllNotes()
	{
		InitializeComponent();
        BindingContext = new Models.AllNotes();
	}

    protected override void OnAppearing()
    {
        ((Models.AllNotes)BindingContext).LoadNotes();
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(NotePage));
    }

    private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count == 0)
            return;

        // Get the note model
        var note = (Note)e.CurrentSelection[0];

        // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
        await Shell.Current.GoToAsync($"{nameof(NotePage)}?{nameof(NotePage.ItemId)}={note.Filename}");

        // Unselect the UI
        notesCollection.SelectedItem = null;
    }
}