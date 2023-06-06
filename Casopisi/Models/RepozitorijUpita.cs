using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;

namespace Casopisi.Models
{
    public class RepozitorijUpita : IRepozitorijUpita
    {
        private readonly AppDbContext _appDbContext;
        public RepozitorijUpita(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Casopis> PopisCasopisa()
        {
            return _appDbContext.Casopisi.Include(x => x.Kategorija).Include(x => x.ZemljaPodrijetla);
        }
        public void Create(Casopis casopis)
        {
            _appDbContext.Add(casopis);
            _appDbContext.SaveChanges();
        }
        public void Update(Casopis casopis)
        {
            _appDbContext.Casopisi.Update(casopis);
            _appDbContext.SaveChanges();
        }
        public void Delete(Casopis casopis)
        {
            _appDbContext.Casopisi.Remove(casopis);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<Kategorija> PopisKategorija()
        {
            return _appDbContext.Kategorije;
        }
        public void Create(Kategorija kategorija)
        {
            _appDbContext.Add(kategorija);
            _appDbContext.SaveChanges();
        }
        public void Update(Kategorija kategorija)
        {
            _appDbContext.Kategorije.Update(kategorija);
            _appDbContext.SaveChanges();
        }
        public void Delete(Kategorija kategorija)
        {
            _appDbContext.Kategorije.Remove(kategorija);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<ZemljaPodrijetla> PopisZemalja()
        {
            return _appDbContext.Zemlje;
        }
        public void Create(ZemljaPodrijetla zemlja)
        {
            _appDbContext.Add(zemlja);
            _appDbContext.SaveChanges();
        }
        public void Update(ZemljaPodrijetla zemlja)
        {
            _appDbContext.Zemlje.Update(zemlja);
            _appDbContext.SaveChanges();
        }
        public void Delete(ZemljaPodrijetla zemlja)
        {
            _appDbContext.Zemlje.Remove(zemlja);
            _appDbContext.SaveChanges();
        }

        public int SljedeciId()
        {
            int zadnjiId = _appDbContext.Casopisi.Include(v => v.Kategorija).Include(j => j.ZemljaPodrijetla).Max(x => x.Id);
            int sljedeciId = zadnjiId + 1;

            return sljedeciId;
        }

        public Casopis DohvatiCasopisSIdom(int id)
        {
            return _appDbContext.Casopisi.Include(v => v.Kategorija).Include(j => j.ZemljaPodrijetla).FirstOrDefault(t => t.Id == id);
        }

        public Kategorija DohvatiKategorijuSIdom(int id)
        {
            return _appDbContext.Kategorije.Find(id);
        }

        public ZemljaPodrijetla DohvatiZemljuSIdom(int id)
        {
            return _appDbContext.Zemlje.Find(id);
        }
    }
}
