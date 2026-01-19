using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Bll.Repositories
{
    public class TranslationKeysRepository : BaseRepository
    {

        protected TranslationsRepository TranslationRepo;
        public TranslationKeysRepository()
            : base()
        {
        }

        public TranslationKeysRepository(Entities dbContext)
            : base(dbContext)
        {
            //DbContext = new Entities();
            TranslationRepo = new TranslationsRepository(DbContext);
        }

        public TranslationKey CreateTranslationKey(string key, string englishValue, long translatorId, bool active,string comments)
        {
            TranslationKey tempTranslationKey =
                new TranslationKey()
                {
                    Created = DateTime.Now,
                    TranslatorId = translatorId,
                    Key = key,
                    EnglishValue = englishValue,
                    Active = active,
                    Comments = comments
                };
            DbContext.TranslationKeys.Add(tempTranslationKey);
            DbContext.SaveChanges();
            return tempTranslationKey;
        }

        public TranslationKey GetNonDeletedById(long id)
        {
            return DbContext.TranslationKeys.Where(m => m.Id == id && m.Deleted == null).FirstOrDefault();
        }

        public IEnumerable<TranslationKey> SearchKeysByKey(string searchText)
        {
            return DbContext.TranslationKeys.Where(m => m.Key.Contains(searchText) && m.Deleted == null).ToList();
        }

        public IEnumerable<TranslationKey> SearchKeysTranslation(string searchText)
        {
            return DbContext.TranslationKeys.Where(m => m.EnglishValue.Contains(searchText) && m.Deleted == null).ToList();
        }

        public IEnumerable<TranslationKey> GetNewNonDeletedKeys()
        {
            DateTime from = DateTime.Today;
            DateTime to = DateTime.Today.AddDays(1).AddTicks(-1);
            return DbContext.TranslationKeys.Where(m => (m.Created >= from && m.Created <= to) && m.Deleted == null).ToList();
        }

        public IEnumerable<Translation> GetUntranslatedNonDeletedKeys()
        {
            DateTime from = DateTime.Today;
            DateTime to = DateTime.Today.AddDays(1).AddTicks(-1);
            return DbContext.Translations.Where(m => m.Translated == null && m.Deleted == null).ToList();
        }

        public TranslationKey GetNonDeletedByTranslatorId(long translatorId)
        {
            return DbContext.TranslationKeys.Where(m => m.TranslatorId == translatorId && m.Deleted == null).FirstOrDefault();
        }       

        public TranslationKey GetNonDeletedByKey(string key)
        {
            return DbContext.TranslationKeys.Where(m => m.Key == key && m.Deleted == null).FirstOrDefault();
        }


        public TranslationKey GetAllById(long id)
        {
            return DbContext.TranslationKeys.Where(m => m.Id == id).FirstOrDefault();
        }

        public IEnumerable<TranslationKey> GetAllNonDeleted()
        {
            return DbContext.TranslationKeys.Where(m => m.Deleted == null).OrderByDescending(m=>m.Created).ToList();
        }

        public void DeleteTranslationKey(TranslationKey key)
        {
            //deleting translations for the particular key
            IEnumerable<Translation> obj = new List<Translation>();
            obj = TranslationRepo.GetNonDeletedByTranslationKeyId(key.Id);
            foreach(Translation tr in obj)
            { 
                tr.Active = false;
                tr.Deleted = DateTime.Now;
            }
            TranslationRepo.SaveChanges();

            //delete key
            key.Active = false;
            key.Deleted = DateTime.Now;
        }


        public void UpdateTranslationKey(string key, string englishValue, long translatorId, bool active, string comments)
        {
            TranslationKey temp = GetNonDeletedByKey(key);            
            temp.TranslatorId = translatorId;
            temp.Key = key;
            temp.EnglishValue = englishValue;
            temp.Active = active;
            temp.Comments = comments;

            //updating english values in translations
            TranslationRepo.UpdateTranslationForUKAndUS(temp.Id, translatorId, englishValue, comments);
            TranslationRepo.SaveChanges();
            //set translationRequired as true
            TranslationRepo.RequireTranslation(temp.Id);
            TranslationRepo.SaveChanges();            
            
        }
    }
}
