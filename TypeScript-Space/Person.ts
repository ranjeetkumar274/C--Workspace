
class Person{
    public Name : string;
    public Age : number;

    constructor(Name : string, Age : number){
        this.Name = Name;
        this.Age = Age;
    }

    greet() : string{
        return `Hello ${this.Name}, You are ${this.Age}`;
    }
}

const p1 = new Person("Ashu",23);
const p2 = new Person("Hrithik",67);

console.log(p1.greet());
console.log(p2.greet());



