using BulletinBoard.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
namespace BulletinBoard.Application.Interfaces
{
    public interface IBulletinBoardDbContextcs
    {
        DbSet<Ad> Ads { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
