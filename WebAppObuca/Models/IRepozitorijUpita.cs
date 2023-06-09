namespace WebAppObuca.Models
{
    public interface IRepozitorijUpita
    {
         
        IEnumerable<Obuca> PopisObuca(); 
        void Create(Obuca obuca); 
        void Delete(Obuca obuca); 
        void Update(Obuca obuca); 
        int SljedeciId();
        int BrendSljedeciId();
        Obuca DohvatiObucuSIdom(int id);

        IEnumerable<Brend> PopisBrend();
        void Create(Brend brend);
        void Delete(Brend brend);
        void Update(Brend brend);

        Brend DohvatiBrendSIdom(int id);


    }
}
