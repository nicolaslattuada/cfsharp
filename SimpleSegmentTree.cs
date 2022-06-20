using System.Text;

StreamReader reader = new StreamReader(Console.OpenStandardInput());
StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
string ReadLine() => reader.ReadLine()!;
T Read<T>() => (T)Convert.ChangeType(ReadLine(), typeof(T));
int ReadInt() => Read<int>();
string[] Split(char c = ' ') => ReadLine().Split(c);
IEnumerable<T> Reads<T>(char c = ' ') => from s in Split() select (T)Convert.ChangeType(s, typeof(T));
T[] ReadArray<T>(char c = ' ') => Reads<T>().ToArray();
(T, T) ToTwoTuple<T>(IEnumerable<T> e) => (e.First(), e.ElementAt(1));
(T, T) ReadTwo<T>(char c = ' ') => ToTwoTuple(Reads<T>(c));
(T, T, T) ToThreeTuple<T>(IEnumerable<T> e) => (e.First(), e.ElementAt(1), e.ElementAt(2));
(T, T, T) ReadThree<T>(char c = ' ') => ToThreeTuple(Reads<T>(c));
void Write<T>(T s) => writer.Write(s);
void WriteLine<T>(T s) => writer.WriteLine(s);

// Segment Tree
static void build(int[] A, int[] T)
{
    int n = A.Length;
    for (int i = 0; i < n; i++)
        T[n + i] = A[i];
    for (int i = n - 1; i >= 1; i--)
        T[i] = T[2 * i]+T[2 * i + 1];
}

static void update(int[] T, int pos, int value)
{
    int n = T.Length / 2;
    pos += n;
    T[pos] = value;
    while (pos > 1)
    {
        pos /= 2;
        T[pos] = T[2 * pos] + T[2 * pos + 1];
    }
}

static int query(int[] T, int left, int right)
{
    int n = T.Length / 2;
    left += n;
    right += n;
    int result = 0;
    while (left < right)
    {
        if (left % 2 == 1) result += T[left++];
        if (right % 2 == 1) result += T[--right];
        left /= 2;
        right /= 2;
    }
    return result;
}

var t = ReadInt();
while (t-- > 0)
{
    var n = ReadInt();
    var A = ReadArray<int>();
    var T = new int[2 * n];
    build(A, T);
    WriteLine($"query(0,1) = {query(T, 0, 1)} {string.Join(",", T)}");
    WriteLine($"query(2,4) = {query(T, 2, 4)}");
    update(T, 9, 1000);
    WriteLine($"query(0,10) = {query(T, 0, 10)}  {string.Join(",", T)}");
}
writer.Flush();
/*
1
10
1 2 3 4 5 6 7 8 9 10

query(2,4) = 7 returns result between left and right -1 so 2,4 is sum of element at pos 3 and 4
*/
