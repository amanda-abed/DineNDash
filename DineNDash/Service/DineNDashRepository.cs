
//Query commands

/*
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using DineNDash.DependencyServices;
using DineNDash.Models;
using SQLite;


namespace DineNDash.Service
{
    public class DineNDashRepository : IDineNDashRepository
    {
        private IFileAccessService _fileAccessService;
        private SQLiteAsyncConnection _sqliteConnection;

        public DineNDashRepository(IFileAccessService fileAccessService)
        {
            _fileAccessService = fileAccessService;
            var databaseFilePath = _fileAccessService.GetSQLiteDataBasePath("DineNDash.db3");
            //Instantiate sqliteasyncconnection
            _sqliteConnection = new SQLiteAsyncConnection(databaseFilePath);
            CreateTablesSynchronously();

            Console.WriteLine($"****{this.GetType().Name}.{nameof(DineNDashRepository)}: ctor. databaseFilePath= {databaseFilePath}");
        }

        private void CreateTablesSynchronously()
        {
            Console.WriteLine($"****{this.GetType().Name}.{nameof(CreateTablesSynchronously)}:");
            _sqliteConnection.CreateTableAsync<Restaraunt>().Wait();
            _sqliteConnection.CreateTableAsync<Restaraunt_Table>().Wait();
            _sqliteConnection.CreateTableAsync<Restaraunt_Menu>().Wait();
            _sqliteConnection.CreateTableAsync<Menu_Category>().Wait();

        }
        //save all restaraunts
        public async Task<int> SaveRestaraunt(Restaraunt RestarauntToSave)
        {
            Console.WriteLine($"****{this.GetType().Name}.{nameof(SaveRestaraunt)}: {RestarauntToSave}");

            try
            {
                if (RestarauntToSave.Restaraunt_ID == 0)
                {
                    RestarauntToSave.Restaraunt_ID = await _sqliteConnection.InsertAsync(RestarauntToSave);
                }
                else
                {
                    await _sqliteConnection.UpdateAsync(RestarauntToSave);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"****{this.GetType().Name}.{nameof(RestarauntToSave)}: EXCEPTION!! {ex}");
            }
            return RestarauntToSave.Restaraunt_ID;
        }

        //save all tables
        public async Task<int> SaveRestarauntTable(Restaraunt_Table RestarauntTableToSave)
        {
            Console.WriteLine($"****{this.GetType().Name}.{nameof(SaveRestaraunt)}: {RestarauntTableToSave}");

            try
            {
                if (RestarauntTableToSave.Table_ID == 0)
                {
                    RestarauntTableToSave.Table_ID = await _sqliteConnection.InsertAsync(RestarauntTableToSave);
                }
                else
                {
                    await _sqliteConnection.UpdateAsync(RestarauntTableToSave);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"****{this.GetType().Name}.{nameof(RestarauntTableToSave)}: EXCEPTION!! {ex}");
            }
            return RestarauntTableToSave.Table_ID;
        }

        //Save all menus
        public async Task<int> SaveRestarauntMenu(Restaraunt_Menu RestarauntMenuToSave)
        {
            Console.WriteLine($"****{this.GetType().Name}.{nameof(SaveRestaraunt)}: {RestarauntMenuToSave}");

            try
            {
                if (RestarauntMenuToSave.Menu_ID == 0)
                {
                    RestarauntMenuToSave.Menu_ID = await _sqliteConnection.InsertAsync(RestarauntMenuToSave);
                }
                else
                {
                    await _sqliteConnection.UpdateAsync(RestarauntMenuToSave);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"****{this.GetType().Name}.{nameof(RestarauntMenuToSave)}: EXCEPTION!! {ex}");
            }
            return RestarauntMenuToSave.Menu_ID;
        }

        //Save all categories
        public async Task<int> SaveMenuCategory(Menu_Category CategoryToSave)
        {
            Console.WriteLine($"****{this.GetType().Name}.{nameof(SaveRestaraunt)}: {CategoryToSave}");

            try
            {
                if (CategoryToSave.Category_ID == 0)
                {
                    CategoryToSave.Category_ID = await _sqliteConnection.InsertAsync(CategoryToSave);
                }
                else
                {
                    await _sqliteConnection.UpdateAsync(CategoryToSave);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"****{this.GetType().Name}.{nameof(CategoryToSave)}: EXCEPTION!! {ex}");
            }
            return CategoryToSave.Category_ID;
        }

        //Get all restaraunts
        public async Task<ObservableCollection<Restaraunt>> GetAllRestaraunts()
        {
            var allTopics = new ObservableCollection<Restaraunt>();

            try
            {
                List<Restaraunt> topicList= await _sqliteConnection.Table<Restaraunt>().ToListAsync();
                allTopics = new ObservableCollection<Restaraunt>(topicList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"****{this.GetType().Name}.{nameof(GetAllRestaraunts)}: EXCEPTION!! {ex}");
            }
            return allTopics;
        }

        //get all menus
        public async Task<ObservableCollection<Restaraunt_Menu>> GetAllRestarauntMenu()
        {
            var allTopics = new ObservableCollection<Restaraunt_Menu>();

            try
            {
                List<Restaraunt_Menu> topicList = await _sqliteConnection.Table<Restaraunt_Menu>().ToListAsync();
                allTopics = new ObservableCollection<Restaraunt_Menu>(topicList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"****{this.GetType().Name}.{nameof(GetAllRestaraunts)}: EXCEPTION!! {ex}");
            }
            return allTopics;
        }

        //get all tables
        public async Task<ObservableCollection<Restaraunt_Table>> GetAllRestarauntTable()
        {
            var allTopics = new ObservableCollection<Restaraunt_Table>();

            try
            {
                List<Restaraunt_Table> topicList = await _sqliteConnection.Table<Restaraunt_Table>().ToListAsync();
                allTopics = new ObservableCollection<Restaraunt_Table>(topicList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"****{this.GetType().Name}.{nameof(GetAllRestaraunts)}: EXCEPTION!! {ex}");
            }
            return allTopics;
        }

        //Get all menu categories
        public async Task<ObservableCollection<Menu_Category>> GetAllCategory()
        {
            var allTopics = new ObservableCollection<Menu_Category>();

            try
            {
                List<Menu_Category> topicList = await _sqliteConnection.Table<Menu_Category>().ToListAsync();
                allTopics = new ObservableCollection<Menu_Category>(topicList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"****{this.GetType().Name}.{nameof(GetAllRestaraunts)}: EXCEPTION!! {ex}");
            }
            return allTopics;
        }
    }
}
*/