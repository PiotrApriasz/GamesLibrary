﻿namespace GamesLibrary.API.Entities;

public class Genre
{
    public int GenreId { get; set; }
    public string GenreName {  get; set; } = default!;
    public virtual ICollection<Game> Games {  get; set; } = default!;
}
