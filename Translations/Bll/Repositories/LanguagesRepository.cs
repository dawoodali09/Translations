using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Bll.Repositories
{
    public class LanguagesRepository : BaseRepository
    {
        public LanguagesRepository()
            : base()
        {
        }

        public LanguagesRepository(Entities dbContext)
            : base(dbContext)
        {
        }

        public void CreateLanguage(string code, string nativeName, string name, string note, bool active)
        {
            Language temp =
                new Language()
                {
                    Active = active,
                    Created = DateTime.Now,
                    Code = code,
                    NativeName = nativeName,
                    Name = name,
                    Note = note
                };
            DbContext.Languages.Add(temp);
        }

        public void DeleteLanguage(long Id)
        {
            Language temp = GetNonDeletedById(Id);
            temp.Deleted = DateTime.Now;
        }

        public void UpdateLanguage(long id, string code, string name, string nativeName, string note, bool active)
        {
            Language temp = GetNonDeletedById(id);
            temp.Active = active;
            temp.Code = code;
            temp.NativeName = nativeName;
            temp.Name = name;
            temp.Note = note;
        }

        public IEnumerable<Language> GetAllNonDeleted()
        {
            return DbContext.Languages.Where(m=>m.Deleted==null).OrderBy(m=>m.Name).ToList();
        }

        public Language GetByname(string name)
        {
            return DbContext.Languages.Where(m => m.Name == name).FirstOrDefault();            
        }

        public Language GetByIso(string code)
        {
            return DbContext.Languages.Where(m => m.Code == code).FirstOrDefault();            
        }

       
        public Language GetAllById(int id)
        {
            return DbContext.Languages.Where(m => m.Id == id).FirstOrDefault();            
        }

        public Language GetNonDeletedById(long id)
        {
            return DbContext.Languages.Where(m => m.Id == id && m.Deleted==null).FirstOrDefault();
        }
       
    }
}
