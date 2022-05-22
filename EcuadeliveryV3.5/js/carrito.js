class Carrito {

    //Añadir producto al carrito
    comprarProducto(e) {
        e.preventDefault();
        //Delegado para agregar al carrito
        if (e.target.classList.contains('agregar-carrito')) {
            const producto = e.target.parentElement.parentElement;
            //Enviamos el producto seleccionado para tomar sus datos
            this.leerDatosProducto(producto);
        }
    }

    //Leer datos del producto
    leerDatosProducto(producto) {
        const infoProducto = {
            imagen: producto.querySelector('img').src,
            titulo: producto.querySelector('h4').textContent,
            precio: producto.querySelector('.precio span').textContent,
            id: producto.querySelector('a').getAttribute('data-id'),
            cantidad: 1
        }
        let productosLS;
        productosLS = this.obtenerProductosLocalStorage();
        productosLS.forEach(function (productoLS) {
            if (productoLS.id === infoProducto.id) {
                productosLS = productoLS.id;
            }
        });

        if (productosLS === infoProducto.id) {
            productosLS = this.obtenerProductosLocalStorage();
            productosLS.forEach(function (productoLS) {
                if (productoLS.id === infoProducto.id) {
                    productoLS.cantidad = parseFloat(productoLS.cantidad)+1;
                }
            });
            localStorage.setItem('productos', JSON.stringify(productosLS));
            
            Swal.fire({
                type: 'info',
                title: 'Producto',
                text: 'Se aumento la cantidad del producto seleccionado en el carrito de compras',
                showConfirmButton: true,
                //timer: 1000
            })
        }
        else {
            this.insertarCarrito(infoProducto);
            Swal.fire({
                type: 'info',
                title: 'Producto',
                text: 'Se agrego el producto a su carrito correctamente',
                showConfirmButton: true,
                //timer: 1000
            })
        }

    }

    //muestra producto seleccionado en carrito
    insertarCarrito(producto) {
        const row = document.createElement('tr');
        row.innerHTML = `
            <td>
                <img src="${producto.imagen}" width=100>
            </td>
            <td>${producto.titulo}</td>
            <td>${producto.precio}</td>
            
            <td>
                <a href="#" class="borrar-producto fas fa-times-circle" data-id="${producto.id}"></a>
            </td>
        `;
        listaProductos.appendChild(row);
        this.guardarProductosLocalStorage(producto);

    }

    //Eliminar el producto del carrito en el DOM
    eliminarProducto(e) {
        e.preventDefault();
        let producto, productoID;
        if (e.target.classList.contains('borrar-producto')) {
            e.target.parentElement.parentElement.remove();
            producto = e.target.parentElement.parentElement;
            productoID = producto.querySelector('a').getAttribute('data-id');
        }
        this.eliminarProductoLocalStorage(productoID);
        this.calcularTotal();

    }

    //Elimina todos los productos
    vaciarCarrito(e) {
        e.preventDefault();
        while (listaProductos.firstChild) {
            listaProductos.removeChild(listaProductos.firstChild);
        }
        this.vaciarLocalStorage();

        return false;
    }

    //Almacenar en el LS
    guardarProductosLocalStorage(producto) {
        let productos;
        //Toma valor de un arreglo con datos del LS
        productos = this.obtenerProductosLocalStorage();
        //Agregar el producto al carrito
        productos.push(producto);
        //Agregamos al LS
        localStorage.setItem('productos', JSON.stringify(productos));
    }

    //Comprobar que hay elementos en el LS
    obtenerProductosLocalStorage() {
        let productoLS;

        //Comprobar si hay algo en LS
        if (localStorage.getItem('productos') === null) {
            productoLS = [];
        }
        else {
            productoLS = JSON.parse(localStorage.getItem('productos'));
        }
        return productoLS;
    }

    //Mostrar los productos guardados en el LS
    leerLocalStorage() {
        let productosLS;
        productosLS = this.obtenerProductosLocalStorage();
        productosLS.forEach(function (producto) {
            //Construir plantilla
            const row = document.createElement('tr');
            row.innerHTML = `
                <td>
                    <img src="${producto.imagen}" width=100>
                </td>
                <td>${producto.titulo}</td>
                <td>${producto.precio}</td>
                <td>
                    <a href="#" class="borrar-producto fas fa-times-circle" data-id="${producto.id}"></a>
                </td>
            `;
            listaProductos.appendChild(row);
        });
    }



    //Mostrar los productos guardados en el LS en compra.html
    leerLocalStorageCompra() {
        let productosLS;

        productosLS = this.obtenerProductosLocalStorage();
        productosLS.forEach(function (producto) {
            const row = document.createElement('tr');
            //let aux = parseFloat(producto.precio) * parseFloat(producto.cantidad);
            row.innerHTML = `
                <td>
                    <img src="${producto.imagen}" width=100>
                </td>
                <td>${producto.titulo}</td>
                <td>${producto.precio}</td>
                <td>
                    <input type="number" class="form-control cantidad" min="1" value=${producto.cantidad}>
                </td>
                <td id='subtotales'>${parseFloat(producto.precio) * parseFloat(producto.cantidad)}</td>
                <td>
                    <a href="#" class="borrar-producto fas fa-times-circle" style="font-size:30px" data-id="${producto.id}"></a>
                </td>
            `;
            listaCompra.appendChild(row);
        });
    }

    //Eliminar producto por ID del LS
    eliminarProductoLocalStorage(productoID) {
        let productosLS;
        //Obtenemos el arreglo de productos
        productosLS = this.obtenerProductosLocalStorage();
        //Comparar el id del producto borrado con LS
        productosLS.forEach(function (productoLS, index) {
            if (productoLS.id === productoID) {
                productosLS.splice(index, 1);
            }
        });

        //Añadimos el arreglo actual al LS
        localStorage.setItem('productos', JSON.stringify(productosLS));
    }

    //Eliminar todos los datos del LS
    vaciarLocalStorage() {
        localStorage.clear();
    }

    //Procesar pedido
    procesarPedido(e) {
        e.preventDefault();

        if (this.obtenerProductosLocalStorage().length === 0) {
            Swal.fire({
                type: 'error',
                title: 'Oops...',
                text: 'El carrito está vacío, agrega algún producto',
                showConfirmButton: false,
                timer: 2000
            })
        }
        else {
            location.href = "compra.html";
        }
    }

    //Calcular montos
    calcularTotal() {
        let productosLS;
        let total = 0, igv = 0, subtotal = 0;
        productosLS = this.obtenerProductosLocalStorage();
        for (let i = 0; i < productosLS.length; i++) {
            let element = Number(parseFloat(productosLS[i].precio) * parseFloat(productosLS[i].cantidad));
            total = total + element;

        }

        igv = parseFloat(total * 0.12).toFixed(2);
        subtotal = parseFloat(total - igv).toFixed(2);

        document.getElementById('subtotal').innerHTML = "$ " + subtotal;
        document.getElementById('igv').innerHTML = "$ " + igv;
        document.getElementById('total').value = "$ " + total.toFixed(2);
    }
    //LEER PARA DETALLE


    leerLocalStorageDetalle() {
        let productosLS;

        productosLS = this.obtenerProductosLocalStorage();
        productosLS.forEach(function (producto) {
            const row = document.createElement('tr');
            //let aux = parseFloat(producto.precio) * parseFloat(producto.cantidad);
            row.innerHTML = `
                
                <td>${producto.titulo}</td>
                
                <td>
                    ${producto.cantidad}
                </td>
                <td id='subtotales'>${parseFloat(producto.precio) * parseFloat(producto.cantidad)}</td>
                
            `;
            listaDetalle.appendChild(row);
        });
    }
    // Datos Final
    leerLocalStorageFinal() {
        this.calcularTotal();
         /*
        let productosLS;
        let total = 0;
        productosLS = this.obtenerProductosLocalStorage();

        for (let i = 0; i < productosLS.length; i++) {
            let element = Number(parseFloat(productosLS[i].precio) * parseFloat(productosLS[i].cantidad));
            total = total + element;

        }
        const row = document.createElement('tr');
        row.innerHTML = `
                <th colspan="4" scope="col" class="text-right">TOTAL :</th>
                <th scope="col">
                    <input id="totalf" name="monto" class="font-weight-bold border-0" readonly style="background-color: white;">${total.toFixed(2}</input>
                </th>
                

        `;
        listaFinal.appendChild(row);
       
        const row = document.createElement('tr');
        row.innerHTML = `
                <td id='total'>${total.toFixed(2)}</td>
                
        `;
        listaFinal.appendChild(row);
        
        document.getElementById('subtotal').innerHTML = "$ " + subtotal;
        document.getElementById('igv').innerHTML = "$ " + igv;
        document.getElementById('total').value = "$ " + total.toFixed(2);
        */

    }

    obtenerEvento(e) {
        e.preventDefault();
        let id, cantidad, producto, productosLS;
        if (e.target.classList.contains('cantidad')) {
            producto = e.target.parentElement.parentElement;
            id = producto.querySelector('a').getAttribute('data-id');
            cantidad = producto.querySelector('input').value;
            let actualizarMontos = document.querySelectorAll('#subtotales');
            productosLS = this.obtenerProductosLocalStorage();
            productosLS.forEach(function (productoLS, index) {
                if (productoLS.id === id) {
                    productoLS.cantidad = parseFloat(cantidad);
                    actualizarMontos[index].innerHTML = Number(parseFloat(cantidad) * parseFloat(productosLS[index].precio));
                }
            });
            localStorage.setItem('productos', JSON.stringify(productosLS));

        }
        else {
            console.log("click afuera");
        }
    }
}