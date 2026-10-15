using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Interfaz_ChavasPollo_proyecto
{//Al crear la clase nos evitamos tener que escribir tanto para llamar a la base de datos solo
 //la llamamos con conexion.cadena
    public class Conexion
    {
      
        public static string cadena =
            @"Server=localhost\SQLEXPRESS;
            Database=proyectoFinal_ChavasPollo;
            Trusted_Connection=True;
            TrustServerCertificate=True;";
    }
}
    

