using System;

[AttributeUsage(AttributeTargets.Assembly)]
public sealed class DotfuscatorAttribute : Attribute
{
    private readonly string a;
    private readonly bool b;
    private readonly int c;

    public DotfuscatorAttribute(string a, int c, bool b)
    {
        this.a = a;
        this.c = c;
        this.b = b;
    }

    public string A
    {
        get { return a; }
    }

    public bool B
    {
        get { return b; }
    }

    public int C
    {
        get { return c; }
    }
}