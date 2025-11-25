//1.Verilmis arrayde tekrarlanan reqemleri silmek ve tekrar reqemlerin sayini gostermek.

let arr = [1, 2, 3, 2, 4, 1, 5];

let counts = {};
let result = [];

for (let num of arr) {
  if (!counts[num]) {
    counts[num] = true;
    result.push(num);   // təkrarsız toplayırıq
  }
}

console.log(result);

//2.Verilmis sozun polindrom olub olmadığını yoxlayan alqoritm yazmaq.

function IsPolinom(polNum) {
  polNum = String(polNum)
  let left = 0
  let right = polNum.length - 1

  while (left < right) {
    if (polNum[left] != polNum[right]) {
      return false
    }
    left++
    right--
  }
  return true;
}


console.log(IsPolinom(122));

//3.Girilen ededin verilmis arreyde nece elementden kicik oldugunu yazan alqoritim.

function IsSmall(num) {
  const arr = [2, 12, 54, 29, 99, 23]
  let count = 0
  arr.forEach(verilmisEded => {
    if (num < verilmisEded) {
      count++
    }

  });
  console.log(`${count} ededden kicikdir`);

}

IsSmall(4)


//4.Daxil edilen ededin Aboundant ve ya Deficient oldugunu yoxlayan algorithm.(Abundant ədəd öz müsbət bolenlerinin(ozunden basqa) cəmi özündən böyük olan müsbət tam ədədlərə deyilir. Eks halda Deficient eded olur. 12-Aboundant, 13- Deficient)

function CheckNum(num) {
  let sum = 0;
  for (let i = 1; i < num; i++) {
    if (num % i == 0) {
      sum += i
    }
  }
  console.log(sum);
  if (sum < num) {
    console.log("Deficient");
  } else if (sum > num) {
    console.log("Aboundant");

  } else {
    console.log("Perfect num");
  }
}

CheckNum(12)

//5.Array-in bütün elementlərini kvadrata yüksəldib yeni array qaytaran funksiya yazın.

function Square(arr) {
  let newarr = []
  arr.forEach(element => {
    newarr.push(element ** 2)
  });
  console.log(newarr);
}
Square([1, 2, 3, 4, 5])

