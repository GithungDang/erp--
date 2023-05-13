namespace DataAccessTier
{
    using BusinessTier;
    using System;
    using System.Collections;
    using System.Data;
    using System.Data.OleDb;
    using System.Windows.Forms;

    public class TDbAccessControl
    {
        private string mDatabaseFile;
        private string mPassWord;
        private OleDbConnection dbConn;

        public TDbAccessControl(string databaseFile, string passWord)
        {
            this.mDatabaseFile = databaseFile;
            this.mPassWord = passWord;
            this.dbConn = null;
        }

        private int ExecuteInserInto(string sql)
        {
            int num2;
            int num = 0;
            this.OpenConnection();
            if (this.dbConn.State != ConnectionState.Open)
            {
                num2 = num;
            }
            else
            {
                OleDbCommand command = new OleDbCommand(sql, this.dbConn);
                try
                {
                    num = command.ExecuteNonQuery();
                }
                catch (Exception exception1)
                {
                    MessageBox.Show(exception1.Message);
                    this.dbConn.Close();
                    return num;
                }
                this.dbConn.Close();
                num2 = num;
            }
            return num2;
        }

        private int ExecuteUpdate(string sql) => 
            this.ExecuteInserInto(sql);

        public ArrayList GetFieldValue(string fieldName, string tableName)
        {
            ArrayList list = null;
            OleDbDataReader reader = null;
            ArrayList list2;
            this.OpenConnection();
            if (this.dbConn.State != ConnectionState.Open)
            {
                list2 = null;
            }
            else
            {
                list = new ArrayList();
                OleDbCommand command = new OleDbCommand(string.Format("Select {0} From {1} Group by {0}", fieldName, tableName), this.dbConn);
                try
                {
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(Convert.ToString(reader[fieldName]));
                    }
                }
                catch (Exception exception1)
                {
                    MessageBox.Show(exception1.Message);
                    reader.Close();
                    this.dbConn.Close();
                    return null;
                }
                reader.Close();
                this.dbConn.Close();
                list2 = list;
            }
            return list2;
        }

        public TScoreRecord[] GetHeroList(string tableName)
        {
            ArrayList list = null;
            OleDbDataReader reader = null;
            TScoreRecord[] recordArray;
            this.OpenConnection();
            if (this.dbConn.State != ConnectionState.Open)
            {
                recordArray = null;
            }
            else
            {
                list = new ArrayList();
                OleDbCommand command = new OleDbCommand($"Select * From {tableName}", this.dbConn);
                try
                {
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string actor = Convert.ToString(reader["决策者"]);
                        double maxScore = Convert.ToDouble(reader["最高记录"]);
                        DateTime finishedTime = Convert.ToDateTime(reader["创立时间"]);
                        TScoreRecord record = new TScoreRecord(actor, maxScore, finishedTime);
                        list.Add(record);
                    }
                }
                catch (Exception exception1)
                {
                    MessageBox.Show(exception1.Message);
                    reader.Close();
                    this.dbConn.Close();
                    return null;
                }
                reader.Close();
                this.dbConn.Close();
                if (list.Count == 0)
                {
                    recordArray = null;
                }
                else
                {
                    TScoreRecord[] recordArray2 = new TScoreRecord[list.Count];
                    int index = 0;
                    while (true)
                    {
                        if (index >= list.Count)
                        {
                            recordArray = recordArray2;
                            break;
                        }
                        recordArray2[index] = (TScoreRecord) list[index];
                        index++;
                    }
                }
            }
            return recordArray;
        }

        private object GetOnlyValue(string valueField, string keyField, string keyWord, string Table)
        {
            object obj2 = null;
            object obj3;
            this.OpenConnection();
            if (this.dbConn.State != ConnectionState.Open)
            {
                obj3 = null;
            }
            else
            {
                OleDbCommand command = new OleDbCommand($"Select {valueField} From {Table} Where {keyField} = "{keyWord}"", this.dbConn);
                try
                {
                    obj2 = command.ExecuteScalar();
                }
                catch (Exception exception1)
                {
                    MessageBox.Show(exception1.Message);
                    this.dbConn.Close();
                    return null;
                }
                this.dbConn.Close();
                obj3 = obj2;
            }
            return obj3;
        }

        public string GetRegistrationID(string tableName)
        {
            ArrayList fieldValue = this.GetFieldValue("注册码", tableName);
            return ((fieldValue.Count == 0) ? "NotRegistration" : fieldValue[0].ToString());
        }

        private bool IsFieldValueExist(string fieldName, string value, string tableName)
        {
            bool flag2;
            bool hasRows = false;
            OleDbDataReader reader = null;
            this.OpenConnection();
            if (this.dbConn.State != ConnectionState.Open)
            {
                flag2 = false;
            }
            else
            {
                OleDbCommand command = new OleDbCommand($"Select * From {tableName} Where {fieldName} = "{value}"", this.dbConn);
                try
                {
                    reader = command.ExecuteReader();
                    hasRows = reader.HasRows;
                }
                catch (Exception exception1)
                {
                    MessageBox.Show(exception1.Message);
                    reader.Close();
                    this.dbConn.Close();
                    return false;
                }
                reader.Close();
                this.dbConn.Close();
                flag2 = hasRows;
            }
            return flag2;
        }

        private void OpenConnection()
        {
            string connectionString = $"Provider = Microsoft.Jet.OLEDB.4.0;Data Source = "{this.mDatabaseFile}";Persist Security Info=True;Jet OLEDB:Database Password={this.mPassWord}";
            try
            {
                this.dbConn = new OleDbConnection(connectionString);
                this.dbConn.Open();
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message);
            }
        }

        public void UpdateHeroList(TScoreRecord sr, string tableName)
        {
            if (!this.IsFieldValueExist("决策者", sr.Actor, tableName))
            {
                string sql = string.Format("INSERT INTO {3} (决策者,最高记录,创立时间) VALUES(\"{0}\",\"{1}\",\"{2}\")", new object[] { sr.Actor, sr.MaxScore, sr.FinishedTime, tableName });
                this.ExecuteInserInto(sql);
            }
            else if (Convert.ToDouble(this.GetOnlyValue("最高记录", "决策者", sr.Actor, tableName)) <= sr.MaxScore)
            {
                string sql = $"UPDATE {tableName} SET 最高记录 = {sr.MaxScore} WHERE 决策者="{sr.Actor}"";
                this.ExecuteUpdate(sql);
                sql = $"UPDATE {tableName} SET 创立时间 = "{sr.FinishedTime}" WHERE 决策者="{sr.Actor}"";
                this.ExecuteUpdate(sql);
            }
        }

        public void UpdateRegistrationID(string registrationID, string tableName)
        {
            if (this.GetRegistrationID(tableName) != "NotRegistration")
            {
                string sql = $"UPDATE {tableName} SET 注册码 = "{registrationID}"";
                this.ExecuteUpdate(sql);
            }
            else
            {
                string sql = $"INSERT INTO {tableName} (注册码) VALUES("{registrationID}")";
                this.ExecuteInserInto(sql);
            }
        }
    }
}

