namespace TiendaElectroShop.Interfaces
{
    interface INotificable
{
    void Enviar(string destinatario, string mensaje);
    }
}