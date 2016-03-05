Tienda Virtual.

Implementaciones extras a lo básico:

	- En el índice de los productos solo se muestran aquellos
	cuya cantidad disponible es mayor que 1, no todos los de la
	base de datos.

	- En caso de escoger dos veces el mismo producto,
	al visualizar el carrito de la compra, este producto
	aparecerá unicamente una vez, pero el campo "cantidad"
	aparecerá con valor de "2".

	- En el carrito de la compra, tras la lista de productos
	aparecerá el precio total del carrito actual.

	- En cualquier momento se puede quitar un producto del carrito,
	en este caso si la cantidad de este producto era >1, se
	reducirá en 1 la cantidad, si era 1, el producto se eliminará
	de la cesta. El precio total del carrito se modificará 
	en consecuencia.

	- En caso de confirmar la compra pueden darse dos situaciones:

		1) La compra es correcta, es decir el stock de los productos
		(cantidades disponibles), es mayor a las cantidades que se compran
		para todos los productos. En este caso al dar a "confirmar compra"
		se registrará el pedido y se disminuirá el stock de cada uno de los 
		productos en base a la cantidad de articulos de cada tipo comprados.
		En caso de que se agote un producto, por ejemplo hay solo 1 lapiz en stock
		y el usuario compra un lapiz, el stock de lapiz ahora será 0 y se generará
		un registro en la tabla "ProductosAgotados" de la base de datos.

		2) La compra no es correcta. Esto se produce si por ejemplo el usuario intenta 
		comprar 3 lapices y solo hay 2 en stock. En este caso al darle a confirmar compra
		se le avisará al usuario de ello y la compra no se realizará, es decir, no se registrará
		el pedido.
	
	- Se pueden visualizar los pedidos realizados desde el Index de Productos
	
	- Se pueden visualizar los productos agotados desde el Index de Productos

	- Tras finalizar la seleccion de 