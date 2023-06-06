namespace Casopisi.Models
{
    public interface IRepozitorijUpita
    {
        IEnumerable<Casopis> PopisCasopisa();
        void Create(Casopis casopis);
        void Update(Casopis casopis);
        void Delete(Casopis casopis);
        Casopis DohvatiCasopisSIdom(int id);

        IEnumerable<Kategorija> PopisKategorija();
        void Create(Kategorija kategorija);
        void Update(Kategorija kategorija);
        void Delete(Kategorija kategorija);
        Kategorija DohvatiKategorijuSIdom(int id);

        IEnumerable<ZemljaPodrijetla> PopisZemalja();
        void Create(ZemljaPodrijetla zemlja);
        void Update(ZemljaPodrijetla zemlja);
        void Delete(ZemljaPodrijetla zemlja);
        ZemljaPodrijetla DohvatiZemljuSIdom(int id);

        int SljedeciId();
    }
}
