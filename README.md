# MusicTools

A Blazor Server application with a web interface for interacting with the public APIs of music metadata databases.

## Features
  - Query the public Discogs and Last.FM APIs, or webscrape the online store VintageVinyl, to retrieve album cover images.
  - Query the Last.FM API to retrieve genre data for artists.
    
## Skills Demonstrated
  - Azure Key Vault - API Keys and Secrets stored in Azure Key Vault.
  - Dependency Injection - External dependencies isolated to their own project for a cleaner code base.
  - Front-End Design - Utilized the MudBlazor Component Library for a clean and responsive user interface.
  - HttpClient - Make HTTP Get requests to obtain html pages for webscraping.

## Third-Party NuGet Packages Used
  - [HtmlAgilityPack](https://html-agility-pack.net/)
  - [Inflatable.Lastfm](https://github.com/inflatablefriends/lastfm)
  - [MudBlazor](https://mudblazor.com/)
  - [ParkSquare.Discogs](https://www.parksq.co.uk/dotnet-core/discogs-csharp)

## Screenshots
  Album Cover Art Query:
  ![Album Art Screenshot](Screenshot%202023-10-02%20130208.png)
  Artist Genre Query:
  ![Genre Feature Screenshot](Screenshot%202023-10-02%20130513.png)
