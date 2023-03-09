namespace BulletinBoard.Persistence
{
    public class DbIntializer 
    {
        public static void Intialze(BulletinBoardDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
