using System;
namespace Jose
{

    public enum TipoDCoordenadas { Geograficas, Cilindricas, Esfericas, Cartesianas }
    public abstract class Punto
    {
        public TipoDCoordenadas Tipo { get;set; }
    }
    public class CooCartesiana : Punto
    {
        public CooCartesiana(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
            Tipo = TipoDCoordenadas.Cartesianas;
        }
        

        public double X { get; }
        public double Y { get; }
        public double Z { get; }
    }
    public class CooEsfericas : Punto
    {
        public CooEsfericas(double modulo,  double omega,double cita)
        {
           Modulo  = modulo;
            Cita = cita;
            Omega = omega;
            Tipo = TipoDCoordenadas.Esfericas;
        }
        

        public double Modulo { get; }
        public double Cita { get; }
        public double Omega { get; }
    }
    public class CooCilindrica : Punto
    {
        public CooCilindrica(double modulo,  double omega,double z)
        {
           Modulo  = modulo;
            Z = z;
            Omega = omega;
            Tipo = TipoDCoordenadas.Cilindricas;
        }
        

        public double Modulo { get; }
        public double Z { get; }
        public double Omega { get; }
    }
    public class CooGeograficas : Punto
    {
        public CooGeograficas(double coordenadasEO,  double coordenadasNS,char EoO,char noS)
        {
           CoordenadasNS  = coordenadasNS;
            CoordenadasEO = coordenadasEO;
            EsteoOeste = EoO;
            NoS = noS;
            Tipo = TipoDCoordenadas.Geograficas;
        }
        

        public double CoordenadasNS { get; }
        public double CoordenadasEO { get; }
        public char EsteoOeste { get; }
        public char NoS { get; }
    }

    public static class Convertir
    {
        public static 
    }
}
