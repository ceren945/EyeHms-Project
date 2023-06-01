using System.Data;
using System.Data.SqlClient;
namespace EyeHMS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-JULAJSR\\SQLEXPRESS;Initial Catalog=C:\\USERS\\USER\\DOCUMENTS\\EYECAREDB.MDF;Integrated Security=True");
        private void temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.Text = "";
            textBox6.Clear();
            textBox4.Clear();
        }
        void griddoldur(String c)
        {
            con.Open();
            SqlDataAdapter mn = new SqlDataAdapter(c, con);
            DataSet d = new DataSet();
            mn.Fill(d);
            guna2DataGridView1.DataSource = d.Tables[0];
            con.Close();
        }

        //guncelle
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-JULAJSR\\SQLEXPRESS;Initial Catalog=C:\\USERS\\USER\\DOCUMENTS\\EYECAREDB.MDF;Integrated Security=True");
            con.Open();
            SqlCommand c = new SqlCommand("Update PatientTbl set PatName=@name, PatPhone=@phone, PatAdress=@address, PatDOB=@birthday, PatGender=@gender, PatAllergies=@allergy where PatId=@id", con);
            c.Parameters.AddWithValue("@id", textBox4.Text);
            c.Parameters.AddWithValue("@name", textBox1.Text);
            c.Parameters.AddWithValue("@phone", textBox2.Text);
            c.Parameters.AddWithValue("@address", textBox3.Text);
            c.Parameters.AddWithValue("@birthday",textBox4.Text);
            c.Parameters.AddWithValue("@gender", comboBox1.Text);
            c.Parameters.AddWithValue("@allergy", textBox6.Text);
            c.ExecuteNonQuery();
            con.Close();
            temizle();

        }
        //kaydet
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-JULAJSR\\SQLEXPRESS;Initial Catalog=C:\\USERS\\USER\\DOCUMENTS\\EYECAREDB.MDF;Integrated Security=True");
            con.Open();
            SqlCommand kayit = new SqlCommand("Insert Into PatientTbl values (@name,@phone,@address,@birthday,@gender, @allergy)", con);
            kayit.Parameters.AddWithValue("@name", textBox1.Text);
            kayit.Parameters.AddWithValue("@phone", textBox2.Text);
            kayit.Parameters.AddWithValue("@address", textBox3.Text);
            kayit.Parameters.AddWithValue("@birthday",textBox4.Text);
            kayit.Parameters.AddWithValue("@gender", comboBox1.Text);
            kayit.Parameters.AddWithValue("@allergy", textBox6.Text);
            kayit.ExecuteNonQuery();
            con.Close();
            temizle();
        }

        //sil
        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            griddoldur("select * from PatientTbl");
        }

        private void label9_Click(object sender, EventArgs e)
        {
           
        }

        private void label10_Click(object sender, EventArgs e)
        {
        }

        private void label11_Click(object sender, EventArgs e)
        {

            

        }
        // goruntule
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilialan = guna2DataGridView1.SelectedCells[0].RowIndex;
            string id = guna2DataGridView1.Rows[secilialan].Cells[0].Value.ToString();
            string ad = guna2DataGridView1.Rows[secilialan].Cells[1].Value.ToString();
            string tel = guna2DataGridView1.Rows[secilialan].Cells[2].Value.ToString();
            string adres = guna2DataGridView1.Rows[secilialan].Cells[3].Value.ToString();
            string gender = guna2DataGridView1.Rows[secilialan].Cells[4].Value.ToString();
            string alerji = guna2DataGridView1.Rows[secilialan].Cells[5].Value.ToString();
            textBox4.Text = id;
            textBox1.Text = ad;
            textBox2.Text = tel;
            textBox3.Text = adres;
            comboBox1.Text = gender;
            textBox6.Text = alerji;

        }
    }
}
