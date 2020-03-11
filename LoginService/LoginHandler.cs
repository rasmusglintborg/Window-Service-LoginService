using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace LoginService
{
    class LoginInfo
    {
        public string username = "username";
        public string password = "password";
        

    }
    class LoginHandler
    {
        private readonly Task task;
        private HostControl hostControl;
        private readonly HttpClient client = new HttpClient();

        public LoginHandler()
        {
            task = new Task(Login);
        }

        private async void Login()
        {
            LoginInfo loginInfo = new LoginInfo();

            string json = JsonConvert.SerializeObject(loginInfo);
            
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "url";
            var response = await client.PostAsync(url, data);
            hostControl.Stop();
        }

        public bool Start(HostControl hostControl)
        {
            this.hostControl = hostControl;
            task.Start();
            return true;
        }
        public bool Stop()
        {
            return true;
        }
    }
}
