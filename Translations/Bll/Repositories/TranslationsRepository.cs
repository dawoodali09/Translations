using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Bll.Repositories
{
    public class TranslationsRepository : BaseRepository
    {
        TranslatorCountryLanguagesRepository TranslatorCountryLanguagesRepo;
       CountryLanguagesRepository CountryLanguageRepo;
        public TranslationsRepository()
            : base()
        {
        }

        public TranslationsRepository(Entities dbContext)
            : base(dbContext)
        {
            DbContext = new Entities();
            TranslatorCountryLanguagesRepo = new TranslatorCountryLanguagesRepository(dbContext);
            CountryLanguageRepo = new CountryLanguagesRepository(dbContext);
        }

        public Translation CreateTranslation(long translationKeyId, long translatorId, long countryLanguageId, string value, string comments, bool active)
        {
            Translation tempTranslation =
                new Translation()
                {
                    Created = DateTime.Now,
                    TranslatorId = translatorId,
                    TranslationKeyId = translationKeyId,
                    CountryLanguageId = countryLanguageId,
                    Value = value,
                    Comments = comments,
                    Active = active
                };
            DbContext.Translations.Add(tempTranslation);
            DbContext.SaveChanges();
            return tempTranslation;
        }

        public Translation GetNonDeletedById(long id)
        {
            return DbContext.Translations.Where(m => m.Id == id && m.Deleted == null).FirstOrDefault();
        }

        public Translation GetNonDeletedByTranslatorId(long translatorId)
        {
            return DbContext.Translations.Where(m => m.TranslatorId == translatorId && m.Deleted == null).FirstOrDefault();
        }

        public IEnumerable<Translation> GetNonDeletedByTranslationKeyId(long translationKeyId)
        {
            return DbContext.Translations.Where(m => m.TranslationKeyId == translationKeyId && m.Deleted == null).ToList();
        }

        public Translation GetNonDeletedByTranslationKeyIdAndCountryLanguageID(long translationKeyId,long countryLanguageId)
        {
            return DbContext.Translations.Where(m => m.TranslationKeyId == translationKeyId && m.CountryLanguageId == countryLanguageId && m.Deleted == null).FirstOrDefault();
        }

        public IEnumerable<Translation> GetCompletedTranslationsByUserId(long userId)
        {
            List<Translation> obj = new List<Translation>();
            foreach(TranslatorCountryLanguage tcl in TranslatorCountryLanguagesRepo.GetNonDeletedByTranslatorID(userId))
            {
                List<Translation> newObj = new List<Translation>();
                newObj = DbContext.Translations.Where(m => m.Translated != null && m.Deleted == null && m.CountryLanguageId == tcl.CountryLanguageId).OrderByDescending(m=>m.Translated).ToList(); 
                obj.AddRange(newObj);
            }
            return obj;            
        }       

        public IEnumerable<Translation> GetPendingTranslations(long userId)
        {
            List<Translation> obj = new List<Translation>();
            foreach (TranslatorCountryLanguage tcl in TranslatorCountryLanguagesRepo.GetNonDeletedByTranslatorID(userId))
            {
                List<Translation> newObj = new List<Translation>();
                newObj = DbContext.Translations.Where(m => m.Translated == null && m.Deleted == null && m.CountryLanguageId == tcl.CountryLanguageId).ToList();
                obj.AddRange(newObj);
            }
            return obj; 
        }


        public Translation GetAllById(long id)
        {
            return DbContext.Translations.Where(m => m.Id == id).FirstOrDefault();
        }

        public IEnumerable<Translation> GetAllNonDeleted()
        {
            return DbContext.Translations.Where(m => m.Deleted == null).ToList();
        }

        public void DeleteTranslation(long Id)
        {
            Translation temp = GetNonDeletedById(Id);
            temp.Active = false;
            temp.Deleted = DateTime.Now;
        }


        public void UpdateTranslation(long id, long translatorId, string value, string comments, bool active)
        {
            Translation temp = GetNonDeletedById(id);
            temp.TranslatorId = translatorId;
            temp.Value = value;
            temp.Comments = comments;
            temp.Active = active;
            temp.Translated = DateTime.Now;
        }

        public void UpdateTranslationForUKAndUS(long keyId, long translatorId, string value, string comments)
        {
            // Get UK English CountryLanguage (look for English language with UK country)
            var ukCountryLanguage = CountryLanguageRepo.GetEnglishUK();
            if (ukCountryLanguage != null)
            {
                Translation tempUK = GetNonDeletedByTranslationKeyIdAndCountryLanguageID(keyId, ukCountryLanguage.Id);
                if (tempUK != null)
                {
                    tempUK.TranslatorId = translatorId;
                    tempUK.Value = value;
                    tempUK.Comments = comments;
                    tempUK.Active = true;
                    tempUK.Translated = DateTime.Now;
                }
            }

            // Get US English CountryLanguage (look for English language with US country)
            var usCountryLanguage = CountryLanguageRepo.GetEnglishUS();
            if (usCountryLanguage != null)
            {
                Translation tempUS = GetNonDeletedByTranslationKeyIdAndCountryLanguageID(keyId, usCountryLanguage.Id);
                if (tempUS != null)
                {
                    tempUS.TranslatorId = translatorId;
                    tempUS.Value = value;
                    tempUS.Comments = comments;
                    tempUS.Active = true;
                    tempUS.Translated = DateTime.Now;
                }
            }
        }

        public void RequireTranslation(long translationKeyId)
        {
            IEnumerable<Translation> temp = new List<Translation>();
            temp = GetNonDeletedByTranslationKeyId(translationKeyId);
            if (temp != null)
            {
                // Get UK and US English CountryLanguage IDs to exclude them
                var ukCountryLanguage = CountryLanguageRepo.GetEnglishUK();
                var usCountryLanguage = CountryLanguageRepo.GetEnglishUS();
                long? ukId = ukCountryLanguage?.Id;
                long? usId = usCountryLanguage?.Id;

                foreach (Translation t in temp)
                {
                    // Skip UK and US English translations
                    if (t.CountryLanguageId != ukId && t.CountryLanguageId != usId)
                    {
                        t.Translated = null;
                    }
                }
            }
        }
    }
}
