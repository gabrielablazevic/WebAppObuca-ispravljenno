using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebAppObuca.Models
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Obuca> Obuca { get; set; }
        public DbSet<Brend> Brend { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Obuca>().Property(c => c.Cijena).HasPrecision(10, 2);


            builder.Entity<Brend>().HasData(
                new Brend() { Id = 1, Model = "Nike" },
                new Brend() { Id = 2, Model = "Adidas" },
                new Brend() { Id = 3, Model = "Puma" },
                new Brend() { Id = 4, Model = "Reebook" },
                new Brend() { Id = 5, Model = "New Balance" }
                );


            builder.Entity<Obuca>().HasData(
                new Obuca() { Id = 1, Model = "Adidas ADI2000", Cijena = 799.00m,  SlikaUrl = "https://static.footshop.com/834961/256309.jpg", BrendId = 2 },
                new Obuca() { Id = 2, Model = "Adidas DUNK", Cijena = 759.00m, SlikaUrl = "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/09c5ea6df1bd4be6baaaac5e003e7047_9366/Forum_Low_Shoes_White_FY7756_01_standard.jpg", BrendId = 2 },
                new Obuca() { Id = 3, Model = "Adidas LOW", Cijena = 699.00m, SlikaUrl = "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/f8addf34a82349f283e4af8c00b759fc_9366/Rivalry_Low_Shoes_White_IE4596_01_standard.jpg", BrendId = 2 },
                new Obuca() { Id = 4, Model = "Adidas FORUM", Cijena = 699.00m, SlikaUrl = "https://cdn-images.farfetch-contents.com/19/42/02/22/19420222_42685478_600.jpg", BrendId = 2 },
                new Obuca() { Id = 5, Model = "Adidas GAZELE", Cijena = 779.00m, SlikaUrl = "https://img.eobuwie.cloud/eob_product_512w_512h(1/2/b/2/12b2f5ae7dccbfcf6e7d85e99327b1eca472a084_01_0000300125113_is,jpg)/obuca-adidas-gazelle-gx2207-blue-ftwht-goldmt.jpg", BrendId = 2 },
                new Obuca() { Id = 6, Model = "Nike AIR FORCE", Cijena = 1099.00m, SlikaUrl = "https://static.nike.com/a/images/t_PDP_1280_v1/f_auto,q_auto:eco/b7d9211c-26e7-431a-ac24-b0540fb3c00f/air-force-1-07-mens-shoes-jBrhbr.png", BrendId = 1 },
                new Obuca() { Id = 7, Model = "Puma CALI DREAM", Cijena = 899.00m, SlikaUrl = "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_1350,h_1350/global/392730/14/sv01/fnd/EEA/fmt/png/Cali-Dream-Leather-Sneakers-Women", BrendId = 3 },
                new Obuca() { Id = 8, Model = "Reebok BB 4000 II", Cijena = 979.00m, SlikaUrl = "https://reebok.bynder.com/transform/dffca0ec-91f1-498c-aba1-ac48cbc31bee/100033844_SLC_eCom-tif?io=transform:fit,width:1000&quality=100", BrendId = 4 },
                new Obuca() { Id = 9, Model = "New Balance FUELCELL SUPERCOMP ELITE", Cijena = 1199.00m, SlikaUrl = "https://nb.scene7.com/is/image/NB/wrcelle3_nb_02_i?$dw_detail_main_lg$&bgc=f1f1f1&layer=1&bgcolor=f1f1f1&blendMode=mult&scale=10&wid=1600&hei=1600", BrendId = 5 }
                );




        }











    }
}
