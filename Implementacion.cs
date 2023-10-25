namespace Sistema_de_Referencia;

public class Implementacion
{
    public static CooCartesiana EsfericasACartesianas(CooEsfericas puntoEsferico)
    {
        double x = puntoEsferico.Modulo * Math.Sin(puntoEsferico.Teta) * Math.Cos(puntoEsferico.Fi);
        double y = puntoEsferico.Modulo * Math.Sin(puntoEsferico.Teta) * Math.Sin(puntoEsferico.Fi);
        double z = puntoEsferico.Modulo * Math.Cos(puntoEsferico.Teta);

        return new CooCartesiana(x, y, z);
    }

    public static CooCartesiana CilindricasACartesianas(CooCilindrica puntoCilindrico)
    {
        double x = puntoCilindrico.Modulo * Math.Cos(puntoCilindrico.Fi);
        double y = puntoCilindrico.Modulo * Math.Sin(puntoCilindrico.Fi);
        double z = puntoCilindrico.Z;

        return new CooCartesiana(x, y, z);
    }

    public static CooEsfericas CartesianasAEsfericas(CooCartesiana puntoCartesiano)
    {
        double modulo = Math.Sqrt(Math.Pow(puntoCartesiano.X, 2) + Math.Pow(puntoCartesiano.Y, 2) + Math.Pow(puntoCartesiano.Z, 2));

        double teta = puntoCartesiano.Z == 0 ? Math.PI / 2 : Math.Atan((Math.Sqrt(Math.Pow(puntoCartesiano.X, 2) + Math.Pow(puntoCartesiano.Y, 2))) / puntoCartesiano.Z);

        double fi = puntoCartesiano.X == 0 ? Math.PI / 2 : Math.Atan(puntoCartesiano.Y / puntoCartesiano.X);

        return new CooEsfericas(modulo, teta, fi);
    }

    public static CooCilindrica CartesianasACilindricas(CooCartesiana puntoCartesiano)
    {
        double modulo = Math.Sqrt(Math.Pow(puntoCartesiano.X, 2) + Math.Pow(puntoCartesiano.Y, 2) + Math.Pow(puntoCartesiano.Z, 2));

        double teta = puntoCartesiano.X == 0 ? Math.PI / 2 : Math.Atan(puntoCartesiano.Y / puntoCartesiano.X);

        double z = puntoCartesiano.Z;

        return new CooCilindrica(modulo, teta, z);
    }

    public static CooEsfericas GeograficasAEsfericas(CooGeograficas puntoGeografico)
    {
        double teta;
        double fi;
        
        if (puntoGeografico.NoS == 'N' && puntoGeografico.EsteoOeste == 'E')
        {
            teta = Math.PI/2 - ToRadian(puntoGeografico.CoordenadasNS);
            fi = ToRadian(puntoGeografico.CoordenadasEO);
        }

        else if (puntoGeografico.NoS == 'N' && puntoGeografico.EsteoOeste == 'O')
        {
            teta = Math.PI/2 - ToRadian(puntoGeografico.CoordenadasNS);
            fi = 2* Math.PI - ToRadian(puntoGeografico.CoordenadasEO);
        }

        else if (puntoGeografico.NoS == 'S' && puntoGeografico.EsteoOeste == 'E')
        {
            teta = Math.PI/2 + ToRadian(puntoGeografico.CoordenadasNS);
            fi = ToRadian(puntoGeografico.CoordenadasEO);
        }
        
        else
        {
            teta = Math.PI/2 + ToRadian(puntoGeografico.CoordenadasNS);
            fi = 2* Math.PI - ToRadian(puntoGeografico.CoordenadasEO);
        }

        return new CooEsfericas(6371, teta, fi);
    }

    public static CooGeograficas CartesianasAGeograficas(CooCartesiana puntoCartesiano)
    {
        CooEsfericas esferico = CartesianasAEsfericas(puntoCartesiano);
        
        double latitud;
        double longitud;
        char Latitud;
        char Longitud;

        double teta = ToDegrees(esferico.Teta);
        double phi = ToDegrees(esferico.Fi);


        //noreste
        if (teta <= 90 && ( 90 <= phi || phi <= 270))
        {
            latitud = 90 - teta;
            longitud = phi-90;
            Latitud= 'N';
            Longitud = 'E';
            
        }
        //noroeste
        else if (teta <= 90 && ( phi < 90 || (270 < phi && phi <= 360 ) ) )
        {
            latitud = 90 - teta;
            
            if (phi<90)
            {
                longitud = 90- phi;
            }
            else
            {
                longitud = 360-phi;
            }
            Latitud= 'N';
            Longitud = 'O';
        }
        //sudeste
        else if (teta > 90 && ( 90 <= phi && phi <= 270))
        {
            latitud=teta-90;
            longitud = phi-90; 
            Latitud= 'S';
            Longitud = 'E';
        }
        //sudoeste
        else
        {
            latitud = teta -90;
            longitud = 360 - phi; 
            Latitud = 'S';
            Longitud = 'O';
        }
        return new CooGeograficas(longitud, Longitud, latitud, Latitud);
        
    }
    public static double ToRadian(double degree)
    {
        return (degree*Math.PI)/180;
    }


    public static double ToDegrees(double radian)
    {
        return (180*radian)/Math.PI;
    }

    


}