using System;
using System.Collections.Generic;
using System.Text;

namespace Plan737
{
    class Plan
    {
		  public float tiempoPlan;

		  public string icaoOrigen;
		  public string nombreOrigen;
		  public string pistaOrigen;
		  public int dirPistaOrigen;
		  public int largoPistaOrigen;
		  public int elevPistaOrigen;	  
		  public double latOrigen;
		  public double lonOrigen;
		  public string metarOrigen;

		  public string icaoDestino;
		  public string nombreDestino;
		  public string pistaDestino;
		  public int dirPistaDestino;
		  public int largoPistaDestino;
		  public int elevPistaDestino;	  
		  public double latDestino;
		  public double lonDestino;
		  public string metarDestino;

		  public double disReal;
		  public double disManiobra;
		  public double disVuelo;

		  public int pasajeros;
		  public int lbPasajeros;
		  public int bodega1;
		  public int bodega2;
		  public int lbBodega;

		  public int ZFW;

        public int altCrucero;

		  public int altAscenso;
		  public int disAscenso;
        public int comAscenso;

		  public int disCrucero;
		  public int comCrucero;

		  public int altDescenso;
		  public int disDescenso;
		  public int comDescenso;

		  public int comUsar;
        public int comReserva;

		  public int comTotal;

        public int TOW;

		  public Plan()
		  {
				comReserva = 6000;
				ZFW = 0;
				disVuelo = 0.0;
				latDestino = 0.0;
				lonDestino = 0.0;
		  }
    }
}
