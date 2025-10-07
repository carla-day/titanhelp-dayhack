namespace TitanHelpDesk.Services
{
    public class AlertService
    {
        public event Action<string, string>? OnShow;

        public void Success(string message) => OnShow?.Invoke("success", message);
        public void Error(string message) => OnShow?.Invoke("danger", message);
        public void Info(string message) => OnShow?.Invoke("info", message);
        public void Warning(string message) => OnShow?.Invoke("warning", message);
    }
}
