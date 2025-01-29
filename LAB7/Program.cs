using System;
using System.Collections.Generic;

namespace LAB7
{
    class Program
    {
        public static List<User> users = new List<User>();

        static void Main(string[] args)
        {
            // Testing done here, you can experiment with more.

            User ke = new User("Kutluhan Erol", "ke");
            User ce = new User("Cem Evrendilek", "ce");
            User tt = new User("Turhan Tunalı", "tt");
            User ha = new User("Hande Aka Uymaz", "ha");
            User eo = new User("Erdem Okur", "eo");
            User su = new User("Serhat Uzunbayır", "su");

            User cg = new User("Cinar Gedizlioglu", "cg");
            User bt = new User("Melek Büşra Temuçin", "bt");
            User td = new User("Tugay Direk", "td");


            users.Add(ke);
            users.Add(ce);
            users.Add(tt);

            users.Add(cg);
            users.Add(ha);
            users.Add(eo);
            users.Add(su);
            users.Add(bt);
            users.Add(td);


            //cg.ComposeMail();
            //cg.ComposeMail();
            string fileName = "users.xml";
            //SerializationHelper.SerializeUser(fileName, ke);
            User deserializedUser = SerializationHelper.DeserializeUser(fileName);
            deserializedUser.ReadMailbox("I");



            //cg.ComposeMail();
            //cg.ComposeMail();
            //cg.ComposeMail();
            //ke.ReadMailbox("I");
            //cg.ReadMailbox("I");
            //ke.ReadMailbox("I");
            //ke.ReadMailbox("T");
            //ke.ComposeMail();

            //ke.ComposeMail();
            //cg.ComposeMail();

            //ke.ReadMailbox("I");
            //eo.ReadMailbox("I");
            //su.ReadMailbox("I");

            //cg.ReadMailbox("I");

        }
    }
}

//using System;
//using System.Collections.Generic;

//namespace LAB7
//{
//    class Program
//    {
//        public static List<User> users = new List<User>();

//        static void Main(string[] args)
//        {
//            // Kullanıcıları oluştur
//            User ke = new User("Kutluhan Erol", "ke");
//            User ce = new User("Cem Evrendilek", "ce");
//            User tt = new User("Turhan Tunalı", "tt");
//            User ha = new User("Hande Aka Uymaz", "ha");
//            User eo = new User("Erdem Okur", "eo");
//            User su = new User("Serhat Uzunbayır", "su");
//            User cg = new User("Cinar Gedizlioglu", "cg");
//            User bt = new User("Melek Büşra Temuçin", "bt");
//            User td = new User("Tugay Direk", "td");

//            // Kullanıcıları listeye ekle
//            users.Add(ke);
//            users.Add(ce);
//            users.Add(tt);
//            users.Add(cg);
//            users.Add(ha);
//            users.Add(eo);
//            users.Add(su);
//            users.Add(bt);
//            users.Add(td);

//            //// Kullanıcıları serileştir
//            //string fileName = "users.xml";
//            //foreach (var user in users)
//            //{
//            //    SerializationHelper.SerializeUser(fileName, user);
//            //    Console.WriteLine($"User {user.Name} serialized to {fileName}");
//            //}

//            //// Kullanıcıyı XML dosyasından deserialle et
//            //User deserializedUser = SerializationHelper.DeserializeUser(fileName);
//            //Console.WriteLine($"User deserialized from {fileName}: {deserializedUser.Name}");

//            //// E-posta işlemleri
//            //deserializedUser.ComposeMail();
//            //deserializedUser.ReadMailbox("I");
//        }
//    }
//}
