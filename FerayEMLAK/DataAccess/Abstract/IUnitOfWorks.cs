using Core.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUnitOfWorks
    {
        public Task<IResult> SaveChanges();
        ////ICategoriesRepositories RepoCategories { get; }
        ////IAimRepositories RepoAim { get; }
        ////IFavoritesRepositories RepoFavorites { get; }
        //IProductImagesRepositories RepoProductImages { get; }
        ////IProductRepositories RepoProduct { get; }
        ////IPropertiesRepositories RepoProperties { get; }
        ////IUserRepositories RepoUser { get; }
    }
}
