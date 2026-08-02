class ProductoDigital : Producto
{
    private double tamannoDeDescarga;

    public ProductoDigital(int id, string nombre, double precio, string categoria, int cantidad,double tamannoDeDescarga)
    : base(id, nombre, precio, categoria, cantidad) 
    {
        this.tamannoDeDescarga = tamannoDeDescarga;
    }

    public override string descripcionProductos()
    {
        Console.WriteLine("ProductoDigital: " + base.MostrarInformacion() + 
        " Tamaño de descarga: " + tamannoDeDescarga);
    }
}