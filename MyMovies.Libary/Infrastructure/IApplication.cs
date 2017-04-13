namespace MyMovies.Libary.Infrastructure
{
    public interface IApplication
    {
        IContainer Services { get; }
        string ServerAddress { get; }
    }
}
