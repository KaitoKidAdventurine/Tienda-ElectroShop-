class NotificadorSMS : INotificable
{
    public void Enviar(string destinatario, string mensaje)
    {
        Console.WriteLine($"SMS a {destinatario}: {mensaje}");
    }
}