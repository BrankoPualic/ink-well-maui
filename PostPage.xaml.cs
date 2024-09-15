namespace InkWell.MAUI;

public partial class PostPage : ContentPage
{
	public Guid Id { get; }

	public PostPage()
	{ }

	public PostPage(Guid id) : this()
	{
		InitializeComponent();

		Id = id;
	}

	// methods

	private async void LoadPost()
	{ }
}