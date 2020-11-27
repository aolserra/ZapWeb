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
    public partial class ListagemMensagens : ContentPage
    {
        public ListagemMensagens()
        {
            InitializeComponent();
        }
    }

    public class ListagemMensagensViewModel
    {
        public List<Mensagem> Mensagems { get; set; }

        public ListagemMensagensViewModel()
        {
            Mensagems = MockMensagens();
        }

        private List<Mensagem> MockMensagens()
        {
            return new List<Mensagem>()
            {
                new Mensagem { NomeGrupo = "1", Texto = "Olá mundo 1!", Usuario = new Usuario { Id = 1, Nome = "Anderson" } },
                new Mensagem { NomeGrupo = "2", Texto = "Olá mundo 2!", Usuario = new Usuario { Id = 2, Nome = "Viviane" } },
                new Mensagem { NomeGrupo = "3", Texto = "Olá mundo 3!", Usuario = new Usuario { Id = 1, Nome = "Anderson" } },
                new Mensagem { NomeGrupo = "4", Texto = "Olá mundo 4!", Usuario = new Usuario { Id = 2, Nome = "Viviane" } },
                new Mensagem { NomeGrupo = "5", Texto = "Olá mundo 5!", Usuario = new Usuario { Id = 1, Nome = "Anderson" } },
            };
        }
    }

    public class MensagemDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate EsquerdaTemplate { get; set; }
        public DataTemplate DireitaTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            Usuario usuarioLogado = new Usuario() { Id = 1, Nome = "Anderson" };
            
            return ((Mensagem)item).Usuario.Id == usuarioLogado.Id ? DireitaTemplate : EsquerdaTemplate;
        }
    }
}