/*//Interface that fetches from local path to applications, and perforns all applications
////THIS IS WHERE WE WRITE QUERY COMMANDS TO MANIPULATE DATA IN RESTARAUNT_TABLE TABLE
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SQLite;
namespace DineNDash
{
    public class Restaraunt_tableDatabase
    {
        //create a connection for SQLite
        readonly SQLiteAsyncConnection database;

        public Restaraunt_tableDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Restaraunt_table>().Wait(); //FETCHES FROM RESTARAUNT_TABLE
            database.CreateTableAsync < Restaraunt_Menu>().Wait(); //FETCHES FROM RESTARAUNT_MENU TABLE
            database.CreateTableAsync<Menu_Category>().Wait(); //FETCHES FROM MENU_CATEGORY TABLE

        }
        //START OF QUERY COMMANDS
        //Get all restaraunts
        public Task<List<Restaraunt_table>> GetRestarauntsAsync()
        {
            return database.Table<Restaraunt_table>().ToListAsync();
        }
        //Get Specific Restaraunt
        public Task<Restaraunt_table> GetRestarauntAsync(int id)
        {
            return database.Table<Restaraunt_table>().Where(i => i.Restaraunt_ID == id).FirstOrDefaultAsync();
        }

        //Save Restaraunt
        public Task<int> SaveRestarauntAsync(Restaraunt_table restaraunt)
        {
            if (restaraunt.Restaraunt_ID== 0)
            {
                return database.InsertAsync(restaraunt);

            }
            else{
                return database.UpdateAsync(restaraunt);
            }
        }

        //Delete Restaraunt
        public Task<int> DeleteEmployeeAsync(Restaraunt_table restaraunt)
        {
            return database.DeleteAsync(restaraunt);
        }

        //Get all menus
        public Task<List<Restaraunt_Menu>> GetMenuAsync()
        {
            return database.Table<Restaraunt_Menu>().ToListAsync();
        }

        //Get all contents in a menu
        public Task<List<Menu_Category>> GetCategoryAsync()
        {
            return database.Table<Menu_Category>().ToListAsync();
        }


    }

}
*/