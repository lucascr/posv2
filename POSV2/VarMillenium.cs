using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSV2
{
    class VarMillenium
    {
        public static VarMilleniumProducto  MilleniumProducto = new VarMilleniumProducto();
        public static List<VarMilleniumProducto> MilleniumLineasFactura = new List<VarMilleniumProducto>();
    }

    class VarMilleniumProducto
    {
        public string id_producto { get; set; }
        public string producto_codigo { get; set; }
        public string producto_descripcion { get; set; }
        public string producto_tipo { get; set; }
        public string producto_moneda { get; set; }

        public string producto_precio1 { get; set; }
        public string producto_precio2 { get; set; }
        public string producto_precio_modificable { get; set; }

        public string producto_impuesto  { get; set; }

        public string producto_cabys { get; set; }

        public void LimpiarProducto() {

            this.id_producto = "";
            this.producto_codigo = "";
            this.producto_descripcion = "";
            this.producto_tipo = "";
            this.producto_moneda = "";

            this.producto_precio1 = "";
            this.producto_precio2 = "";
            this.producto_precio_modificable = "";

            this.producto_cabys = "";
        }
    }
    /*
    class VarMilleniumProductos {
        List<VarMilleniumProducto> LineasFacturaMillenium= new List<VarMilleniumProducto>();

        public void Agregar(VarMilleniumProducto NewProducto) {
            LineasFacturaMillenium.Add(NewProducto);
        }

        public void Limpiar() {
            LineasFacturaMillenium.Clear();
        }
    }*/
    
    /*
    public class VarMilleniumProductos<TModel> where TModel : class
    {
        public List<VarMilleniumProducto> MiProducto { get; set; }
    }*/
}
