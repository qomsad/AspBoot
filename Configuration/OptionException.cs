namespace AspBoot.Configuration;

[Serializable]
public class OptionException : Exception
{
    public OptionException() { }

    public OptionException(string? message)
        : base(CreateMessage(message)) { }

    public OptionException(string? message, Exception? innerException)
        : base(CreateMessage(message), innerException) { }

    private static string CreateMessage(string? name)
    {
        return $"Can't found {name} options in configuration json file";
    }
}
