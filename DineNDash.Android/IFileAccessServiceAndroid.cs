/*using System;
using System.IO;
using DineNDash.DependencyServices;
using DineNDash.Droid.DependencyServices;
using Xamarin.Forms;
//Tells app how to implement IFIleAccessService on android
[assembly: Dependency(typeof(IFileAccessServiceAndroid))]
namespace DineNDash.Droid.DependencyServices
{
    public class IFileAccessServiceAndroid:IFileAccessService
    {
        public IFileAccessServiceAndroid()
        {
        }
        //Android Immplementation code. IDK what that means because i just followed some instructions, but i'm assuming it allows the android db to be implemeneted. Hire me Fam
        public string GetSQLiteDataBasePath(string databaseName)
        {
            string personalFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var dbPath = Path.Combine(personalFolderPath, databaseName);
            Console.WriteLine($"****{this.GetType().Name}.{nameof(GetSQLiteDataBasePath)}: returning[{dbPath}]");
            return dbPath;

        }
    }
}
*/