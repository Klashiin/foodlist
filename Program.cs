using System;
namespace foodlist
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            for (int i = 1; i > 0; i++)
            {
                Console.WriteLine("\n### COMIDA ALEATÓRIA! ###\n");
                Console.WriteLine("[1] Gerar Comida Aleatória");
                Console.WriteLine("[0] Sair");
                Console.Write("\nSelecione uma opção: ");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        string query = "SELECT * FROM comida ORDER BY RAND() LIMIT 1;";
                        PrintFood(mysql.RunQuery(query));
                        break;
                    case "0":
                        Console.WriteLine("\nEncerrando a execução...");
                        Console.WriteLine("Pressione qualquer tecla para sair.");
                        Console.ReadKey();
                        i = -1;
                        break;
                    default:
                        Console.WriteLine("ERRO! Selecione uma opção válida.");
                        break;
                }
            }
        }

        static void PrintFood(food comida)
        {
            Console.WriteLine($"\n{comida.nome.ToUpper()}");
            Console.WriteLine($"Categoria: {comida.categoria.ToUpper()}");
            Console.WriteLine($"Tempo de preparo: {comida.tempo} MIN");
            Console.WriteLine($"Avaliação: {comida.nota} / 5");
            Console.WriteLine($"Dificuldade: {comida.dificuldade.ToUpper()}");
            Console.ReadLine();
        }
    }
}
