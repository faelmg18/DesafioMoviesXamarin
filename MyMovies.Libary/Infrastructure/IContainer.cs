namespace MyMovies.Libary.Infrastructure
{
    public interface IContainer
    {
        T Resolve<T>() where T : class;
    }
}
