using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class SerieService
{
    private readonly HttpClient _httpClient;

    public SerieService(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public async Task<List<Serie>> GetSeries()
    {
        try
        {
            // Appel à votre API pour récupérer la liste des séries
            var series = await _httpClient.GetFromJsonAsync<List<Serie>>("api/series");
#pragma warning disable CS8603 // Existence possible d'un retour de référence null.
            return series;
#pragma warning restore CS8603 // Existence possible d'un retour de référence null.
        }
        catch (HttpRequestException)
        {
            // Gestion des erreurs de connexion à l'API
            // Vous pouvez logger l'erreur ou afficher un message à l'utilisateur
            throw new ApplicationException("Impossible de récupérer la liste des séries. Veuillez réessayer plus tard.");
        }
    }

    public async Task<Serie> GetSerieById(string id)
    {
        try
        {
            // Appel à votre API pour récupérer les détails d'une série spécifique
            var serie = await _httpClient.GetFromJsonAsync<Serie>($"api/series/{id}");
#pragma warning disable CS8603 // Existence possible d'un retour de référence null.
            return serie;
#pragma warning restore CS8603 // Existence possible d'un retour de référence null.
        }
        catch (HttpRequestException)
        {
            // Gestion des erreurs de connexion à l'API
            // Vous pouvez logger l'erreur ou afficher un message à l'utilisateur
            throw new ApplicationException($"Impossible de récupérer les détails de la série avec l'identifiant {id}. Veuillez réessayer plus tard.");
        }
    }
}

public class Serie
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
    // Autres propriétés des séries...
}