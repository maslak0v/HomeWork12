using System;
using System.Collections.Concurrent;
using System.Threading;

class Program
{
    // Коллекция книг с процентом прочтения
    static ConcurrentDictionary<string, int> books = new ConcurrentDictionary<string, int>();

    static void Main(string[] args)
    {
        Thread backgroundThread = new Thread(UpdateReadingProgress);
        backgroundThread.IsBackground = true;
        backgroundThread.Start(); // Запускаем фоновый поток

        while (true)
        {
            Console.WriteLine("1 - добавить книгу; 2 - вывести список непрочитанного; 3 - выйти");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("Введите название книги:");
                string title = Console.ReadLine();
                books.TryAdd(title, 0); // Добавляем книгу с начальным прогрессом 0%
            }
            else if (choice == "2")
            {
                Console.WriteLine("Список непрочитанных книг:");
                foreach (var book in books)
                {
                    Console.WriteLine($"{book.Key} - {book.Value}%");
                }
            }
            else if (choice == "3")
            {
                break; // Выход из программы
            }
        }
    }

    // Фоновый поток для обновления прогресса чтения
    static void UpdateReadingProgress()
    {
        while (true)
        {
            Thread.Sleep(1000); // Ждем 1 секунду

            foreach (var book in books.Keys.ToList())
            {
                if (books.TryGetValue(book, out int progress))
                {
                    if (progress < 100)
                    {
                        books[book] = progress + 1; // Увеличиваем прогресс на 1%
                    }
                    else
                    {
                        books.TryRemove(book, out _); // Удаляем книгу, если прогресс достиг 100%
                    }
                }
            }
        }
    }
}