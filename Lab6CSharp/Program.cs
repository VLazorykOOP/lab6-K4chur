using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//!! https://github.com/VLazorykOOP/lab6-K4chur
//https://github.com/K4chur/LabsCSharp


namespace Lab6CSharp//1`st
{
    public interface Kadr
    {
        string viddil { get; set; }
    }

    public interface IShow
    {
        void Show();
    }

    public class Robitnik : Kadr, IShow
    {
        public string viddil { get; set; }
        protected string name { get; set; }
        protected string surname { get; set; }
        int count { get; set; }
        ~Robitnik()
        {
            Console.WriteLine("Destruction///");
            count--;
        }
        public Robitnik(string viddil, string name, string surname) 
        {
            this.viddil = viddil;
            this.name = name;
            this.surname = surname;
            count++;
        }

        public Robitnik(string viddil)
        {
            this.viddil = viddil;
            this.name = "none";
            this.surname = "none";
            count++;
        }

        public Robitnik(string name, string surname)
        {
            this.viddil = "none";
            this.name = name;
            this.surname = surname;
            count++;
        }

        public void Show()
        {
            Console.WriteLine("Show Robitnik:");
            Console.WriteLine($"Viddil: {this.viddil}");
            Console.WriteLine($"Name: {this.name}");
            Console.WriteLine($"Surname: {this.surname}");
        }
    }

    public class Ingener : Robitnik, Kadr, IShow
    {
        protected int category { get; set; }
        ~Ingener()
        {
            Console.WriteLine("Destruction///");
        }
        public Ingener(string viddil, string name, string surname, int category) : base(viddil, name, surname)
        {
            this.category = category;
            this.viddil = viddil;
            this.name = name;
            this.surname = surname;
        }

        public Ingener(string viddil) : base(viddil)
        {
            this.viddil = viddil;
            this.category = -1;
            this.name = "none";
            this.surname = "none";
        }

        public Ingener(string name, string surname) : base(name, surname)
        {
            this.viddil = "none";
            this.name = name;
            this.surname = surname;
            this.category = -1;
        }

        public void Show()
        {
            Console.WriteLine("Show Robitnik:");
            Console.WriteLine($"Viddil: {this.viddil}");
            Console.WriteLine($"Name: {this.name}");
            Console.WriteLine($"Surname: {this.surname}");
            Console.WriteLine($"Category: {this.category}");
        }
    }

    public class Administration : Robitnik, Kadr
    {
        protected string posada { get; set; }

        ~Administration()
        {
            Console.WriteLine("Destruction///");
        }
        public Administration(string viddil, string name, string surname, string posada) : base(viddil, name, surname)
        {
            this.posada = posada;
            this.viddil = viddil;
            this.name = name;
            this.surname = surname;
        }
        public Administration(string viddil) : base(viddil)
        {
            this.viddil = viddil;
            this.posada = "none";
            this.name = "none";
            this.surname = "none";
        }

        public Administration(string name, string surname) : base(name, surname)
        {
            this.viddil = "none";
            this.name = name;
            this.surname = surname;
            this.posada = "none";
        }
        public void Show()
        {
            Console.WriteLine("Show Robitnik:");
            Console.WriteLine($"Viddil: {this.viddil}");
            Console.WriteLine($"Name: {this.name}");
            Console.WriteLine($"Surname: {this.surname}");
            Console.WriteLine($"Posada: {this.posada}");
        }
    }
}



namespace Lab6CSharp
{
    abstract class Edition
    {
        public string NameOfPublication;
        public string LastNameOfAuthor;
        public Edition(string nameofpublic, string lastname)
        {
            NameOfPublication = nameofpublic;
            LastNameOfAuthor = lastname;
        }
        public abstract void GetInformation();
    }
    class Book : Edition
    {
        public string YearOfPublication;
        public string NameOfEdition;
        public Book(string nameofpublic, string lastname, string yearofpublic, string nameofedition) : base(nameofpublic, lastname)
        {
            YearOfPublication = yearofpublic;
            NameOfEdition = nameofedition;
        }
        public override void GetInformation()
        {
            Console.WriteLine("Information : {0},{1},{2},{3}", NameOfPublication, LastNameOfAuthor, YearOfPublication, NameOfEdition);
        }
    }
    class Article : Edition
    {
        public string NameOfMagazine;
        public int Number;
        public string YearOfPublicat;
        public Article(string nameofpublic, string lastname, string yearofpublic, string nameofmagazine, int number) : base(nameofpublic, lastname)
        {
            NameOfMagazine = nameofmagazine;
            Number = number;
            YearOfPublicat = yearofpublic;
        }
        public override void GetInformation()
        {
            Console.WriteLine("Information:{0},{1},{2},{3},{4}", NameOfPublication, LastNameOfAuthor, NameOfMagazine, Number, YearOfPublicat);
        }
    }
    class InterntEdition : Edition
    {
        public string Link;
        public string Annotation;
        public InterntEdition(string nameofpublic, string lastname, string link, string annotation) : base(nameofpublic, lastname)
        {
            Link = link;
            Annotation = annotation;
        }
        public override void GetInformation()
        {
            Console.WriteLine("Information:{0},{1},{2},{3}", NameOfPublication, LastNameOfAuthor, Link, Annotation);
        }
    }
    class Catalog
    {
        public List<Edition> list = new List<Edition>();
        public void AddEdition(Edition edit)
        {
            list.Add(edit);
        }
        public void FindEdition(string lastname)
        {
            foreach (var p in list.FindAll(p => p.LastNameOfAuthor == lastname))
                p.GetInformation();
        }
    }
}

namespace Lab6CSharp
{
    public class VectorShort
    {
        short[] ShortArray { get; set; }
        uint n { get; }
        uint codeError { get; set; }
        static uint num_v { get; set; }

        public short this[uint i]
        {
            get
            {
                if (i > n)
                {
                    codeError = 10;
                    return 0;
                }
                return ShortArray[i];
            }
            set
            {
                if (i > n)
                {
                    codeError = 10;
                }
                else
                {
                    ShortArray[i] = value;
                }
            }
        }

        public VectorShort()
        {
            n = 1;
            ShortArray = new short[n];
            ShortArray[0] = 0;
            num_v++;
        }

        public VectorShort(uint n_)
        {
            n = n_;
            ShortArray = new short[n];
            for (int i = 0; i < n; i++)
            {
                ShortArray[i] = 0;
            }
            num_v++;
        }

        public VectorShort(uint n_, short a)
        {
            n = n_;
            ShortArray = new short[n];
            for (int i = 0; i < n; i++)
            {
                ShortArray[i] = a;
            }
            num_v++;
        }

        ~VectorShort()
        {
            Console.WriteLine("Destructed///");
            num_v--;
        }

        public void Input()
        {
            for(int i = 0; i < this.n; i++)
            {
                Console.WriteLine($"Input A[{i}] = ");
                this.ShortArray[i] = short.Parse(Console.ReadLine());
            }
        }

        public void Output()
        {
            for (int i = 0; i < this.n; i++)
            {
                Console.WriteLine($"Array[{i}] = {this.ShortArray[i]}");
            }
        }

        public void SetVec(short A)
        {
            for (int i = 0; i < this.n; i++)
            {
                this.ShortArray[i] = A;
            }
        }

        public void SetVec(uint w,short A)
        {
            if (w < 0 || w > n) { Console.WriteLine("Error!"); }
            else
            {
                this.ShortArray[w] = A;
                
            } 
        }
        public static VectorShort operator ++(VectorShort A)
        {
            for (int i = 0; i < A.n; i++)
            {
                A.ShortArray[i]++;
            }

            return A;
        }

        public static VectorShort operator --(VectorShort A)
        {
            for (int i = 0; i < A.n; i++)
            {
                A.ShortArray[i]--;
            }

            return A;
        }

        public static VectorShort operator +(VectorShort A, short B)
        {
            for (int i = 0; i < A.n; i++)
            {
                A.ShortArray[i] += B;
            }

            return A;
        }

        public static VectorShort operator -(VectorShort A, short B)
        {
            for (int i = 0; i < A.n; i++)
            {
                A.ShortArray[i] -= B;
            }

            return A;
        }

        public static VectorShort operator *(VectorShort A, short B)
        {
            for (int i = 0; i < A.n; i++)
            {
                A.ShortArray[i] *= B;
            }

            return A;
        }
        public static VectorShort operator /(VectorShort A, short B)
        {
            for (int i = 0; i < A.n; i++)
            {
                A.ShortArray[i] /= B;
            }

            return A;
        }

        public static VectorShort operator %(VectorShort A, short B)
        {
            for (int i = 0; i < A.n; i++)
            {
                A.ShortArray[i] %= B;
            }

            return A;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0;i < this.n ;i++)
            {
                if (i == n) yield break;
                yield return this.ShortArray[i];
            }
        }

        public IEnumerable FromTo(int begin, int end)
        {
            for(int i = begin; i <= end; i++)
            {
                yield return this.ShortArray[i];
            }
        }
        public void ShowNum()
        {
            Console.WriteLine($"Number of vectors is {num_v}");
        }

    }
}

namespace Lab6CSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choose = 0;
            do
            {
                Console.Write("Which excersice you want to test? (1 or 2 or 3): ");
                choose = int.Parse(Console.ReadLine());
            } while (choose != 1 && choose != 2 && choose != 3);

            switch (choose)
            {
                case 1:
                    Console.WriteLine("1.");
                    {
                        Robitnik robitnik1 = new Robitnik("Танкобудування", "Юрiй", "Буруняк");
                        robitnik1.Show();
                        Console.WriteLine();
                        Robitnik robitnik2 = new Robitnik("Машинобудування");
                        robitnik2.Show();
                        Console.WriteLine();
                        Robitnik robitnik3 = new Robitnik("Петро", "Моставчук");
                        robitnik3.Show();
                        Console.WriteLine();

                        Ingener ingener1 = new Ingener("Вiдновлювання", "Денис", "Юлiйович", 3);
                        ingener1.Show();
                        Console.WriteLine();
                        Ingener ingener2 = new Ingener("Будування");
                        ingener2.Show();
                        Console.WriteLine();
                        Ingener ingener3 = new Ingener("Олег", "Папироса");
                        ingener3.Show();
                        Console.WriteLine();

                        Administration admin1 = new Administration("Перевiрки", "Юлiй", "Цезар", "Головнокомандувач");
                        admin1.Show();
                        Console.WriteLine();
                        Administration admin2 = new Administration("Постування");
                        admin2.Show();
                        Console.WriteLine();
                        Administration admin3 = new Administration("Денис", "Буруря");
                        admin3.Show();
                        Console.WriteLine();

                    }
                    break;
                case 2:
                    Console.WriteLine("2.");
                    {
                        Catalog c = new Catalog();
                        c.AddEdition(new Book("Book", "Test", "2005", "Star"));
                        c.AddEdition(new Article("Article", "Test", "2012", "Super", 12));
                        c.AddEdition(new InterntEdition("Internet", "Test", "http", "Annotation"));
                        foreach (var p in c.list)
                        {
                            p.GetInformation();
                        }
                        c.FindEdition("Test");
                        Console.ReadLine();
                    }
                    break;
                case 3:
                    Console.WriteLine("3.");
                    {
                        Console.WriteLine("Input N for 3`d: ");
                        uint n = uint.Parse(Console.ReadLine());
                        Console.WriteLine("Input Initiation for 3`d: ");
                        short a = short.Parse(Console.ReadLine());
                        VectorShort C = new VectorShort(n,a);
                        Console.WriteLine();
                        foreach (short temp in C)
                            Console.WriteLine(temp + "");
                        Console.WriteLine();
                        foreach (short temp in C.FromTo(1, (int)n - 1)) 
                            Console.WriteLine(temp + "");
                    }
                    break;
                default:
                    Console.WriteLine("Something went wrong!");
                    break;
            }
        }
    }
}


