using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using websrvs.Models;

namespace websrvs.Controllers
{
    public class PembelianController : ApiController
    {
        PembelianDataContext db = new PembelianDataContext();
        public IQueryable<trs_pembelian> GetDataPembelian()
        {
            var data = db.trs_pembelians.Select(p => p);
            return data;
        }
        public trs_pembelian GetDataPembelian(int Nofaktur)
        {
            trs_pembelian item = db.trs_pembelians.Where(p => p.nofaktur.Equals(Nofaktur)).Single<trs_pembelian>();
            return item;
        }
        public void PostDataPembelian(int Nofaktur, String Vendor, String Kode_barang, String Nama_barang, int Jml, int Hargasatuan)
        {
            trs_pembelian item = new trs_pembelian();
            item.nofaktur = Nofaktur;
            item.vendor = Vendor;
            item.kode_barang = Kode_barang;
            item.nama_barang = Nama_barang;
            item.jml = Jml;
            item.hargasatuan = Hargasatuan;
            item.subtotal = Jml * Hargasatuan;
            db.trs_pembelians.InsertOnSubmit(item);
            db.SubmitChanges();
        }
        public void PutDataPembelian(int Nofaktur, String Vendor, String Kode_barang, String Nama_barang, int Jml, int Hargasatuan)
        {
            trs_pembelian item = db.trs_pembelians.Where(p => p.nofaktur.Equals(Nofaktur)).Single<trs_pembelian>();
            item.vendor = Vendor;
            item.kode_barang = Kode_barang;
            item.nama_barang = Nama_barang;
            item.jml = Jml;
            item.hargasatuan = Hargasatuan;
            item.subtotal = Jml * Hargasatuan;
            db.SubmitChanges();
        }
        public void DeleteDataPembelian(int Nofaktur)
        {
            trs_pembelian item = db.trs_pembelians.Where(p => p.nofaktur.Equals(Nofaktur)).Single<trs_pembelian>();
            db.trs_pembelians.DeleteOnSubmit(item);
            db.SubmitChanges();
        }
    }
}
