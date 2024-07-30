using System.ComponentModel.DataAnnotations;

namespace CSharp_HW_modul_12_part_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ints = new int[100];
            Random random = new Random();
            string parthForSimpleNumber = @"C:\Users\Brill\Desktop\Simple Numbers.txt";
            string parthForFibonachi = @"C:\Users\Brill\Desktop\Fibonachi Numbers.txt";
            if (!File.Exists(parthForSimpleNumber))
            {
                throw new FileNotFoundException();
            }
            for (int i = 0; i < ints.Length; i++)
            {
                ints[i] = random.Next(0,100);
            }
            List<string> listSimpleNumbers = new List<string>();
            for (int i = 0; i < ints.Length; i++)
            {
                bool isSimple = true;
                for (int j = 2; j < ints[i]; j++)
                {
                    if (ints[i] % j == 0)
                    {
                        isSimple = false;
                        break;
                    }
                }
                if(isSimple)
                {
                    listSimpleNumbers.Add(ints[i].ToString());
                }
            }
            File.WriteAllLines(parthForSimpleNumber, listSimpleNumbers);
            Console.WriteLine($"Count of Simple numbers: {listSimpleNumbers.Count}");

            int[] temp = GetFibonachiNumbers(ints);
            string[] stringsFibonachi = new string[temp.Length]; 
            for (int i = 0; i < temp.Length; i++)
            {
                stringsFibonachi[i] = temp[i].ToString();
            }
            File.WriteAllLines(parthForFibonachi, stringsFibonachi);
            Console.WriteLine($"Count of Fibonachi numbers: {stringsFibonachi.Length}");
        }

        static int[] GetFibonachiNumbers(int[] ints)
        {
            List<int> listFibonachi = new List<int>();
            for (int i = 0; i < ints.Length; i++)
            {
                if (IsFibonacci(ints[i]))
                {
                    listFibonachi.Add(ints[i]);
                }
            }
            return listFibonachi.ToArray();
        }

        static bool IsFibonacci(int n)
        {
            long x1 = 5 * (long)n * n + 4;
            long x2 = 5 * (long)n * n - 4;
            return IsPerfectSquare(x1) || IsPerfectSquare(x2);
        }

        static bool IsPerfectSquare(long x)
        {
            long s = (long)Math.Sqrt(x);
            return s * s == x;
        }
    }
}

//Задание 1:
//Приложение генерирует 100 целых чисел. 
//Нужно сохранить в один файл все простые числа, в другой файл все числа Фибоначчи. 
//Статистику работы приложения нужно отобразить на экран.