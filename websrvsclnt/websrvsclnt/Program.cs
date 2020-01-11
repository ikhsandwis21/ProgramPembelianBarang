using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace websrvsclnt
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();
            System.Console.ReadKey();
        }
        public static async Task RunAsync()
        {
            Pembelian Pembelian = new Pembelian();
            int Nofaktur, Jml, Hargasatuan, Menu;
            String Vendor, Kode_barang, Nama_barang;
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
        Ulang:
            System.Console.WriteLine("\n\nProgram Pembelian Barang: ");
            System.Console.WriteLine("1. Lihat Data Pembelian");
            System.Console.WriteLine("2. Input Data Pembelian");
            System.Console.WriteLine("3. Update Data Pembelian");
            System.Console.WriteLine("4. Delete Data Pembelian");
            System.Console.WriteLine("5. Keluar");
            System.Console.WriteLine("Masukkan Pilihan: ");
            Menu = int.Parse(Console.ReadLine());
            switch (Menu)
            {
                case 1:
                    System.Console.Clear();
                    client.BaseAddress = new Uri("http://localhost:14685/");
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var resp2 = await client.GetAsync("api/Pembelian");
                    resp2.EnsureSuccessStatusCode();
                    var contn = resp2.Content;
                    string result = await contn.ReadAsStringAsync();
                    Console.WriteLine(result);
                    break;

                case 2:
                    System.Console.Clear();
                    client.BaseAddress = new Uri("http://localhost:14685/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    System.Console.WriteLine("Masukkan Nofaktur: ");
                    Nofaktur = int.Parse(Console.ReadLine());
                    System.Console.WriteLine("Masukkan Vendor: ");
                    Vendor = Console.ReadLine();
                    System.Console.WriteLine("Masukkan Kode Barang: ");
                    Kode_barang = Console.ReadLine();
                    System.Console.WriteLine("Masukkan Nama Barang: ");
                    Nama_barang = Console.ReadLine();
                    System.Console.WriteLine("Masukkan Jumlah Barang: ");
                    Jml = int.Parse(Console.ReadLine());
                    System.Console.WriteLine("Masukkan Harga Satuan: ");
                    Hargasatuan = int.Parse(Console.ReadLine());
                    Pembelian.Nofaktur = Nofaktur;
                    Pembelian.Vendor = Vendor;
                    Pembelian.Kode_barang = Kode_barang;
                    Pembelian.Nama_barang = Nama_barang;
                    Pembelian.Jml = Jml;
                    Pembelian.Hargasatuan = Hargasatuan;
                    HttpResponseMessage response = client.PostAsJsonAsync("api/Pembelian?Nofaktur=" + Pembelian.Nofaktur + "&Vendor=" + Pembelian.Vendor + "&Kode_barang=" + Pembelian.Kode_barang + "&Nama_Barang=" + Pembelian.Nama_barang + "&Jml=" + Pembelian.Jml + "&Hargasatuan=" + Hargasatuan, Pembelian).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        System.Console.WriteLine("Tambah Data Pembelian Berhasil");
                    }
                    else
                    {
                        System.Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                    }
                    System.Console.WriteLine();
                    break;

                case 3:
                    System.Console.Clear();
                    client.BaseAddress = new Uri("http://localhost:14685/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    System.Console.WriteLine("Masukkan Nofaktur yang ingin diupdate: ");
                    Nofaktur = int.Parse(Console.ReadLine());
                    System.Console.WriteLine("Masukkan Vendor: ");
                    Vendor = Console.ReadLine();
                    System.Console.WriteLine("Masukkan Kode Barang: ");
                    Kode_barang = Console.ReadLine();
                    System.Console.WriteLine("Masukkan Nama Barang: ");
                    Nama_barang = Console.ReadLine();
                    System.Console.WriteLine("Masukkan Jumlah Barang: ");
                    Jml = int.Parse(Console.ReadLine());
                    System.Console.WriteLine("Masukkan Harga Satuan: ");
                    Hargasatuan = int.Parse(Console.ReadLine());
                    Pembelian.Nofaktur = Nofaktur;
                    Pembelian.Vendor = Vendor;
                    Pembelian.Kode_barang = Kode_barang;
                    Pembelian.Nama_barang = Nama_barang;
                    Pembelian.Jml = Jml;
                    Pembelian.Hargasatuan = Hargasatuan;
                    response = client.PutAsJsonAsync("api/Pembelian?Nofaktur=" + Pembelian.Nofaktur + "&Vendor=" + Pembelian.Vendor + "&Kode_barang=" + Pembelian.Kode_barang + "&Nama_Barang=" + Pembelian.Nama_barang + "&Jml=" + Pembelian.Jml + "&Hargasatuan=" + Hargasatuan, Pembelian).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        System.Console.WriteLine("Update Data Pembelian Berhasil");
                    }
                    else
                    {
                        System.Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                    }
                    System.Console.WriteLine();
                    break;

                case 4:
                    System.Console.Clear();
                    client.BaseAddress = new Uri("http://localhost:14685/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    System.Console.WriteLine("Masukkan Nofaktur yang ingin dihapus: ");
                    Nofaktur = int.Parse(Console.ReadLine());
                    Pembelian.Nofaktur = Nofaktur;
                    var del = client.DeleteAsync("api/Pembelian?Nofaktur=" + Pembelian.Nofaktur).Result;
                    if (del.IsSuccessStatusCode)
                    {
                        System.Console.WriteLine("Hapus Data Pembelian Berhasil");
                    }
                    else
                    {
                        System.Console.WriteLine("{0} ({1})", (int)del.StatusCode, del.ReasonPhrase);
                    }
                    System.Console.WriteLine();
                    break;

                case 5:
                    System.Environment.Exit(1);
                    break;

                default:
                    System.Console.WriteLine("Menu Tidak Tersedia");
                    goto Ulang;
            }
        }
    }
}
