namespace WindowsClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            int x = 0, y = 0;
            try
            {
                x = Convert.ToInt32(textBox1.Text);
                y = Convert.ToInt32(textBox2.Text);
            }
            catch
            {
                MessageBox.Show("Неккоректоно введены числа!");
                return;
            }

            using (HttpClient client = new HttpClient())
            {
                var formData = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("x", x.ToString()),
                    new KeyValuePair<string, string>("y", y.ToString())
                });

                var response = await client.PostAsync("https://localhost:7203/sum", formData);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    textBox3.Text = result.ToString();
                }
                else
                {
                    MessageBox.Show("Произошла ошибка при выполнении запроса.");
                }
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}