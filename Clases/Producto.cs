using System;
using TiendaElectroShop.Enum;

namespace TiendaElectroShop.Clases
{
    abstract class Producto
{
    protected int id;
    protected string nombre;
    protected double precio;
    protected CategoriaProducto categoria;
    protected int cantidad;

    protected Producto(int id, string nombre, double precio, CategoriaProducto categoria, int cantidad)
    {
        Id = id;
        Nombre = nombre;
        Precio = precio;
        Categoria = categoria;
        this.cantidad = cantidad;
    }

    public int Id
    {
        get { return id; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("El ID debe ser un número entero positivo.");
            id = value;
        }
    }

    public string Nombre
    {
        get { return nombre; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El nombre no puede estar vacío o ser solo espacios.");
            if (value.Length < 3)
                throw new ArgumentException("El nombre debe tener al menos 3 caracteres.");
            nombre = value;
        }
    }

    public double Precio
    {
        get { return precio; }
        set
        {
            if (value < 0)
                throw new ArgumentException("El precio no puede ser negativo.");
            precio = value;
        }
    }

    public CategoriaProducto Categoria
    {
        get { return categoria; }
        set
        {
            if (!System.Enum.IsDefined(typeof(CategoriaProducto), value))
                throw new ArgumentException("La categoría no es válida.");
            categoria = value;
        }
    }
    
    public int Cantidad
    {
        get { return cantidad; }
        set
        {
            if (value < 0)
                throw new ArgumentException("La cantidad no puede ser negativa.");
            cantidad = value;
        }
    }
    
        public abstract string DescripcionProductos();
    }
}