class ProductoFisico : Producto
{
    private double peso;
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
    
    public ProductoFisico(int id, string nombre, double precio, string categoria, int cantidad, double peso)
    : base(id, nombre, precio, categoria, cantidad) 
    {
        this.peso = peso;
    }

    public override void descripcionProductos()
    {
        base.MostrarInformacion();
        Console.WriteLine($"Peso: {peso} kg");
    }
}