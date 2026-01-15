namespace Kuros.Web.Services;

public class AuthService
{
    private bool _isAuthenticated = false;
    public bool IsAuthenticated => _isAuthenticated;

    public event Action? OnAuthStatusChanged;

    public bool Login(string username, string password)
    {
        // Hardcoded credentials
        if (username == "sreyas@gmail.com" && password == "sreyas@123")
        {
            _isAuthenticated = true;
            OnAuthStatusChanged?.Invoke();
            return true;
        }
        return false;
    }

    public void Logout()
    {
        _isAuthenticated = false;
        OnAuthStatusChanged?.Invoke();
    }
}
