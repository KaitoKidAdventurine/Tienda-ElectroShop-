class Cliente
{
    private int Id { get; set; }
    private string Nombre { get; set; }
    private string Email { get; set; }
    private string Telefono { get; set; }

    public string informacion()
    {
        return $"[Id={Id}, Nombre={Nombre}, Email={Email}, Telefono={Telefono}]";
    }
}