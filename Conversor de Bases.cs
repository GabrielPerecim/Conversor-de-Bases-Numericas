// =============================================
// CONVERSOR DE BASES NUMÉRICAS
// Converte números entre bases 2, 5, 8, 10, 16
// e qualquer base customizada entre 2 e 36.
// =============================================

// --- FUNÇÃO: ExibirMenu ---
// Exibe o menu de seleção de base e retorna a base escolhida pelo usuário.
int ExibirMenu(string mensagem, string ordem)
{
    int baseOrigem;                          // Armazena a base escolhida pelo usuário
    bool sucesso;                            // Indica se a conversão de string para int funcionou
    bool baseCustomizada = false;            // Indica se o usuário escolheu uma base personalizada via [0]

    do
    {
        // Exibe as opções do menu
        Console.WriteLine(mensagem);
        Console.WriteLine("[2] - Binária");
        Console.WriteLine("[5] - Quinária");
        Console.WriteLine("[8] - Octal");
        Console.WriteLine("[10] - Decimal");
        Console.WriteLine("[16] - Hexadecimal");
        Console.WriteLine("[0] - Outra base");
        Console.WriteLine("[-1] - Sair");

        // Tenta converter a entrada do usuário para inteiro
        sucesso = int.TryParse(Console.ReadLine(), out baseOrigem);

        if (sucesso) // Se a entrada foi um número válido
        {
            switch (baseOrigem)
            {
                case 2:
                    Console.WriteLine($"Sua base de {ordem} é binária.");
                    break;
                case 5:
                    Console.WriteLine($"Sua base de {ordem} é quinária.");
                    break;
                case 8:
                    Console.WriteLine($"Sua base de {ordem} é octal.");
                    break;
                case 10:
                    Console.WriteLine($"Sua base de {ordem} é decimal.");
                    break;
                case 16:
                    Console.WriteLine($"Sua base de {ordem} é hexadecimal.");
                    break;
                case 0:
                    // Usuário escolheu base personalizada
                    Console.WriteLine($"Digite a base de {ordem} que você deseja: ");
                    sucesso = int.TryParse(Console.ReadLine(), out baseOrigem);
                    baseCustomizada = true; // Marca que a base veio do campo customizado

                    // Valida se a base customizada é válida (mínimo 2)
                    if (baseOrigem < 2)
                    {
                        Console.WriteLine("Base inválida, tente novamente.");
                        baseOrigem = 1; // Força o loop a continuar
                    }
                    break;
                case -1:
                    // Usuário escolheu sair — o loop termina e retorna -1
                    break;
                default:
                    // Número digitado não corresponde a nenhuma opção válida
                    Console.WriteLine("Opção inválida, tente novamente.");
                    break;
            }
        }
        else
        {
            // Entrada não era um número (ex: letra digitada)
            Console.WriteLine("Opção inválida, tente novamente.");
            baseOrigem = 1; // Força o loop a continuar (evita que TryParse deixe baseOrigem = 0)
        }

    // O loop continua enquanto a base não for uma das opções válidas do menu
    // ou uma base customizada válida entre 2 e 36
    } while (baseOrigem != 2 && baseOrigem != 5 && baseOrigem != 8 &&
             baseOrigem != 10 && baseOrigem != 16 && baseOrigem != 0 &&
             baseOrigem != -1 && !(baseOrigem >= 2 && baseOrigem <= 36 && baseCustomizada));

    return baseOrigem;
}

// --- FUNÇÃO: ConverterParaDecimal ---
// Converte um número em qualquer base para decimal.
//   numero: o número como string (ex: "FF", "101")
long ConverterParaDecimal(string numero, long base1)
{
    char digito;        // Caractere atual sendo processado
    int valorDigito;    // Valor numérico do caractere atual
    long resultado = 0;

    numero = numero.ToUpper(); // Converte para maiúsculas para padronizar (ex: 'f' → 'F')

    // Percorre o número da direita para a esquerda
    for (int i = numero.Length - 1; i >= 0; i--)
    {
        int posicao = numero.Length - 1 - i; // Posição da direita (expoente da base)

        digito = numero[i];

        // Converte o caractere para seu valor numérico
        if (digito >= 'A' && digito <= 'Z')
        {
            valorDigito = digito - 'A' + 10; // Letras: A=10, B=11, ..., Z=35
        }
        else
        {
            valorDigito = digito - '0';       // Dígitos: '0'=0, '1'=1, ..., '9'=9
        }
        // Valida se o dígito é compatível com a base
        if (valorDigito < 0 || valorDigito > base1 - 1)
        {
            Console.WriteLine("O número não se encontra na base de origem desejada. Digite outro.");
            return -2; // Sinal de erro
        }

        // Acumula o valor: dígito × base^posição
        resultado = resultado + (long)(valorDigito * Math.Pow(base1, posicao));
    }

    return (long)resultado;
}

// --- FUNÇÃO: ConverterDeDecimal ---
// Converte um número decimal para qualquer outra base.
string ConverterDeDecimal(int base2, long numero)
{
    string resultado = "";
    long[] resto = new long[64]; // Armazena os restos das divisões sucessivas
    int i = 0;

    // Caso especial: número 0 sempre resulta em "0" em qualquer base
    if (numero == 0)
        return "0";

    // Divisões sucessivas: coleta os restos de trás para frente
    while (numero > 0)
    {
        resto[i] = numero % base2; // Resto da divisão = próximo dígito (da direita)
        numero = numero / base2;   // Quociente para a próxima iteração
        i++;
    }

    // Monta o resultado lendo os restos de trás para frente
    for (i = i - 1; i >= 0; i--)
    {
        if (resto[i] >= 10)
            // Converte restos >= 10 para letras: 10=A, 11=B, ..., 35=Z
            resultado = resultado + (char)((resto[i] - 10) + 65);
        else
            // Converte restos 0-9 para seus caracteres correspondentes
            resultado = resultado + (char)(resto[i] + 48);
    }

    return resultado;
}

// =============================================
//              BLOCO PRINCIPAL
// =============================================

int baseOrigem;
int baseDestino;

do
{
    Console.Clear(); // Limpa a tela a cada nova conversão

    // Exibe o cabeçalho do programa
    Console.WriteLine("=======================================");
    Console.WriteLine("         CONVERSOR DE BASES");
    Console.WriteLine("=======================================");

    // Solicita a base de origem
    baseOrigem = ExibirMenu("Escolha a base de origem: ", "origem");

    if (baseOrigem == -1)
    {
        Console.WriteLine("Saindo...");
        break; // Encerra o programa
    }

    Console.WriteLine("--------------------------");

    // Solicita a base de destino
    baseDestino = ExibirMenu("Escolha a base de destino: ", "destino");

    if (baseDestino == -1)
    {
        Console.WriteLine("Saindo...");
        break; // Encerra o programa
    }

    Console.WriteLine("--------------------------");

    string numero;          // Número digitado pelo usuário
    long numeroDecimal = -2; // Inicializado como erro para forçar o loop

    // Loop que repete até o usuário digitar um número válido para a base escolhida
    do
    {
        Console.WriteLine("Digite o número que deseja ser convertido: ");
        numero = Console.ReadLine();

        Console.WriteLine("--------------------------");

        if (string.IsNullOrEmpty(numero))
        {
            // Entrada vazia — pede novamente
            Console.WriteLine("Número inválido, tente novamente.");
            numeroDecimal = -2;
            Console.WriteLine("--------------------------");
        }
        else
        {
            // Tenta converter para decimal — retorna -2 se inválido
            numeroDecimal = ConverterParaDecimal(numero, baseOrigem);
        }

    } while (numeroDecimal == -2);

    // Converte o número decimal para a base de destino
    string resultado = ConverterDeDecimal(baseDestino, numeroDecimal);

    // Exibe o resumo e o resultado centralizado
    Console.WriteLine($"{numero}(base {baseOrigem}) --> ?(base {baseDestino})");
    Console.WriteLine("==========================");
    int espacos = (26 - resultado.Length) / 2;
    Console.WriteLine(resultado.PadLeft(espacos + resultado.Length)); // Centraliza o resultado
    Console.WriteLine("==========================");

    Console.WriteLine("Pressione qualquer tecla para continuar.");
    Console.ReadKey();

} while (baseOrigem != -1 || baseDestino != -1); // Repete até o usuário sair