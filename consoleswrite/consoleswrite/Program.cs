// See https://aka.ms/new-console-template for more information
using System.Globalization;
string produto1 = "Computador";
string produto2 = "Mesa de escritório";
byte idade = 30;
int codigo = 5290;
char genero = 'M';
double preco1 = 2100.00;
double preco2 = 650.50;
double medida = 53.234567;
Console.WriteLine("Produtos: ");
Console.WriteLine($"{produto1},  cujo preço é R$ {preco1.ToString("F2")}");
Console.WriteLine($"{produto2},  cujo preço é R$ {preco2.ToString("F2")}");
Console.WriteLine($"Registro: {idade} anos de idade, código: {codigo} e genero {genero}");
Console.WriteLine($"Medida com oito casas demais: {medida.ToString("F8")}");
Console.WriteLine($"arredondando tres casas decimais : {medida.ToString("F3")}");
Console.WriteLine($"Separador decimal invariant culture: {medida.ToString("F3", CultureInfo.InvariantCulture)}");
