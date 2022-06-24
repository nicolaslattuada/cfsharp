using System.Numerics;
using System.Text;

StreamReader reader = new StreamReader(Console.OpenStandardInput());
if (File.Exists("input.txt")) reader = new StreamReader("input.txt");
StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
// if (File.Exists("output.txt")) writer = new StreamWriter("output.txt");
string ReadLine() => reader.ReadLine()!;
T Read<T>() => (T)Convert.ChangeType(ReadLine(), typeof(T));
int ReadInt() => Read<int>();
string[] Split(char c = ' ') => ReadLine().Split(c);
IEnumerable<T> Reads<T>(char c = ' ') => from s in Split(c) select (T)Convert.ChangeType(s, typeof(T));
T[] ReadArray<T>(char c = ' ') => Reads<T>(c).ToArray();
(T, T) ToTwoTuple<T>(IEnumerable<T> e) => (e.ElementAt(0), e.ElementAt(1));
(T, T) ReadTwo<T>(char c = ' ') => ToTwoTuple(Reads<T>(c));
(T, T, T) ToThreeTuple<T>(IEnumerable<T> e) => (e.ElementAt(0), e.ElementAt(1), e.ElementAt(2));
(T, T, T) ReadThree<T>(char c = ' ') => ToThreeTuple(Reads<T>(c));
void Write<T>(T s) => writer.Write(s);
void WriteLine<T>(T s) => writer.WriteLine(s);

var t = ReadInt();
while (t-- > 0)
{
    var n = ReadInt();
    var value = Read<string>();
    StringBuilder sb = new();
    var append = '9';
    if (value[0] == '9')
    {
        n++;
        append = '1';
    }
    for (int i = 0; i < n; i++) sb.Append(append);
    WriteLine(BigInteger.Parse(sb.ToString()) - BigInteger.Parse(value));
}
writer.Flush();

public class Solution
{
}
