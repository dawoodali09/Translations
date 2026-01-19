using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Bll.Repositories;
using System.Drawing;
using System.Resources;
using System.Collections;


namespace ResxFileGenerator
{
    public class Program
    {   
        protected Entities DbContext;
        protected TranslatorsRepository TranslatorsRepo;
        protected TranslationKeysRepository TranslationKeyRepo;
        protected CountryLanguagesRepository CountryLanguageRepo;
        protected CountriesRepository CountryRepo;
        protected LanguagesRepository LanguageRepo;
        protected TranslationsRepository TranslationRepo;
        protected TranslatorCountryLanguagesRepository TranslatorCountryLanguageRepo;

        public Program()
        {
            DbContext = new Entities();
            TranslatorsRepo = new TranslatorsRepository(DbContext);
            TranslationKeyRepo = new TranslationKeysRepository(DbContext);
            CountryLanguageRepo = new CountryLanguagesRepository(DbContext);
            CountryRepo = new CountriesRepository(DbContext);
            LanguageRepo = new LanguagesRepository(DbContext);
            TranslationRepo = new TranslationsRepository(DbContext);
            TranslatorCountryLanguageRepo = new TranslatorCountryLanguagesRepository(DbContext);
        }
        static void Main(string[] args)
        {
            Program prog = new Program();
            //prog.CreateRegxTransaltionFiles();
            prog.createreg();
        }

        public void CreateRegxTransaltionFiles()
        {

            IEnumerable<TranslationKey> keys1 = new List<TranslationKey>();
              keys1 = TranslationKeyRepo.GetAllNonDeleted();
              
              foreach (TranslationKey keys in keys1)
               {
                   Console.WriteLine("Key" + keys.EnglishValue);
                   int i = 0;
                  foreach(CountryLanguage CntLang in CountryLanguageRepo.GetAllNonDeleted())
                  {
                      Translation obj = new Translation();
                      obj = TranslationRepo.GetNonDeletedByTranslationKeyIdAndCountryLanguageID(keys.Id, CntLang.Id);

                      ResXResourceWriter resx = new ResXResourceWriter(@"ResxFiles\Test1.resx");
                     
                        //  ResXDataNode node = new ResXDataNode()
                         // resx.AddResource("Title", "Classic American Cars");
                          if(obj != null)
                          {
                              i++;
                              string Key = "testkey"+i;// keys.EnglishValue.Trim();
                              resx.AddResource(Key, "value1");
                              
                          }
                  

                  }
               }
        }

        public void createreg()
        {
            foreach (CountryLanguage CntLang in CountryLanguageRepo.GetAllNonDeleted())
            {
                if (!System.IO.Directory.Exists(@"ResxFiles"))
                {
                    System.IO.Directory.CreateDirectory(@"ResxFiles");
                }

                Console.WriteLine("Language= " + CntLang.Language.Name);

                string FileName = GetResxFileName(CntLang.Title);
                
                ResXResourceWriter resx = new ResXResourceWriter(@"ResxFiles\" + FileName);

                Console.WriteLine("FileName= " + FileName);

                foreach (TranslationKey keys in TranslationKeyRepo.GetAllNonDeleted())
                {
                    Translation obj = new Translation();
                    obj = TranslationRepo.GetNonDeletedByTranslationKeyIdAndCountryLanguageID(keys.Id, CntLang.Id);

                    Console.WriteLine("keys= " + keys.Key);

                    if (obj != null)
                    {
                        string Key = obj.TranslationKey.Key != null ? obj.TranslationKey.Key : string.Empty;
                        string Value = obj.Value != null ? obj.Value : string.Empty;
                        if (Value != "")
                        {
                           resx.AddResource(Key, Value);
                           Console.WriteLine("keys Inserted Successfully= " + Key + "  Value " + Value);
                        }
                       
                    }
                }
                resx.Close();
            }
        }

        public string GetResxFileName(string Language)
        {
            string Result = string.Empty;
            Result = "string." + Language + ".resx";
             //if(Language.ToLowerInvariant() == "english")
             //{
             //    Result = "string.resx";
             //}
             //else if (Language.ToLowerInvariant() == "turkish")
             //{
             //    Result = "string.tr-TR.resx";
             //}
             //else
             //{
             //    Result = "string.Others.resx";
             //}

            return Result;
        }
    }
}
