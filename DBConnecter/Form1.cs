using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBConnecter
{
    public partial class Form1 : Form
    {
        //接続情報
        String connectionString;
        List<Label> lblIds;
        List<Label> lblNames;
        List<Label> lblRoles;

        public Form1()
        {
            InitializeComponent();
            //接続情報の設定
            connectionString = "Server=localhost;Database=Major;UserID=root;Password=kcsf;Pooling=true;";
            lblIds = new List<Label> { lblId1, lblId2, lblId3 };
            lblNames = new List<Label> { lblName1, lblName2, lblName3 };
            lblRoles = new List<Label> { lblRole1, lblRole2, lblRole3 };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //DBに接続してユーザ情報を取得
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();

                //クエリの実行
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Users",con))
                {
                    //javaにおける「ResultSe rs = stmt ExecuteQuery()」
                    using(MySqlDataReader reader = cmd.ExecuteReader()) 
                    {
                        int index = 0;
                        while (reader.Read() && index < lblIds.Count)
                        {
                            lblIds[index].Text = reader["id"].ToString();
                            lblNames[index].Text = reader["name"].ToString();
                            lblRoles[index].Text = reader["role"].ToString();

                            index++;
                        }
                        reader.Close();
                    }
                }
            }
        }
    }
}
