using InkWell.MAUI.Common;
using System.Windows.Input;

namespace InkWell.MAUI.Components;

public partial class Post : ContentView
{
	// Commands

	public ICommand ReadMoreCommand { get; }

	// Bindable Properties

	#region Bindable Properties

	public static readonly BindableProperty IdentifierProperty =
		BindableProperty.Create(nameof(Identifier), typeof(Guid), typeof(Post), Guid.Empty);

	public static readonly BindableProperty TitleProperty =
		BindableProperty.Create(nameof(Title), typeof(string), typeof(Post), string.Empty);

	public static readonly BindableProperty DescriptionProperty =
		BindableProperty.Create(nameof(Description), typeof(string), typeof(Post), string.Empty);

	public static readonly BindableProperty ImageProperty =
		BindableProperty.Create(nameof(Image), typeof(string), typeof(Post), string.Empty);

	public static readonly BindableProperty AuthorProperty =
		BindableProperty.Create(nameof(Author), typeof(string), typeof(Post), string.Empty);

	public static readonly BindableProperty CreatedAtProperty =
		BindableProperty.Create(nameof(CreatedAt), typeof(DateTime), typeof(Post), null);

	public static readonly BindableProperty ViewCountProperty =
		BindableProperty.Create(nameof(ViewCount), typeof(int), typeof(Post), 0);

	public static readonly BindableProperty LikesProperty =
		BindableProperty.Create(nameof(Likes), typeof(int), typeof(Post), 0);

	public static readonly BindableProperty CommentsProperty =
		BindableProperty.Create(nameof(Comments), typeof(int), typeof(Post), 0);

	public Guid Identifier
	{
		get => (Guid)GetValue(IdentifierProperty);
		set => SetValue(IdentifierProperty, value);
	}

	public string Title
	{
		get => (string)GetValue(TitleProperty);
		set => SetValue(TitleProperty, value);
	}

	public string Description
	{
		get => (string)GetValue(DescriptionProperty);
		set => SetValue(DescriptionProperty, value);
	}

	public string Image
	{
		get => (string)GetValue(ImageProperty);
		set => SetValue(ImageProperty, value);
	}

	public string Author
	{
		get => (string)GetValue(AuthorProperty);
		set => SetValue(CreatedAtProperty, value);
	}

	public DateTime CreatedAt
	{
		get => (DateTime)GetValue(CreatedAtProperty);
		set => SetValue(CreatedAtProperty, value);
	}

	public int ViewCount
	{
		get => (int)GetValue(ViewCountProperty);
		set => SetValue(ViewCountProperty, value);
	}

	public int Likes
	{
		get => (int)GetValue(LikesProperty);
		set => SetValue(LikesProperty, value);
	}

	public int Comments
	{
		get => (int)GetValue(CommentsProperty);
		set => SetValue(CommentsProperty, value);
	}

	#endregion Bindable Properties

	public string CreateDetails => $"Created by {Author} at {CreatedAt.ToString(Constants.DATETIME_DATE_MONTH_FORMAT)}";

	public Post()
	{
		InitializeComponent();

		//ReadMoreCommand = new Command(ReadMore);
	}

	// methods

	//private void ReadMore() => App.Current.MainPage = new PostPage(Identifier);
}