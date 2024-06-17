
/// <summary>
/// Drive and initialize basic DB seeding for a test club
/// </summary>
public static class DbSeeding
{
    public static async Task TryRunSeed(AppDbContext context)
    {
        Console.WriteLine("TryRunSeed");
        if (!context.Clubs.Any())
        {
            await SeedClubs(context);
        }
    }

    static async Task SeedClubs(AppDbContext context)
    {
        if (!context.Clubs.Any())
        {
            context.Clubs.Add(CreateDefaultClubWithMembers());
            try
            {
                await context.SaveChangesAsync();
            }
            catch
            {
                Console.WriteLine("Failed to seed clubs");
            }
        }
    }

    #region Club Default

    static Club CreateDefaultClubWithMembers()
    {
        DateTime date = DateTime.Now;
        Club club = new("IT Science Park", date);

        club.AddMember(new Member("srafferty89@gmail.com", "Sean", "Rafferty", 50));
        club.AddMember(new Member("frankydon@gmail.com", "Francy", "Donald", 99));
        club.AddMember(new Member("wee.dev@email.com", "Conor" , "Devlin", 88));
        club.AddMember(new Member("ross.bratton@email.com", "Ross", "Bratton", 74));
        club.AddMember(new Member("test.user@email.com", "Test", "User", 100));
        club.AddMember(new Member("test.user2@email.com", "Test", "User2", 50));
        club.AddMember(new Member("test.user3@email.com", "Test", "User3", 40));
        club.AddMember(new Member("test.user4@email.com", "Test", "User4", 15));

        var matches = CreateDefaultMatches();
        foreach (var match in matches)
        {
            club?.Matches?.Add(match);
        }
        return club;
    }

    static IEnumerable<Match> CreateDefaultMatches()
    {
        var matches = new List<Match>
        {
            new Match { Date = DateTime.UtcNow, Complete = false },
            new Match { Date = DateTime.UtcNow.AddDays(5), Complete = false },
            new Match { Date = DateTime.UtcNow.AddDays(-5), Complete = true },
            new Match { Date = DateTime.UtcNow.AddDays(-10), Complete = true },
        };
        return matches;
    }

    #endregion
}