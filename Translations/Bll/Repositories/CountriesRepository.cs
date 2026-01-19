using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Bll.Repositories
{
    public class CountriesRepository : BaseRepository
    {
        public CountriesRepository()
            : base()
        {
        }

        public CountriesRepository(Entities dbContext)
            : base(dbContext)
        {
        }

        public void CreateCountry(string name, string ISONumber, string ISOCode, string shortCode, bool active)
        {
            Country tempCountry =
                new Country()
                {
                    Created = DateTime.Now,
                    Name = name,
                    ISONumber = ISONumber,
                    ISOCode = ISOCode,
                    ShortCode = shortCode,
                    Active = active
                };
            DbContext.Countries.Add(tempCountry);
        }

        public IEnumerable<Country> GetAllNonDeleted()
        {
            return DbContext.Countries.Where(m => m.Deleted == null).OrderBy(m => m.Name).ToList();
        }

        public IEnumerable<Country> GetAllActive()
        {
            return DbContext.Countries.Where(m => m.Deleted == null && m.Active == true).ToList().OrderBy(m => m.Name);
        }

        public Country GetNonDeletedById(long id)
        {
            return DbContext.Countries.Where(m => m.Id == id && m.Deleted == null).FirstOrDefault();
        }


        public Country GetNonDeletedByName(string Name)
        {
            return DbContext.Countries.Where(m => m.Name == Name && m.Deleted == null).FirstOrDefault();
        }

        public void DeleteCountry(long Id)
        {
            Country temp = GetNonDeletedById(Id);
            temp.Deleted = DateTime.Now;
        }

        public void UpdateCountry(long id, string ISONumber, string name, string ISOCode, string shortCode, bool active)
        {
            Country temp = GetNonDeletedById(id);
            temp.Name = name;
            temp.ISONumber = ISONumber;
            temp.ISOCode = ISOCode;
            temp.ShortCode = shortCode;
            temp.Active = active;
        }
    }
}
