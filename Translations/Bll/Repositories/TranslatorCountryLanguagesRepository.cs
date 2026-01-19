using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Bll.Repositories
{
    public class TranslatorCountryLanguagesRepository : BaseRepository
    {
        public TranslatorCountryLanguagesRepository()
            : base()
        {
        }

        public TranslatorCountryLanguagesRepository(Entities dbContext)
            : base(dbContext)
        {
        }

        public TranslatorCountryLanguage CreateTranslatorCountryLanguage(long translatorId, long countryLanguageId, string note, bool active)
        {
            TranslatorCountryLanguage tempTranslatorCountryLanguage =
                new TranslatorCountryLanguage()
                {
                    Created = DateTime.Now,
                    TranslatorId = translatorId,
                    CountryLanguageId = countryLanguageId,
                    Note = note,
                    Active = active
                };
            DbContext.TranslatorCountryLanguages.Add(tempTranslatorCountryLanguage);
            DbContext.SaveChanges();
            return tempTranslatorCountryLanguage;
        }

        public TranslatorCountryLanguage GetNonDeletedById(long id)
        {
            return DbContext.TranslatorCountryLanguages.Where(m => m.Id == id && m.Deleted == null).FirstOrDefault();
        }


        public TranslatorCountryLanguage GetAllById(long id)
        {
            return DbContext.TranslatorCountryLanguages.Where(m => m.Id == id).FirstOrDefault();
        }

        public IEnumerable<TranslatorCountryLanguage> GetAllNonDeleted()
        {
            return DbContext.TranslatorCountryLanguages.Where(m => m.Deleted == null).ToList();
        }

        public void DeleteTranslatorCountryLanguage(long Id)
        {
            TranslatorCountryLanguage temp = GetNonDeletedById(Id);
            temp.Active = false;
            temp.Deleted = DateTime.Now;
        }

        public TranslatorCountryLanguage GetNonDeletedByCountryLanguageId(long countryLanguageId)
        {
            return DbContext.TranslatorCountryLanguages.Where(m => m.CountryLanguageId == countryLanguageId && m.Deleted == null).FirstOrDefault();
        }

        public IEnumerable<TranslatorCountryLanguage> GetNonDeletedByTranslatorID(long translatorId)
        {
            return DbContext.TranslatorCountryLanguages.Where(m => m.TranslatorId == translatorId && m.Deleted == null && m.Active == true).ToList();
        }

        public TranslatorCountryLanguage GetByTranslatorAndCountryLanguageId(long translatorId,long countryLanguageId)
        {
            return DbContext.TranslatorCountryLanguages.Where(m => m.TranslatorId == translatorId && m.CountryLanguageId == countryLanguageId && m.Deleted == null).FirstOrDefault();
        }

        public void UpdateTranslatorCountryLanguage(long id, long translatorId, long countryLanguageId, string note, bool active)
        {
            TranslatorCountryLanguage temp = GetNonDeletedById(id);
            temp.TranslatorId = translatorId;
            temp.CountryLanguageId = countryLanguageId;
            temp.Note = note;
            temp.Active = active;
        }
    }
}
