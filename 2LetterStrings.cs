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
    int n = ReadInt();
    List<string> list = new();
    int[] first = new int[26];
    int[] second = new int[26];
    int[] both = new int[26*26];
    for (int i = 0; i < n; i++)
    {
        string s = ReadLine();
        int firstCharCode = s[0] - 'a';
        int lastCharCode = s[1] - 'a';
        first[firstCharCode]++;
        second[lastCharCode]++;
        both[(firstCharCode * 26) + lastCharCode]++;
        list.Add(s);
    }
    long count = 0;
    for (int i = 0; i < n - 1; i++)
    {
        string s = list.ElementAt(i);
        int firstCharCode = s[0] - 'a';
        int lastCharCode = s[1] - 'a';
        first[firstCharCode]--;
        second[lastCharCode]--;
        both[(firstCharCode * 26) + lastCharCode]--;
        int local = first[firstCharCode] + second[lastCharCode] - 2 * both[(firstCharCode * 26) + lastCharCode];
        count += local;
    }
    WriteLine(count);
}
writer.Flush();

// https://codeforces.com/problemset/problem/1669/E
// https://codeforces.com/contest/1669/submission/159430447
