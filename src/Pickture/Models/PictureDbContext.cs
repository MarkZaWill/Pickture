
using Microsoft.EntityFrameworkCore;

namespace Pickture.Models
{
    public class PictureDbContext: DbContext
        {
            public PictureDbContext(DbContextOptions<PictureDbContext> options)
                   : base(options)
            { }

            public DbSet<Emotion> Emotions { get; set; }
            public DbSet<Image> Images { get; set; }
            public DbSet<Taker> Takers { get; set; }
        }

    }