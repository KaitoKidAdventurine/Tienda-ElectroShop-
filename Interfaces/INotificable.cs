interface INotificable
{
    void Enviar(string destinatario, string mensaje);
}

class NotificadorEmail : INotificable
{
    public void Enviar(string destinatario, string mensaje)
    {
        Console.WriteLine($"EMAIL a {destinatario}: {mensaje}");
    }
}

class NotificadorSMS : INotificable
{
    public void Enviar(string destinatario, string mensaje)
    {
        Console.WriteLine($"SMS a {destinatario}: {mensaje}");
    }
}