using Npgsql;
using System.Windows.Forms.DataVisualization.Charting;

namespace GoodsForm
{
    public partial class Form1 : Form
    {
        private const string CONNECTION_STRING = "Host=localhost:5432;" +
            "Username=postgres;" +
            "Password=25481;" +
            "Database=ProductDatabase";
        private readonly NpgsqlConnection connection;
        public Form1()
        {
            InitializeComponent();
            connection = new NpgsqlConnection(CONNECTION_STRING);
            connection.Open();
            LoadGoods();

            Chart myChart = new Chart();
            //кладем его на форму и растягиваем на все окно.
            myChart.Parent = this;
            myChart.Dock = DockStyle.Fill;
            //добавляем в Chart область для рисования графиков, их может быть
            //много, поэтому даем ей имя.
            myChart.ChartAreas.Add(new ChartArea("Math functions"));
            //Создаем и настраиваем набор точек для рисования графика, в том
            //не забыв указать имя области на которой хотим отобразить этот
            //набор точек.
            Series mySeriesOfPoint = new Series("Sinus");
            mySeriesOfPoint.ChartType = SeriesChartType.Line;
            mySeriesOfPoint.ChartArea = "Math functions";
            for (double x = -Math.PI; x <= Math.PI; x += Math.PI / 10.0)
            {
                mySeriesOfPoint.Points.AddXY(x, Math.Sin(x));
            }
            //Добавляем созданный набор точек в Chart
            myChart.Series.Add(mySeriesOfPoint);
        }

        private void LoadGoods()
        {
            string commandText = $"SELECT * FROM product_without_image";
            NpgsqlCommand cmd = new NpgsqlCommand(commandText, connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dataGridView1.Rows.Add(
                     (int)reader.GetValue(0),
                    (string)reader.GetValue(1),
                    (int)reader.GetValue(2)
                );
            }
        }
    }
}