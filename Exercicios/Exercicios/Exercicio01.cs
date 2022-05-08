using Unicesumar.Exercicios.Exercicios;

namespace Exercicios.Exercicios;

/// <summary>
/// Ler N marcações de litros e apontar a maior quantia em metros cúbicos
/// </summary>
public class Exercicio01
{
    public static void Run()
    {
        const string escape = "N";

        double lastVolume = 0;  
        
        string input = string.Empty;

        while(input != escape)
        {
            try
            {
                var liters = Utils.GetInputDouble("Digite o valor de litros:");

                lastVolume = liters > lastVolume ? liters : lastVolume;

                input = Utils.GetInputString("Deseja inserir outro valor? Y/N");
            }
            catch (Exception)
            {
                Console.WriteLine("Houve um erro de entrada, tente novamente.");
            }
        }

        Console.WriteLine($"\nO maior volume é {(lastVolume / 1000).ToString("0.000")}M³");

        Console.ReadKey();
    }
}