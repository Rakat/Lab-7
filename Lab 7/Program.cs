using System;
using System.Collections;
using System.Collections.Generic;

// Завдання 1: Універсальні методи для обміну даними
public static class UniversalMethods
{
    // Універсальний метод для обміну значеннями
    public static void Swap<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }
}

// Завдання 2: Універсальні методи з обмеженнями
public static class GenericMethods
{
    // Пошук максимального елемента в масиві
    public static T FindMax<T>(T[] array) where T : IComparable<T>
    {
        T max = array[0];
        foreach (var item in array)
        {
            if (item.CompareTo(max) > 0)
            {
                max = item;
            }
        }
        return max;
    }

    // Пошук мінімального елемента в масиві
    public static T FindMin<T>(T[] array) where T : IComparable<T>
    {
        T min = array[0];
        foreach (var item in array)
        {
            if (item.CompareTo(min) < 0)
            {
                min = item;
            }
        }
        return min;
    }
}

// Завдання 3: Універсальні класи з одним параметром
public class GenericClass<T> where T : IComparable<T>
{
    private T value;

    public GenericClass(T value)
    {
        this.value = value;
    }

    // Метод для знаходження меншого з двох значень
    public T FindMin(T a, T b)
    {
        return a.CompareTo(b) < 0 ? a : b;
    }
}

// Завдання 4: Клас Тварина та універсальний клас для списку
public class Animal
{
    public string Name { get; set; }
    public double Weight { get; set; }

    public Animal(string name, double weight)
    {
        Name = name;
        Weight = weight;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Weight: {Weight}";
    }
}

public class GenericList<T> where T : class
{
    private List<T> items = new List<T>();

    public void Add(T item)
    {
        items.Add(item);
    }

    public void Display()
    {
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }
}

// Головна програма
public class Program
{
    public static void Main()
    {
        // --- Завдання 1: Обмін значеннями ---
        Console.WriteLine("Task 1: Swap Method");
        double num1 = 5.5, num2 = 10.2;
        Console.WriteLine($"Before Swap: num1 = {num1}, num2 = {num2}");
        UniversalMethods.Swap(ref num1, ref num2);
        Console.WriteLine($"After Swap: num1 = {num1}, num2 = {num2}");

        string str1 = "Hello", str2 = "World";
        Console.WriteLine($"\nBefore Swap: str1 = {str1}, str2 = {str2}");
        UniversalMethods.Swap(ref str1, ref str2);
        Console.WriteLine($"After Swap: str1 = {str1}, str2 = {str2}");

        // --- Завдання 2: Пошук максимуму та мінімуму ---
        Console.WriteLine("\nTask 2: FindMax and FindMin");
        int[] intArray = { 1, 3, 7, 2, 5 };
        double[] doubleArray = { 1.1, 3.5, 0.2, 8.8, 5.5 };

        Console.WriteLine($"Max in intArray: {GenericMethods.FindMax(intArray)}");
        Console.WriteLine($"Min in intArray: {GenericMethods.FindMin(intArray)}");
        Console.WriteLine($"Max in doubleArray: {GenericMethods.FindMax(doubleArray)}");
        Console.WriteLine($"Min in doubleArray: {GenericMethods.FindMin(doubleArray)}");

        // --- Завдання 3: Універсальний клас ---
        Console.WriteLine("\nTask 3: Generic Class");
        GenericClass<int> intClass = new GenericClass<int>(10);
        Console.WriteLine($"Min of 5 and 10: {intClass.FindMin(5, 10)}");

        GenericClass<double> doubleClass = new GenericClass<double>(7.5);
        Console.WriteLine($"Min of 7.5 and 2.3: {doubleClass.FindMin(7.5, 2.3)}");

        // --- Завдання 4: Клас Тварина та GenericList ---
        Console.WriteLine("\nTask 4: Generic List of Animals");
        GenericList<Animal> animalList = new GenericList<Animal>();
        animalList.Add(new Animal("Elephant", 5000));
        animalList.Add(new Animal("Tiger", 300));
        animalList.Add(new Animal("Rabbit", 2));
        animalList.Display();
    }
}
