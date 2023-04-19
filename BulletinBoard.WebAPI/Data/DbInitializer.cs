namespace BulletinBoard.WebAPI.Data
{
    public class DbInitializer
    {
        public static void Intialize(AuthDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
