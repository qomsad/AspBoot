namespace AspBoot.Data.Model;

public static class Filter
{
    public class Predicate
    {
        public required string Selector { get; init; }
        public required Operator Operator { get; init; }
        public required IEnumerable<string> Values { get; init; }
    }

    public enum Operator
    {
        Eq, // ==
        NEq, // !=
        Gt, // >
        Lt, // <
        Gte, // >=
        Lte, // <=
        In, // Contains
        Stw, // Starts with
        Etw, // Ends with
        NIn, // Not contains
        NStw, // Not starts with
        NEtw, // Not ends with

        EqI, // == case-insensitive
        NEqI, // != case-insensitive
        InI, // Contains case-insensitive
        StwI, // Starts with case-insensitive
        EtwI, // Ends with case-insensitive
        NInI, // Not contains case-insensitive
        NStwI, // Not starts with case-insensitive
        NEtwI, // Not ends with case-insensitive
    }
}
