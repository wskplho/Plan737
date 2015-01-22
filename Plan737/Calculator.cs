using System;
using System.Collections.Generic;
using System.Text;

namespace Plan737
{
	 class Calculator
	 {
		  public static double distanciaReal(double lat1, double lat2, double lon1, double lon2)
		  {
				double real = 3963.191 * Math.Acos(Math.Cos(((Math.PI * lat1) / 100)) * Math.Cos(((Math.PI * lat2) / 100)) * Math.Cos(((Math.PI * lon2) / 100) - ((Math.PI * lon1) / 100)) + Math.Sin(((Math.PI * lat1) / 100)) * Math.Sin(((Math.PI * lat2) / 100))) * 0.868976240408186;
				return Math.Truncate(real);
		  }

		  public static double distanciaManiobra(double plan, double real)
		  {
				return Math.Truncate(plan - real);
		  }

		  public static int pesoPasajeros(int pasajeros)
		  {
				return pasajeros * 175;
		  }

		  public static int[] pesoBodega(double pasajeros)
		  {
				int[] salida = new int[3];
				salida[0] = (int)(pasajeros * 94.252 * 0.8);
				salida[1] = (int)(45.1219512195122 * ((pasajeros * 94.252 * 0.8) / 100));
				salida[2] = (int)(54.87804878048782 * ((pasajeros * 94.252 * 0.8) / 100));
				return salida;
		  }

		  public static int[] pesoBodega12(double pesoBodega)
		  {
				int[] salida = new int[2];
				salida[0] = (int)(45.1219512195122 * (pesoBodega / 100));
				salida[1] = (int)(54.87804878048782 * (pesoBodega / 100));
				return salida;
		  }

		  public static int[] combustible(double altCrucero, double elevOrigen, double elevDestino, double distancia)
		  {
				int[] salida = new int[9];

				salida[0] = (int)(altCrucero - elevOrigen);
				salida[1] = (int)((altCrucero - elevOrigen) / 300);
				salida[2] = (int)(((altCrucero - elevOrigen) / 1000) * 120);
				salida[3] = (int)(altCrucero - elevDestino);
				salida[4] = (int)((altCrucero - elevDestino) / 250);
				salida[5] = (int)(((altCrucero - elevDestino) / 1000) * 30);
				salida[6] = (int)(distancia - ((altCrucero - elevOrigen) / 300) - ((altCrucero - elevDestino) / 250));
				salida[7] = (int)((distancia - ((altCrucero - elevOrigen) / 300) - ((altCrucero - elevDestino) / 250)) * 16);
				salida[8] = salida[2] + salida[5] + salida[7] + 1000;

				return salida;
		  }

		  public static int libras2kilos(int libras)
		  {
				return (int)(libras*0.45359237);
		  }

		  public static int kilos2libras(int kilos)
		  {
				return (int)(kilos*2.20462262);
		  }
	 }
}
