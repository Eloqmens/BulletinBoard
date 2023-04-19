namespace BulletinBoard.Persistence
{
    public class DbIntializer 
    {
        public static void Intialize(BulletinBoardDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
