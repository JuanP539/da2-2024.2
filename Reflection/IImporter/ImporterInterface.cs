using Domain;

namespace IImporter
{
    public interface ImporterInterface
    {
        string GetName();

        // 2. Esta bien compartir el dominio?
        List<Movie> ImportMovie();
    }
}
