using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
public class Service : IService
{
	public string GetData(int value)
	{
		return string.Format("You entered: {0}", value);
	}

	public CompositeType GetDataUsingDataContract(CompositeType composite)
	{
		if (composite == null)
		{
			throw new ArgumentNullException("composite");
		}
		if (composite.BoolValue)
		{
			composite.StringValue += "Suffix";
		}
		return composite;
	}

	const int dados = 5;

	public EventHandler<Eventos> juegoTerminado;

	public Respuesta Jugar(Random rnd)
    {
		int[] numeros = ObtenerNumeros(rnd);

        if (numeros.Distinct().Count() == dados)
        {
            if (!numeros.Contains(1) && numeros.Contains(6))
            {
				Juego.Instancia.SumarPuntos(20); //escalera
				return new Respuesta(Juego.Instancia.ObtenerPuntos(), 0, false);

				//MostrarEvento(0, false);
			}
			else
            {
				Juego.Instancia.SumarPuntos(-20); //papa
				return new Respuesta(Juego.Instancia.ObtenerPuntos(), 0, true);

				//MostrarEvento(0, true);
			}
		}
        else
        {
			Juego.Instancia.SumarPuntos(numeros.ValidarRepetidos().Suma); //repetidos

			int res = 5 - numeros.ValidarRepetidos().CantRepetidos;

			return new Respuesta(Juego.Instancia.ObtenerPuntos(), res, res == 1);

			//MostrarEvento(res, res == 1);
        }
    }

	void MostrarEvento(int dados, bool termino)
    {
		this.juegoTerminado(this, new Eventos()
        {
			Puntos = Juego.Instancia.ObtenerPuntos(),
			DadosRestantes = dados,
			Terminado = termino
        });
    }

	int[] ObtenerNumeros(Random rnd)
    {
		int[] numeros = new int[6];

		for (int i = 0; i < numeros.Length; i++)
		{
			numeros[i] = rnd.Next(1, 7);
		}

		Juego.Instancia.AgregarNumeros(numeros);

		return numeros;
	}
}

public sealed class Juego
{
	private static Juego instancia = null;
	private Juego() { }
	public static Juego Instancia
    {
        get
        {
            if (instancia == null)
            {
				instancia = new Juego();
			}

			return instancia;
        }
    }

    static int Puntos { get; set; }
    static List<int> Numeros{ get; set; }

	public void SumarPuntos(int puntos)
    {
		Puntos += puntos;
    }

	public void AgregarNumeros(int[] numeros)
    {
		Numeros = numeros.ToList();
    }

	public int ObtenerPuntos()
    {
		return Puntos;
    }
}

public class Respuesta
{
    public int Puntos { get; set; }
    public bool Termino { get; set; }
    public int DadosRestantes { get; set; }

	public Respuesta()
	{

	}

	public Respuesta(int puntos, int restantes, bool termino)
	{
		Puntos = puntos;
		DadosRestantes = restantes;
		Termino = termino;
	}
}
