using System;
using System.Collections.Generic;
using System.Linq;

class Carrito
{
    private readonly Dictionary<Producto, int> _items = new Dictionary<Producto, int>();

    public void AgregarProducto(List<Producto> productosEnTienda, string nombreBuscado, int cantidad)
    {
        Producto productoEncontrado = productosEnTienda.FirstOrDefault(p => p.Nombre == nombreBuscado);
        if (productoEncontrado == null || cantidad <= 0)
            throw new ArgumentException("El producto o la cantidad ingresada son inválidos");

        if (!_items.ContainsKey(productoEncontrado))
            _items[productoEncontrado] = 0;

        _items[productoEncontrado] += cantidad;
    }

    public void EliminarProducto(List<Producto> productosEnTienda, string nombreBuscado)
    {
        Producto productoEncontrado = productosEnTienda.FirstOrDefault(p => p.Nombre == nombreBuscado);
        if (productoEncontrado != null && _items.ContainsKey(productoEncontrado))
            _items.Remove(productoEncontrado);
    }

    public decimal CalcularSubtotal()
    {
        decimal subtotal = 0;
        foreach (var (producto, cantidad) in _items)
        {
            decimal precioVenta = producto.PrecioVenta;
            subtotal += precioVenta * cantidad;
        }
        return subtotal;
    }
}

