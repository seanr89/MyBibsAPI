
/// <summary>
/// Drive and initialize basic DB seeding for a test club
/// </summary>
public static class DbSeeding
{
    public static async Task TryRunSeed(AppDbContext context)
    {
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

        club.AddMember(new Member("srafferty89@gmail.com", "Sean", "Rafferty"));
        // club.AddMember(new Member("francis.donald@randox.com", "Francis Donald", true));
        // club.AddMember(new Member("ross.bratton@randox.com", "Ross Bratton", true));
        // club.AddMember(new Member("conor.devlin@randox.com", "Conor Devlin", true));
        // club.AddMember(new Member("steven.kennedy@randox.com", "Steve Kennedy", true));
        // club.AddMember(new Member("rory.corr@randox.com", "Rory Corr", true));
        // club.AddMember(new Member("michael.hayes@randox.com", "Michael Hayes", true));

        return club;
    }

    #endregion
}