const addToShoppingCartButtons = document.querySelectorAll('.addToCart');
addToShoppingCartButtons.forEach((addToCartButton) => { addToCartButton.addEventListener('click', AnadirProducto); });

const comprarButton = document.querySelector('.comprarButton');
comprarButton.addEventListener('click', comprarButtonClicked);

const shoppingCartItemsContainer = document.querySelector('.shoppingCartItemsContainer');

function AnadirProducto(evento) {
    const boton = evento.target;
    const item = boton.closest('.item');
    const p_tit = item.querySelector('.p-titulo').textContent;
    const p_prec = item.querySelector('.p-producto').textContent;
    const p_ima = item.querySelector('.p-imagen').src;

    AnadirProductoCarrito(p_tit, p_prec, p_ima);
}

function AnadirProductoCarrito(p_tit, p_prec, p_ima) {
    const elementsTitle = shoppingCartItemsContainer.getElementsByClassName('shoppingCartItemTitle');
    for (let i = 0; i < elementsTitle.length; i++) {
        if (elementsTitle[i].innerText === p_tit) {
            let elementQuantity = elementsTitle[i].parentElement.parentElement.parentElement.querySelector('.shoppingCartItemQuantity');
            elementQuantity.value++;
            
            ActualizarCarritoTotal();
            return;
        }
    }

    const Fila_Carrito_Compra = document.createElement('div');
    const Contenido_Carrito_Compra = `
  <div class="row shoppingCartItem">
        <div class="col-6">
            <div class="shopping-cart-item">
                <img src=${p_ima} class="shopping-cart-image">
                <h4 class="shopping-cart-p-producto shoppingCartItemTitle">${p_tit}</h4>
            </div>
        </div>
        <div class="col-2">
            <div class="shopping-cart-price">
                <p class="p-producto shoppingCartItemPrice">${p_prec}</p>
            </div>
        </div>
        <div class="col-4">
            <div class="shopping-cart-quantity">
                <input class="shopping-cart-quantity-input shoppingCartItemQuantity" type="number" value="1">
                <button class="BotonBorrar" type="button">X</button>
            </div>
        </div>
    </div>`;
    Fila_Carrito_Compra.innerHTML = Contenido_Carrito_Compra;
    shoppingCartItemsContainer.append(Fila_Carrito_Compra);
    Fila_Carrito_Compra.querySelector('.BotonBorrar').addEventListener('click', EliminarProductoCarrito);
    Fila_Carrito_Compra.querySelector('.shoppingCartItemQuantity').addEventListener('change', CambiarValor);

    ActualizarCarritoTotal();
}

function ActualizarCarritoTotal() {
    let total = 0;
    const shoppingCartTotal = document.querySelector('.shoppingCartTotal');
    const shoppingCartItems = document.querySelectorAll('.shoppingCartItem');

    shoppingCartItems.forEach((shoppingCartItem) => {
        const shoppingCartItemPriceElement = shoppingCartItem.querySelector('.shoppingCartItemPrice');
        const shoppingCartItemPrice = Number(shoppingCartItemPriceElement.textContent.replace('$', ''));
        const shoppingCartItemQuantityElement = shoppingCartItem.querySelector('.shoppingCartItemQuantity');
        const shoppingCartItemQuantity = Number(shoppingCartItemQuantityElement.value);
        total = total + shoppingCartItemPrice * shoppingCartItemQuantity;
    });
    shoppingCartTotal.innerHTML = `${total.toFixed(2)}$`;
}

function EliminarProductoCarrito(evento) {
    const buttonClicked = evento.target;
    buttonClicked.closest('.shoppingCartItem').remove();
    ActualizarCarritoTotal();
}

function CambiarValor(evento) {
    const input = evento.target;
    input.value <= 0 ? (input.value = 1) : null;
    ActualizarCarritoTotal();
}

function comprarButtonClicked() {
    shoppingCartItemsContainer.innerHTML = '';
    ActualizarCarritoTotal();
}

function enviarFormulario() {

    var vtot = document.getElementById("tot").innerText;
    console.log("tot:" + vtot);

    if (vtot != "0$" && vtot != "0.00$") {

        let email = prompt("Escribe tu correo, para enviarte la factura.");

        if (email != null || email != "") {
            if (confirm("Esta seguro de comprar")) {
                alert("Su compra ya est hecha \nVenga a nuestra sucursal a retirar sus productos \n Muchas Gracias :)");
            } else {
                alert("No se realizo su compra");
            }
        } else {
            alert("No ha seleccionado nada");
        }
    }
}
