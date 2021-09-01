﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBasic8
{
    class Program
    {
        class Parent { }
        class Child : Parent, IDisposable, IComparable
        {
            public int CompareTo(object obj)
            {
                throw new NotImplementedException();
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }
        }

        class TestClass : IBasic
        {
            public int TestProperty
            {
                get => 0;
                set => throw new NotImplementedException();
            }

            public int TestInstanceMethod()
            {
                throw new NotImplementedException();
            }
        }
        class Dummy : IDisposable
        {
            public void Dispose()
            {
                Console.WriteLine("Dispose() 메서드 호출!");
            }
        }
        class Product : IComparable
        {
            public string Name { get; set; }
            public int Price { get; set; }

            public int CompareTo(object obj)
            {
                return -1 * Price.CompareTo((obj as Product).Price);
                //return Name.CompareTo((obj as Product).Name);
            }

            public override string ToString()
            {
                return Name + ":" + Price + "원";
            }
        }

        static void Main(string[] args)
        {
            File.WriteAllText(@"c:\Users\progh2\Desktop\test.txt", "안녕하세요!");
            Console.WriteLine(File.ReadAllText(@"c:\Users\progh2\Desktop\test.txt"));

            using (StreamWriter writer = new StreamWriter(@"c:\Users\progh2\Desktop\test2.txt"))
            {
                writer.WriteLine("안녕하세요~");
                writer.WriteLine("StreamWriter 클래스를 사용해");
                writer.WriteLine("글자를 여러 줄 입력해봅니다.");
                for (int i = 0; i < 10; i++)
                {
                    writer.WriteLine("반복문 - " + i);
                }
            }
            using (StreamReader reader = new StreamReader(@"c:\Users\progh2\Desktop\test2.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }

            Child child = new Child();
            Parent childAsParent = new Child();
            IDisposable childAsDisposable = new Child();
            IComparable childAsComparable = new Child();

            using (Dummy dummy = new Dummy())
            {
                Console.WriteLine("뭔가 작업을 했음. 주절주절");
            }

            List<Product> list = new List<Product>()
            {
                new Product(){Name="고구마", Price=1500 },
                new Product(){Name="사과", Price=2400 },
                new Product(){Name="바나나", Price=1000 },
                new Product(){Name="배", Price=3000 },
            };
            list.Sort();
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}