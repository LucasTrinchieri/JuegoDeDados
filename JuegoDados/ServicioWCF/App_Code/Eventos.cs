using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Eventos
/// </summary>
public class Eventos : EventArgs
{
    public int Puntos { get; set; }
    public int DadosRestantes { get; set; }
    public bool Terminado { get; set; }
}