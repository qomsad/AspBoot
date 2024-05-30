namespace AspBoot.Data.Model;

public class PageSorted<TEntity> : Page<TEntity>
{
    public Sort.Order? Orders { get; init; }
}
