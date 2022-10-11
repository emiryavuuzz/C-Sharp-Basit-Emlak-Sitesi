using Core.Results;
using Core.Results.ComplexTypes;
using DataAccess.Abstract;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class UnitOfWorks
    {
        private readonly FerayContext db;
        public UnitOfWorks(FerayContext db)
        {
            this.db = db;
        }
        public async Task<IResult> SaveChanges()
        {
            using (db.Database.BeginTransaction())
            {
                try
                {
                    db.SaveChanges();
                    db.Database.CommitTransaction(); // Datalarda Sorun yok ise İşlem Onaylanıyor.
                    return new Result(ResultStatus.Success, "İşlem Başarılı");
                }
                catch (Exception e)
                {
                    db.Database.RollbackTransaction();// Datalarda Sorun var ise İşlemi geri al.
                    return new Result(ResultStatus.Success, "İşlem Başarısız", e);
                }
            }
        }

        //private CategoriesRepositories Categories;
        //private AimRepositories Aim;
        //private FavoritesRepositories Favorites;
        //private ProductImagesRepositories ProductImages;
        //private ProductRepositories Product;
        //private PropertiesRepositories Properties;
        //private UserRepositories User;

        //public ICategoriesRepositories RepoCategories => Categories ?? new CategoriesRepositories(db);
        //public IAimRepositories RepoAim => Aim ?? new AimRepositories(db);
        //public IProductRepositories RepoProduct => Product ?? new ProductRepositories(db);
        //public IProductImagesRepositories RepoProductImages => ProductImages ?? new ProductImagesRepositories(db);
        //public IPropertiesRepositories RepoProperties => Properties ?? new PropertiesRepositories(db);
        //public IFavoritesRepositories RepoFavorites => Favorites ?? new FavoritesRepositories(db);
        //public IUserRepositories RepoUser => User ?? new UserRepositories(db);
    }
}
