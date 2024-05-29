namespace AspBoot.Data.Model;

public class PageSearched<TEntity> : Page<TEntity>
{
    public string SearchString { get; init; } = "";
}
