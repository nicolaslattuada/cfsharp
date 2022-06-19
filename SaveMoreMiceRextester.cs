//Microsoft (R) Visual C# Compiler version 3.4.0-beta4-19562-05 (ff930dec)
//Copyright (C) Microsoft Corporation. All rights reserved.

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rextester
{
    public class Program
    {
        static StreamReader reader = new StreamReader(Console.OpenStandardInput());
        static StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
        static string ReadLine() => reader.ReadLine()!;
        static T Read<T>() => (T)Convert.ChangeType(ReadLine(), typeof(T));
        static int ReadInt() => Read<int>();
        static string[] Split(char c = ' ') => ReadLine().Split(c);
        static IEnumerable<T> Reads<T>(char c = ' ') => from s in Split() select (T)Convert.ChangeType(s, typeof(T));
        static T[] ReadArray<T>(char c = ' ') => Reads<T>().ToArray();
        static (T, T) ToTwoTuple<T>(IEnumerable<T> e) => (e.First(), e.ElementAt(1));
        static (T, T) ReadTwo<T>(char c = ' ') => ToTwoTuple(Reads<T>(c));
        static (T, T, T) ToThreeTuple<T>(IEnumerable<T> e) => (e.First(), e.ElementAt(1), e.ElementAt(2));
        static (T, T, T) ReadThree<T>(char c = ' ') => ToThreeTuple(Reads<T>(c));
        static void Write<T>(T s) => writer.Write(s);
        static void WriteLine<T>(T s) => writer.WriteLine(s);

        public static void Main(string[] args)
        {
            var t = ReadInt();
            while (t-- > 0)
            {
                var (n, k) = ReadTwo<int>();
                var A = Reads<int>().ToList();
                A.Sort();
                int cat = 0, result = 0;
                while (A.Count > 0 && cat < A.Last())
                {
                    int mouse = A.Last();
                    int distToSaveMouse = n - mouse;
                    cat += distToSaveMouse;
                    A.RemoveAt(A.Count-1);
                    result++;
                }
                WriteLine(result);
            }
            writer.Flush();
        }
    }
}

// https://rextester.com/
