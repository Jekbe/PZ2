namespace PZ2;

public class DuplikatIsbnException : Exception
{
    public DuplikatIsbnException(string message) : base(message) { }
}

public class NiepoprawnyTomException : Exception
{
    public NiepoprawnyTomException(string message) : base(message) { }
}

public class WczesnaKsiazkaException : Exception
{
    public WczesnaKsiazkaException(string message) : base(message) { }
}