StreamReader reader = new StreamReader(Console.OpenStandardInput());
StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
string ReadLine() => reader.ReadLine()!;
T Read<T>() => (T)Convert.ChangeType(ReadLine(), typeof(T));
int ReadInt() => Read<int>();
string[] Split(char c = ' ') => ReadLine().Split(c);
IEnumerable<T> Reads<T>(char c = ' ') => from s in Split() select (T)Convert.ChangeType(s, typeof(T));
(T, T) ToTwoTuple<T>(IEnumerable<T> e) => (e.First(), e.ElementAt(1));
(T, T) ReadTwo<T>(char c = ' ') => ToTwoTuple(Reads<T>(c));
(T, T, T) ToThreeTuple<T>(IEnumerable<T> e) => (e.First(), e.ElementAt(1), e.ElementAt(2));
(T, T, T) ReadThree<T>(char c = ' ') => ToThreeTuple(Reads<T>(c));
void Write<T>(T s) => writer.Write(s);
void WriteLine<T>(T s) => writer.WriteLine(s);

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

// https://codeforces.com/contest/1593/problem/C
// https://codeforces.com/contest/1593/submission/159291916
