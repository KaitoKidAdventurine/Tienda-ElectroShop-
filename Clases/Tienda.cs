using System;
using System.Collections.Generic;
using System.Linq;
using TiendaElectroShop.Enum;
using TiendaElectroShop.Interfaces;

namespace TiendaElectroShop.Clases
{
    class Tienda
    {
        public List<Producto> Inventario { get; set; } = new List<Producto>();
        public List<Cliente> Clientes { get; set; } = new List<Cliente>();
        public List<Pedido> Pedidos { get; set; } = new List<Pedido>();
        public List<INotificable> CanalesNotificacion { get; set; } = new List<INotificable>();

        public Tienda()
        {
            // Suscribir el evento de pedido entregado
            foreach (var pedido in Pedidos)
            {
                pedido.PedidoEntregado += NotificarEntregaPedido;
            }
        }

        public IEnumerable<CategoriaProducto> ListadoCategoria() => Inventario.Select(p => p.Categoria).Distinct();

        public IEnumerable<Producto> TopTres() => Inventario.OrderByDescending(p => p.Precio).Take(3);

        public IEnumerable<Producto> StockBajo() => Inventario.Where(p => p.Cantidad <= 10);

        public IEnumerable<Pedido> PedidoUsuario(int id) => Pedidos.Where(p => p.IdUsuario == id);

        public double CantDineroObtenida() => Pedidos.Sum(p => p.GetTotal());

        public IEnumerable<Pedido> PedidosEnElDia(DateTime fechaPar) => Pedidos.Where(p => p.Fecha.Date == fechaPar.Date && p.Estado == Estado.Entregado);

        private void NotificarEntregaPedido(Pedido pedido, Tienda tienda)
        {
            var cliente = Clientes.FirstOrDefault(c => c.Id == pedido.IdUsuario);
            if (cliente != null)
            {
                string mensaje = $"¡Su pedido #{pedido.NroPedido} ha sido entregado! Total: ${pedido.GetTotal():F2}";

                foreach (var canal in CanalesNotificacion)
                {
                    if (canal is NotificadorEmail)
                    {
                        canal.Enviar(cliente.Email, mensaje);
                    }
                    else if (canal is NotificadorSMS)
                    {
                        canal.Enviar(cliente.Telefono, mensaje);
                    }
                }
            }
        }
        public void AgregarPedido(Pedido pedido)
        {
            Pedidos.Add(pedido);
            pedido.PedidoEntregado += NotificarEntregaPedido;
        }
    }
}