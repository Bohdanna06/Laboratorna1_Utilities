using System;
using System.Data;
using System.Windows.Forms;
using MySqlConnector;

namespace Laboratorna1_Utilities
{
    public partial class Form1 : Form
    {
        
        private string connectionString = "Server=localhost;Database=Utilities;User ID=root;Password=bohdanna1106;";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

 
        private void LoadData()
        {
           
            string query = @"
                SELECT 
                    t.AccountNumber AS `Особовий рахунок`,
                    t.FullName AS `ПІБ`,
                    t.Address AS `Адреса`,
                    t.OccupantsCount AS `Мешканців`,
                    t.Area AS `Площа (м²)`,
                    s.ServiceName AS `Послуга`,
                    IFNULL(s.RatePerSqMeter, 0) AS `Тариф за м²`,
                    IFNULL(s.RatePerPerson, 0) AS `Тариф за особу`,
                    CAST(
                        CASE 
                            WHEN s.RatePerSqMeter IS NOT NULL THEN t.Area * s.RatePerSqMeter
                            ELSE t.OccupantsCount * s.RatePerPerson
                        END AS DECIMAL(10,2)
                    ) AS `Нараховано (грн)`
                FROM Tenants t
                JOIN TenantServices ts ON t.ID = ts.TenantID
                JOIN Services s ON ts.ServiceID = s.ID
                ORDER BY t.AccountNumber;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();

                  
                    adapter.Fill(dataTable);

                   
                    dgvData.DataSource = dataTable;
                    dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка підключення до БД: " + ex.Message);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
