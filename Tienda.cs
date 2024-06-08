using System;
using System.Collections.Generic;

class Tienda 
{
    private List<Producto> productosEnTienda = new List<Producto>();
    private decimal dineroEnCaja = 0;

    public List<Producto> ObtenerListaProductosEnTienda()
    {
        return productosEnTienda;
    }

    public void AgregarProducto(Producto producto)
    { 
        productosEnTienda.Add(producto);
    }
    public void ELiminarProducto(Producto producto)
    {
        productosEnTienda.Remove(producto);
    }
    public void MostrarProducto()
    {
        Console.WriteLine("Productos disponibles en la tienda: ");
        foreach (var producto in productosEnTienda)
        {
            Console.WriteLine($"{producto.Nombre}(Stock: {producto.Stock})");

        }
    }
    public void Cobrar(decimal montoPago, decimal subtotal)
    {
        //decimal totalVenta = 0;
        //foreach (var producto in productosEnTienda)
        //{
        //    totalVenta += subtotal;
        //}
        if (montoPago >= subtotal)
        {
            decimal vuelto = montoPago - subtotal;
            dineroEnCaja += subtotal;
            Console.WriteLine($"Venta realizada. Vuelto: {vuelto:C}");
        }
        else 
        {
            Console.WriteLine("El monto ingresado no es suficiente para pagar la compra.");
        }

    }
     public void ModificarStockProducto(string nombreProducto, int nuevaCantidad)
    {
        var producto = productosEnTienda.FirstOrDefault(p => p.Nombre == nombreProducto);
        if (producto != null)
        {
            producto.Stock = nuevaCantidad;
        }
        else
        {
            Console.WriteLine($"El producto '{nombreProducto}' no existe en la tienda.");
        }
    }

    public void ModificarPrecioProducto(string nombreProducto, decimal nuevoPrecio)
    {
        var producto = productosEnTienda.FirstOrDefault(p => p.Nombre == nombreProducto);
        if (producto != null)
        {
            producto.ActualizarCosto(nuevoPrecio);
        }
        else
        {
            Console.WriteLine($"El producto '{nombreProducto}' no existe en la tienda.");
        }
    }
}