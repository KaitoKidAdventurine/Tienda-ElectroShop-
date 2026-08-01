# Tienda-ElectroShop-
Proyecto para practicar mis conocimientos en C#

En la tienda "ElectroShop" se desea implementar un sistema de gestión que permita administrar el inventario de productos, los clientes y los pedidos realizados. El sistema debe llevar un control de los estados de los pedidos (Pendiente, Enviado, Entregado) y, al momento en que un pedido se entregue, deberá notificar al cliente a través de los canales de comunicación disponibles (correo electrónico y SMS) utilizando un mecanismo de eventos.

De cada producto se conoce su identificador único, nombre, precio y categoría. Existen dos tipos de productos: los digitales, de los cuales se almacena el tamaño de descarga en megabytes; y los físicos, de los cuales se registra el peso en kilogramos. Ambos tipos heredan de la clase base Producto y deben implementar un método que devuelva un detalle descriptivo del producto, incluyendo los atributos específicos de cada tipo.

Los clientes se registran con su nombre, correo electrónico y número de teléfono. Un cliente puede realizar múltiples pedidos, y un pedido está compuesto por una lista de productos. Cada pedido tiene un identificador, la referencia al cliente que lo realiza, el estado (Pendiente, Enviado o Entregado) y la fecha de creación. El sistema debe calcular el importe total del pedido sumando los precios de todos sus productos.

El sistema debe contar con un mecanismo de notificaciones a través de una interfaz INotificable, que define el método Enviar(destinatario, mensaje). Se dispondrá de dos implementaciones: notificador por correo electrónico y notificador por SMS. Cuando un pedido cambie su estado a Entregado, se disparará un evento que, al ser capturado, enviará un mensaje de confirmación al cliente a través de todos los canales de notificación configurados.

La tienda (clase principal) mantiene listas del inventario de productos, los clientes registrados, los pedidos realizados y los canales de notificación disponibles. Se deben implementar las siguientes consultas utilizando LINQ:

    Listado de productos por categoría.

    Top 3 productos más caros.

    Productos con stock bajo (aplicable a productos físicos, que dispondrán de una propiedad Stock adicional, para practicar consultas con condiciones).

    Pedidos de un cliente específico (dado su identificador).

    Total facturado por todos los pedidos.

    Pedidos entregados en el día actual.

El sistema debe proporcionar un menú interactivo que permita:

    Agregar productos al inventario (tanto digitales como físicos).

    Registrar nuevos clientes.

    Crear un pedido, seleccionando un cliente existente y los productos que lo componen.

    Cambiar el estado de un pedido manualmente, lo que probará el evento y el envío de notificaciones.

    Visualizar todas las consultas LINQ antes mencionadas.

    Salir de la aplicación.

El sistema debe garantizar lo siguiente:

    Utilizar herencia para diferenciar los tipos de productos, con la clase base Producto y sus derivadas ProductoDigital y ProductoFisico.

    Implementar la interfaz INotificable en al menos dos clases concretas.

    Emplear eventos (event Action) para notificar la entrega de un pedido, con un suscriptor que utilice los canales de notificación.

    Todas las operaciones de consulta y cálculo sobre colecciones deben resolverse mediante LINQ.

    El cambio de estado de un pedido debe actualizar la propiedad correspondiente y, en caso de ser Entregado, invocar el evento.

    Los productos físicos deben incluir un atributo de stock para poder aplicar las consultas de stock bajo.

    La creación de un pedido debe permitir seleccionar productos del inventario y calcular el total automáticamente.

    El menú debe ser claro y funcional, permitiendo probar todas las características del sistema sin necesidad de base de datos externa.

