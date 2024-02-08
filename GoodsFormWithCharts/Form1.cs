using Npgsql;
using System;
using System.Numerics;
using System.Windows.Forms;
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

            var points = chart.Series[0].Points;
            //points.Clear();
            points.AddXY("Категория 1 (от 0 до 500)", CountGoods(0, 500));
            points.AddXY("Категория 2 (от 500 до 1000)", CountGoods(500, 1000));
            points.AddXY("Категория 3 (от 1000 до 1500)", CountGoods(1000, 1500));
            points.AddXY("Категория 4 (от 1500 до 2000)", CountGoods(1500, 2000));
            points.AddXY("Категория 5 (от 2000 и выше)", CountGoods(2000, Int32.MaxValue));

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
            reader.Close();
        }

        private void ShowGraph()
        {

        }

        private int CountGoods(int startPrice, int endPrice)
        {
            string commandText = $"SELECT COUNT(vendor_code) FROM product_without_image WHERE price > {startPrice} AND price <= {endPrice}";
            NpgsqlCommand cmd = new NpgsqlCommand(commandText, connection);
            var reader = cmd.ExecuteReader();
            Int64 result = 0;
            while (reader.Read())
            {
                result = (Int64)reader.GetInt64(0);
            }
            reader.Close();
            return (int)result;
        }
    }
}