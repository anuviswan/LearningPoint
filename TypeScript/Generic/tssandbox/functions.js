function getSum(num1, num2) {
    return num1 + num2;
}
var getMultiply = function (num1, num2) {
    if (typeof num1 == 'string') {
        num1 = parseInt(num1);
    }
    return num1 * num2;
};
function getName(firstName, lastName) {
    if (lastName == undefined) {
        return firstName;
    }
    return firstName + ' ' + lastName;
}
function myVoid() {
    console.log('void Method');
}
console.log(getSum(2, 5));
console.log(getMultiply(2, 5));
console.log(getMultiply('2', 5));
console.log(getName('jia', 'naina'));
console.log(getName('sreena', 'anu'));
console.log(getName('anu'));
console.log(myVoid());
