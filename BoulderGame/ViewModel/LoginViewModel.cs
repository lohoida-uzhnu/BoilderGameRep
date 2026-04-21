using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BoulderGame;

public class LoginViewModel : INotifyPropertyChanged
{
    private string _login = "";
    private string _password = "";

    public string Login
    {
        get => _login;
        set { _login = value; OnPropertyChanged(); }
    }

    public string Password
    {
        get => _password;
        set { _password = value; OnPropertyChanged(); }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}