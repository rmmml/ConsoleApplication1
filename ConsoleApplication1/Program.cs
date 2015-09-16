using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "data.txt";   // Название исходного файла
            FileStream file;
            
            try
            {
                // Инициализируется новый экземпляр класса FileStream заданным путем, режимом открытия и разрешением на чтение
                file = new FileStream(filename, FileMode.Open, FileAccess.Read);
            }
            catch (Exception e)
            {
                // В случае неудачной попытки открытия файла выводится сообщение об ошибке
                Console.WriteLine("Ошибка: " + e.Message);
                Console.ReadLine();
                // Программа завершает свое выполнение
                return;
            }
            /* В случае удачного открытия файла создается новый экземпляр
             * класса StreamReader для чтения данных из заданного потока */
            StreamReader reader = new StreamReader(file);
            string[] previos = new string[3];   // Массив для данных предыдущей обработанной строки
            string[] current = new string[3];   // Массив для данных текущей обрабатываемой строки
            // Выполняется цикл обработки строк до достижения конца потока
            while(!reader.EndOfStream)
            {
                string str = reader.ReadLine(); // Чтение очередной строки файла
                if (str.Length != 0)
                {
                    /* Если строка содержит символы, то массиву current присваиваются
                     * значения трех слов из прочитанной строки; пустые элементы пропускаются */
                    current = str.Split(new char[] {}, 3, StringSplitOptions.RemoveEmptyEntries); 
                    /* Если значение первого элемента текущей обрабатываемой строки
                     * не совпадает со значением первого элемента предыдущей обработанной строки,
                     * то в консоль выводится строка со значением текущего первого элемента */
                    if (!current[0].Equals(previos[0]))
                        Console.WriteLine(current[0]);
                    /* Если значение второго элемента текущей обрабатываемой строки
                     * не совпадает со значением второго элемента предыдущей обработанной строки,
                     * то в консоль выводится строка со значением текущего второго элемента
                     * с одиночной табуляцией и двумя пробелами */
                    if (!current[1].Equals(previos[1]))
                        Console.WriteLine("\t  " + current[1]);
                    /* В консоль выводится строка со значением третьего элемента текущей
                     * обрабатываемой строки с двойной табуляцией и двумя пробелами */
                    Console.WriteLine("\t\t  " + current[2]);
                    /* Массиву для данных предыдущей обрабатываемой строки присваивается
                     * знчения массива для данных текущей обрабатываемой строки */
                    previos = current;
                }
            }
            // Освобождаются все системные ресурсы, связанные с устройством чтения
            reader.Close();
            Console.ReadLine();
        }
    }
}
