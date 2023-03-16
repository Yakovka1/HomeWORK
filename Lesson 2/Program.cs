public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("В введенном вами массиве будет найден второй наибольший элемент\n");
        var elementsCount = 0;
        while (elementsCount < 2)
        {
            try
            {
                Console.Write("Укажите количество элементов массива: ");
                elementsCount = int.Parse(Console.ReadLine());
                if (elementsCount < 2)
                {
                    Console.WriteLine("\n#ERROR#\nКоличество элементов массива должно быть больше двух\n");
                }
            }
            catch (System.OverflowException)
            {
                Console.WriteLine("\n#ERROR#\nКоличество элементов массива слишком большое\n");
            }
            catch (System.FormatException)
            {
                Console.WriteLine("\n#ERROR#\nКоличество элементов массива должно быть целым числом\n");
            }
        }
        var Array = new int[elementsCount];
        while (true)
        {
            try
            {
                for (int i = 0; i < Array.Length; i++)
                {
                    Console.Write($"\nВведите значение массива под индексом {i}: ");
                    Array[i] = int.Parse(Console.ReadLine());
                }
                Console.WriteLine("\n\nПолученный массив:");
                for (int i = 0; i < Array.Length; i++)
                {
                    Console.WriteLine(Array[i]);
                }
                int largestValue = int.MinValue;
                int secondLargestValue = int.MinValue;
                for (int i = 0; i < Array.Length; i++)
                {
                    if (Array[i] > largestValue)
                    {
                        secondLargestValue = largestValue;
                        largestValue = Array[i];
                    }
                    else if (Array[i] > secondLargestValue)
                    {
                        secondLargestValue = Array[i];
                    }
                }
                Console.WriteLine("\nВторой наибольший элемент: " + secondLargestValue);
                return;
            }
            catch (System.FormatException)
            {
                Console.WriteLine("\n#ERROR#\nЗначение массива должно быть целым числом");
            }
            catch (System.OverflowException)
            {
                Console.WriteLine("\n#ERROR#\nЗначение массива слишком большое/малое");
            }
        }
    }
}