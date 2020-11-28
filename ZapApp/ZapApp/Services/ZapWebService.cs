using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZapApp.Models;

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

            if (_instance == null)
            {
                _instance = new ZapWebService();
            }
            return _instance;
        }

        private ZapWebService()
        {
            _connection.On<bool, Usuario, string>("ReceberLogin", (sucesso, usuario, msg) =>
            {
                if (sucesso)
                {
                    UsuarioManager.SetUsuarioLogado(usuario);

                    Task.Run(async () => { await Entrar(usuario); });

                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        App.Current.MainPage = new ListagemUsuarios();
                    });
                }
                else
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        //((Login)((Inicio)App.Current.MainPage).Children[0]).SetMensagem(msg);
                        var inicioPage = ((Inicio)App.Current.MainPage);
                        var loginPage = ((Login)inicioPage.Children[0]);
                        loginPage.SetMensagem(msg);
                    });
                }
            });

            _connection.On<bool, Usuario, string> ("ReceberCadastro", (sucesso, Usuario, msg) => {
                if (sucesso)
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() => {
                        var inicioPage = ((Inicio)App.Current.MainPage);
                        var loginPage = (Cadastro)inicioPage.Children[1];
                        loginPage.SetMensagem(msg, false);
                    });
                }
                else
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() => {
                        var inicioPage = ((Inicio)App.Current.MainPage);
                        var loginPage = (Cadastro)inicioPage.Children[1];
                        loginPage.SetMensagem(msg, true);
                    });
                }
            });
        }

        public async Task Login(Usuario usuario)
        {
            await _connection.InvokeAsync("Login", usuario);
        }

        public async Task Cadastrar(Usuario usuario)
        {
            await _connection.InvokeAsync("Cadastrar", usuario);
        }

        public async Task Sair(Usuario usuario)
        {
            await _connection.InvokeAsync("DelConnectionIdDoUsuario", usuario);
        }

        public async Task Entrar(Usuario usuario)
        {
            await _connection.InvokeAsync("AddConnectionIdDoUsuario");
        }
    }
}
