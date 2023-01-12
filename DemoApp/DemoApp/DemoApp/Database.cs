using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace DemoApp
{
    internal class Database
    {
        
        static string auth = "JqzzkTJOsqE9whUeblswVB6DRFqyUUwC8KEF9WAo"; // your app secret
        FirebaseClient firebaseClient = new FirebaseClient(
          "https://guldur422-default-rtdb.europe-west1.firebasedatabase.app/",
          new FirebaseOptions
          {
              AuthTokenAsyncFactory = () => Task.FromResult(auth)
          });

        public async Task AddStudent(string no,string name,string gender)
        {
            await firebaseClient
                 .Child("students")
                .Child(no)
                 .PutAsync(new Student { No = no, StudentName = name, StudentGender = gender });
        }  
        
        public async Task<Student> GetStudent(string no)
        {
            var student = await firebaseClient
                    .Child("students")
                      .Child(no)
                    .OnceSingleAsync<Student>();

            return student;
        }
    }
}
