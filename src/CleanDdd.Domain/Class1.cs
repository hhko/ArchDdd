namespace CleanDdd.Domain;

public class Class1
{
    public int Add(int x, int y)
    {
        return x + y;
    }

    public int DoSomething()
    {
        int x;
        int y;
        x = 3;
        y = 6;
        x += y;
        return x;
    }

    public int Divide(int x, int y)
    {
        return x / y;
    }

    public bool TryDivide(int x, int y, out int result)
    {
        try
        {
            result = x / y;
        }
        catch
        {
            result = default;
            return false;
        }

        return true;
    }
}
