function getSum(num1:number,num2:number):number{
    return num1 + num2;
}

let getMultiply = function(num1:any,num2:number):number{
    if(typeof num1 == 'string'){
        num1 = parseInt(num1);
    }
    return num1*num2;
}

function getName(firstName:string,lastName?:string):string{
    if(lastName==undefined){
        return firstName;
    }
    return firstName + ' ' + lastName;
}

function myVoid():void{
    console.log('void Method');
}

console.log(getSum(2,5));
console.log(getMultiply(2,5));
console.log(getMultiply('2',5));
console.log(getName('jia','naina'));
console.log(getName('sreena','anu'));
console.log(getName('anu'));
console.log(myVoid());