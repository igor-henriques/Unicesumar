namespace Unicesumar.Exercicios.Exercicios;

/// <summary>
/// Algoritmo para controle de abastecimento de aeronaves
/// Imagine que voce trabalhe na área de Tecnologia de uma companhia aérea de grande porte e foi solicitado a sua área que criasse um algoritmo para controle de abastecimento das aeronaves antes dos voos.Um Boeing 737-800 por exemplo, pode gastar em média 3,6 litros por km de voo.O gasto de uma aeronave de grande porte é tanto que a medição muda de eixo, sendo utilizado litros por quilômetros, diferente do que estamos acostumados a calcular nos automóveis que é quilômetros por litro. Um trecho de 1100km, como por exemplo de São Paulo a Porto Alegre precisaria de 3960 litros, sem contar a margem de segurança e outos fatores que podem alterar a quantidade.

/// Para criação do algoritmo solicitado deverão ser considerados os seguintes dados para o calculo desejado, são eles:
///   - Média da aeronave em litros por quilômetros
///   - Capacidade máxima em litros do tanque
///    - Quantidade de quilômetros do trecho planejado
///    - Quantidade de quilômetros do trecho alternativo
///    - Quantidade de combustível já na aeronave

/// O algoritmo deve conter as seguintes regras
///    - Uma aeronave deve sempre ser abastecida considerando o trecho planejado + trecho alternativo, visto que se o aeroporto de destino estiver com problemas, uma rota alternativa deverá ser realizada.
///    - Além do trecho total, uma margem de 30% de combustível deverá ser adicionada, para que qualquer emergência a aeronave esteja com uma quantidade segura de combustível.
///    - Se o trecho total mais a margem de segurança, extrapolarem a capacidade máxima de combustível do tanque da aeronave, uma mensagem de alerta deve ser mostrada na tela, dizendo a seguinte mensagem “Voo Reprovado, reveja seu planejamento.”. Caso contrário mostrar "Voo Aprovado, bom voo!"
///    - Se o tanque suportar o trecho total mais a margem de segurança o algoritmo deverá mostrar na tela o valor do trecho principal, trecho alternativo, total do trecho com a margem de segurança, quantidade de combustível necessária para o trecho e quantidade necessária de abastecimento.
/// </summary>
public class Exercicio02
{
    private record Aeronave
    {
        public Guid Guid { get; init; }
        public float MediaConsumoLitrosPorKM { get; init; }
        public float CapacidadeMaximaTanqueLitros { get; init; }
        public float QuantidadeCombustivelAtual { get; init; }
        public Trecho TrechoPrincipal { get; init; }
        public Trecho TrechoAlternativo { get; init; }

        public float ObterQuantiaCombustivelReabastecimento()
        {
            var parcial = (this.TrechoPrincipal.DistanciaKM + this.TrechoAlternativo.DistanciaKM - this.QuantidadeCombustivelAtual);

            return parcial + parcial * 0.3f;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Distância do trecho principal: {this.TrechoPrincipal.DistanciaKM}KM\n");
            sb.AppendLine($"Distância do trecho alternativo: {this.TrechoAlternativo.DistanciaKM}KM\n");
            sb.AppendLine($"Distância total do trecho: {(this.TrechoPrincipal.DistanciaKM + this.TrechoAlternativo.DistanciaKM + (this.TrechoPrincipal.DistanciaKM + this.TrechoAlternativo.DistanciaKM) * 0.3f).ToString("0.00")}KM\n");
            sb.AppendLine($"Combustível necessário para todo o trajeto: {((this.TrechoPrincipal.DistanciaKM + this.TrechoAlternativo.DistanciaKM + (this.TrechoPrincipal.DistanciaKM + this.TrechoAlternativo.DistanciaKM) * 0.3f) / this.MediaConsumoLitrosPorKM).ToString("0.000")}L\n");

            return sb.ToString();
        }
    }

    private record Trecho
    {
        public Guid Guid { get; init; }
        public float DistanciaKM { get; init; }
    }

    public static void Run()
    {
        Aeronave boeing737 = new Aeronave()
        {
            Guid = Guid.NewGuid(),
            MediaConsumoLitrosPorKM = 3.6f,
            CapacidadeMaximaTanqueLitros = 14_628, 
            QuantidadeCombustivelAtual = 1230,
            TrechoPrincipal = new() { Guid = Guid.NewGuid(), DistanciaKM = 5000 },
            TrechoAlternativo = new() { Guid = Guid.NewGuid(), DistanciaKM = 100 }
        };

        var quantiaCombustivelReabastecer = boeing737.ObterQuantiaCombustivelReabastecimento();

        if (quantiaCombustivelReabastecer > boeing737.CapacidadeMaximaTanqueLitros)
        {
            Console.WriteLine("VOO REPROVADO\n");
            Console.WriteLine($"QUANTIA DE COMBUSTÍVEL NECESSÁRIA PARA O TRAJETO ({quantiaCombustivelReabastecer}L) MAIOR QUE A CAPACIDADE MÁXIMA DO TANQUE ({boeing737.CapacidadeMaximaTanqueLitros}L)");
            return;
        }

        Console.WriteLine("VOO APROVADO");

        Console.WriteLine(boeing737.ToString()); 
    }
}
