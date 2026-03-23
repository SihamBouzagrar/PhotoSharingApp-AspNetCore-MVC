using Microsoft.EntityFrameworkCore;  
using PhotoSharingApplication.Models;

namespace PhotoSharingApplication.Data
{
    public class PhotoSharingContext : DbContext
    {
        public PhotoSharingContext(DbContextOptions<PhotoSharingContext> options)
            : base(options)
        { }

        public DbSet<Photo> photos { get; set; }
        public DbSet<Commentaire> commentaires { get; set; }
    }
}