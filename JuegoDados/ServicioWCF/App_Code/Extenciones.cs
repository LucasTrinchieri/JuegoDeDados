﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public static class Extenciones
{
    public static Resultado ValidarRepetidos(this int[] array)
    {
        array = array.OrderBy(x => x).ToArray();

        int suma = 0;

        int cant = 0;

        for (int i = 0; i < 5; i++)
        {
            if (array[i] == array[i + 1])
            {
                suma += cant == 0 ? array[i] + array[i + 1] : array[i + i];

                cant ++;
            }
        }

        return new Resultado(suma, cant);
    }
}

public class Resultado
{
    public int Suma { get; set; }
    public int CantRepetidos { get; set; }

    public Resultado()
    {

    }

    public Resultado(int suma, int cant)
    {
        Suma = suma;
        CantRepetidos = cant;
    }
}