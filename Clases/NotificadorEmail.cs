
using System;
using TiendaElectroShop.Interfaces;

namespace TiendaElectroShop.Clases
{
    class NotificadorEmail : INotificable
{
    public void Enviar(string destinatario, string mensaje)
    {
        Console.WriteLine($"EMAIL a {destinatario}: {mensaje}");
        }
    }
}
