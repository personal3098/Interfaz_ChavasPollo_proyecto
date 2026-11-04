using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.Data.SqlClient;

using Microsoft.EntityFrameworkCore;
using Interfaz_ChavasPollo_proyecto.Data;

namespace Interfaz_ChavasPollo_proyecto
{
    public class Conexion
    {
        public static string cadena =
            @"Server=localhost\SQLEXPRESS;
              Database=proyectoFinal_ChavasPollo;
              Trusted_Connection=True;
              TrustServerCertificate=True;";

        public static ChavasPolloContext CrearContexto()
        {
            var opciones = new DbContextOptionsBuilder<ChavasPolloContext>();

            opciones.UseSqlServer(cadena);

            return new ChavasPolloContext(opciones.Options);
        }
    }
}
