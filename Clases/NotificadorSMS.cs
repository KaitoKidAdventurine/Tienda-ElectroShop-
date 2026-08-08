using System;
using TiendaElectroShop.Interfaces;

namespace TiendaElectroShop.Clases
{
    class NotificadorSMS : INotificable
{
    public void Enviar(string destinatario, string mensaje)
    {
        Console.WriteLine($"SMS a {destinatario}: {mensaje}");
        }
    }
}