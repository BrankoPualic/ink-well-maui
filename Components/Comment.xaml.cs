using InkWell.MAUI.Business.Interfaces;
using InkWell.MAUI.Business.Services;
using InkWell.MAUI.Common;
using System.ComponentModel;

namespace InkWell.MAUI.Components;

public partial class Comment : ContentView, INotifyPropertyChanged
{
	private readonly ICommentService commentService;

	#region Bindable Properties

	public static readonly BindableProperty IdentifierProperty =
		BindableProperty.Create(nameof(Identifier), typeof(Guid), typeof(Comment), null);

	public static readonly BindableProperty ProfileImageProperty =
		BindableProperty.Create(nameof(ProfileImage), typeof(string), typeof(Comment), string.Empty);

	public static readonly BindableProperty UsernameProperty =
		BindableProperty.Create(nameof(Username), typeof(string), typeof(Comment), string.Empty);

	public static readonly BindableProperty TitleProperty =
		BindableProperty.Create(nameof(Title), typeof(string), typeof(Comment), string.Empty, propertyChanged: OnTitleChanged);

	public static readonly BindableProperty TextProperty =
		BindableProperty.Create(nameof(Text), typeof(string), typeof(Comment), string.Empty);

	public static readonly BindableProperty AuthorProperty =
		BindableProperty.Create(nameof(Author), typeof(string), typeof(Comment), string.Empty, propertyChanged: OnCreateDetailsChanged);

	public static readonly BindableProperty CreatedAtProperty =
		BindableProperty.Create(nameof(CreatedAt), typeof(DateTime), typeof(Comment), null, propertyChanged: OnCreateDetailsChanged);

	public static readonly BindableProperty UpvotesProperty =
		BindableProperty.Create(nameof(Upvotes), typeof(int), typeof(Comment), 0);

	public static readonly BindableProperty RepliesProperty =
		BindableProperty.Create(nameof(Replies), typeof(int), typeof(Comment), 0);

	public string Author
	{
		get => (string)GetValue(AuthorProperty);
		set => SetValue(AuthorProperty, value);
	}

	public DateTime CreatedAt
	{
		get => (DateTime)GetValue(CreatedAtProperty); set => SetValue(CreatedAtProperty, value);
	}

	public int Upvotes
	{
		get => (int)GetValue(UpvotesProperty); set => SetValue(UpvotesProperty, value);
	}

	public int Replies
	{
		get => (int)GetValue(RepliesProperty); set => SetValue(RepliesProperty, value);
	}

	public Guid Identifier
	{
		get => (Guid)GetValue(IdentifierProperty);
		set => SetValue(IdentifierProperty, value);
	}

	public string ProfileImage
	{
		get => (string)GetValue(ProfileImageProperty);
		set => SetValue(ProfileImageProperty, value);
	}

	public string Username
	{
		get => (string)(GetValue(UsernameProperty));
		set => SetValue(UsernameProperty, value);
	}

	public string Title
	{
		get => (string)(GetValue(TitleProperty));
		set => SetValue(TitleProperty, value);
	}

	public string Text
	{
		get => ((string)GetValue(TextProperty));
		set => SetValue(TextProperty, value);
	}

	#endregion Bindable Properties

	public string CreateDetails => $"Created by {Author} at {CreatedAt.ToString(Constants.DATETIME_DATE_MONTH_FORMAT)}";

	public bool HasTitle => !string.IsNullOrEmpty(Title);

	public Comment()
	{
		commentService = new CommentService();

		InitializeComponent();
	}

	private async void UpvoteAction(object sender, EventArgs e) => await commentService.UpvoteAsync(Identifier);

	private static void OnTitleChanged(BindableObject bindable, object oldValue, object newValue)
	{
		var comment = (Comment)bindable;
		comment.OnPropertyChanged(nameof(HasTitle));
	}

	private static void OnCreateDetailsChanged(BindableObject bindable, object oldValue, object newValue)
	{
		var comment = (Comment)bindable;
		comment.OnPropertyChanged(nameof(CreateDetails)); // Notify that CreateDetails changed
	}
}