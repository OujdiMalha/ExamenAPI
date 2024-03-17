using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;


public class FilmService
{
    private readonly HttpClient _httpClient;

    public FilmService(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }
    public async Task<List<Film>> GetPopularFilmsAsync(int numberOfFilms)
    {
        try
        {
            // Appel à votre API pour récupérer la liste des films populaires
            var popularFilms = await _httpClient.GetFromJsonAsync<List<Film>>($"api/popularfilms/{numberOfFilms}");
#pragma warning disable CS8603 // Existence possible d'un retour de référence null.
            return popularFilms;
#pragma warning restore CS8603 // Existence possible d'un retour de référence null.
        }
        catch (HttpRequestException)
        {
            // Gestion des erreurs de connexion à l'API
            // Vous pouvez logger l'erreur ou afficher un message à l'utilisateur
            throw new ApplicationException($"Impossible de récupérer la liste des films populaires. Veuillez réessayer plus tard.");
        }
    }

    public async Task<List<Film>> GetFilms()
    {
        try
        {
            // Appel à votre API pour récupérer la liste des films
            var films = await _httpClient.GetFromJsonAsync<List<Film>>("api/films");
#pragma warning disable CS8603 // Existence possible d'un retour de référence null.
            return films;
#pragma warning restore CS8603 // Existence possible d'un retour de référence null.
        }
        catch (HttpRequestException)
        {
            // Gestion des erreurs de connexion à l'API
            // Vous pouvez logger l'erreur ou afficher un message à l'utilisateur
            throw new ApplicationException("Impossible de récupérer la liste des films. Veuillez réessayer plus tard.");
        }
    }

    public async Task<Film> GetFilmById(string id)
    {
        try
        {
            // Appel à votre API pour récupérer les détails d'un film spécifique
            var film = await _httpClient.GetFromJsonAsync<Film>($"api/films/{id}");
#pragma warning disable CS8603 // Existence possible d'un retour de référence null.
            return film;
#pragma warning restore CS8603 // Existence possible d'un retour de référence null.
        }
        catch (HttpRequestException)
        {
            // Gestion des erreurs de connexion à l'API
            // Vous pouvez logger l'erreur ou afficher un message à l'utilisateur
            throw new ApplicationException($"Impossible de récupérer les détails du film avec l'identifiant {id}. Veuillez réessayer plus tard.");
        }
    }
}

public class Film
{
#pragma warning disable CS8618 // Un champ non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le champ comme nullable.
    public string Id { get; set; }
#pragma warning restore CS8618 // Un champ non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le champ comme nullable.
#pragma warning disable CS8618 // Un champ non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le champ comme nullable.
    public string Title { get; set; }
#pragma warning restore CS8618 // Un champ non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le champ comme nullable.
#pragma warning disable CS8618 // Un champ non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le champ comme nullable.
    public string Description { get; set; }
#pragma warning restore CS8618 // Un champ non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le champ comme nullable.
    public int ReleaseYear { get; set; }
#pragma warning disable CS8618 // Un champ non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le champ comme nullable.
    public string Genre { get; set; }
#pragma warning restore CS8618 // Un champ non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le champ comme nullable.
    // Autres propriétés des films...
}
