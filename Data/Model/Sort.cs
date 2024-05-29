namespace AspBoot.Data.Model;

public static class Sort
{
    public class Order
    {
        public required string Selector { get; init; }
        public Direction Direction { get; init; } = Direction.Asc;
    }

    public enum Direction
    {
        Asc, Desc
    }
}
