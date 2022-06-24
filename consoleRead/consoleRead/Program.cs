// See https://aka.ms/new-console-template for more information
Console.WriteLine("Digite seu nome:");
string nome = Console.ReadLine();
Console.WriteLine($"Olá, {nome}");
Console.WriteLine($"Digite o primeiro nome de jogadores separado por espaço ");
string players = Console.ReadLine();
string[] players_list = players.Split(' ');
for (int i = 0; i < players_list.Length; i++)
{
    Console.WriteLine($"{i}: {players_list[i]}");
}
