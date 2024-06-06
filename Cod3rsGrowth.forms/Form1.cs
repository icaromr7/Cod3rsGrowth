using Cod3rsGrowth.dominio;
using Cod3rsGrowth.Servico;
using System.ComponentModel;
using System.Globalization;
using Cod3rsGrowth.infra;
using Cod3rsGrowth.testes;

namespace Cod3rsGrowth.forms
{
    public partial class Form1 : Form
    {
        List<Anime> listaDeAnimes;
        List<Genero> listaGeneros;

        public Form1()
        {
            InitializeComponent();
            load();
        }

        private void load()
        {
            listaDeAnimes = new List<Anime>()
            {
                new Anime()
                {
                Id = 1,
                Nome = "Anime1",
                Sinopse = "Sinopse1",
                GenerosIds = new List<int>() { 1, 2 },
                DataLancamento = new DateTime(2024, 5, 15),
                Nota = 7.8m,
                StatusDeExibicao = Anime.Status.EmExibicao
                }
            };
            dataAnime.DataSource = listaDeAnimes;
            listaGeneros = new List<Genero>() {
                new Genero() {
                    Id = 1,
                    Nome = "Aventura"
                    }
                };
            dataGenero.DataSource = listaGeneros;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
