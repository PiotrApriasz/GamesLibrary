using GamesLibrary.API.Entities;

namespace GamesLibrary.API;

public static class GamesLibraryTestSeeder
{
    public static void Seed(GamesLibraryDbContext dbContext)
    {
        if (dbContext.Database.CanConnect())
        {
            if (!dbContext.Games.Any())
            {
                var games = GetGames();
                dbContext.Games.AddRange(games);
                dbContext.SaveChanges();
            }

            if (!dbContext.Roles.Any())
            {
                var roles = GetRoles();
                dbContext.Roles.AddRange(roles);
                dbContext.SaveChanges();
            }
        }
    }

    private static IEnumerable<Role> GetRoles()
    {
        var roles = new List<Role>()
        {
            new Role()
            {
                RoleName = "User"
            },
            new Role()
            {
                RoleName = "Admin"
            }
        };

        return roles;
    }

    private static IEnumerable<Game> GetGames()
    {
        var games = new List<Game>()
        {
            new Game()
            {
                Title = "Witcher 3: Wild Hunt",
                Description = "The best game from CD PROJEKT GAME. History of legendary witcher - Geralt of Rivia",
                Price = 125,
                Premiere = new DateTime(2015, 05, 18),
                Pegi = new Pegi()
                {
                    PegiValue = "18"
                },
                Genres = new List<Genre>()
                {
                    new Genre()
                    {
                        GenreName = "RPG"
                    },
                    new Genre()
                    {
                        GenreName = "Fantasy"
                    },
                    new Genre()
                    {
                        GenreName = "Action"
                    }
                },
                Company = new Company()
                {
                    CompanyName = "CD PROJEKT RED"
                }
            },
            new Game()
            {
                Title = "Assassin's Creed Valhalla",
                Description = "The newest game from assassin's franichse from Ubisoft studio. Now we are vikings",
                Price = 259,
                Premiere = new DateTime(2020, 11, 10),
                Pegi = new Pegi()
                {
                    PegiValue = "18"
                },
                Genres = new List<Genre>()
                {
                    new Genre()
                    {
                        GenreName = "RPG"
                    },
                    new Genre()
                    {
                        GenreName = "Action"
                    },
                    new Genre()
                    {
                        GenreName = "Adventure"
                    }
                },
                Company = new Company()
                {
                    CompanyName = "Ubisoft"
                }
            },
            new Game()
            {
                Title = "Red Dead Redemption 2",
                Description = "Insane Wild West style game. Amazing adventure, Precious gameplay. Everythin is top of the top",
                Price = 315,
                Premiere = new DateTime(2018, 10, 25),
                Pegi = new Pegi()
                {
                    PegiValue = "18"
                },
                Genres = new List<Genre>()
                {
                    new Genre()
                    {
                        GenreName = "Action"
                    },
                    new Genre()
                    {
                        GenreName = "Western"
                    },
                    new Genre()
                    {
                        GenreName = "Shooter"
                    }
                },
                Company = new Company()
                {
                    CompanyName = "Rockstar Games"
                }
            }
        };
        return games;
    }
}
