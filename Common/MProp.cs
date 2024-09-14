using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace InkWell.MAUI.Common;

public class MProp<T> : INotifyPropertyChanged
{
	private T _value;
	private string _error;
	private Action _onChange;

	public MProp()
	{ }

	public MProp(T value, string error) : this()
	{
		_value = value;
		_error = error;
	}

	public MProp(T value, string error, Action action) : this(value, error) => _onChange = action;

	public Action OnChange
	{
		set
		{
			_onChange = value;
		}
	}

	public string Error
	{
		get => _error;

		set
		{
			_error = value;
			OnPropertyChanged();
			OnPropertyChanged(nameof(HasError));
		}
	}

	public bool HasError => !string.IsNullOrEmpty(_error);

	public T Value
	{
		get => _value;

		set
		{
			_value = value;
			OnPropertyChanged();

			_onChange?.Invoke();
		}
	}

	public event PropertyChangedEventHandler? PropertyChanged;

	protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}