using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BoulderGame;

public class RegisterViewModel : INotifyPropertyChanged
{
    private string _login = "";
    private string _password = "";
    private string _confirmpassword = "";

    public string Login
    {
        get => _login;
        set
        {
            _login = value;
            OnPropertyChanged();
        }
    }
    public string Password
    {
        get => _password;
        set
        {
            _password = value;
            OnPropertyChanged();
        }
    }
    public string ConfirmPassword
    { 
        get => _confirmpassword;
        set 
        {
            _confirmpassword = value;
            OnPropertyChanged();
        }
    }
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}