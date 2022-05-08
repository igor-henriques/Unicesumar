namespace Unicesumar.Exercicios;

internal class Utils
{
    public static string GetInputString(string message)
    {
        Console.WriteLine(message);
        return Console.ReadLine()!.ToUpper();
    }

    public static int GetInputInt(string message)
    {
        Console.WriteLine(message);

        if (!int.TryParse(Console.ReadLine()!.ToUpper(), out int result))
        {
            Console.WriteLine("Entrada incorreta");
        }

        return result;
    }

    public static double GetInputDouble(string message)
    {
        Console.WriteLine(message);

        if (!double.TryParse(Console.ReadLine()!.ToUpper(), out double result))
        {
            Console.WriteLine("Entrada incorreta");
        }

        return result;
    }

    public static float GetInputFloat(string message)
    {
        Console.WriteLine(message);

        if (!float.TryParse(Console.ReadLine()!.ToUpper(), out float result))
        {
            Console.WriteLine("Entrada incorreta");
        }

        return result;
    }

    public static decimal GetInputDecimal(string message)
    {
        Console.WriteLine(message);

        if (!decimal.TryParse(Console.ReadLine()!.ToUpper(), out decimal result))
        {
            Console.WriteLine("Entrada incorreta");
        }

        return result;
    }

    public static char GetInputChar(string message)
    {
        Console.WriteLine(message);

        if (!char.TryParse(Console.ReadLine()!.ToUpper(), out char result))
        {
            Console.WriteLine("Entrada incorreta");
        }

        return result;
    }
}
