using System;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Media.Imaging;
using DataService.Context;

namespace DataService.Migrations
{
    
    internal sealed class Configuration : DbMigrationsConfiguration<EF>
    {
        public Configuration()
        {          
            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;           
        }

        protected override void Seed(EF EF)
        {
            //EF.Database.CreateIfNotExists ();

            Student_SeedFromSql (EF);
            Staff_SeedFromSql (EF);

            MessageBox.Show ("Seed Done");
        }



        private static void Staff_SeedFromSql ( EF EF )
        {
                      
            const string FilePath = @"C:\\Users\\Halid\\Documents\\Visual Studio 2013\\Projects\\Matrix\\DataService\\Initializer\\Staffs.sql";
                      
            var SqlFile = new FileInfo (@FilePath);
            var SqlString = SqlFile.OpenText ().ReadToEnd();
                    
            EF.Database.ExecuteSqlCommand ("DELETE FROM Staffs");
            EF.Database.ExecuteSqlCommand (SqlString);

            var x = EF.STAFF.ToList();

            x.ForEach (S => S.PHOTO_IDENTITY = GetRandomImg());
            //x.ForEach (S => S.STAFF_ID = "ST-" + GenID(6));                     
        }

        private static void Student_SeedFromSql ( EF EF )
        {

            const string FilePath = @"C:\Users\Halid\Documents\Visual Studio 2013\Projects\Matrix\DataService\Initializer\Students.sql";

            var SqlFile = new FileInfo (FilePath);
            var SqlString = SqlFile.OpenText ().ReadToEnd ();

            EF.Database.ExecuteSqlCommand ("DELETE FROM Students");
            EF.Database.ExecuteSqlCommand (SqlString);

            var x = EF.STUDENT.ToList ();

            x.ForEach (S => S.PHOTO_IDENTITY = GetRandomImg ());
            //x.ForEach (S => S.STUDENT_ID = "M-" + GenID (6));
           
        }



        #region Helpers

        public static string GenID ( int lengthOfTheID )
        {
            var x = new Random ();
            var IdOut = string.Empty;

            for(var i = 0; i < lengthOfTheID; i++)
            {
                IdOut = IdOut + x.Next (1, 9);
            }
            return IdOut;
        }

        private static byte[] GetRandomImg()
        {
            Thread.Sleep(1000);
            var x = new Random ().Next (1, 9);

            var Img = BitmapArrayFromFile("portrait" + x + ".jpg");

            return Img;
        }

        private static byte[] BitmapArrayFromFile ( string FilePath )
        {
            //FilePath = GetRes (FilePath);

            FilePath = @"C:\Users\Halid\Documents\Visual Studio 2013\Projects\Matrix\Matrix\Portrait\" + FilePath;
            if(!File.Exists (FilePath)) return null;

            var fs = new FileStream (FilePath, FileMode.Open, FileAccess.Read);
            var imgByteArr = new byte[fs.Length];
            fs.Read (imgByteArr, 0, Convert.ToInt32 (fs.Length));
            fs.Close ();
            return imgByteArr;
        }

        public static Byte[] ByteFromBitmap ( string PathInApp )
        {
            var bitmapImage = new BitmapImage(new Uri(GetRes(PathInApp)));

            byte[] data;
            var encoder = new JpegBitmapEncoder ();
            encoder.Frames.Add (BitmapFrame.Create (bitmapImage));
            using(var ms = new MemoryStream ())
            {
                encoder.Save (ms);
                data = ms.ToArray ();
            }
            return data;
        }

        private static string GetRes ( string pathInApplication, Assembly assembly = null )
        {
            if(assembly == null)
            {
                assembly = Assembly.GetExecutingAssembly ( );
            }

            if(pathInApplication[0] == '/')
            {
                pathInApplication = pathInApplication.Substring (1);
            }
            return (new Uri (@"pack://application:,,,/" + assembly.GetName ().Name + ";component/" + pathInApplication, UriKind.Absolute).ToString ());
        }

        #endregion

    }
}




//private static void AddPersonSeed ( EF EF )
//{
//    ImageBuff = BitmapArrayFromFile ("defaultStudent.png");

//    MessageBox.Show("adding person");

//    var MyPersons = new List<Person> {
//        //new Person {PERSON_ID = "DI100", FIRSTNAME = "Halid", LASTNAME = "Cisse", PHONE_NUMBER = "00122445545"},
//        //new Person {PERSON_ID = "DI102", FIRSTNAME = "Mat", LASTNAME = "Pearson", PHONE_NUMBER = "0012244545545"},
//        //new Person {PERSON_ID = "DI103", FIRSTNAME = "Dave" , LASTNAME = "Wood", PHONE_NUMBER = "001544545578"},
//        //new Person {PERSON_ID = "DI104", FIRSTNAME = "Adam", LASTNAME = "Nolan", PHONE_NUMBER = "0012445454545"}
//    };

//    //MyPersons.ForEach (Person => EF.PERSON.AddOrUpdate (Person));
//}


 //private static void AddStudentSeed ( EF EF )
 //       {
            
 //           var MyStudents = new List<Student>{

 //               new Student
 //               {
 //                   STUDENT_ID = "DI100", TITLE = "Mr", FIRSTNAME = "Halid", LASTNAME = "Cisse", PHOTO_IDENTITY = GetRandomImg(),
 //                   NATIONALITY = "Mali", IDENTITY_NUMBER = "PL785445", BIRTH_DATE = DateTime.Today.AddDays(-500), BIRTH_PLACE = "Tayba",
 //                   PHONE_NUMBER = "00122445545", EMAIL_ADRESS = "Halid@gmail.com", HOME_ADRESS ="Mabella, Rabat", REGISTRATION_DATE = DateTime.Today.AddDays(-100), STATUT = "Regulier"
 //               },

 //               new Student
 //               {
 //                   STUDENT_ID = "DI101", TITLE = "Mr", FIRSTNAME = "Mat", LASTNAME = "Pearson", PHOTO_IDENTITY = GetRandomImg(),
 //                   NATIONALITY = "Mali", IDENTITY_NUMBER = "PL785445", BIRTH_DATE = DateTime.Today.AddDays(-1200), BIRTH_PLACE = "Tripoli",
 //                   PHONE_NUMBER = "+124578784545", EMAIL_ADRESS = "Pearson@gmail.com", HOME_ADRESS ="Mabella, Rabat", REGISTRATION_DATE = DateTime.Today.AddDays(-100), STATUT = "Regulier"
 //               },

 //               new Student
 //               {
 //                   STUDENT_ID = "DI102", TITLE = "Mr", FIRSTNAME = "Dave", LASTNAME = "Wood", PHOTO_IDENTITY = GetRandomImg(),
 //                   NATIONALITY = "Senegal", IDENTITY_NUMBER = "PL785445", BIRTH_DATE = DateTime.Today.AddDays(-500), BIRTH_PLACE = "Tayba",
 //                   PHONE_NUMBER = "+78122445545", EMAIL_ADRESS = "Dave@gmail.com", HOME_ADRESS ="Mabella, Rabat", REGISTRATION_DATE = DateTime.Today.AddDays(-100), STATUT = "Regulier"
 //               },

 //               new Student
 //               {
 //                   STUDENT_ID = "DI103", TITLE = "Mr", FIRSTNAME = "Adam", LASTNAME = "Nolan", PHOTO_IDENTITY = GetRandomImg(),
 //                   NATIONALITY = "Mali", IDENTITY_NUMBER = "PL785445", BIRTH_DATE = DateTime.Today.AddDays(-1200), BIRTH_PLACE = "Tripoli",
 //                   PHONE_NUMBER = "+124578784545", EMAIL_ADRESS = "Nolan@gmail.com", HOME_ADRESS ="Mabella, Rabat", REGISTRATION_DATE = DateTime.Today.AddDays(-100), STATUT = "Regulier"
 //               },

 //               new Student
 //               {
 //                   STUDENT_ID = "DI104", TITLE = "Mr", FIRSTNAME = "Oumar", LASTNAME = "Cisse", PHOTO_IDENTITY = GetRandomImg(),
 //                   NATIONALITY = "Mali", IDENTITY_NUMBER = "PL785445", BIRTH_DATE = DateTime.Today.AddDays(-500), BIRTH_PLACE = "Tayba",
 //                   PHONE_NUMBER = "00122445545", EMAIL_ADRESS = "Oumar@gmail.com", HOME_ADRESS ="Mabella, Rabat", REGISTRATION_DATE = DateTime.Today.AddDays(-100), STATUT = "Regulier"
 //               },

 //               new Student
 //               {
 //                   STUDENT_ID = "DI105", TITLE = "Mr", FIRSTNAME = "Amadou", LASTNAME = "Pearson", PHOTO_IDENTITY = GetRandomImg(),
 //                   NATIONALITY = "Mali", IDENTITY_NUMBER = "PL785445", BIRTH_DATE = DateTime.Today.AddDays(-1200), BIRTH_PLACE = "Tripoli",
 //                   PHONE_NUMBER = "+124578784545", EMAIL_ADRESS = "Amadou@gmail.com", HOME_ADRESS ="Mabella, Rabat", REGISTRATION_DATE = DateTime.Today.AddDays(-100), STATUT = "Regulier"
 //               },

 //               new Student
 //               {
 //                   STUDENT_ID = "DI106", TITLE = "Mr", FIRSTNAME = "Saif", LASTNAME = "Wood", PHOTO_IDENTITY = GetRandomImg(),
 //                   NATIONALITY = "Senegal", IDENTITY_NUMBER = "PL785445", BIRTH_DATE = DateTime.Today.AddDays(-500), BIRTH_PLACE = "Tayba",
 //                   PHONE_NUMBER = "+78122445545", EMAIL_ADRESS = "Saif@gmail.com", HOME_ADRESS ="Mabella, Rabat", REGISTRATION_DATE = DateTime.Today.AddDays(-100), STATUT = "Regulier"
 //               },

 //               new Student
 //               {
 //                   STUDENT_ID = "DI107", TITLE = "Mr", FIRSTNAME = "Youssouf", LASTNAME = "Nolan", PHOTO_IDENTITY = GetRandomImg(),
 //                   NATIONALITY = "Mali", IDENTITY_NUMBER = "PL785445", BIRTH_DATE = DateTime.Today.AddDays(-1200), BIRTH_PLACE = "Tripoli",
 //                   PHONE_NUMBER = "+124578784545", EMAIL_ADRESS = "Youssouf@gmail.com", HOME_ADRESS ="Mabella, Rabat", REGISTRATION_DATE = DateTime.Today.AddDays(-100), STATUT = "Regulier"
 //               },

 //               new Student
 //               {
 //                   STUDENT_ID = "DI108", TITLE = "Mr", FIRSTNAME = "Katherine", LASTNAME = "Wright", PHOTO_IDENTITY = GetRandomImg(),
 //                   NATIONALITY = "Mali", IDENTITY_NUMBER = "PL785445", BIRTH_DATE = DateTime.Today.AddDays(-500), BIRTH_PLACE = "Tayba",
 //                   PHONE_NUMBER = "00122445545", EMAIL_ADRESS = "Wright@gmail.com", HOME_ADRESS ="Mabella, Rabat", REGISTRATION_DATE = DateTime.Today.AddDays(-100), STATUT = "Regulier"
 //               },

 //               new Student
 //               {
 //                   STUDENT_ID = "DI109", TITLE = "Mr", FIRSTNAME = "Oumou", LASTNAME = "Keita", PHOTO_IDENTITY = GetRandomImg(),
 //                   NATIONALITY = "Mali", IDENTITY_NUMBER = "PL785445", BIRTH_DATE = DateTime.Today.AddDays(-1200), BIRTH_PLACE = "Tripoli",
 //                   PHONE_NUMBER = "+124578784545", EMAIL_ADRESS = "Keita@gmail.com", HOME_ADRESS ="Mabella, Rabat", REGISTRATION_DATE = DateTime.Today.AddDays(-100), STATUT = "Regulier"
 //               },

 //               new Student
 //               {
 //                   STUDENT_ID = "DI110", TITLE = "Mr", FIRSTNAME = "Toto", LASTNAME = "Wood", PHOTO_IDENTITY = GetRandomImg(),
 //                   NATIONALITY = "Senegal", IDENTITY_NUMBER = "PL785445", BIRTH_DATE = DateTime.Today.AddDays(-500), BIRTH_PLACE = "Tayba",
 //                   PHONE_NUMBER = "+78122445545", EMAIL_ADRESS = "Toto@gmail.com", HOME_ADRESS ="Mabella, Rabat", REGISTRATION_DATE = DateTime.Today.AddDays(-100), STATUT = "Regulier"
 //               },

 //               new Student
 //               {
 //                   STUDENT_ID = "DI111", TITLE = "Mr", FIRSTNAME = "Tom", LASTNAME = "Nolan", PHOTO_IDENTITY = GetRandomImg(),
 //                   NATIONALITY = "Mali", IDENTITY_NUMBER = "PL785445", BIRTH_DATE = DateTime.Today.AddDays(-1200), BIRTH_PLACE = "Tripoli",
 //                   PHONE_NUMBER = "+124578784545", EMAIL_ADRESS = "Tom@gmail.com", HOME_ADRESS ="Mabella, Rabat", REGISTRATION_DATE = DateTime.Today.AddDays(-100), STATUT = "Regulier"
 //               },

 //               new Student
 //               {
 //                   STUDENT_ID = "DI112", TITLE = "Mr", FIRSTNAME = "Jerry", LASTNAME = "Cisse", PHOTO_IDENTITY = GetRandomImg(),
 //                   NATIONALITY = "Mali", IDENTITY_NUMBER = "PL785445", BIRTH_DATE = DateTime.Today.AddDays(-500), BIRTH_PLACE = "Tayba",
 //                   PHONE_NUMBER = "00122445545", EMAIL_ADRESS = "Jerry@gmail.com", HOME_ADRESS ="Mabella, Rabat", REGISTRATION_DATE = DateTime.Today.AddDays(-100), STATUT = "Regulier"
 //               },

 //               new Student
 //               {
 //                   STUDENT_ID = "DI113", TITLE = "Mr", FIRSTNAME = "Ousou", LASTNAME = "Pearson", PHOTO_IDENTITY = GetRandomImg(),
 //                   NATIONALITY = "Mali", IDENTITY_NUMBER = "PL785445", BIRTH_DATE = DateTime.Today.AddDays(-1200), BIRTH_PLACE = "Tripoli",
 //                   PHONE_NUMBER = "+124578784545", EMAIL_ADRESS = "Ousou@gmail.com", HOME_ADRESS ="Mabella, Rabat", REGISTRATION_DATE = DateTime.Today.AddDays(-100), STATUT = "Regulier"
 //               },

 //               new Student
 //               {
 //                   STUDENT_ID = "DI114", TITLE = "Mr", FIRSTNAME = "Braa", LASTNAME = "Wood", PHOTO_IDENTITY = GetRandomImg(),
 //                   NATIONALITY = "Senegal", IDENTITY_NUMBER = "PL785445", BIRTH_DATE = DateTime.Today.AddDays(-500), BIRTH_PLACE = "Tayba",
 //                   PHONE_NUMBER = "+78122445545", EMAIL_ADRESS = "Braa@gmail.com", HOME_ADRESS ="Mabella, Rabat", REGISTRATION_DATE = DateTime.Today.AddDays(-100), STATUT = "Regulier"
 //               },

 //               new Student
 //               {
 //                   STUDENT_ID = "DI115", TITLE = "Mr", FIRSTNAME = "Idrissa", LASTNAME = "Nolan", PHOTO_IDENTITY = GetRandomImg(),
 //                   NATIONALITY = "Mali", IDENTITY_NUMBER = "PL785445", BIRTH_DATE = DateTime.Today.AddDays(-1200), BIRTH_PLACE = "Tripoli",
 //                   PHONE_NUMBER = "+124578784545", EMAIL_ADRESS = "Idrissa@gmail.com", HOME_ADRESS ="Mabella, Rabat", REGISTRATION_DATE = DateTime.Today.AddDays(-100), STATUT = "Regulier"
 //               },

 //           };


 //           MyStudents.ForEach (Student => EF.STUDENT.AddOrUpdate (Student));

 //           MessageBox.Show ("Finish student");
 //       }

       

 //       private static void AddStaffSeed ( EF EF )
 //       {
            
 //           var MyStaffs = new List<Staff> {
 //               new Staff
 //               {
 //                   STAFF_ID = "DI100", POSITION = "Chef de Departement Info", DEPARTEMENT = "Informatique", HIRED_DATE = DateTime.Today.AddDays(-500), STATUT = "Regulier",                   
 //                   TITLE = "Mr", FIRSTNAME = "Halid", LASTNAME = "cisse", PHOTO_IDENTITY = GetRandomImg(),              
 //                   NATIONALITY = "", IDENTITY_NUMBER= "", BIRTH_DATE= DateTime.Today.AddDays(-5000),BIRTH_PLACE= "",PHONE_NUMBER= "",EMAIL_ADRESS= "",HOME_ADRESS= "",REGISTRATION_DATE= DateTime.Today.AddDays(-100)
 //               },
                
 //               new Staff
 //               {
 //                   STAFF_ID = "DI101", POSITION = "Chef de Departement Info", DEPARTEMENT = "Informatique", HIRED_DATE = DateTime.Today.AddDays(-500), STATUT = "Regulier",                   
 //                   TITLE = "Mr", FIRSTNAME = "Halid", LASTNAME = "cisse", PHOTO_IDENTITY = GetRandomImg(),              
 //                   NATIONALITY = "", IDENTITY_NUMBER= "", BIRTH_DATE= DateTime.Today.AddDays(-5000),BIRTH_PLACE= "",PHONE_NUMBER= "",EMAIL_ADRESS= "",HOME_ADRESS= "",REGISTRATION_DATE= DateTime.Today.AddDays(-100)
 //               },

 //               new Staff
 //               {
 //                   STAFF_ID = "DI102", POSITION = "Chef de Departement Info", DEPARTEMENT = "Informatique", HIRED_DATE = DateTime.Today.AddDays(-500), STATUT = "Regulier",                   
 //                   TITLE = "Mr", FIRSTNAME = "Halid", LASTNAME = "cisse", PHOTO_IDENTITY = GetRandomImg(),              
 //                   NATIONALITY = "", IDENTITY_NUMBER= "", BIRTH_DATE= DateTime.Today.AddDays(-5000),BIRTH_PLACE= "",PHONE_NUMBER= "",EMAIL_ADRESS= "",HOME_ADRESS= "",REGISTRATION_DATE= DateTime.Today.AddDays(-100)
 //               },
                
 //               new Staff
 //               {
 //                   STAFF_ID = "DI103", POSITION = "Chef de Departement Info", DEPARTEMENT = "Informatique", HIRED_DATE = DateTime.Today.AddDays(-500), STATUT = "Regulier",                   
 //                   TITLE = "Mr", FIRSTNAME = "Halid", LASTNAME = "cisse", PHOTO_IDENTITY = GetRandomImg(),              
 //                   NATIONALITY = "", IDENTITY_NUMBER= "", BIRTH_DATE= DateTime.Today.AddDays(-5000),BIRTH_PLACE= "",PHONE_NUMBER= "",EMAIL_ADRESS= "",HOME_ADRESS= "",REGISTRATION_DATE= DateTime.Today.AddDays(-100)
 //               },
 //               new Staff
 //               {
 //                   STAFF_ID = "DI104", POSITION = "Chef de Departement Info", DEPARTEMENT = "Informatique", HIRED_DATE = DateTime.Today.AddDays(-500), STATUT = "Regulier",                   
 //                   TITLE = "Mr", FIRSTNAME = "Halid", LASTNAME = "cisse", PHOTO_IDENTITY = GetRandomImg(),              
 //                   NATIONALITY = "", IDENTITY_NUMBER= "", BIRTH_DATE= DateTime.Today.AddDays(-5000),BIRTH_PLACE= "",PHONE_NUMBER= "",EMAIL_ADRESS= "",HOME_ADRESS= "",REGISTRATION_DATE= DateTime.Today.AddDays(-100)
 //               },
                
 //               new Staff
 //               {
 //                   STAFF_ID = "DI105", POSITION = "Chef de Departement Info", DEPARTEMENT = "Informatique", HIRED_DATE = DateTime.Today.AddDays(-500), STATUT = "Regulier",                   
 //                   TITLE = "Mr", FIRSTNAME = "Halid", LASTNAME = "cisse", PHOTO_IDENTITY = GetRandomImg(),              
 //                   NATIONALITY = "", IDENTITY_NUMBER= "", BIRTH_DATE= DateTime.Today.AddDays(-5000),BIRTH_PLACE= "",PHONE_NUMBER= "",EMAIL_ADRESS= "",HOME_ADRESS= "",REGISTRATION_DATE= DateTime.Today.AddDays(-100)
 //               },
 //               new Staff
 //               {
 //                   STAFF_ID = "DI106", POSITION = "Chef de Departement Info", DEPARTEMENT = "Informatique", HIRED_DATE = DateTime.Today.AddDays(-500), STATUT = "Regulier",                   
 //                   TITLE = "Mr", FIRSTNAME = "Halid", LASTNAME = "cisse", PHOTO_IDENTITY = GetRandomImg(),              
 //                   NATIONALITY = "", IDENTITY_NUMBER= "", BIRTH_DATE= DateTime.Today.AddDays(-5000),BIRTH_PLACE= "",PHONE_NUMBER= "",EMAIL_ADRESS= "",HOME_ADRESS= "",REGISTRATION_DATE= DateTime.Today.AddDays(-100)
 //               },
                
 //               new Staff
 //               {
 //                   STAFF_ID = "DI107", POSITION = "Chef de Departement Info", DEPARTEMENT = "Informatique", HIRED_DATE = DateTime.Today.AddDays(-500), STATUT = "Regulier",                   
 //                   TITLE = "Mr", FIRSTNAME = "Halid", LASTNAME = "cisse", PHOTO_IDENTITY = GetRandomImg(),              
 //                   NATIONALITY = "", IDENTITY_NUMBER= "", BIRTH_DATE= DateTime.Today.AddDays(-5000),BIRTH_PLACE= "",PHONE_NUMBER= "",EMAIL_ADRESS= "",HOME_ADRESS= "",REGISTRATION_DATE= DateTime.Today.AddDays(-100)
 //               },
 //               new Staff
 //               {
 //                   STAFF_ID = "DI108", POSITION = "Chef de Departement Info", DEPARTEMENT = "Informatique", HIRED_DATE = DateTime.Today.AddDays(-500), STATUT = "Regulier",                   
 //                   TITLE = "Mr", FIRSTNAME = "Halid", LASTNAME = "cisse", PHOTO_IDENTITY = GetRandomImg(),              
 //                   NATIONALITY = "", IDENTITY_NUMBER= "", BIRTH_DATE= DateTime.Today.AddDays(-5000),BIRTH_PLACE= "",PHONE_NUMBER= "",EMAIL_ADRESS= "",HOME_ADRESS= "",REGISTRATION_DATE= DateTime.Today.AddDays(-100)
 //               },
                
 //               new Staff
 //               {
 //                   STAFF_ID = "DI109", POSITION = "Chef de Departement Info", DEPARTEMENT = "Informatique", HIRED_DATE = DateTime.Today.AddDays(-500), STATUT = "Regulier",                   
 //                   TITLE = "Mr", FIRSTNAME = "Halid", LASTNAME = "cisse", PHOTO_IDENTITY = GetRandomImg(),              
 //                   NATIONALITY = "", IDENTITY_NUMBER= "", BIRTH_DATE= DateTime.Today.AddDays(-5000),BIRTH_PLACE= "",PHONE_NUMBER= "",EMAIL_ADRESS= "",HOME_ADRESS= "",REGISTRATION_DATE= DateTime.Today.AddDays(-100)
 //               },
 //               new Staff
 //               {
 //                   STAFF_ID = "DI110", POSITION = "Chef de Departement Info", DEPARTEMENT = "Informatique", HIRED_DATE = DateTime.Today.AddDays(-500), STATUT = "Regulier",                   
 //                   TITLE = "Mr", FIRSTNAME = "Halid", LASTNAME = "cisse", PHOTO_IDENTITY = GetRandomImg(),              
 //                   NATIONALITY = "", IDENTITY_NUMBER= "", BIRTH_DATE= DateTime.Today.AddDays(-5000),BIRTH_PLACE= "",PHONE_NUMBER= "",EMAIL_ADRESS= "",HOME_ADRESS= "",REGISTRATION_DATE= DateTime.Today.AddDays(-100)
 //               },
                
 //               new Staff
 //               {
 //                   STAFF_ID = "DI111", POSITION = "Chef de Departement Info", DEPARTEMENT = "Informatique", HIRED_DATE = DateTime.Today.AddDays(-500), STATUT = "Regulier",                   
 //                   TITLE = "Mr", FIRSTNAME = "Halid", LASTNAME = "cisse", PHOTO_IDENTITY = GetRandomImg(),              
 //                   NATIONALITY = "", IDENTITY_NUMBER= "", BIRTH_DATE= DateTime.Today.AddDays(-5000),BIRTH_PLACE= "",PHONE_NUMBER= "",EMAIL_ADRESS= "",HOME_ADRESS= "",REGISTRATION_DATE= DateTime.Today.AddDays(-100)
 //               },
 //               new Staff
 //               {
 //                   STAFF_ID = "DI112", POSITION = "Chef de Departement Info", DEPARTEMENT = "Informatique", HIRED_DATE = DateTime.Today.AddDays(-500), STATUT = "Regulier",                   
 //                   TITLE = "Mr", FIRSTNAME = "Halid", LASTNAME = "cisse", PHOTO_IDENTITY = GetRandomImg(),              
 //                   NATIONALITY = "", IDENTITY_NUMBER= "", BIRTH_DATE= DateTime.Today.AddDays(-5000),BIRTH_PLACE= "",PHONE_NUMBER= "",EMAIL_ADRESS= "",HOME_ADRESS= "",REGISTRATION_DATE= DateTime.Today.AddDays(-100)
 //               },
                
 //               new Staff
 //               {
 //                   STAFF_ID = "DI113", POSITION = "Chef de Departement Info", DEPARTEMENT = "Informatique", HIRED_DATE = DateTime.Today.AddDays(-500), STATUT = "Regulier",                   
 //                   TITLE = "Mr", FIRSTNAME = "Halid", LASTNAME = "cisse", PHOTO_IDENTITY = GetRandomImg(),              
 //                   NATIONALITY = "", IDENTITY_NUMBER= "", BIRTH_DATE= DateTime.Today.AddDays(-5000),BIRTH_PLACE= "",PHONE_NUMBER= "",EMAIL_ADRESS= "",HOME_ADRESS= "",REGISTRATION_DATE= DateTime.Today.AddDays(-100)
 //               },
 //               new Staff
 //               {
 //                   STAFF_ID = "DI114", POSITION = "Chef de Departement Info", DEPARTEMENT = "Informatique", HIRED_DATE = DateTime.Today.AddDays(-500), STATUT = "Regulier",                   
 //                   TITLE = "Mr", FIRSTNAME = "Halid", LASTNAME = "cisse", PHOTO_IDENTITY = GetRandomImg(),              
 //                   NATIONALITY = "", IDENTITY_NUMBER= "", BIRTH_DATE= DateTime.Today.AddDays(-5000),BIRTH_PLACE= "",PHONE_NUMBER= "",EMAIL_ADRESS= "",HOME_ADRESS= "",REGISTRATION_DATE= DateTime.Today.AddDays(-100)
 //               },
                
 //               new Staff
 //               {
 //                   STAFF_ID = "DI115", POSITION = "Chef de Departement Info", DEPARTEMENT = "Informatique", HIRED_DATE = DateTime.Today.AddDays(-500), STATUT = "Regulier",                   
 //                   TITLE = "Mr", FIRSTNAME = "Halid", LASTNAME = "cisse", PHOTO_IDENTITY = GetRandomImg(),              
 //                   NATIONALITY = "", IDENTITY_NUMBER= "", BIRTH_DATE= DateTime.Today.AddDays(-5000),BIRTH_PLACE= "",PHONE_NUMBER= "",EMAIL_ADRESS= "",HOME_ADRESS= "",REGISTRATION_DATE= DateTime.Today.AddDays(-100)
 //               },

 //           };

            
 //           MyStaffs.ForEach (Staff => EF.STAFF.AddOrUpdate(Staff));
 //           MessageBox.Show ("Finish staff");
 //       }