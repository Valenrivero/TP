using System;

class Producto
{
    private decimal costo;
    public string Nombre { get;}
    public decimal PrecioVenta => costo * 1.3m;
    public int Stock { get; set; }
    public Producto(string nombre, decimal costo, int stock)
    {
        if(string.IsNullOrWhiteSpace(nombre) || costo <=0)
            throw new ArgumentException("Nombre y costo son obligatorios.");
        
        Nombre = nombre;
        this.costo = costo;
        Stock = stock;
    }
    public void ActualizarCosto(decimal nuevoCosto)
    {
        if (nuevoCosto <= 0)
            throw new ArgumentException("El costo debe ser mayor que cero.");

        costo = nuevoCosto;
    }
}   