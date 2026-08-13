// using System;

// public class Formatter
// {
//     // Method overload 1
//     public string Format(int value)
//     {
//         return value.ToString();
//     }

//     // Method overload 2
//     public string Format(double value)
//     {
//         return value.ToString("F2");
//     }

//     // Method overload 3
//     public string Format(int numerator, int denominator)
//     {
//         return $"{numerator}/{denominator}";
//     }
// }

// public class Notifier
// {
//     public virtual void Send()
//     {
//         Console.WriteLine("Notifier: generic send");
//     }

//     public void Log()
//     {
//         Console.WriteLine("Notifier: generic log");
//     }
// }

// public class EmailNotifier : Notifier
// {
//     // Override
//     public override void Send()
//     {
//         Console.WriteLine("EmailNotifier: sending email");
//     }

//     // Hide
//     public new void Log()
//     {
//         Console.WriteLine("EmailNotifier: logging to email log");
//     }
// }

// public struct Vector2
// {
//     public double X, Y;

//     public Vector2(double x, double y)
//     {
//         X = x;
//         Y = y;
//     }

//     // Operator +
//     public static Vector2 operator +(Vector2 a, Vector2 b)
//     {
//         return new Vector2(
//             a.X + b.X,
//             a.Y + b.Y);
//     }

//     // Operator *
//     public static Vector2 operator *(Vector2 vector, double scalar)
//     {
//         return new Vector2(
//             vector.X * scalar,
//             vector.Y * scalar);
//     }

//     // Allows scalar * vector as well
//     public static Vector2 operator *(double scalar, Vector2 vector)
//     {
//         return vector * scalar;
//     }

//     public override string ToString()
//     {
//         return $"({X}, {Y})";
//     }
// }

// public class Program
// {
//     public static void Main()
//     {
//         Formatter formatter = new Formatter();

//         Console.WriteLine(
//             $"Format(7) -> \"{formatter.Format(7)}\""
//         );

//         Console.WriteLine(
//             $"Format(3.5) -> \"{formatter.Format(3.5)}\""
//         );

//         Console.WriteLine(
//             $"Format(3, 4) -> \"{formatter.Format(3, 4)}\""
//         );

//         Console.WriteLine();

//         EmailNotifier email = new EmailNotifier();

//         Console.WriteLine("-- through EmailNotifier variable --");

//         email.Send();
//         email.Log();

//         Console.WriteLine();

//         Console.WriteLine(
//             "-- through Notifier variable, same object --"
//         );

//         Notifier notifier = email;

//         notifier.Send();
//         notifier.Log();

//         Console.WriteLine();

//         Vector2 v1 = new Vector2(1, 2);
//         Vector2 v2 = new Vector2(3, 4);

//         Vector2 sum = v1 + v2;

//         Vector2 scaled = v1 * 3;

//         Console.WriteLine(
//             $"{v1} + {v2} = {sum}"
//         );

//         Console.WriteLine(
//             $"{v1} * 3 = {scaled}"
//         );
//     }
// }