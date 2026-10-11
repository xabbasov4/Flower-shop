using System;
using System.Windows.Forms;
namespace Flower_shop
{
    public partial class Form1 : Form
    {
        private double toplamGelir = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Zəhmət olmasa bütün xanaları doldurun!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }
            int count;
            double price;
            string sayText = textBox2.Text.Replace('.', ',');
            string qiymetText = textBox3.Text.Replace('.', ',');
            bool isCountValid = int.TryParse(sayText, out count);
            bool isPriceValid = double.TryParse(qiymetText, out price);
            if (!isCountValid || count <= 0)
            {
                MessageBox.Show("Say mənfi və ya sıfır ola bilməz!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!isPriceValid || price <= 0)
            {
                MessageBox.Show("Qiymət mənfi və ya sıfır ola bilməz!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            double result = count * price;
            dataGridView1.Rows.Add(textBox1.Text, count.ToString(), price.ToString(), result.ToString("F2"));
            toplamGelir += result;
            label1.Text = "Toplam gəlir: " + toplamGelir.ToString("F2");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox1.Focus();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult cavab = MessageBox.Show("Çıxış edilsinmi?", "Çıxış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cavab == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}