class User implements UserInterface{
    name:string;
    email:string;
    age:number;

    constructor(name:string,email:string,age:number){
        this.name = name;
        this.email = email;
        this.age = age;

        console.log('User created: '+ this.name);
    }
    
    register(){
        console.log(this.name + 'is now registered')
    }
}

interface UserInterface{
    name:string;
    email:string;
    age:number;

    register();
}

class Member extends User{
    id:number;

    constructor(id:number,name:string,email:string,age:number){
        super(name,email,age);
        this.id = id;
    }

    register(){
        console.log('calling from child');
        super.register();
    }
}


let jia = new User('Jia','jia.anu@sample.com',4);
console.log(jia.name);
// console.log(jia.email);
console.log(jia.age);
jia.register();

let nikki = new Member(123,'Nikki','Naina.anu@sample.com',0.4);

console.log(nikki.name);
// console.log(jia.email);
console.log(nikki.age);
nikki.register();
