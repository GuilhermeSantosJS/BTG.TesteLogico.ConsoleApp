using BTG.TesteLogico.Application.Services;
static void ExecutarAppCorteDeTijolos()
{
    CorteDeTijolosService corteDeTijolos = new();
    IList<IList<int>> paredeDeTijolos = [];

    Console.WriteLine("Insira o número de linhas da parede:");
    int numeroLinhas = int.Parse(Console.ReadLine());

    for (int i = 0; i < numeroLinhas; i++)
    {
        Console.WriteLine($"Insira os comprimentos dos tijolos na linha {i + 1}, separados por espaço:");
        string[] entrada = Console.ReadLine().Split(' ');
        IList<int> linha = [];

        foreach (var comprimento in entrada)
        {
            linha.Add(int.Parse(comprimento));
        }

        paredeDeTijolos.Add(linha);
    }

    int resultado = corteDeTijolos.CorteDeTijolos(paredeDeTijolos);

    Console.WriteLine($"O menor número de tijolos cortados é: {resultado}");
}

ExecutarAppCorteDeTijolos();


