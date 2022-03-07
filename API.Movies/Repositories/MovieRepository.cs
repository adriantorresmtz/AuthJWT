using API.Movies.Models;

namespace API.Movies.Repositories
{
    public class MovieRepository
    {
        public static List<Movie> Movies = new()
        {
            new() { Id = 1,Title ="Eternals", Description = "The saga of eternals movies very good",Rating=6.8},
            new() { Id = 2, Title = "Dumbo", Description = "Pelicula del elefantito con orejas algo grandes", Rating = 8.5 },
            new() { Id = 3, Title = "Risa en Vacaciones", Description = "Pelicula mexicana de comedia, que no da risa", Rating = 5.0 },
            new() { Id = 4, Title = "Juego de Gemelas", Description = "Segun son gemelas que se separaron", Rating = 9.0 },
            new() { Id = 5, Title = "Cruela", Description = "Que le gusta la moda, antes de ser mala", Rating = 7.9 },
        };
    }
}
