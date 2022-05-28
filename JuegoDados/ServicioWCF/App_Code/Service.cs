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
	Juego juego = new Juego();
	public string Jugar(List<int> lista)
    {
		return "";
    }

	public List<int> ObtenerNumeros(Random rnd)
    {
		//return juego.ObtenerNumeros(rnd);
    }
}

public class Juego
{
    public int Puntos { get; set; }
    public int[] Numeros{ get; set; }

	public void SumarPuntos()
    {

    }

	public  int[] ObtenerNumeros(Random rnd)
	{
		int dados = 5;

		int[] numeros = ObtenerArray(rnd, dados);

		Numeros = numeros;

		return numeros;
	}
	int[] ObtenerArray(Random rnd, int dados)
	{
		int[] numeros = new int[6];

		for (int i = 0; i < dados; i++)
		{
			numeros[i] = rnd.Next(1, 7);
		}

		return numeros;
	}
}
