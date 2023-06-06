using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Casopisi.Models
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Casopis> Casopisi{ get; set; }
        public DbSet<Kategorija> Kategorije { get; set; }
        public DbSet<ZemljaPodrijetla> Zemlje{ get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Casopis>().Property(f => f.Cijena).HasPrecision(5, 2);

            builder.Entity<Casopis>().HasData(
                new Casopis() { Id = 1, Naziv = "Vogue", KategorijaId = 2, Cijena = 18.78m, ZemljaPodrijetlaId = 2, Urednik = "Condé Nast", SlikaUrl = "https://assets.vogue.com/photos/5877049471b368a625a08fff/master/w_2000,h_2741,c_limit/jennifer-lawrence-december-2015-cover.jpg" },
                new Casopis() { Id = 2, Naziv = "Globus", KategorijaId = 4, Cijena = 15.30m, ZemljaPodrijetlaId = 1, Urednik = "Hanza Media", SlikaUrl = "https://pretplata.hanzamedia.hr/wp-content/uploads/2016/03/GLB-23.2.18..jpg" },
                new Casopis() { Id = 3, Naziv = "Esquire", KategorijaId = 2, Cijena = 24.66m, ZemljaPodrijetlaId = 1, Urednik = "Adria Media Zagreb", SlikaUrl = "https://hips.hearstapps.com/hmg-prod/images/cover-esq0423-144-642edab94ab5e.jpg" },
                new Casopis() { Id = 4, Naziv = "Lider", KategorijaId = 3, Cijena = 24.86m, ZemljaPodrijetlaId = 1, Urednik = "Lider Media", SlikaUrl = "https://storyeditor.com.hr/images/portfolio/Lider.jpg" },
                new Casopis() { Id = 5, Naziv = "Elle", KategorijaId = 2, Cijena = 60.00m, ZemljaPodrijetlaId = 3, Urednik = "Hachette Livre", SlikaUrl = "https://www.adriamedia.hr/wp-content/uploads/2018/07/elle-kolovoz.jpg" },
                new Casopis() { Id = 6, Naziv = "Rolling Stone", KategorijaId = 1, Cijena = 60.00m, ZemljaPodrijetlaId = 2, Urednik = "Jason Fine", SlikaUrl = "https://rappart.com/wp-content/uploads/2019/04/R1345_COV_BIDEN.jpg" },
                new Casopis() { Id = 7, Naziv = "Dissent", KategorijaId = 4, Cijena = 60.00m, ZemljaPodrijetlaId = 2, Urednik = "Natasha Lewis", SlikaUrl = "https://www.dissentmagazine.org/wp-content/files_mf/1578091896Winter2020_frontcover_350x500.jpg" }
            );

            builder.Entity<Kategorija>().HasData(
                new Kategorija() { Id = 1, Naziv = "Glazba"},
                new Kategorija() { Id = 2, Naziv = "Moda" },
                new Kategorija() { Id = 3, Naziv = "Poslovanje" },
                new Kategorija() { Id = 4, Naziv = "Politika" }
                );

            builder.Entity<ZemljaPodrijetla>().HasData(
                new ZemljaPodrijetla() { Id = 1, Naziv = "Hrvatska" },
                new ZemljaPodrijetla() { Id = 2, Naziv = "SAD" },
                new ZemljaPodrijetla() { Id = 3, Naziv = "Francuska" }
                );
        }
    }
}
