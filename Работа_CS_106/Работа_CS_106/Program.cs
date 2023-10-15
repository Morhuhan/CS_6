using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.ConstrainedExecution;

namespace Работа_CS_106
{
    internal class Program
    {

        class Car : IComparable
        {
            private string name = "noname";

            public Car() { }

            public Car(string name) { this.name = name; }

            public string Name { get { return name; } }

            // Сравнение объектов
            int IComparable.CompareTo(object obj)
            {
                return name.CompareTo(((Car)obj).name);
            }

            // Чтобы устранить недостаток подхода с внешним классом
            public static System.Collections.IComparer SortByName
            {
                get
                {
                    return (System.Collections.IComparer)new SortByName();
                }
            }
        }


        class SortByName : System.Collections.IComparer
        {
            public SortByName() { }

            int IComparer.Compare(object a, object b)
            {
                return String.Compare(((Car)a).Name, ((Car)b).Name);
            }
        }

        //// Интерфейсы перечисления
        //class Cars : IEnumerable, IEnumerator
        //{
        //    private Car[] cars;

        //    private int current = -1;

        //    public Cars()
        //    {
        //        cars = new Car[4];
        //        cars[0] = new Car("alpha");
        //        cars[1] = new Car("porshe");
        //        cars[2] = new Car("nissan");
        //        cars[3] = new Car("ГАЗ-13");
        //    }

        //    // IEnumerable 
        //    public IEnumerator GetEnumerator()
        //    {
        //        return (IEnumerator)this;
        //        //for (int i = 0; i < cars.Length; i++)
        //        //{
        //        //    yield return cars[i];
        //        //}
        //    }

        //    public void Reset()
        //    {
        //        current = -1;
        //    }

        //    public bool MoveNext()
        //    {
        //        if (current < cars.Length - 1)
        //        {
        //            current++;
        //            return true;
        //        }
        //        else { return false; }
        //    }

        //    public object Current { get { return cars[current]; } }
        //}

        class CarsList : IEnumerable
        {
            private ArrayList cars;

            public CarsList()
            {
                cars = new ArrayList();
            }

            public void Add(Car car)
            {
                cars.Add(car);
            }

            public int count
            {
                get { return cars.Count; }
            }

            public void Clear()
            {
                cars.Clear();
            }

            public void RemoveAt(int index)
            {
                cars.RemoveAt(index);
            }

            public bool Contains(Car car)
            {
                return cars.Contains(car);
            }

            public IEnumerator GetEnumerator()
            {
                return cars.GetEnumerator();
            }
        }

        class Cars : System.Collections.IEnumerable
        {

            // Внутренний перечислитель
            private class CarsEnumerator : System.Collections.IEnumerator
            {
                private int current = -1;
                private Cars c;

                public CarsEnumerator(Cars c) { this.c = c;}

                public void Reset()
                {
                    current = -1;
                }

                public bool MoveNext()
                {
                    if (current < c.cars.Length - 1)
                    {
                        current++;
                        return true;
                    }
                    else { return false; }
                }

                public object Current
                {
                    get { return c.cars[current]; }
                }
            }


            private Car[] cars;

            public Cars()
            {
                cars = new Car[4];
                cars[0] = new Car("alpha");
                cars[1] = new Car("porshe");
                cars[2] = new Car("nissan");
                cars[3] = new Car("ГАЗ-13");
            }

            public System.Collections.IEnumerator GetEnumerator()
            {
                return new CarsEnumerator(this);
            }
        }

        class Point
        {
            public int x;
            public int y;

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public override string ToString()
            {
                return "(" + x.ToString() + "," + y.ToString() + ")";
            }
        }

        class Point2 : ICloneable
        {
            public int x;
            public int y;

            public Point2(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public override string ToString()
            {
                return "(" + x.ToString() + "," + y.ToString() + ")";
            }

            public object Clone()
            {
                return new Point2(this.x, this.y);
            }
        }

        static void Main(string[] args)
        {
            //Cars carlot = new Cars();
            //foreach (Car c in carlot)
            //{
            //    Console.WriteLine(c.Name);
            //}

            //carlot.Reset();
            //carlot.MoveNext();
            //Console.WriteLine(((Car)carlot.Current).Name);

            //Point p1 = new Point(2, 3);
            //Point p2 = p1;

            //p2.x = 3;

            //Console.WriteLine("1: " + p1.ToString());
            //Console.WriteLine("2: " + p2.ToString());

            //// Клон ICloneable
            //Point2 p3 = new Point2(6, 6);
            //Point2 p4 = (Point2)p3.Clone();

            //p4.x = 3;

            //Console.WriteLine("3: " + p3.ToString());
            //Console.WriteLine("4: " + p4.ToString());

            ///////////////////////////////////////////

            //Car[] cars = new Car[4];
            //cars[0] = new Car("3");
            //cars[1] = new Car("2");
            //cars[2] = new Car("1");
            //cars[3] = new Car("4");

            //foreach (Car car in cars)
            //{
            //    Console.WriteLine(((Car)car).Name);
            //}

            ////// Сортировка через IComparable.CompareTo
            ////Array.Sort(cars);

            ////Console.WriteLine("SORTED");

            ////foreach (Car car in cars)
            ////{
            ////    Console.WriteLine(((Car)car).Name);
            ////}

            //// Сортировка через класс SortByName

            ////Array.Sort(cars, new SortByName());

            //Array.Sort(cars, Car.SortByName);


            //Console.WriteLine("SORTED");

            //foreach (Car car in cars)
            //{
            //    Console.WriteLine(((Car)car).Name);
            //}

            CarsList cars = new CarsList();

            cars.Add(new Car("Alpha"));
            cars.Add(new Car("RR"));
            cars.Add(new Car("117"));
            cars.Add(new Car("Nissan"));

            Console.WriteLine("We have {0} cars: ", cars.count);

            foreach (Car car in cars)
            {
                Console.WriteLine(car.Name);
            }

            Console.WriteLine("RemoveAt(3)");

            cars.RemoveAt(3);

            Console.WriteLine("We have {0} cars: ", cars.count);

            foreach (Car car in cars)
            {
                Console.WriteLine(car.Name);
            }

            Car a = new Car("Audi100");

            cars.Add(a);

            Console.WriteLine("Add Audi");


            if (cars.Contains(a))
            {
                Console.WriteLine(a.Name + " is present");
            }

            cars.Clear();

            
            // Использование ArrayList напрямую
            ArrayList ar = new ArrayList();
            ar.Add(cars);
            ar.Add(new Car("asd"));
            ar.Add("Hi!");
            ar.Add(33);

            foreach (object o in ar)
            {
                Console.WriteLine(o.ToString());
            }

        }
    }
}
