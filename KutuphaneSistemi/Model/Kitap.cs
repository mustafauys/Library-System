using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace KutuphaneSistemi.Model
{
    class Kitap
    {
        public int Id { get; set; }
        public String Ad { get; set; }
        public String Detay { get; set; }
        public String Yazar { get; set; }
        public String YayınEvi { get; set; }

        SqlConnection _baglan = new SqlConnection(@"Data Source=.\SQLExpress;Initial Catalog=Kutuphane;Integrated Security=True");

        public void connect()
        {
            if (_baglan.State == ConnectionState.Closed)
            {
                _baglan.Open();
            }
        }

        public List<Kitap> Get()
        {
            connect();
            SqlCommand command = new SqlCommand("Select * From Kitap order by Id DESC",_baglan);
            SqlDataReader reader = command.ExecuteReader();

            List<Kitap> kitaplar = new List<Kitap>();

            while (reader.Read())
            {
                Kitap kitap = new Kitap();

                kitap.Id = Convert.ToInt32(reader["Id"]);
                kitap.Ad = reader["Ad"].ToString();
                kitap.Detay = reader["Detay"].ToString();
                kitap.Yazar = reader["Yazar"].ToString();
                kitap.YayınEvi = reader["YayınEvi"].ToString();

                kitaplar.Add(kitap);
            }

            reader.Close();
            _baglan.Close();

            return kitaplar;
        }

        public List<Kitap> Get(string arama)
        {
            connect();
            SqlCommand command = new SqlCommand("Select * From Kitap where Ad like  '%"+ @arama +"%' order by Id DESC", _baglan);
            SqlDataReader reader = command.ExecuteReader();
            command.Parameters.AddWithValue("@arama", arama);
            List<Kitap> kitaplar = new List<Kitap>();

            while (reader.Read())
            {
                Kitap kitap = new Kitap();

                kitap.Id = Convert.ToInt32(reader["Id"]);
                kitap.Ad = reader["Ad"].ToString();
                kitap.Detay = reader["Detay"].ToString();
                kitap.Yazar = reader["Yazar"].ToString();
                kitap.YayınEvi = reader["YayınEvi"].ToString();

                kitaplar.Add(kitap);
            }

            reader.Close();
            _baglan.Close();

            return kitaplar;
        }

        public void Kaydet(Kitap Model)
        {
            connect();

            SqlCommand command = new SqlCommand(
                "Insert Into Kitap values(@Ad,@Detay,@Yazar,@YayınEvi)",_baglan);

            command.Parameters.AddWithValue("@Ad",Model.Ad);
            command.Parameters.AddWithValue("@Detay", Model.Detay);
            command.Parameters.AddWithValue("@Yazar", Model.Yazar);
            command.Parameters.AddWithValue("@YayınEvi", Model.YayınEvi);

            command.ExecuteNonQuery();

            _baglan.Close();
        }

        public void Guncelle(Kitap Model)
        {
            connect();

            SqlCommand command = new SqlCommand(
                "Update Kitap set Ad = @Ad, Detay = @Detay, Yazar = @Yazar, YayınEvi = @YayınEvi where Id = @Id", _baglan);

            command.Parameters.AddWithValue("@Ad", Model.Ad);
            command.Parameters.AddWithValue("@Detay", Model.Detay);
            command.Parameters.AddWithValue("@Yazar", Model.Yazar);
            command.Parameters.AddWithValue("@YayınEvi", Model.YayınEvi);
            command.Parameters.AddWithValue("@Id", Model.Id);

            command.ExecuteNonQuery();

            _baglan.Close();
        }

        public void Sil(Kitap Model)
        {
            connect();

            SqlCommand command = new SqlCommand(
                "Delete from Kitap where Id = @Id", _baglan);

            command.Parameters.AddWithValue("@Id", Model.Id);

            command.ExecuteNonQuery();

            _baglan.Close();
        }


    }
}
