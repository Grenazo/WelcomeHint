using Exiled.API.Interfaces;

namespace WelcomPlugin
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        public string WelcomeMessage { get; set; } = "Welcome to the server!";
        public float Duration { get; set; } = 5.0f;
        public int Priority { get; set; } = 5;
    }
}