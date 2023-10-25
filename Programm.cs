using System;
namespace Sistema_de_Referencia
{
    public enum TipoDCoordenadas { Geograficas, Cilindricas, Esfericas, Cartesianas }
    public abstract class Punto
    {
        public TipoDCoordenadas Tipo { get; set; }
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
        public CooEsfericas(double modulo, double teta, double fi)
        {
            Modulo = modulo;
            Teta = teta;
            Fi = fi;
            Tipo = TipoDCoordenadas.Esfericas;
        }


        public double Modulo { get; }
        public double Teta { get; }
        public double Fi { get; }
    }
    public class CooCilindrica : Punto
    {
        public CooCilindrica(double modulo, double fi, double z)
        {
            Modulo = modulo;
            Z = z;
            Fi = fi;
            Tipo = TipoDCoordenadas.Cilindricas;
        }


        public double Modulo { get; }
        public double Z { get; }
        public double Fi { get; }
    }
    public class CooGeograficas : Punto

    {
        public CooGeograficas(double coordenadasEO, char EoO, double coordenadasNS, char noS)
        {
            CoordenadasNS = coordenadasNS;
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

    public class Convert
    {
        public static CooCartesiana Construir_Punto_Cartesiana(List<string> parametros)
        {
            double x = double.Parse(parametros[0]);
            double y = double.Parse(parametros[1]);
            double z = double.Parse(parametros[2]);
            return new CooCartesiana(x, y, z);
        }
        public static CooEsfericas Construir_Punto_Esferico(List<string> parametros)
        {
            double modulo = double.Parse(parametros[0]);
            double teta = double.Parse(parametros[1]);
            double fi = double.Parse(parametros[2]);
            return new CooEsfericas(modulo, teta, fi);
        }
        public static CooCilindrica Construir_Punto_Cilindrica(List<string> parametros)
        {
            double modulo = double.Parse(parametros[0]);
            double fi = double.Parse(parametros[1]);
            double z = double.Parse(parametros[2]);
            return new CooCilindrica(modulo, fi, z);
        }
        public static CooGeograficas Construir_Punto_Geografica(List<string> parametros)
        {
            double coordenadasEO = double.Parse(parametros[0]);
            char EsteoOeste = parametros[1][0];
            double coordenadasNS = double.Parse(parametros[2]);
            char NorteoSur = parametros[3][0];
            return new CooGeograficas(coordenadasEO, EsteoOeste, coordenadasNS, NorteoSur);
        }
        public static List<string> Convertir(List<string> parametros, string TipoDPartida, string TipoDLlegada)
        {

            switch (TipoDPartida)
            {
                case "Cartesiana":
                    {
                        CooCartesiana pepillo = Construir_Punto_Cartesiana(parametros);
                        switch (TipoDLlegada)
                        {
                            case "Esféricas":
                                {
                                    CooEsfericas a = Implementacion.CartesianasAEsfericas(pepillo);
                                    List<string> componentes = new();
                                    componentes.Add(a.Modulo.ToString());
                                    componentes.Add(a.Teta.ToString());
                                    componentes.Add(a.Fi.ToString());
                                    return componentes;
                                }
                            case "Geográficas":
                                {
                                    CooGeograficas b = Implementacion.CartesianasAGeograficas(pepillo);
                                    List<string> componentes = new();
                                    componentes.Add(b.CoordenadasEO.ToString());
                                    componentes.Add(b.EsteoOeste.ToString());
                                    componentes.Add(b.CoordenadasNS.ToString());
                                    componentes.Add(b.NoS.ToString());
                                    return componentes;
                                }
                            default:
                                {
                                    CooCilindrica c = Implementacion.CartesianasACilindricas(pepillo);
                                    List<string> componentes = new();
                                    componentes.Add(c.Modulo.ToString());
                                    componentes.Add(c.Fi.ToString());
                                    componentes.Add(c.Z.ToString());
                                    return componentes;
                                }
                        }
                    }
                case "Esféricas":
                    {
                        CooEsfericas pepillo = Construir_Punto_Esferico(parametros);
                        switch (TipoDLlegada)
                        {
                            case "Cartesiana":
                                {
                                    CooCartesiana a = Implementacion.EsfericasACartesianas(pepillo);
                                    List<string> componentes = new();
                                    componentes.Add(a.X.ToString());
                                    componentes.Add(a.Y.ToString());
                                    componentes.Add(a.Z.ToString());
                                    return componentes;
                                }
                            case "Geográficas":
                                {
                                    CooCartesiana b = Implementacion.EsfericasACartesianas(pepillo);
                                    CooGeograficas g = Implementacion.CartesianasAGeograficas(b);
                                    List<string> componentes = new();
                                    componentes.Add(g.CoordenadasEO.ToString());
                                    componentes.Add(g.EsteoOeste.ToString());
                                    componentes.Add(g.CoordenadasNS.ToString());
                                    componentes.Add(g.NoS.ToString());
                                    return componentes;
                                }
                            default:
                                {
                                    CooCartesiana x = Implementacion.EsfericasACartesianas(pepillo);
                                    CooCilindrica c = Implementacion.CartesianasACilindricas(x);
                                    List<string> componentes = new();
                                    componentes.Add(c.Modulo.ToString());
                                    componentes.Add(c.Fi.ToString());
                                    componentes.Add(c.Z.ToString());
                                    return componentes;
                                }
                        }
                    }
                case "Geográficas":
                    {
                        CooGeograficas pepillo = Construir_Punto_Geografica(parametros);
                        switch (TipoDLlegada)
                        {
                            case "Cartesianas":
                                {
                                    CooEsfericas d = Implementacion.GeograficasAEsfericas(pepillo);
                                    CooCartesiana e = Implementacion.EsfericasACartesianas(d);
                                    List<string> componentes = new();
                                    componentes.Add(e.X.ToString());
                                    componentes.Add(e.Y.ToString());
                                    componentes.Add(e.Z.ToString());
                                    return componentes;
                                }
                            case "Esféricas":
                                {
                                    CooEsfericas d = Implementacion.GeograficasAEsfericas(pepillo);
                                    List<string> componentes = new();
                                    componentes.Add(d.Modulo.ToString());
                                    componentes.Add(d.Teta.ToString());
                                    componentes.Add(d.Fi.ToString());
                                    return componentes;
                                }
                            default:
                                {
                                    CooEsfericas d = Implementacion.GeograficasAEsfericas(pepillo);
                                    CooCartesiana e = Implementacion.EsfericasACartesianas(d);
                                    CooCilindrica x = Implementacion.CartesianasACilindricas(e);
                                    List<string> componentes = new();
                                    componentes.Add(x.Modulo.ToString());
                                    componentes.Add(x.Fi.ToString());
                                    componentes.Add(x.Z.ToString());
                                    return componentes;
                                }
                        }
                    }
                default:
                    {
                        CooCilindrica pepillo = Construir_Punto_Cilindrica(parametros);
                        switch (TipoDLlegada)
                        {
                            case "Cartesiana":
                                {
                                    CooCartesiana f = Implementacion.CilindricasACartesianas(pepillo);
                                    List<string> componentes = new();
                                    componentes.Add(f.X.ToString());
                                    componentes.Add(f.Y.ToString());
                                    componentes.Add(f.Z.ToString());
                                    return componentes;
                                }
                            case "Esféricas":
                                {
                                    CooCartesiana f = Implementacion.CilindricasACartesianas(pepillo);
                                    CooEsfericas e = Implementacion.CartesianasAEsfericas(f);
                                    List<string> componentes = new();
                                    componentes.Add(e.Modulo.ToString());
                                    componentes.Add(e.Teta.ToString());
                                    componentes.Add(e.Fi.ToString());
                                    return componentes;
                                }
                            default:
                                {
                                    CooCartesiana f = Implementacion.CilindricasACartesianas(pepillo);
                                    CooGeograficas e = Implementacion.CartesianasAGeograficas(f);
                                    List<string> componentes = new();
                                    componentes.Add(e.CoordenadasEO.ToString());
                                    componentes.Add(e.EsteoOeste.ToString());
                                    componentes.Add(e.CoordenadasNS.ToString());
                                    componentes.Add(e.NoS.ToString());
                                    return componentes;
                                }
                        }
                    }
            }
        }

    }

}

