using System;


class Program
{
    static void Main()
    {

        Console.WriteLine("Qual a placa do seu veiculo?");
        string placaVeiculo = Console.ReadLine();

        if (placaVeiculo.Length != 7)
        {
            Console.WriteLine("Erro: A placa deve conter 7 caracteres!");
            return;
        }

        Console.WriteLine("Qual o valor da multa?");
        decimal valorMulta;
        try
        {
            valorMulta = Convert.ToDecimal(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Erro: O valor da multa deve ser um número válido (ex.: 130.50)!");
            return;
        }


        DateTime data = DateTime.Now;

        MostrarMulta(placaVeiculo, valorMulta, data);

        if (valorMulta > 200)

        {
            Console.WriteLine($"Condutor da placa {placaVeiculo} foi multado com uma multa Grave");
        }
        else
        {
            Console.WriteLine($"Condutor da placa {placaVeiculo} foi multado com uma multa Leve");
        }

        decimal valordeDesconto = CalcularDesconto(valorMulta, data);

        if (valordeDesconto < valorMulta)
        {
            Console.WriteLine($"Que otimo, devido ter pago antes do prazo, você recebeu um desconto de 10% na multa! Valor com desconto: R${valordeDesconto}");
        }

        Console.WriteLine("\nRegistrando sua multa no sistema ...");
        int contador = 1;
        while (contador <= 3)
        {
            Console.WriteLine($"Multa {contador} registrada com sucesso.");
            contador++;
        }


    }

    static void MostrarMulta(string placaVeiculo, decimal valorMulta, DateTime data)
    {
        Console.WriteLine($"\nMulta registrada para a placa {placaVeiculo}, valor: R${valorMulta} na data: {data.ToShortDateString()}");
    }
    static decimal CalcularDesconto(decimal valorMulta, DateTime data)
    {
        if (data.Date == DateTime.Now.Date)
        {
            return valorMulta * 0.9m;
        }

        return valorMulta;
    }
}
