// NOTE

// Nan test

let num1 = document.querySelector(".num1")
let num2 = document.querySelector(".num2")

num1.addEventListener("keydown", evt => ["e", "E", "+", "-"].includes(evt.key) ? (alert("invalid number"), evt.preventDefault()) : null);
num2.addEventListener("keydown", evt => ["e", "E", "+", "-"].includes(evt.key) ? (alert("invalid number"), evt.preventDefault()) : null);



let result = document.querySelector(".result")

let minusBtn = document.querySelector(".minus")
let devideBtn = document.querySelector(".devide")
let multBtn = document.querySelector(".mult")
let sumBtn = document.querySelector(".sum")
let clearBtn = document.querySelector(".clear")

minusBtn.addEventListener("click", Minus)
devideBtn.addEventListener("click", Devide)
multBtn.addEventListener("click", Multi)
sumBtn.addEventListener("click", Sum)
clearBtn.addEventListener("click", Clear)



function CheckValue() {
    if (num1.value == "" || num2.value == "") {
        alert("Please enter number")
        return false
    }
    return true
}

function Minus() {
    if (CheckValue()) {
        result.textContent = Number(num1.value) - Number(num2.value)
    }
}
function Devide() {
    if (CheckValue()) {
        if (num2.value == 0) {
            alert("cant divide by 0")
            return;
        }
        result.textContent = Number(num1.value) / Number(num2.value)

    }
} function Multi() {
    if (CheckValue()) {
        result.textContent = Number(num1.value) * Number(num2.value)
    }
} function Sum() {
    if (CheckValue()) {
        result.textContent = Number(num1.value) + Number(num2.value)
    }
} function Clear() {

    num1.value = ""
    num2.value = ""
    result.textContent = 0
}