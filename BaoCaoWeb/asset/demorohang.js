const btn= document.querySelectorAll("button")
//console.log(btn)
btn.forEach(function(button,index)){
button.addEventlistener("click",function(event){{
    var btnItem = event.target
    var product = btnItem.parentElement
    var productImg= product.querySelector("img").src  
    var productName= product.querySelector("H1").innerText
    var productPrice=product.querySelector("span").innerText
    addcart(productPrice,producImg,productName)
}})
})
function addcart(productPrice,productImg,productName){
    var addtr= document.createElement("tr")
    var trcontent='<tr><td style="display:flex; align-items:center" ><img style="width:70px" src="https://thieuhoa.com.vn/wp-content/uploads/2021/11/05f475c52e80e7cbbc5c62205cadfdda.jpg" alt=""/> Iphon6 </td><td><span>120.000</span><sup>đ</sup></td><td><input style="width:30px; outline:none" type="number" value="1" min="1" /></td><td style="cursor:pointer">Xóa</td></tr><tr><td style="display:flex; align-items:center" ><img style="width:70px" src="https://leanhtien.net/wp-content/uploads/2021/01/164.jpg" alt=""/> Iphon6 </td><td><span>294.000</span><sup>đ</sup></td><td><input style="width:30px; outline:none" type="number" value="1" min="1" /></td><td style="cursor:pointer">Xóa</td></tr>'
    addtr.innerHTML=trcontent
    var cartable=document.querySeclector("tbody")
    cartTable.append(addtr)
}