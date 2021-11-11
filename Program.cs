using System;

namespace RecordsStructsClasses
{
    class Program
    {
        static void Main(string[] args)
        {

            //Create some locations
            Location tokyo = new Location { Name = "Tokyo" };
            Location dehli = new Location { Name = "Dehli" };

            //Date
            DateTime date = new DateTime(year: 2021, month: 11, day: 11);

            WeatherClass weatherC = new WeatherClass(date, 25, dehli);
            WeatherStruct WeatherS = new WeatherStruct(date, 25, dehli);
            WeatherRecord weatherR = new WeatherRecord(date, 25, dehli);

            //In C# values can either be value types, or reference types. 
            //An int is a primitive, and an example of a value type. 
            //When comparing value types, the == operator checks their values are the same. 

            int a = 5;
            int b = 5;

            if(a == b)
            {
                Console.WriteLine("These two integers are equal"); //This will print <---------
            } else
            {
                Console.WriteLine("These two integers are not equal");
            }

            //Classes are an example of a reference type.
            //When being compared with the == operator, it is checking if the objects are the same.

            Person jenny1 = new Person { Name = "Jenny", Age = 35 };
            Person jenny2 = new Person { Name = "Jenny", Age = 35 };


            if (jenny1 == jenny2)
            {
                Console.WriteLine("These two people are equal"); 
            }
            else
            {
                Console.WriteLine("These two people are not equal"); //This will print <---------
            }

            //these are two separate objects. Despite containing the same information, they are not equal. 
            //How an object decides whether something is equal to it or not can be changed
            //by overriding the Equals(object obj) method.
            //You can also implement the IEquatable<T> interface. 

            //Another difference between value types and refence types is how they are modified. 
            int x = 5;
            int y = x;
            y++;

            Console.WriteLine(x);   //prints 5
            Console.WriteLine(y);   //prints 6

            //This should be intuative. When we modify y, x remains the same. 
            //However, this is not the case with reference types. 

            Person p1 = new Person { Name = "Han", Age = 22 };
            Person p2 = p1;
            p2.Age++; //increase the Age by 1.

            Console.WriteLine(p1.Age);   //prints 23
            Console.WriteLine(p2.Age);   //prints 23, not 22

            //In this example, even though we changed p2's age, that change is reflected in p1.
            //This is because p1 and p2 are not separate objects, but two references to the same object. 
            //This is an example of aliasing, where a single object is referenced by multiple variables. 

            //Now we know about reference and value types, let's talk about structs.
            //A struct is like a class, put it is a value type. 
            //We generally use structs when we just want to hold some data. 

            Point2D point1 = new Point2D(3, 5);
            Point2D point2 = new Point2D(2, 6);
            Point2D point3 = point1; //copies values of fields instead of aliasing.
            point3.X++; //new value: 3
            point3.Y--; //new value: 5
            //Even though we changed point 3's values, because a struct is a value type, we have not modified point 1. 

            if (point1.X == point3.X) 
            {
                Console.WriteLine("These two points' x values are equal"); 
            }
            else
            {
                Console.WriteLine("These two points' x values are not equal"); //This will print <---------
            }

            //The == operator is not available for struct comparison by default. 
            //You can override it, but instead you could use records.

            //According to the official documentation:
            /*
             * A record is still a class, but the record keyword imbues it with several additional value-like behaviors. 
             * Generally speaking, records are defined by their contents, not their identity. 
             * In this regard, records are much closer to structs, but records are still reference types.
             */
            //You can think about a record as somewhere between a class and a struct.
            //One cool feature of records is that the equality comparisons are value based, like structs. 
            //This allows us to use the == operator.

            Point2DRecord point1R = new Point2DRecord(3, 5);
            Point2DRecord point2R = new Point2DRecord(3, 5);
            //Even though we changed point 3's values, because a struct is a value type, we have not modified point 1. 

            if (point1R == point2R)
            {
                Console.WriteLine("These two points are equal");
            }
            else
            {
                Console.WriteLine("These two points are not equal"); //This will print <---------
            }

            //A key feature about records is they are immutable, which means they cannot be changed once they are created. 
            //So once a record is created, it's values cannot be modified. 
            //Classes and structs are mutable by default, although its generally recommended to make structs immutable using the
            //readonly keyword

            //When you use an immutable type, you are making a guarantee that at any point in your code's execution after the object
            //has been created, it will always be the same. This is useful for many reasons. It means the object is thread safe, meaning
            //that multiple threads can work on it at the same time without the risk of concurency problems. 
            //Immutability is widely used in functional programming, which C# has begun to incorperate from F#, and lends itself to
            //useful tools like pattern matching. 






        }

        class Person
        {
            public string Name;
            public int Age;
        }

        struct Point2D
        {
            public int X;
            public int Y;

            public Point2D(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        record Point2DRecord
        {
            public int X;
            public int Y;

            public Point2DRecord(int x, int y)
            {
                X = x;
                Y = y;
            }
        }


    }

    public class Location
    {
        public string Name;
    }

    public class WeatherClass
    {
        public DateTime Date;
        public int TempC;
        public Location Loc;

        public WeatherClass(DateTime date, int tempC, Location loc)
        {
            Date = date;
            TempC = tempC;
            Loc = loc;
        }
    }

    public struct WeatherStruct
    {
        public DateTime Date;
        public int TempC;
        public Location Loc;

        public WeatherStruct(DateTime date, int tempC, Location loc)
        {
            Date = date;
            TempC = tempC;
            Loc = loc;
        }
    }

    public record WeatherRecord
    {
        public DateTime Date;
        public int TempC;
        public Location Loc;

        public WeatherRecord(DateTime date, int tempC, Location loc)
        {
            Date = date;
            TempC = tempC;
            Loc = loc;
        }
    }
}
