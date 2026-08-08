namespace TiendaElectroShop.Clases
{
    class Cliente
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public string Email { get; private set; }
        public string Telefono { get; private set; }

        public Cliente(int id, string nombre, string email, string telefono)
        {
            Id = id;
            Nombre = nombre;
            Email = email;
            Telefono = telefono;
        }

        public string Informacion()
        {
            return $"ID: {Id}, Nombre: {Nombre}, Email: {Email}, Teléfono: {Telefono}";
        }
    }
}