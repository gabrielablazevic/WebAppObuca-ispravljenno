using Microsoft.EntityFrameworkCore;

namespace WebAppObuca.Models
{
    public class RepozitorijUpita : IRepozitorijUpita
    {
        private readonly AppDbContext _appDbContext;
        public RepozitorijUpita(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Create(Obuca obuca)
        {
            _appDbContext.Add(obuca);
            _appDbContext.SaveChanges();
        }

        public void Create(Brend brend)
        {
            _appDbContext.Add(brend);
            _appDbContext.SaveChanges();
        }

        public void Delete(Obuca obuca)
        {
            _appDbContext.Obuca.Remove(obuca);
            _appDbContext.SaveChanges();
        }

        public void Delete(Brend brend)
        {
            _appDbContext.Brend.Remove(brend);
            _appDbContext.SaveChanges();
        }

        public Obuca DohvatiObucuSIdom(int id)
        {
            return _appDbContext.Obuca
                .Include(k => k.Brend)
                .FirstOrDefault(f => f.Id == id);
        }

        public Brend DohvatiBrendSIdom(int id)
        {
            return _appDbContext.Brend.Find(id);
        }

        public int BrendSljedeciId()
        {
            int zadnjiId = _appDbContext.Brend
               .Count();

            int sljedeciId = zadnjiId + 1;
            return sljedeciId;
        }

        public IEnumerable<Obuca> PopisObuca()
        {

            return _appDbContext.Obuca.Include(k => k.Brend);
        }

        public IEnumerable<Brend> PopisBrend()
        {
            return _appDbContext.Brend;
        }

        public int SljedeciId()
        {
            int zadnjiId = _appDbContext.Obuca
                .Include(k => k.Brend)
                .Max(x => x.Id);

            int sljedeciId = zadnjiId + 1;
            return sljedeciId;
        }

        public void Update(Obuca obuca)
        {
            _appDbContext.Obuca.Update(obuca);
            _appDbContext.SaveChanges();
        }

        public void Update(Brend brend)
        {
            _appDbContext.Brend.Update(brend);
            _appDbContext.SaveChanges();
        }
    }
}
