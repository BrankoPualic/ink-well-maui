using InkWell.MAUI.Business.Dtos.User;
using InkWell.MAUI.Common;
using System.ComponentModel;

namespace InkWell.MAUI.Components;

public partial class User : ContentView, INotifyPropertyChanged
{
	public static readonly BindableProperty UserPProperty =
		BindableProperty.Create(nameof(UserP), typeof(PersonalInformationsDto), typeof(User), propertyChanged: OnUserChanged);

	public PersonalInformationsDto UserP
	{
		get => (PersonalInformationsDto)GetValue(UserPProperty);
		set => SetValue(UserPProperty, value);
	}

	public string UserStatus
	{
		get
		{
			if (UserP is null)
				return string.Empty;
			return UserP.IsActive ? "Active" : "Inactive";
		}
	}

	public string DoB
	{
		get
		{
			if (UserP is null)
				return string.Empty;
			return UserP.DateOfBirth.ToDateTime(TimeOnly.MinValue).ToString(Constants.DATETIME_DATE_FOMRAT);
		}
	}

	public string CreatedAt
	{
		get
		{
			if (UserP is null)
				return string.Empty;
			return UserP.CreatedAt.ToString(Constants.DATETIME_DATE_FOMRAT);
		}
	}

	public string Roles
	{
		get
		{
			if (UserP is null)
				return string.Empty;
			return string.Join(", ", UserP.Roles);
		}
	}

	public User()
	{
		InitializeComponent();
	}

	private static void OnUserChanged(BindableObject bindable, object oldValue, object newValue)
	{
		var user = (User)bindable;
		user.OnPropertyChanged(nameof(UserStatus));
		user.OnPropertyChanged(nameof(DoB));
		user.OnPropertyChanged(nameof(CreatedAt));
		user.OnPropertyChanged(nameof(Roles));
	}
}