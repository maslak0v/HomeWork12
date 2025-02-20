using System;
using System.Collections.ObjectModel;
using System.Linq;

// Класс товара
class Item
{
    public int Id { get; set; } // Идентификатор товара
    public string Name { get; set; } // Название товара

    public Item(int id, string name)
    {
        Id = id;
        Name = name;
    }
}

// Класс магазина
class Shop
{
    private ObservableCollection<Item> _items = new ObservableCollection<Item>();
    public ObservableCollection<Item> Items => _items;

    public void Add(Item item)
    {
        _items.Add(item); // Добавляем товар в коллекцию
    }

    public void Remove(int id)
    {
        var item = _items.FirstOrDefault(i => i.Id == id);
        if (item != null)
        {
            _items.Remove(item); // Удаляем товар из коллекции
        }
    }
}

// Класс покупателя
class Customer
{
    public void OnItemChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        if (e.NewItems != null)
        {
            foreach (Item newItem in e.NewItems)
            {
                Console.WriteLine($"Добавлен товар: ID={newItem.Id}, Название={newItem.Name}");
            }
        }

        if (e.OldItems != null)
        {
            foreach (Item oldItem in e.OldItems)
            {
                Console.WriteLine($"Удален товар: ID={oldItem.Id}, Название={oldItem.Name}");
            }
        }
    }
}

// Основная программа
class Regular_customer
{
    static void Main(string[] args)
    {
        Shop shop = new Shop();
        Customer customer = new Customer();

        // Подписываемся на изменения в коллекции товаров
        shop.Items.CollectionChanged += customer.OnItemChanged;

        int nextId = 1; // Генератор идентификаторов для товаров

        while (true)
        {
            Console.WriteLine("Нажмите A для добавления товара, D для удаления товара, X для выхода.");
            var key = Console.ReadKey().Key;

            if (key == ConsoleKey.A)
            {
                // Добавляем новый товар с текущей датой и временем
                string itemName = $"Товар от {DateTime.Now}";
                shop.Add(new Item(nextId, itemName));
                nextId++;
            }
            else if (key == ConsoleKey.D)
            {
                // Удаляем товар по ID
                Console.WriteLine("\nВведите ID товара для удаления:");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    shop.Remove(id);
                }
                else
                {
                    Console.WriteLine("Неверный ID.");
                }
            }
            else if (key == ConsoleKey.X)
            {
                // Выход из программы
                break;
            }

            Console.WriteLine();
        }
    }
}