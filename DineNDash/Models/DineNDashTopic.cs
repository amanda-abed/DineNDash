/*using System;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace DineNDash.Models
{
    
        [Table("Restaraunt")]
        public class Restaraunt
        {
            [PrimaryKey, AutoIncrement]
            public int Restaraunt_ID
            {
                get;
                set;
            }
            [MaxLength(50)]
            public string Restaraunt_Name
            {
                get;
                set;
            }
            public string Restaraunt_Address
            {
                get;
                set;
            }
            public string Restaraunt_City
            {
                get;
                set;
            }
            public string Restaraunt_State
            {
                get;
                set;
            }
            public int Restaraunt_Zip
            {
                get;
                set;
            }
            public string Restaraunt_Phone
            {
                get;
                set;
            }
            public String Restaraunt_Email
            {
                get;
                set;
            }
            public float Restaraunt_Lat
            {
                get;
                set;
            }
            public float Restaraunt_Long
            {
                get;
                set;
            }

            [ForeignKey(typeof(Restaraunt_Menu))]
            public int Menu_ID
            {
                get;
                set;

            }
            [ForeignKey(typeof(Restaraunt_Table))]
            public int Table_ID
            {
                get;
                set;
            }
        }
        [Table("Restaraunt_Table")]
        public class Restaraunt_Table
        {
            [PrimaryKey, AutoIncrement]
            public int Table_ID
            {
                get; set;
            }

            public int Table_QRcode
            {
                get; set;
            }

            public int Max_Capacity
            {
                get; set;
            }

            public int Server_ID
            {
                get; set;
            }

            public bool Order_Status
            {
                get; set;
            }

            public bool DineIn_Status
            {
                get; set;
            }


        }
        */
        /*  RESTARAUNT_MENU TABLE*/
        //[Table("Restaraunt_Menu")]
        /*
        public class Restaraunt_Menu
        {
            [PrimaryKey, AutoIncrement]
            public int Menu_ID
            {
                get;
                set;
            }
            public string Menu_Name
            {
                get;
                set;
            }
            [ForeignKey(typeof(Menu_Category))]
            public int Category_ID
            {
                get;
                set;
            }
            public string Menu_Description
            {
                get;
                set;
            }
            public string Menu_Image
            {
                get;
                set;
            }
        }
        /*
        /*  MENU_CATEGORY Table */
        /*
        [Table("Restaraunt_Category")]
        public class Menu_Category
        {
            [PrimaryKey, AutoIncrement]
            public int Category_ID
            {
                get;
                set;
            }
            public string Category_Name
            {
                get;
                set;
            }
            public string Category_Description
            {
                get;
                set;
            }
            public float Category_Price
            {
                get;
                set;
            }
        }
    }
*/