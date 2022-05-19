// See https://aka.ms/new-console-template for more information

using RegexYep;

BinaryTree tree = new BinaryTree();
Random rnd = new Random();

for (int i = 0; i < 10; i++)
{
    double n = Math.Round(rnd.NextDouble() * 10);
    Console.WriteLine(n);
    tree.Insert(n);
}

Console.WriteLine("\n");
List<double> res = tree.Query(1, 4);

foreach(double x in res)
{
    Console.WriteLine(x);
}