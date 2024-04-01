
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
        var club = new Club("IT Science Park", date);

        club.AddMember(new Member("srafferty89@gmail.com", "Sean", "Rafferty", 50));
        club.AddMember(new Member("frankydon@gmail.com", "Francy", "Donald", 99));
        club.AddMember(new Member("wee.dev@email.com", "Conor" , "Devlin", 88));
        club.AddMember(new Member("ross.bratton@email.com", "Ross", "Bratton", 74));
        club.AddMember(new Member("test.user@email.com", "Test", "User", 100));
        club.AddMember(new Member("test.user2@email.com", "Test", "User2", 50));
        club.AddMember(new Member("test.user3@email.com", "Test", "User3", 40));
        club.AddMember(new Member("test.user4@email.com", "Test", "User4", 15));

        return club;
    }

    #endregion
}