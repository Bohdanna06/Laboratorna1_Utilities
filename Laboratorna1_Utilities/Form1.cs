
namespace Laboratorna1_Utilities
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //private void btnLoad_Click(object sender, EventArgs e)
        //{
        //    LoadData();
        //}
        private void LoadData()
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var data = db.TenantServices
                        .Select(ts => new
                        {
                            Особовий_рахунок = ts.Tenant.AccountNumber,
                            ПІБ = ts.Tenant.FullName,
                            Адреса = ts.Tenant.Address,
                            Мешканців = ts.Tenant.OccupantsCount,
                            Площа_м2 = ts.Tenant.Area,
                            Послуга = ts.Service.ServiceName,
                            Тариф_за_м2 = ts.Service.RatePerSqMeter ?? 0,
                            Тариф_за_особу = ts.Service.RatePerPerson ?? 0,
                            Нараховано_грн = ts.Service.RatePerSqMeter.HasValue && ts.Service.RatePerSqMeter > 0
                                ? ts.Tenant.Area * ts.Service.RatePerSqMeter.Value
                                : ts.Tenant.OccupantsCount * (ts.Service.RatePerPerson ?? 0)
                        })
                        .OrderBy(x => x.Особовий_рахунок)
                        .ToList();

                    dgvData.DataSource = data;
                    dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvData.Columns["Нараховано_грн"].DefaultCellStyle.Format = "N2";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка підключення через EF Core: " + ex.Message);
            }
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnLoad_Click_1(object sender, EventArgs e)
        {
            LoadData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
