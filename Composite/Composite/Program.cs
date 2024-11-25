/*
Програма, яка реалізує структуру бібліотеки за допомогою шаблону Composite Pattern.
У бібліотеці кожен елемент може бути як окремою книгою (листом), 
так і категорією (композитом), що містить інші категорії або книги.*/
using System;
using System.Collections.Generic;

namespace CompositePatternLibraryDemo
{
    // "Component" - Base class for library items
    abstract class LibraryItem
    {
        protected string name;

        public LibraryItem(string name)
        {
            this.name = name;
        }

        public virtual void Add(LibraryItem item)
        {
            throw new NotSupportedException("Cannot add to this item.");
        }

        public virtual void Remove(LibraryItem item)
        {
            throw new NotSupportedException("Cannot remove from this item.");
        }
        public virtual void Display(int depth)
        {
            throw new NotImplementedException("Display method must be implemented.");
        }
    }

    // "Leaf" - Represents a book
    class Book : LibraryItem
    {
        private string author;

        public Book(string name, string author)
            : base(name)
        {
            this.author = author;
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + $" {name} by {author}");
        }
    }

    // "Composite" - Represents a category of books
    class Category : LibraryItem
    {
        private List<LibraryItem> items = new List<LibraryItem>();

        public Category(string name)
            : base(name) { }

        public override void Add(LibraryItem item)
        {
            items.Add(item);
        }

        public override void Remove(LibraryItem item)
        {
            items.Remove(item);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + $" Category: {name}");
            foreach (var item in items)
            {
                item.Display(depth + 2);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Root category
            LibraryItem library = new Category("Library");

            // Fiction category
            LibraryItem fiction = new Category("Fiction");
            fiction.Add(new Book("The Great Gatsby", "F. Scott Fitzgerald"));
            fiction.Add(new Book("To Kill a Mockingbird", "Harper Lee"));

            // Non-fiction category
            LibraryItem nonFiction = new Category("Non-Fiction");
            /*Book book1 = new Book("Sapiens", "Yuval Noah Harari");
            nonFiction.Add(book1);*/
            nonFiction.Add(new Book("Sapiens", "Yuval Noah Harari"));
            nonFiction.Add(new Book("Educated", "Tara Westover"));

            // Science subcategory under Non-Fiction
            LibraryItem science = new Category("Science");
            science.Add(new Book("A Brief History of Time", "Stephen Hawking"));
            science.Add(new Book("The Selfish Gene", "Richard Dawkins"));
            nonFiction.Add(science);

            // Add categories to library
            library.Add(fiction);
            library.Add(nonFiction);

            // Display the library structure
            library.Display(1);
            /*nonFiction.Remove(book1);
             * library.Display(1);
             */
            Console.ReadLine();
        }
    }
}
