using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Bll.Repositories
{
    public class CountryLanguagesRepository : BaseRepository
    {
        public CountryLanguagesRepository()
            : base()
        {
        }

        public CountryLanguagesRepository(Entities dbContext)
            : base(dbContext)
        {
        }

        public CountryLanguage CreateCountryLanguage(long countryId, string title, bool active, long languageId)
        {
            CountryLanguage temp =
                new CountryLanguage()
                {
                    Active = active,
                    Created = DateTime.Now,
                    CountryId = countryId,
                    LanguageId = languageId,
                    Title = title

                };
            DbContext.CountryLanguages.Add(temp);
            DbContext.SaveChanges();
            return temp;
        }

        public void DeleteCountryLanguage(long Id)
        {
            CountryLanguage temp = GetNonDeletedById(Id);
            temp.Deleted = DateTime.Now;
        }

        public CountryLanguage GetNonDeletedById(long id)
        {
            return DbContext.CountryLanguages.Where(m => m.Id == id && m.Deleted == null).FirstOrDefault();
        }

        public void UpdateCountryLanguage(long id, long countryId, string title, bool active, long languageId)
        {
            CountryLanguage temp = GetNonDeletedById(id);
            temp.Active = active;
            temp.CountryId = countryId;
            temp.LanguageId = languageId;
            temp.Title = title;
        }

        public IEnumerable<CountryLanguage> GetAllNonDeleted()
        {
            return DbContext.CountryLanguages.Where(m => m.Deleted == null).OrderBy(m => m.Title).ToList();
        }

        public CountryLanguage GetNonDeletedByTitle(string title)
        {
            return DbContext.CountryLanguages.Where(m => m.Title == title && m.Deleted == null).FirstOrDefault();
        }

        public CountryLanguage GetNonDeletedByCountryAndLanguage(long countryId,long languageId)
        {
            return DbContext.CountryLanguages.Where(m => m.CountryId == countryId && m.LanguageId == languageId && m.Deleted == null).FirstOrDefault();
        }

        public IEnumerable<CountryLanguage> GetAllByLanguageId(long languageID)
        {
            return DbContext.CountryLanguages.Where(m => m.LanguageId == languageID).ToList();
        }

        public IEnumerable<CountryLanguage> GetAllByCountryId(long countryID)
        {
            return DbContext.CountryLanguages.Where(m => m.CountryId == countryID).ToList();
        }


        public Language GetAllById(int id)
        {
            return DbContext.Languages.Where(m => m.Id == id).FirstOrDefault();
        }
    }
}
