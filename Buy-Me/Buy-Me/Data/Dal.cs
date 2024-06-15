using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Collections;
//using Microsoft.Office .Interop.Access;

namespace Buy_Me.Data
{
    class Dal
    {
        private static Dal instance;
        //מכיל את המידע על  מסלול ההתקשרות למסד הנתונים
        private OleDbConnection con;
        //מכיל את אוסף כל הטבלאות
        private DataSet ds;

        private Dal(string connectionString)
        {
            con = new OleDbConnection(connectionString);
            ds = new DataSet();

        }
        public static Dal GetInstance()
        {
            if (instance == null)
            {
                string path = System.IO.Directory.GetCurrentDirectory();
                int x = path.IndexOf("\\bin");
                path = path.Substring(0, x) + "\\Data\\buy_me.accdb";
                instance = new Dal(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + path + "';Persist Security Info=true");
            }
            return instance;
        }
        //מקבלת שם טבלה ומוסיפה אותה מאקסס לדטהסט
        public void AddTable(string tableName)
        {
            //אם הדטהסט אינו מכיל כבר את הטבלה הזו תתבצע ההוספה  
            if (!ds.Tables.Contains(tableName))
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter("Select * from " + tableName, con);
                 adapter.Fill(ds, tableName);
            `}
        }

        //מקבל שם טבלה ומחזיר את הטבלה מתוך הדטהסט
        public DataTable GetTable(string tableName)
        {
            if (!ds.Tables.Contains(tableName))
                AddTable(tableName);
            return ds.Tables[tableName];

        }

        public bool RemoveTable(string tablename)
        {
            bool suceed = true;
            try
            {
                ds.Tables.Remove(tablename);

            }
            catch
            {
                suceed = false;
            }
            return suceed;
        }
        //מקבלת משפט SQL ומחזיר את התוצאה בדטהטייבל
        public DataTable GetSelectTable(string sql)
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, con);
            adapter.Fill(dt);
            return dt;
        }
        //מקבל שם טבלה ומעדכן אותה באקסס

        public void Update(string tableName)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter("select * from " + tableName, con);

            OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);
            adapter.InsertCommand = builder.GetInsertCommand();
            adapter.UpdateCommand = builder.GetUpdateCommand();
            adapter.DeleteCommand = builder.GetDeleteCommand();
            //עדכון מסד נתונים
            adapter.Update(ds, tableName);


        }
        public void Update()
        {
            foreach (DataTable table in ds.Tables)
            {
                Update(table.TableName);
            }
        }
      /*  public static void DealWithReportWithParam(string reportName, string whereCondindition)
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            int x = path.IndexOf("\\bin");
            path = path.Substring(0, x) + "\\Data\\library.accdb";
            Microsoft.Office.Interop.Access.Application oAccess = null;
            // Start a new instance of Access for Automation:
            oAccess = new Microsoft.Office.Interop.Access.Application();
            // Open a database in exclusive mode:
            oAccess.OpenCurrentDatabase(path, true);
            // Preview a report named Sales:
            try
            {
                oAccess.DoCmd.OpenReport(
                   reportName, //ReportName
                  AcView.acViewPreview, //View
                   System.Reflection.Missing.Value, //FilterName
                  whereCondindition //WhereCondition
                   );
                oAccess.DoCmd.OutputTo(AcOutputObjectType.acOutputReport, System.Reflection.Missing.Value, "pdf", System.Reflection.Missing.Value, true, System.Reflection.Missing.Value, System.Reflection.Missing.Value, AcExportQuality.acExportQualityPrint);
                oAccess.Quit();

            }
            catch
            {
                oAccess.Quit();
            }

        }*/
    }

            
        
}

