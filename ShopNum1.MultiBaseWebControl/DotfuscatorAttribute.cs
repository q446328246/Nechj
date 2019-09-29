using System;

[AttributeUsage(AttributeTargets.Assembly)]
public sealed class DotfuscatorAttribute : Attribute
{
    private string a;
    private bool b;
    private int c;

    public DotfuscatorAttribute(string a, int c, bool b)
    {
        this.a = a;
        this.c = c;
        this.b = b;
    }

    public string A
    {
        get
        {
            return this.a;
        }
    }

    public bool B
    {
        get
        {
            return this.b;
        }
    }

    public int C
    {
        get
        {
            return this.c;
        }
    }
}

