using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SQLite;

namespace Plan737
{
	 class SQLite
	 {
		  private SQLiteConnection sql_con;

		  public string[] bestRunway(int dirViento, string icao)
		  {
				string consulta = "select * FROM runways where abs(" + dirViento.ToString() + "-dir) = (select min( abs(" + dirViento.ToString() + "-dir)) from runways WHERE large = (select max(large) from runways where icao='" + icao.ToUpper() + "')) AND icao = '" + icao.ToUpper() + "'";
				SQLiteCommand cmd = new SQLiteCommand(consulta, sql_con);
				SQLiteDataReader datos = cmd.ExecuteReader();
				string[] salida = new string[3];
				Console.WriteLine(dirViento + ";" + icao);
				if (datos.Read())
				{
					 salida[0] = datos[2].ToString();
					 salida[1] = datos[3].ToString();
					 salida[2] = datos[4].ToString();
					 return salida;
				}
				return null;
		  }

		  public string[] longRunway(string icao)
		  {
				string consulta = "SELECT * FROM RUNWAYS WHERE LARGE = (select max(large) from runways where icao='"+ icao  +"') AND ICAO='" + icao + "'";
				SQLiteCommand cmd = new SQLiteCommand(consulta, sql_con);
				SQLiteDataReader datos = cmd.ExecuteReader();
				string[] salida = new string[3];
				if (datos.Read())
				{
					 salida[0] = datos[2].ToString();
					 salida[1] = datos[3].ToString();
					 salida[2] = datos[4].ToString();
					 return salida;
				}
				return null;
		  }

		  public string[] airport(string icao)
		  {
				string consulta = "select name, elev, lat, lon from airports where icao='" + icao.ToUpper() + "'";
            SQLiteCommand cmd = new SQLiteCommand(consulta, sql_con);
            SQLiteDataReader datos = cmd.ExecuteReader();
				string[] salida = new string[4];
				if (datos.Read())
				{
					 salida[0] = datos[0].ToString();
					 salida[1] = datos[1].ToString();
					 salida[2] = datos[2].ToString();
					 salida[3] = datos[3].ToString();
					 return salida;
				}
				return null;
		  }

		  public void SetConnection(string file)
		  {
				sql_con = new SQLiteConnection("Data Source="+ file +";Version=3;New=False;Compress=True;");
				sql_con.Open();
		  }
	 }
}
