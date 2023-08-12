using FirstMauiApp.Models;

namespace FirstMauiApp.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class NotePage : ContentPage
{
    public string ItemId {
		set { LoadNote(value); }
	}
    private string _folder = FileSystem.AppDataDirectory;

    public NotePage()
	{
		InitializeComponent();
		string fileName = $"{Path.GetRandomFileName()}.notes.txt";
		LoadNote(Path.Combine(_folder, fileName));
	}

	private async void SaveButton_Clicked(object sender, EventArgs e)
	{
		if(BindingContext is Note note)
			File.WriteAllText(note.Filename, TextEditor.Text);
		await Shell.Current.GoToAsync("..");
	}

	private async void DeleteButton_Clicked(Object sender, EventArgs e)
	{
		if(BindingContext is Note note && File.Exists(note.Filename))
            File.Delete(note.Filename);

		await Shell.Current.GoToAsync("..");
	}

	private void LoadNote(string fileName)
	{
		var note = new Note()
		{
			Filename = fileName,
		};

		if (File.Exists(fileName))
		{
            note.Text = File.ReadAllText(fileName);
			note.Date = File.GetCreationTime(fileName);
        }

		BindingContext = note;
	}
}