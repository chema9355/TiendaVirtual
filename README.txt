Tienda Virtual.

Implementaciones extras a lo b�sico:

	- En el �ndice de los productos solo se muestran aquellos
	cuya cantidad disponible es mayor que 1, no todos los de la
	base de datos.

	- En caso de escoger dos veces el mismo producto,
	al visualizar el carrito de la compra, este producto
	aparecer� unicamente una vez, pero el campo "cantidad"
	aparecer� con valor de "2".

	- En el carrito de la compra, tras la lista de productos
	aparecer� el precio total del carrito actual.

	- En cualquier momento se puede quitar un producto del carrito,
	en este caso si la cantidad de este producto era >1, se
	reducir� en 1 la cantidad, si era 1, el producto se eliminar�
	de la cesta. El precio total del carrito se modificar� 
	en consecuencia.

	- En caso de confirmar la compra pueden darse dos situaciones:

		1) La compra es correcta, es decir el stock de los productos
		(cantidades disponibles), es mayor a las cantidades que se compran
		para todos los productos. En este caso al dar a "confirmar compra"
		se registrar� el pedido y se disminuir� el stock de cada uno de los 
		productos en base a la cantidad de articulos de cada tipo comprados.
		En caso de que se agote un producto, por ejemplo hay solo 1 lapiz en stock
		y el usuario compra un lapiz, el stock de lapiz ahora ser� 0 y se generar�
		un registro en la tabla "ProductosAgotados" de la base de datos.

		2) La compra no es correcta. Esto se produce si por ejemplo el usuario intenta 
		comprar 3 lapices y solo hay 2 en stock. En este caso al darle a confirmar compra
		se le avisar� al usuario de ello y la compra no se realizar�, es decir, no se registrar�
		el pedido.
	
	- Se pueden visualizar los pedidos realizados desde el Index de Productos
	
	- Se pueden visualizar los productos agotados desde el Index de Productos

	- Tras finalizar la seleccion de 