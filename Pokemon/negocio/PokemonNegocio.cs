﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;

namespace negocio
{   
    //clase para acceso a datos
      public class PokemonNegocio
    {
        public List<Pokemon> listar()
        {
            List<Pokemon> lista = new List<Pokemon>();

                SqlConnection conexion = new SqlConnection();
                SqlCommand comando = new SqlCommand();
                SqlDataReader lector;
            try
            {
                //cfg cadena de conexión

                conexion.ConnectionString = "server =.\\SQLEXPRESS; database=POKEDEX_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select Numero, Nombre, P.Descripcion, UrlImagen, E.Descripcion Tipo,D.Descripcion Debilidad  From POKEMONS P, ELEMENTOS E, ELEMENTOS D where E.id = P.IdTipo AND D.Id = P.IdDebilidad";
                comando.Connection = conexion;

                conexion.Open();

                lector = comando.ExecuteReader();


                while (lector.Read())
                {
                    Pokemon aux = new Pokemon();
                    aux.Numero = (int) lector["Numero"];
                    aux.Nombre = (string) lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];
                    aux.UrlImagen = (string)lector["UrlImagen"];
                    aux.Tipo = new Elemento();
                    aux.Tipo.Descripcion = (string)lector["Tipo"];
                    aux.Debilidad = new Elemento();
                    aux.Debilidad.Descripcion = (string)lector["Debilidad"];

                    lista.Add(aux);

                }

                conexion.Close();
                return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}