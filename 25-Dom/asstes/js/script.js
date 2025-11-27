let card = document.createElement("div")
card.style.display = 'flex'
card.style.flexDirection = "column"
card.style.backgroundColor = "#f5f5f5";
card.style.width = "520px";
card.style.padding = "15px";
card.style.borderRadius = "10px";
card.style.boxShadow = "0 4px 10px rgba(0,0,0,0.1)";
card.style.margin = "20px auto";
card.style.justifyContent = "center"
card.style.alignItems = "center"
card.style.position = "relative"



let image = document.createElement("div")
image.style.display = "flex"
image.style.position = "relative"

let image_icon = document.createElement('i')
image_icon.classList.add("fa-regular", "fa-heart")
image_icon.style.position = "absolute"
image_icon.style.right = '0'
image_icon.style.color = "white"
image_icon.style.margin = "10px "
image_icon.style.fontSize = '30px'

let photo = document.createElement('img')
photo.src = "asstes/images/istockphoto-1987630154-612x612.jpg"
photo.style.width = "500px";
photo.style.height = "400px";

//
let house_name = document.createElement('p')
house_name.textContent = "DETACHED HOUSE • 5Y OLD"
house_name.style.color = "darkgray"
house_name.style.marginLeft = "10px"
house_name.style.alignSelf = "flex-start";
house_name.style.fontWeight = 'bold';


//
let house_cost = document.createElement('b')
house_cost.textContent = "$750.000"
house_cost.style.color = "black"
house_cost.style.marginLeft = "10px"
house_cost.style.alignSelf = "flex-start";
house_cost.style.fontSize = '45PX'

//
let house_adress = document.createElement('p')
house_adress.textContent = "742 Evergreen Terrace"
house_adress.style.color = "gray"
house_adress.style.marginLeft = "10px"
house_adress.style.alignSelf = "flex-start";
house_cost.style.fontSize = '35PX'

//
let center = document.createElement('div')
center.style.display = "flex";
center.style.justifyContent = "space-between";
center.style.border = "2px solid #e7e5e5ff";
center.style.padding = "10px";
center.style.width = "100%";
center.style.fontSize = "30px"
//
let bed = document.createElement('div')
bed.style.display = "flex";
bed.style.alignItems = "center";
bed.style.gap = "5px";

let bed_icon = document.createElement('i')
bed_icon.style.color = "gray"
bed_icon.classList.add("fa-solid", "fa-bed")

let bed_count = document.createElement('b')
bed_count.textContent = "3"



let bed_text = document.createElement('p')
bed_text.textContent = "Bedrooms"

//

//
let bath = document.createElement('div')
bath.style.display = "flex";
bath.style.alignItems = "center";
bath.style.gap = "5px";


let bath_icon = document.createElement('i')
bath_icon.style.color = "gray"
bath_icon.classList.add("fa-solid", "fa-bath")

let bath_count = document.createElement('b')
bath_count.textContent = "2"

let bath_text = document.createElement('p')
bath_text.textContent = "Bathrooms"
////




//
let realtor = document.createElement('p')
//
realtor.textContent = "REALTOR"
realtor.style.alignSelf = "flex-start";
realtor.style.color = "gray"

//
let contact = document.createElement('div')
contact.style.display = "flex";
contact.style.padding = "10px";
contact.style.width = "100%";
contact.style.fontSize = "23px"
contact.style.textAlign = "center"

let contact_photo = document.createElement('img')
contact_photo.src = "/asstes/images/groupphoto.jpeg"
contact_photo.style.width = "80px";
contact_photo.style.height = "80px";
contact_photo.style.objectFit = "cover";
contact_photo.style.borderRadius = "50%";

//
let contact_text = document.createElement('div')
contact_text.style.marginLeft = '30px'
let fullName = document.createElement('b')
fullName.textContent = "Ilham Huseynov"
let number = document.createElement('p')
number.textContent = "+9940105150132"
////


image.append(image_icon, photo)//

bed.append(bed_icon, bed_count, bed_text)
bath.append(bath_icon, bath_count, bath_text)

center.append(bed, bath)//

contact_text.append(fullName, number)

contact.append(contact_photo, contact_text)//


card.append(image, house_name, house_cost, house_adress, center, realtor, contact)

let body = document.querySelector("body")
body.append(card) 