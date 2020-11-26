using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZapApp.Models;

namespace ZapApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListagemUsuarios : ContentPage
    {
        public ListagemUsuarios()
        {
            InitializeComponent();
        }
    }

    public class ListagemUsuariosViewModel
    {
        public List<Usuario> Usuarios { get; set; }

        public ListagemUsuariosViewModel()
        {
            Usuarios = MockUsuarios();
        }

        private List<Usuario> MockUsuarios()
        {
            return new List<Usuario>()
            {
                new Usuario { Nome = "Anderson Serra", Email = "aolserra@gmail.com", Senha = "123456", IsOnline = false },
                new Usuario { Nome = "Viviane Barboza", Email = "vivianebarboza@live.com", Senha = "123456", IsOnline = false },
                new Usuario { Nome = "Jonas Serra", Email = "jonas123@gmail.com", Senha = "123456", IsOnline = false },
                new Usuario { Nome = "Fernando Serra", Email = "fernando123@gmail.com", Senha = "123456", IsOnline = false },
            };
        }
    }
}