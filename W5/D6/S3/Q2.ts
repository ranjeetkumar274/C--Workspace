script.ts
 
document.addEventListener('DOMContentLoaded', ()=>{
    const productButtons = document.querySelectorAll('.product button');
    const cart = document.querySelector('.cart') as HTMLDivElement;
 
    productButtons.forEach((button, index) =>{
        button.addEventListener('click', ()=>{
            const existingCartItem =cart.querySelector(`.cart-item[data-product-id="${index}"]`)
        if(existingCartItem){
            const quantityElement = existingCartItem.querySelector(`.quantity`) as HTMLSpanElement;
            const quantity = parseInt(quantityElement.textContent?.split(' ')[1] || '1', 10);
            quantityElement.textContent = `x ${quantity + 1}`;
        }
        else{
            const cartItem = document.createElement('div');
            cartItem.classList.add('cart-item');
            cartItem.setAttribute('data-product-id', index.toString());
            cartItem.innerHTML = `
            <span>Product ${index +1}</span>
            <span class="quantity">x 1</span>
            <button class="remove">Remove</button>
            `;
            cart.appendChild(cartItem);
            const removeButton = cartItem.querySelector('.remove') as HTMLButtonElement;
            removeButton.addEventListener('click', ()=>{
                cart.removeChild(cartItem);
            });
        }
    });
});
});
 
html
 
<!DOCTYPE html>
<html>
<head>
   
</head>
<body>
    //write your code here
    <div class="product-list">
        <div class="product">
            <p>Product 1</p>
            <button>Add to Cart</button>
        </div>
        <div class="product">
            <p>Product 2</p>
            <button>Add to Cart</button>
        </div>
        <div class="product">
            <p>Product 3</p>
            <button>Add to Cart</button>
        </div>
    </div>
    <div class="cart">
        <!-- Cart items will be added here-->
    </div>
    <script src="script.js"></script>
</body>
</html>
 
 
 
 
