using System;
using System.Threading.Tasks;

namespace Lab2._8
{
    class Program
    {
        static bool MyTask()       // метод без аргументів, що повертає результат типу bool
        {
            Console.WriteLine("MyTask is running.");
            return true;           // Повертає значення true
        }

        static int SumIt(object v) // метод, що повертає суму чисел, що менше заданого параметру
        {
            int x = (int)v;        // оголошується змінна x типу int і їй присвоюється значення v, вже після перетворення object на int
            int sum = 0;

            for (; x > 0; x--)    // обчислення суми чисел, менших за заданий параметр
                sum += x;

            Console.WriteLine("SumIt is done.");
            return sum;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Main Thread is starting.");

            Task<bool> tsk1 = Task<bool>.Factory.StartNew(MyTask);                      // створюємо та запускаємо об'єкт першої задачі
            Console.WriteLine("The Result after running of MyTask = " + tsk1.Result);   // отримуємо результ після виконання задачі

            Task<int> tsk2 = Task<int>.Factory.StartNew(SumIt, 5);                      // створюємо та запускаємо об'єкт другої задачі з параметром 5
            Console.WriteLine("The Result after running of SumIt = " + tsk2.Result);    // отримуємо результат після виконання задачі

            tsk1.Dispose();     // звільняємо ресурси після завершення задач
            tsk2.Dispose();

            Console.WriteLine("Main() is done.");
            Console.ReadLine(); // очікуємо введення, щоб побачити результат виконання
        }
    }
}



// порожнє місце перед ; означає, що ініціалізація змінної в циклі не відбувається -> x вже визначено і передано як параметр у методі SumIt
// x > 0. Цикл виконується, поки x більше нуля
// x--. Після кожної ітерації значення x зменшується на одиницю
// тіло циклу sum += x;