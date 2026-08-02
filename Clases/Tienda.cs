Using linq;
class Tienda
{
    public List<Producto> Inventario { get; set; } = new List<Producto>();
    public List<Cliente> Clientes { get; set; } = new List<Cliente>();
    public List<Pedido> Pedidos { get; set; } = new List<Pedido>();
    public List<INotificable> CanalesNotificacion { get; set; } = new List<INotificable>();

    public IEnumerable<string>  ListadoCategoria()=> Inventario.Select(p => p.CategoriaProducto).Distinct();

    public IEnumerable<Producto> TopTres() => Inventario.OrderByDescending(p=> p.precio).Take(3);

    public IEnumerable<Producto> StockBajo() => Inventario.Where(p => p.cantidad <= 10);
}