using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ZapApp.Services
{
    class ZapWebService
    {
        private static HubConnection _connection;
        private static ZapWebService _instance;


        public static ZapWebService GetInstance()
        {
            if (_connection == null)
            {
                _connection = new HubConnectionBuilder().WithUrl("https://xn--zapwebapwebaolserra-s1b.azurewebsites.net/ZapWebHub").Build();
            }
            if (_connection.State == HubConnectionState.Disconnected)
            {
                _connection.StartAsync();
            }
            _connection.Closed += async (error) =>
            {
                await Task.Delay(500);
                await _connection.StartAsync();
            };

            if(_instance == null)
            {
                _instance = new ZapWebService();
            }
            return _instance;
        }

        private ZapWebService()
        {
        }
    }
}
