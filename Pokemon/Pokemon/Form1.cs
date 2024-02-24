using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;


namespace winform
{
    public partial class Form1 : Form
    {

        private List<Pokemon> listaPokemons;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Cargar();

        }
        private void dgvPokemons_SelectionChanged(object sender, EventArgs e)
        {
            Pokemon seleccionado = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem;
            cargarImagen(seleccionado.UrlImagen);



        }
       
        private void Cargar()
        {
            PokemonNegocio negocio = new PokemonNegocio();

            try
            {
                listaPokemons = negocio.listar();
                dgvPokemons.DataSource = listaPokemons;
                dgvPokemons.Columns["UrlImagen"].Visible = false;
                cargarImagen(listaPokemons[0].UrlImagen);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void cargarImagen(string imagen)
        {
            try
            {
                pbPokemons.Load(imagen);
            }
            catch (Exception )
            {

                pbPokemons.Load("https://editorial.unc.edu.ar/wp-content/uploads/sites/33/2022/09/placeholder.png");
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormAltaPokemon alta = new FormAltaPokemon();
            alta.ShowDialog();
            Cargar();
        }
    }
}
