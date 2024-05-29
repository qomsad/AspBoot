namespace AspBoot.Data.Model;

public class PageSorted<TEntity> : Page<TEntity>
{
    public IEnumerable<Sort.Order> Orders { get; init; } = [];
}
