const compra = new Carrito();
const listaCompra = document.querySelector("#lista-compra tbody");
const listaFinal = document.querySelector("#lista-final tbody");
const listaDetalle = document.querySelector("#lista-detalle tbody");
const carrito = document.getElementById('carrito');
const btnelim = document.getElementById('btnelim');
const procesarCompraBtn = document.getElementById('procesar-compra');
const procesarCom = document.getElementById('procompra');
const cliente = document.getElementById('cliente');
const correo = document.getElementById('correo');


cargarEventos();

function cargarEventos() {
    if (listaCompra != null) {
        document.addEventListener('DOMContentLoaded', compra.leerLocalStorageCompra());

        //document.addEventListener('DOMContentLoaded', compra.leerLocalStorageFinal());
        //Eliminar productos del carrito
        carrito.addEventListener('click', (e) => { compra.eliminarProducto(e) });

        compra.calcularTotal();

        //cuando se selecciona procesar Compra
        //procesarCompraBtn.addEventListener('click', procesarCompra);
        //procesarCom.addEventListener('click', vaciar());
        carrito.addEventListener('change', (e) => { compra.obtenerEvento(e) });
        carrito.addEventListener('keyup', (e) => { compra.obtenerEvento(e) });
    } else if (listaFinal != null) {
        document.addEventListener('DOMContentLoaded', compra.leerLocalStorageFinal());
        btnelim.addEventListener('click', (e) => { compra.vaciarLocalStorage(e) })
    }
    document.addEventListener('DOMContentLoaded', compra.leerLocalStorageDetalle());
    compra.calcularTotal();
    


}
function vaciar() {
    compra.vaciarLocalStorage();
    
}

function ocultar() {
    var x = document.getElementById("myDIV");
    if (x.style.display === "none") {
        x.style.display = "block";
    } else {
        x.style.display = "none";
    }
    var x = document.getElementById("myDIV1");
    if (x.style.display === "none") {
        x.style.display = "block";
    } else {
        x.style.display = "none";
    }
}

function procesarCompra() {
    // e.preventDefault();
    if (compra.obtenerProductosLocalStorage().length === 0) {
        Swal.fire({
            type: 'error',
            title: 'Oops...',
            text: 'No hay productos, selecciona alguno',
            showConfirmButton: false,
            timer: 2000
        }).then(function () {
            window.location = "index.html";
        })
    }
    else if (cliente.value === '' || correo.value === '') {
        Swal.fire({
            type: 'error',
            title: 'Oops...',
            text: 'Ingrese todos los campos requeridos',
            showConfirmButton: false,
            timer: 2000
        })
    }
    else {
        
        //aqui se coloca el user id generado en el emailJS
        (function () {
            emailjs.init("user_CEozz2F39lJJOLF5mJiDA");
        })();

        var myform = $("form#procesar-pago");

        myform.submit( (event) => {
            event.preventDefault();

            // Change to your service ID, or keep using the default service
            var service_id = "default_service";
            var template_id = "template_3SA9LsqQ";

            const cargandoGif = document.querySelector('#cargando');
            cargandoGif.style.display = 'block';

            const enviado = document.createElement('img');
            enviado.src = 'img/mail.gif';
            enviado.style.display = 'block';
            enviado.width = '150';

            emailjs.sendForm(service_id, template_id, myform[0])
                .then(() => {
                    cargandoGif.style.display = 'none';
                    document.querySelector('#loaders').appendChild(enviado);

                    setTimeout(() => {
                        compra.vaciarLocalStorage();
                        enviado.remove();
                        window.location = "index.html";
                    }, 2000);


                }, (err) => {
                    alert("Error al enviar el email\r\n Response:\n " + JSON.stringify(err));
                    // myform.find("button").text("Send");
                });

            return false;

        });

    }
}

