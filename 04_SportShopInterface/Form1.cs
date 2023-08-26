using data_access;
namespace _04_SportShopInterface
{
    public partial class Form1 : Form
    {
        SportShopDb db = null;
        public Form1()
        {
            InitializeComponent();
            db = new SportShopDb(@"DESKTOP-3HG9UVT\SQLEXPRESS", "SportShop");
            dataGridView1.DataSource = db.GetAll();
        }
    }
}