using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Bll.Repositories
{
    public class TranslatorsRepository : BaseRepository
    {
        public TranslatorsRepository()
            : base()
        {
        }

        public TranslatorsRepository(Entities dbContext)
            : base(dbContext)
        {
        }

        public Translator CreateTranslator(string emailAddress, string password, string firstName, string lastName, string mobileNumber, string contactNumber, string address, string photoUrl, bool active, string role)
        {
            Translator tempTranslator =
                new Translator()
                {
                    Created = DateTime.Now,
                    EmailAddress = emailAddress,
                    Password = password,
                    FirstName = firstName,
                    LastName = lastName,
                    MobileNumber = mobileNumber,
                    ContactNo = contactNumber,
                    Address = address,
                    Active = active,
                    PhotoURL = photoUrl,
                    Role = role

                };
            DbContext.Translators.Add(tempTranslator);
            DbContext.SaveChanges();
            return tempTranslator;
        }

        public Translator GetNonDeletedById(long id)
        {
            return DbContext.Translators.Where(m => m.Id == id && m.Deleted == null).FirstOrDefault();
        }

        public Translator GetActiveById(long id)
        {
            return DbContext.Translators.Where(m => m.Id == id && m.Deleted == null && m.Active==true).FirstOrDefault();
        }

        public Translator CheckLogin(string UserName, string Password)
        {
            return DbContext.Translators.Where(m => m.EmailAddress == UserName && m.Password == Password && m.Deleted == null && m.Active == true).FirstOrDefault();
        }


        public Translator GetAllById(long id)
        {
            return DbContext.Translators.Where(m => m.Id == id).FirstOrDefault();
        }

        public IEnumerable<Translator> GetAllNonDeleted()
        {
            return DbContext.Translators.Where(m => m.Deleted == null).ToList();
        }

        public void DeleteTranslator(long Id)
        {
            Translator temp = GetNonDeletedById(Id);
            temp.Active = false;
            temp.Deleted = DateTime.Now;
        }


        public Translator GetNonDeletedByEmail(string EmailId)
        {
            return DbContext.Translators.Where(m => m.EmailAddress == EmailId && m.Deleted == null).FirstOrDefault();
        }

        public void UpdateTranslator(long id, string firstName, string lastName, string mobileNumber, string contactNumber, string address, string photoUrl, bool active,string role)
        {
            Translator temp = GetNonDeletedById(id);
            //temp.Password = password;
            temp.FirstName = firstName;
            temp.LastName = lastName;
            temp.MobileNumber = mobileNumber;
            temp.ContactNo = contactNumber;
            temp.Address = address;
            temp.Active = active;
            temp.PhotoURL = photoUrl;
            temp.Role = role;
        }
    }
}
