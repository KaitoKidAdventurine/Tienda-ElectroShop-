using System;
using System.Collections.Generic;
using System.Linq;
using TiendaElectroShop.Enum;

namespace TiendaElectroShop.Clases
{
    class Pedido
    {
        private int nroPedido;
        private DateTime fecha;
        private int idUsuario;
        private List<Producto> productos;
        private Estado estado;

        // Evento para notificar entrega
        public event Action<Pedido, Tienda> PedidoEntregado;

        public Pedido(int nro, int idUsuario)
        {
            this.nroPedido = nro;
            fecha = DateTime.Now;
            this.idUsuario = idUsuario;
            this.productos = new List<Producto>();
            this.estado = Estado.Pendiente;
        }

        public int NroPedido { get { return nroPedido; } }
        public DateTime Fecha { get { return fecha; } }
        public int IdUsuario { get { return idUsuario; } }
        public List<Producto> Productos { get { return productos; } }
        public Estado Estado { get { return estado; } }

        public void AddProducto(Producto p)
        {
            this.productos.Add(p);
        }

        public void RemoveProducto(Producto p)
        {
            this.productos.Remove(p);
        }

        public double GetTotal() => productos.Sum(p => p.Precio);

        // Cambia el estado del pedido
        public void CambiarEstado(Estado nuevoEstado, Tienda tienda)
        {
            Estado estadoAnterior = estado;
            estado = nuevoEstado;


            if (nuevoEstado == Estado.Entregado && estadoAnterior != Estado.Entregado)
            {
                OnPedidoEntregado(tienda);
            }
        }

        protected virtual void OnPedidoEntregado(Tienda tienda)
        {
            PedidoEntregado?.Invoke(this, tienda);
        }
    }
}