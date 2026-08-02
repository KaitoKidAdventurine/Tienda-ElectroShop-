class Pedido
{
    
    //Campos
    private int nroPedido;
    private DateTime fecha;
    private Cliente cliente;
    private List<Producto> productos;

    private Estado estado;

    public Pedido(int nro, Cliente cli)
    {
        this.nroPedido = nro;
        fecha = DateTime.Now; 
        this.cliente = cli;
        this.productos = new List<Producto>();
    }
    
    public void addProducto(Producto p)
    {
        this.productos.Add(p);
    }

    public void removeProducto(Producto p)
    {
        this.productos.Remove(p);
    }
    
    public double getTotal() => productos => productos.Sum(p => p.Precio);
}