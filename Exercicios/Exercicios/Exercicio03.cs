namespace Unicesumar.Exercicios.Exercicios;

/// <summary>
/// https://github.com/igor-henriques/Unicesumar/blob/master/Exercicios/Exercicios/Exercicio03.cs
/// Imagine então que você trabalha na área de desenvolvimento de software do seu estado, e você foi 
/// designado para registrar os dados de aplicação das vacinas. Nesta aplicação a pessoa responsável
/// precisará pegar do paciente as informações como nome, cpf, nome da vacina aplicada, número do lote 
/// e a data da aplicação.

///Este programa deve ser capaz de cadastrar as informações de aplicação de vacina, que em resumo são:
///    - Código(você fará o controle, não será digitado pelo usuário)
///    - Nome
///    - CPF
///    - Vacina
///    - Data(pode ser tratada como String)
///    - Numero Lote

///Para controlar este programa deverá ter um menu de opções como abaixo:
///    1 - Cadastrar Vacina
///    2 - Listar Aplicações
///    3 - Consultar por CPF
///    4 - Sair
/// </summary>
public class Exercicio03
{
    private static List<Vacina> vacinas = new List<Vacina>();

    private record Vacina
    {
        public Guid Guid { get; init; }
        public string PacienteNome { get; init; }
        public string PacienteCPF { get; init; }
        public string NomeVacina { get; init; }
        public DateTime DataAplicacaoVacina { get; init; }
        public long NumeroLote { get; init; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"\nCódigo {this.Guid}");
            sb.AppendLine($"Nome {this.PacienteNome}");
            sb.AppendLine($"CPF {this.PacienteCPF}");
            sb.AppendLine($"Vacina: {this.NomeVacina}");
            sb.AppendLine($"Data: {this.DataAplicacaoVacina.ToString("d")}");
            sb.AppendLine($"Lote: {this.NumeroLote}");

            return sb.ToString();
        }
    }

    public static void Run()
    {
        bool isUserLeaving = false;

        while (!isUserLeaving)
        {
            Func<bool> function;

            Dictionary<char, Func<bool>> programFlow = new Dictionary<char, Func<bool>>()
            {
                { '1', () => CadastrarVacina() },
                { '2', () => ListarAplicacoes() },
                { '3', () => ConsultaCPF() },
                { '4', () => { Console.WriteLine("Finalizando aplicação."); Environment.Exit(0); return true; } }
            };

            PrintOptions();

            while (!programFlow.TryGetValue(Utils.GetInputChar("↓"), out function))
            {
                Console.WriteLine("Opção Inválida");

                PrintOptions();
            }

            while (function.Invoke() is false) { }

            var _isUserContinuing = Utils.GetInputChar("Deseja realizar mais alguma operação? S/N");

            while (_isUserContinuing is not 'S' or 'N')
            {
                Console.WriteLine("\n*Opção Inválida*\n");

                _isUserContinuing = Utils.GetInputChar("Deseja realizar mais alguma operação? S/N");
            }

            isUserLeaving = _isUserContinuing == 'S' ? false : true;
        }

        Console.WriteLine("Finalizando aplicação.");
    }

    private static void PrintOptions()
    {
        Console.WriteLine("1. Cadastrar Vacina");
        Console.WriteLine("2. Listar Aplicações");
        Console.WriteLine("3. Consultar por CPF");
        Console.WriteLine("4. Sair");
    }

    private static bool CadastrarVacina()
    {
        try
        {
            vacinas.Add(new()
            {
                Guid = Guid.NewGuid(),
                PacienteNome = Utils.GetInputString("\nInsira o nome do paciente"),
                NomeVacina = Utils.GetInputString("Insira o nome da vacina"),
                NumeroLote = (long)Utils.GetInputDouble("Insira o número do lote"),
                PacienteCPF = Utils.GetInputString("Insira o CPF do paciente"),
                DataAplicacaoVacina = DateTime.Parse(Utils.GetInputString("Insira a data da aplicação da vacina (dd/MM/yyyy)")),
            });

            Console.WriteLine($"Vacina cadastrada: {vacinas.Last()}");

            return true;
        }
        catch (Exception)
        {
            Console.WriteLine("Houve um erro no cadastro da vacina. Tente novamente.");

            return false;
        }
    }

    private static bool ListarAplicacoes()
    {
        try
        {
            if (vacinas.Count == 0)
                Console.WriteLine("Não há nenhum registro de vacina.");

            vacinas.ForEach(vac => 
            {
                Console.WriteLine(vac.ToString());
                Console.WriteLine("================================================");
            });

            return true;
        }
        catch (Exception)
        {
            Console.WriteLine("Houve um erro na listagem das aplicações. Tente novamente.");

            return false;
        }
    }

    private static bool ConsultaCPF()
    {
        try
        {
            var cpf = Utils.GetInputString("Insira o CPF a ser pesquisado");

            var search = vacinas.FirstOrDefault(vac => vac.PacienteCPF.Equals(cpf));

            if (search is null)
            {
                Console.WriteLine("Não foi encontrada nenhuma vacina para o CPF especificado");
                return true;
            }

            Console.WriteLine(search.ToString());

            return true;
        }
        catch (Exception)
        {
            Console.WriteLine("Houve um erro na consulta. Tente novamente.");

            return false;
        }
    }
}
