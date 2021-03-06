﻿using System;
using System.ComponentModel.DataAnnotations;

namespace DataService.Entities
{
    public class Staff //: Human
    {
        [Key]
        public string STAFF_ID { get; set; }

        public string POSITION { get; set; }    
        public string DEPARTEMENT { get; set; }

        public string QUALIFICATION { get; set; }
        public DateTime? HIRED_DATE { get; set; }       
      
        public string STATUT { get; set; }  // suspended, regulier, Licencier



        #region Human

        public string TITLE { get; set; }
        public string FIRSTNAME { get; set; }
        public string LASTNAME { get; set; }
        public byte[] PHOTO_IDENTITY { get; set; }

        public string NATIONALITY { get; set; }
        public string IDENTITY_NUMBER { get; set; }
        public DateTime? BIRTH_DATE { get; set; }
        public string BIRTH_PLACE { get; set; }

        public string PHONE_NUMBER { get; set; }
        public string EMAIL_ADRESS { get; set; }
        public string HOME_ADRESS { get; set; }

        public DateTime? REGISTRATION_DATE { get; set; }

        public string FULL_NAME
        {
            get
            {
                return FIRSTNAME + " " + LASTNAME;
            }
        }

        #endregion


        #region The Person


        //public string FULL_NAME
        //{             
        //    get
        //    {               
        //        return PERSON.FULL_NAME;                           
        //    }
        //}

        //[NotMappedAttribute]
        //public string TITLE
        //{
        //    get
        //    {
               
                   
        //          return PERSON.TITLE;
                
        //    }
        //    set
        //    {
               
        //          PERSON.TITLE = value;
                
        //    }
        //}
        ////[NotMappedAttribute]
        //public string FIRSTNAME
        //{
        //    get
        //    {
                
        //        return PERSON.FIRSTNAME;
                
        //    }

        //    //set
        //    //{
                
        //    //     PERSON.FIRSTNAME = value;
               
        //    //}
        //}
        //[NotMapped]
        //public string LASTNAME
        //{
        //    get
        //    {
                
        //            return PERSON.LASTNAME;
                
        //    }

        //    set
        //    {
               
        //            PERSON.LASTNAME = value;
                
        //    }
        //}
        //[NotMapped]
        //public byte[] PHOTO_IDENTITY
        //{
        //    get
        //    {
               
        //            return PERSON.PHOTO_IDENTITY;
                
        //    }

        //    set
        //    {
                
        //          PERSON.PHOTO_IDENTITY = value;
                
        //    }
        //}

        //[NotMapped]
        //public string NATIONALITY
        //{
        //    get
        //    {
        //        using(var Db = new EF ())
        //        {
        //            return Db.PERSON.Single (P => P.PERSON_ID == "STAFF_ID" + STAFF_ID).NATIONALITY;
        //        }
        //    }

        //    set
        //    {
        //        using(var Db = new EF ())
        //        {
        //            Db.PERSON.Single (P => P.PERSON_ID == "STAFF_ID" + STAFF_ID).NATIONALITY = value;
        //        }
        //    }
        //}
        //[NotMappedAttribute]
        //public string IDENTITY_NUMBER
        //{
        //    get
        //    {
        //        using(var Db = new EF ())
        //        {
        //            return Db.PERSON.Single (P => P.PERSON_ID == "STAFF_ID" + STAFF_ID).IDENTITY_NUMBER;
        //        }
        //    }

        //    set
        //    {
        //        using(var Db = new EF ())
        //        {
        //            Db.PERSON.Single (P => P.PERSON_ID == "STAFF_ID" + STAFF_ID).IDENTITY_NUMBER = value;
        //        }
        //    }
        //}
        //[NotMappedAttribute]
        //public DateTime? BIRTH_DATE
        //{
        //    get
        //    {
        //        using(var Db = new EF ())
        //        {
        //            return Db.PERSON.Single (P => P.PERSON_ID == "STAFF_ID" + STAFF_ID).BIRTH_DATE;
        //        }
        //    }

        //    set
        //    {
        //        using(var Db = new EF ())
        //        {
        //            Db.PERSON.Single (P => P.PERSON_ID == "STAFF_ID" + STAFF_ID).BIRTH_DATE = value;
        //        }
        //    }
        //}
        //[NotMappedAttribute]
        //public string BIRTH_PLACE
        //{
        //    get
        //    {
        //        using(var Db = new EF ())
        //        {
        //            return Db.PERSON.Single (P => P.PERSON_ID == "STAFF_ID" + STAFF_ID).BIRTH_PLACE;
        //        }
        //    }

        //    set
        //    {
        //        using(var Db = new EF ())
        //        {
        //            Db.PERSON.Single (P => P.PERSON_ID == "STAFF_ID" + STAFF_ID).BIRTH_PLACE = value;
        //        }
        //    }
        //}

        //[NotMappedAttribute]
        //public string PHONE_NUMBER
        //{
        //    get
        //    {
        //        using(var Db = new EF ())
        //        {
        //            return Db.PERSON.Single (P => P.PERSON_ID == "STAFF_ID" + STAFF_ID).PHONE_NUMBER;
        //        }
        //    }

        //    set
        //    {
        //        using(var Db = new EF ())
        //        {
        //            Db.PERSON.Single (P => P.PERSON_ID == "STAFF_ID" + STAFF_ID).PHONE_NUMBER = value;
        //        }
        //    }
        //}
        //[NotMappedAttribute]
        //public string EMAIL_ADRESS
        //{
        //    get
        //    {
        //        using(var Db = new EF ())
        //        {
        //            return Db.PERSON.Single (P => P.PERSON_ID == "STAFF_ID" + STAFF_ID).EMAIL_ADRESS;
        //        }
        //    }

        //    set
        //    {
        //        using(var Db = new EF ())
        //        {
        //            Db.PERSON.Single (P => P.PERSON_ID == "STAFF_ID" + STAFF_ID).EMAIL_ADRESS = value;
        //        }
        //    }
        //}
        //[NotMappedAttribute]
        //public string HOME_ADRESS
        //{
        //    get
        //    {
        //        using(var Db = new EF ())
        //        {
        //            return Db.PERSON.Single (P => P.PERSON_ID == "STAFF_ID" + STAFF_ID).HOME_ADRESS;
        //        }
        //    }

        //    set
        //    {
        //        using(var Db = new EF ())
        //        {
        //            Db.PERSON.Single (P => P.PERSON_ID == "STAFF_ID" + STAFF_ID).HOME_ADRESS = value;
        //        }
        //    }
        //}
        //[NotMappedAttribute]
        //public DateTime? REGISTRATION_DATE
        //{
        //    get
        //    {
        //        using(var Db = new EF ())
        //        {
        //            return Db.PERSON.Single (P => P.PERSON_ID == "STAFF_ID" + STAFF_ID).REGISTRATION_DATE;
        //        }
        //    }

        //    set
        //    {
        //        using(var Db = new EF ())
        //        {
        //            Db.PERSON.Single (P => P.PERSON_ID == "STAFF_ID" + STAFF_ID).REGISTRATION_DATE = value;
        //        }
        //    }
        //}

        #endregion

    }
}
