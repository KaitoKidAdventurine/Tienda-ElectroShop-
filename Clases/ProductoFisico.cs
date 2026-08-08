using TiendaElectroShop.Enum;

namespace TiendaElectroShop.Clases
{
    class ProductoFisico : Producto
{
    private double peso;
    
    public ProductoFisico(int id, string nombre, double precio, CategoriaProducto categoria, int cantidad, double peso)
        : base(id, nombre, precio, categoria, cantidad) 
    {
        this.peso = peso;
    }

    public double Peso
    {
        get { return peso; }
        set
        {
            if (value < 0)
                throw new ArgumentException("El peso no puede ser negativo.");
            peso = value;
        }
    }

    public override string DescripcionProductos()
    {
        return $"Producto Físico: {Nombre} (ID: {Id}) - Precio: ${Precio} - Categoría: {Categoria} - Peso: {peso} kg - Stock: {Cantidad}";
        }
    }
}