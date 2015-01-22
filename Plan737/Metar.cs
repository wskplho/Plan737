using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;

namespace Plan737
{
	 class Metar
	 {
		  public static string metarDecoded(string icao)
		  {
				HttpWebRequest request = (HttpWebRequest)
				WebRequest.Create("http://weather.noaa.gov/pub/data/observations/metar/decoded/" + icao.ToUpper() + ".TXT");
				HttpWebResponse response = (HttpWebResponse) request.GetResponse();
				Stream resStream = response.GetResponseStream();
				string tempString = null;
				int count = 0;
				byte[] buf = new byte[8192];
				StringBuilder sb = new StringBuilder();
				do
				{
					 count = resStream.Read(buf, 0, buf.Length);
					 if (count != 0)
					 {
						  tempString = Encoding.ASCII.GetString(buf, 0, count);
						  sb.Append(tempString);
					 }
				}
				while (count > 0);
				string[] words = sb.ToString().Split('\n');
				string salida = "";
				for (int i = 1; i < words.Length - 3; i++)
				{
					 salida += words[i].ToString() + Environment.NewLine;
				}
				salida = salida.ToString().Substring(0, salida.Length - 1);
				return salida;
		  }

		  public static string dirViento(string icao)
		  {
				HttpWebRequest request = (HttpWebRequest)
				WebRequest.Create("http://weather.noaa.gov/pub/data/observations/metar/stations/" + icao.ToUpper() + ".TXT");
				HttpWebResponse response = (HttpWebResponse) request.GetResponse();
				Stream resStream = response.GetResponseStream();
				string tempString = null;
				int count = 0;
				byte[] buf = new byte[8192];
				StringBuilder sb = new StringBuilder();
				do
				{
					 count = resStream.Read(buf, 0, buf.Length);
					 if (count != 0)
					 {
						  tempString = Encoding.ASCII.GetString(buf, 0, count);
						  sb.Append(tempString);
					 }
				}
				while (count > 0);
				string[] metarLinea = sb.ToString().Split('\n');
				string[] metar = metarLinea[1].ToString().Split(' ');
				Console.WriteLine(metar);
				string[] regs = null;
				for (int i = 0; i < metar.Length; i++)
				{
					 if (ClassEreg.ereg("([0-9]{3}|VRB)([0-9]{2,3})G?([0-9]{2,3})?(KT|MPS|KMH)", metar[i], ref regs))
					 {
						  /* Wind Group */
						  //this.wind.b_no_data = false;

						  if (regs[1] == "VRB")
								return "VRB";
						  else
								return regs[1];
					 }
					 else if (ClassEreg.ereg("^([0-9]{3})V([0-9]{3})$", metar[i], ref regs))
					 {
						  /*
						  * Variable wind-direction
						  */
						  return ((System.Convert.ToDouble(regs[1]) + System.Convert.ToDouble(regs[2]))/2).ToString();
					 }
				}
				return "error";
		  }
	 }

	 public class ClassEreg
	 {
		  public static bool ereg(string pattern, string input_string, ref string[] strregs)
		  {
				if (input_string == "")
					 return false;
				if (!System.Text.RegularExpressions.Regex.IsMatch(input_string, pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
					 return false;
				System.Text.RegularExpressions.Match m = System.Text.RegularExpressions.Regex.Match(input_string, pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
				strregs = new string[m.Groups.Count];
				for (int cpt = 0; cpt < m.Groups.Count; cpt++)
				{
					 if (m.Groups[cpt].Captures.Count > 0)
						  strregs[cpt] = m.Groups[cpt].Captures[0].Value;
					 else
						  strregs[cpt] = "";
				}

				return true;
		  }
		  public static bool ereg(string pattern, string input_string)
		  {
				return System.Text.RegularExpressions.Regex.IsMatch(input_string, pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
		  }
	 }
}
