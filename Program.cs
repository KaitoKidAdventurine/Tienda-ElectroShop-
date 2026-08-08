using System;
using System.Collections.Generic;
using System.Linq;

using TiendaElectroShop.Clases;
using TiendaElectroShop.Enum;
using TiendaElectroShop.Interfaces;

namespace TiendaElectroShop
{
    class Program
    {
        static Tienda tienda = new Tienda();

        // ------------------------------------------------------------
        // Metodo principal
        // ------------------------------------------------------------
        static void Main(string[] args)
        {
            InicializarDatosPrueba();
            tienda.CanalesNotificacion.Add(new NotificadorEmail());
            tienda.CanalesNotificacion.Add(new NotificadorSMS());

            bool salir = false;
            while (!salir)
            {
                MostrarMenu();
                string opcion = Console.ReadLine();
                salir = ProcesarOpcionMenu(opcion);
                if (!salir)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }

        // ------------------------------------------------------------
        // Metodo para mostrar el MENU
        // ------------------------------------------------------------
        static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("=== TIENDA ELECTROSHOP ===");
            Console.WriteLine("1. Agregar producto al inventario");
            Console.WriteLine("2. Registrar nuevo cliente");
            Console.WriteLine("3. Crear pedido");
            Console.WriteLine("4. Cambiar estado de pedido");
            Console.WriteLine("5. Mostrar consultas LINQ");
            Console.WriteLine("6. Mostrar inventario");
            Console.WriteLine("7. Mostrar clientes");
            Console.WriteLine("8. Mostrar pedidos");
            Console.WriteLine("9. Salir");
            Console.Write("\nSeleccione una opción: ");
        }

        // ------------------------------------------------------------
        // Metodo para procesar la opción seleccionada en el menú
        // ------------------------------------------------------------
        static bool ProcesarOpcionMenu(string opcion)
        {
            switch (opcion)
            {
                case "1": AgregarProducto(); break;
                case "2": RegistrarCliente(); break;
                case "3": CrearPedido(); break;
                case "4": CambiarEstadoPedido(); break;
                case "5": MostrarConsultas(); break;
                case "6": MostrarInventario(); break;
                case "7": MostrarClientes(); break;
                case "8": MostrarPedidos(); break;
                case "9":
                    Console.WriteLine("¡Gracias por usar ElectroShop!");
                    return true;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
            return false;
        }

        // ------------------------------------------------------------
        // Metodo para inicializar datos de prueba
        // ------------------------------------------------------------
        static void InicializarDatosPrueba()
        {
            tienda.Inventario.Add(new ProductoFisico(1, "Laptop Gaming", 1200.99, CategoriaProducto.Informatica, 15, 2.5));
            tienda.Inventario.Add(new ProductoFisico(2, "Smartphone", 699.99, CategoriaProducto.Electronica, 8, 0.3));
            tienda.Inventario.Add(new ProductoDigital(3, "Curso C# Avanzado", 49.99, CategoriaProducto.Capacitacion, 100, 2.5));
            tienda.Inventario.Add(new ProductoFisico(4, "Auriculares Bluetooth", 89.99, CategoriaProducto.Electronica, 5, 0.2));
            tienda.Inventario.Add(new ProductoDigital(5, "E-book Programación", 19.99, CategoriaProducto.Literatura, 50, 1.2));

            tienda.Clientes.Add(new Cliente(1, "Juan Pérez", "juan@email.com", "123456789"));
            tienda.Clientes.Add(new Cliente(2, "María García", "maria@email.com", "987654321"));
            tienda.Clientes.Add(new Cliente(3, "Carlos López", "carlos@email.com", "555555555"));
        }

        // ============================================================
        //  OPCIÓN 1: AGREGAR PRODUCTO
        // ============================================================

        // Metodo para agregar un producto al inventario
        static void AgregarProducto()
        {
            Console.Clear();
            Console.WriteLine("=== AGREGAR PRODUCTO ===");

            int id = SolicitarEntero("ID del producto: ");
            string nombre = SolicitarTexto("Nombre: ");
            double precio = SolicitarDouble("Precio: ");
            CategoriaProducto categoria = SeleccionarCategoria();
            int cantidad = SolicitarEntero("Cantidad/Stock: ");
            bool esFisico = SolicitarTipoProducto();

            Producto nuevoProducto = esFisico
                ? CrearProductoFisico(id, nombre, precio, categoria, cantidad)
                : CrearProductoDigital(id, nombre, precio, categoria, cantidad);

            tienda.Inventario.Add(nuevoProducto);
            Console.WriteLine($"\nProducto '{nombre}' agregado correctamente.");
        }

        // Metodo para solicitar un valor entero al usuario
        static int SolicitarEntero(string mensaje)
        {
            Console.Write(mensaje);
            return int.Parse(Console.ReadLine());
        }

        // Metodo para solicitar un valor double al usuario
        static double SolicitarDouble(string mensaje)
        {
            Console.Write(mensaje);
            return double.Parse(Console.ReadLine());
        }

        // Metodo para solicitar un texto al usuario
        static string SolicitarTexto(string mensaje)
        {
            Console.Write(mensaje);
            return Console.ReadLine();
        }

        // Metodo para seleccionar una categoría de producto
        static CategoriaProducto SeleccionarCategoria()
        {
            Console.WriteLine("\nCategorías disponibles:");
            var categorias = System.Enum.GetValues(typeof(CategoriaProducto));
            for (int i = 0; i < categorias.Length; i++)
                Console.WriteLine($"{i + 1}. {categorias.GetValue(i)}");

            Console.Write("Seleccione categoría (número): ");
            int indice = int.Parse(Console.ReadLine()) - 1;
            return (CategoriaProducto)categorias.GetValue(indice);
        }

        // Metodo para preguntar si el producto es físico o digital
        static bool SolicitarTipoProducto()
        {
            Console.WriteLine("\nTipo de producto:");
            Console.WriteLine("1. Producto Físico");
            Console.WriteLine("2. Producto Digital");
            Console.Write("Seleccione tipo: ");
            return Console.ReadLine() == "1";
        }

        // Metodo para crear un producto físico
        static ProductoFisico CrearProductoFisico(int id, string nombre, double precio, CategoriaProducto categoria, int cantidad)
        {
            double peso = SolicitarDouble("Peso (kg): ");
            return new ProductoFisico(id, nombre, precio, categoria, cantidad, peso);
        }

        // Metodo para crear un producto digital
        static ProductoDigital CrearProductoDigital(int id, string nombre, double precio, CategoriaProducto categoria, int cantidad)
        {
            double tamanno = SolicitarDouble("Tamaño de descarga (MB): ");
            return new ProductoDigital(id, nombre, precio, categoria, cantidad, tamanno);
        }

        // ============================================================
        //  OPCIÓN 2: REGISTRAR CLIENTE
        // ============================================================

        // Metodo para registrar un nuevo cliente
        static void RegistrarCliente()
        {
            Console.Clear();
            Console.WriteLine("=== REGISTRAR CLIENTE ===");

            int id = SolicitarEntero("ID del cliente: ");
            string nombre = SolicitarTexto("Nombre: ");
            string email = SolicitarTexto("Email: ");
            string telefono = SolicitarTexto("Teléfono: ");

            var cliente = new Cliente(id, nombre, email, telefono);
            tienda.Clientes.Add(cliente);
            Console.WriteLine($"\nCliente '{nombre}' registrado correctamente.");
        }

        // ============================================================
        //  OPCIÓN 3: CREAR PEDIDO (ya refactorizada)
        // ============================================================

        // Metodo para crear un nuevo pedido
        static void CrearPedido()
        {
            Console.Clear();
            Console.WriteLine("=== CREAR PEDIDO ===");

            if (!ValidarPrecondiciones(tienda))
                return;

            Cliente cliente = SeleccionarCliente(tienda);
            if (cliente == null)
                return;

            Pedido pedido = CrearYCompletarPedido(tienda, cliente);

            if (pedido.Productos.Count > 0)
                FinalizarPedido(tienda, pedido);
            else
                Console.WriteLine("\nPedido cancelado. No se agregaron productos.");
        }

        // Metodo para validar que existan clientes e inventario
        static bool ValidarPrecondiciones(Tienda tienda)
        {
            if (tienda.Clientes.Count == 0)
            {
                Console.WriteLine("No hay clientes registrados. Registre un cliente primero.");
                return false;
            }
            if (tienda.Inventario.Count == 0)
            {
                Console.WriteLine("No hay productos en el inventario. Agregue productos primero.");
                return false;
            }
            return true;
        }

        // Metodo para seleccionar un cliente de la lista
        static Cliente SeleccionarCliente(Tienda tienda)
        {
            Console.WriteLine("Clientes disponibles:");
            for (int i = 0; i < tienda.Clientes.Count; i++)
                Console.WriteLine($"{i + 1}. {tienda.Clientes[i].Nombre} (ID: {tienda.Clientes[i].Id})");

            Console.Write("\nSeleccione cliente (número): ");
            int indice = int.Parse(Console.ReadLine()) - 1;

            if (indice < 0 || indice >= tienda.Clientes.Count)
            {
                Console.WriteLine("Cliente no válido.");
                return null;
            }
            return tienda.Clientes[indice];
        }

        // Metodo para crear el pedido y gestionar la selección de productos
        static Pedido CrearYCompletarPedido(Tienda tienda, Cliente cliente)
        {
            int nuevoId = tienda.Pedidos.Count > 0
                ? tienda.Pedidos.Max(p => p.NroPedido) + 1
                : 1;

            var pedido = new Pedido(nuevoId, cliente.Id);
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                MostrarProductosDisponibles(tienda);
                Console.Write("\nSeleccione producto (número) o 0 para terminar: ");

                Producto producto = SeleccionarProducto(tienda);
                if (producto == null)
                {
                    continuar = false;
                }
                else
                {
                    AgregarProductoAlPedido(tienda, pedido, producto);
                    if (continuar)
                    {
                        Console.Write("\n¿Agregar otro producto? (s/n): ");
                        continuar = Console.ReadLine().ToLower() == "s";
                    }
                }
            }
            return pedido;
        }

        // Metodo para mostrar el inventario disponible
        static void MostrarProductosDisponibles(Tienda tienda)
        {
            Console.WriteLine("Productos disponibles:");
            for (int i = 0; i < tienda.Inventario.Count; i++)
            {
                var p = tienda.Inventario[i];
                Console.WriteLine($"{i + 1}. {p.Nombre} - ${p.Precio} - Stock: {p.Cantidad}");
            }
        }

        // Metodo para seleccionar un producto del inventario
        static Producto SeleccionarProducto(Tienda tienda)
        {
            int indice = int.Parse(Console.ReadLine()) - 1;
            if (indice == -1) return null;

            if (indice < 0 || indice >= tienda.Inventario.Count)
            {
                Console.WriteLine("Producto no válido.");
                return null;
            }
            return tienda.Inventario[indice];
        }

        // Metodo para agregar un producto al pedido y descontar stock
        static void AgregarProductoAlPedido(Tienda tienda, Pedido pedido, Producto producto)
        {
            if (producto.Cantidad > 0)
            {
                pedido.AddProducto(producto);
                producto.Cantidad--;
                Console.WriteLine($"Producto '{producto.Nombre}' agregado al pedido.");
            }
            else
            {
                Console.WriteLine("Producto sin stock disponible.");
            }
        }

        // Metodo para finalizar el pedido (guardar y mostrar total)
        static void FinalizarPedido(Tienda tienda, Pedido pedido)
        {
            tienda.Pedidos.Add(pedido);
            Console.WriteLine($"\nPedido #{pedido.NroPedido} creado correctamente.");
            Console.WriteLine($"Total: ${pedido.GetTotal():F2}");
        }

        // ============================================================
        //  OPCIÓN 4: CAMBIAR ESTADO DE PEDIDO
        // ============================================================

        // Metodo para cambiar el estado de un pedido
        static void CambiarEstadoPedido()
        {
            Console.Clear();
            Console.WriteLine("=== CAMBIAR ESTADO DE PEDIDO ===");

            if (!HayPedidos()) return;

            Pedido pedido = SeleccionarPedido();
            if (pedido == null) return;

            Estado nuevoEstado = SeleccionarNuevoEstado();
            if (nuevoEstado == pedido.Estado)
            {
                Console.WriteLine("El estado seleccionado es el mismo que el actual.");
                return;
            }

            pedido.CambiarEstado(nuevoEstado, tienda);
            Console.WriteLine($"\nEstado del pedido #{pedido.NroPedido} cambiado a {nuevoEstado}.");
        }

        // Metodo para verificar si hay pedidos registrados
        static bool HayPedidos()
        {
            if (tienda.Pedidos.Count == 0)
            {
                Console.WriteLine("No hay pedidos registrados.");
                return false;
            }
            return true;
        }

        // Metodo para mostrar la lista de pedidos y seleccionar uno
        static Pedido SeleccionarPedido()
        {
            Console.WriteLine("Pedidos disponibles:");
            for (int i = 0; i < tienda.Pedidos.Count; i++)
            {
                var pedido = tienda.Pedidos[i];
                var cliente = tienda.Clientes.FirstOrDefault(c => c.Id == pedido.IdUsuario);
                string nombreCliente = cliente != null ? cliente.Nombre : "Cliente no encontrado";
                Console.WriteLine($"{i + 1}. Pedido #{pedido.NroPedido} - Cliente: {nombreCliente} - Estado: {pedido.Estado} - Total: ${pedido.GetTotal():F2}");
            }

            Console.Write("\nSeleccione pedido (número): ");
            int indice = int.Parse(Console.ReadLine()) - 1;
            if (indice < 0 || indice >= tienda.Pedidos.Count)
            {
                Console.WriteLine("Pedido no válido.");
                return null;
            }
            return tienda.Pedidos[indice];
        }

        // Metodo para seleccionar un nuevo estado
        static Estado SeleccionarNuevoEstado()
        {
            Console.WriteLine("\nEstados disponibles:");
            Console.WriteLine("1. Pendiente");
            Console.WriteLine("2. Enviado");
            Console.WriteLine("3. Entregado");
            Console.Write("Seleccione nuevo estado: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1": return Estado.Pendiente;
                case "2": return Estado.Enviado;
                case "3": return Estado.Entregado;
                default:
                    Console.WriteLine("Estado no válido.");
                    return Estado.Pendiente; // valor por defecto, pero se maneja en el llamador
            }
        }

        // ============================================================
        //  OPCIÓN 5: MOSTRAR CONSULTAS LINQ
        // ============================================================

        // Metodo para mostrar todas las consultas LINQ
        static void MostrarConsultas()
        {
            Console.Clear();
            Console.WriteLine("=== CONSULTAS LINQ ===");

            MostrarListadoCategorias();
            MostrarTop3ProductosMasCaros();
            MostrarProductosConStockBajo();
            MostrarTotalFacturado();
            MostrarPedidosEntregadosHoy();
            BuscarPedidosPorCliente();
        }

        // Metodo para mostrar categorías
        static void MostrarListadoCategorias()
        {
            Console.WriteLine("\n1. Listado de categorías:");
            var categorias = tienda.ListadoCategoria();
            foreach (var categoria in categorias)
                Console.WriteLine($"- {categoria}");
        }

        // Metodo para mostrar top 3 productos más caros
        static void MostrarTop3ProductosMasCaros()
        {
            Console.WriteLine("\n2. Top 3 productos más caros:");
            var top3 = tienda.TopTres();
            foreach (var producto in top3)
                Console.WriteLine($"- {producto.Nombre}: ${producto.Precio}");
        }

        // Metodo para mostrar productos con stock bajo
        static void MostrarProductosConStockBajo()
        {
            Console.WriteLine("\n3. Productos con stock bajo (<= 10):");
            var stockBajo = tienda.StockBajo();
            foreach (var producto in stockBajo)
                Console.WriteLine($"- {producto.Nombre}: Stock {producto.Cantidad}");
        }

        // Metodo para mostrar total facturado
        static void MostrarTotalFacturado()
        {
            Console.WriteLine("\n4. Total facturado por todos los pedidos:");
            Console.WriteLine($"- ${tienda.CantDineroObtenida():F2}");
        }

        // Metodo para mostrar pedidos entregados hoy
        static void MostrarPedidosEntregadosHoy()
        {
            Console.WriteLine("\n5. Pedidos entregados hoy:");
            var pedidosHoy = tienda.PedidosEnElDia(DateTime.Now);
            foreach (var pedido in pedidosHoy)
            {
                var cliente = tienda.Clientes.FirstOrDefault(c => c.Id == pedido.IdUsuario);
                string nombreCliente = cliente != null ? cliente.Nombre : "Cliente no encontrado";
                Console.WriteLine($"- Pedido #{pedido.NroPedido} - Cliente: {nombreCliente} - Total: ${pedido.GetTotal():F2}");
            }
        }

        // Metodo para buscar pedidos por cliente
        static void BuscarPedidosPorCliente()
        {
            Console.WriteLine("\n6. Buscar pedidos de un cliente:");
            Console.Write("Ingrese ID del cliente: ");
            if (int.TryParse(Console.ReadLine(), out int idCliente))
            {
                var pedidosCliente = tienda.PedidoUsuario(idCliente);
                Console.WriteLine($"Pedidos del cliente ID {idCliente}:");
                foreach (var pedido in pedidosCliente)
                    Console.WriteLine($"- Pedido #{pedido.NroPedido} - Estado: {pedido.Estado} - Total: ${pedido.GetTotal():F2}");
            }
            else
            {
                Console.WriteLine("ID no válido.");
            }
        }

        // ============================================================
        //  OPCIÓN 6: MOSTRAR INVENTARIO
        // ============================================================

        // Metodo para mostrar todo el inventario
        static void MostrarInventario()
        {
            Console.Clear();
            Console.WriteLine("=== INVENTARIO ===");

            if (tienda.Inventario.Count == 0)
            {
                Console.WriteLine("No hay productos en el inventario.");
                return;
            }

            foreach (var producto in tienda.Inventario)
                MostrarDetalleProducto(producto);
        }

        // Metodo para mostrar el detalle de un producto
        static void MostrarDetalleProducto(Producto producto)
        {
            Console.WriteLine($"\nID: {producto.Id}");
            Console.WriteLine($"Nombre: {producto.Nombre}");
            Console.WriteLine($"Precio: ${producto.Precio}");
            Console.WriteLine($"Categoría: {producto.Categoria}");
            Console.WriteLine($"Stock: {producto.Cantidad}");

            if (producto is ProductoFisico pf)
                Console.WriteLine($"Tipo: Físico\nPeso: {pf.Peso} kg");
            else if (producto is ProductoDigital pd)
                Console.WriteLine($"Tipo: Digital\nTamaño: {pd.TamannoDeDescarga} MB");

            Console.WriteLine($"Descripción: {producto.DescripcionProductos()}");
            Console.WriteLine("---");
        }

        // ============================================================
        //  OPCIÓN 7: MOSTRAR CLIENTES
        // ============================================================

        // Metodo para mostrar todos los clientes
        static void MostrarClientes()
        {
            Console.Clear();
            Console.WriteLine("=== CLIENTES REGISTRADOS ===");

            if (tienda.Clientes.Count == 0)
            {
                Console.WriteLine("No hay clientes registrados.");
                return;
            }

            foreach (var cliente in tienda.Clientes)
                MostrarDetalleCliente(cliente);
        }

        // Metodo para mostrar el detalle de un cliente
        static void MostrarDetalleCliente(Cliente cliente)
        {
            Console.WriteLine($"\nID: {cliente.Id}");
            Console.WriteLine($"Nombre: {cliente.Nombre}");
            Console.WriteLine($"Email: {cliente.Email}");
            Console.WriteLine($"Teléfono: {cliente.Telefono}");
            var pedidosCliente = tienda.PedidoUsuario(cliente.Id);
            Console.WriteLine($"Pedidos realizados: {pedidosCliente.Count()}");
            Console.WriteLine("---");
        }

        // ============================================================
        //  OPCIÓN 8: MOSTRAR PEDIDOS
        // ============================================================

        // Metodo para mostrar todos los pedidos
        static void MostrarPedidos()
        {
            Console.Clear();
            Console.WriteLine("=== PEDIDOS ===");

            if (tienda.Pedidos.Count == 0)
            {
                Console.WriteLine("No hay pedidos registrados.");
                return;
            }

            foreach (var pedido in tienda.Pedidos)
                MostrarDetallePedido(pedido);
        }

        // Metodo para mostrar el detalle de un pedido
        static void MostrarDetallePedido(Pedido pedido)
        {
            var cliente = tienda.Clientes.FirstOrDefault(c => c.Id == pedido.IdUsuario);
            string nombreCliente = cliente != null ? cliente.Nombre : "Cliente no encontrado";

            Console.WriteLine($"\nPedido #{pedido.NroPedido}");
            Console.WriteLine($"Cliente: {nombreCliente}");
            Console.WriteLine($"Fecha: {pedido.Fecha}");
            Console.WriteLine($"Estado: {pedido.Estado}");
            Console.WriteLine($"Total: ${pedido.GetTotal():F2}");

            Console.WriteLine("Productos:");
            foreach (var producto in pedido.Productos)
                Console.WriteLine($"- {producto.Nombre}: ${producto.Precio}");
            Console.WriteLine("---");
        }
    }
}