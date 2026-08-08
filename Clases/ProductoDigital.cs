using TiendaElectroShop.Enum;

namespace TiendaElectroShop.Clases
{
    class ProductoDigital : Producto
    {
        private double tamannoDeDescarga;

        public ProductoDigital(int id, string nombre, double precio, CategoriaProducto categoria, int cantidad, double tamannoDeDescarga)
            : base(id, nombre, precio, categoria, cantidad)
        {
            this.tamannoDeDescarga = tamannoDeDescarga;
        }

        public double TamannoDeDescarga
        {
            get { return tamannoDeDescarga; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("El tamaño de descarga no puede ser negativo.");
                tamannoDeDescarga = value;
            }
        }

        public override string DescripcionProductos()
        {
            return $"Producto Digital: {Nombre} (ID: {Id}) - Precio: ${Precio} - Categoría: {Categoria} - Tamaño: {tamannoDeDescarga} MB - Stock: {Cantidad}";
        }
    }
}