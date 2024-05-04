using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Sql_connect_form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void LoadDataToDataGridView()
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection(); // Ваше підключення до бази даних

                string sql = "Select order_number, customer_store_id, book_id, ordered_copies from ordering_stores";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                conn.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        // Додаємо стовпці до DataGridView
                        dataGridView1.Columns.Add("OrderNumberColumn", "Order Number");
                        dataGridView1.Columns.Add("StoreColumn", "Customer Store ID");
                        dataGridView1.Columns.Add("BookColumn", "Book ID");
                        dataGridView1.Columns.Add("OrderedCopiesColumn", "Ordered Copies");

                        // Додаємо рядки з даними
                        while (reader.Read())
                        {
                            object[] rowData = new object[reader.FieldCount];
                            reader.GetValues(rowData);
                            dataGridView1.Rows.Add(rowData);
                        }
                    }
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDataToDataGridView();
        }
    }
}