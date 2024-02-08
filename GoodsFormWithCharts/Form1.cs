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
            points.AddXY("��������� 1 (�� 0 �� 500)", CountGoods(0, 500));
            points.AddXY("��������� 2 (�� 500 �� 1000)", CountGoods(500, 1000));
            points.AddXY("��������� 3 (�� 1000 �� 1500)", CountGoods(1000, 1500));
            points.AddXY("��������� 4 (�� 1500 �� 2000)", CountGoods(1500, 2000));
            points.AddXY("��������� 5 (�� 2000 � ����)", CountGoods(2000, Int32.MaxValue));

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