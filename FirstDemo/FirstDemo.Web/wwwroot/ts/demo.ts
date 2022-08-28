//Variable declaration
let message: string = 'Hello World';
let x: number = 3;
let y: number = 3.2;
let s: string = 'test';
let condition: boolean = true;

//Array
let numbers: number[] = [1, 2, 3, 4, 5, 6];
let fruits: string[] = ["apple", "mango", "banana"];
let conditions: boolean[] = [true, false, true];

//Tuple
//Declaring a tuple type
//Correct way to initialize it, we can't initialize without declaring it
let coordinate: [number, number];
//Initializing it
coordinate = [2, 4];
console.log(coordinate[0]);
//Enum
//enum Color {
//    Red,
//    Green,
//    Blue
//}

enum Color {
    Red = 1,
    Green = 2,
    Blue = 4
}

let g: Color = Color.Green;
console.log(g);

let colorName: string = Color[2];
console.log(colorName); //Display according to it value as value of Green is 2

//Any
let notSure: any = 4;
notSure.ifItExists(); // okay, ifItExists might exist at runtime
notSure.toFixed(); // okay, toFixed exists (but the compiler doesn't check)
//toFixed doesn't work on Objects
notSure = "using a string";
notSure = true;
let anyNumbers: any[] = [1, 2, 4, 5];
anyNumbers = ['a', 'v', 'b'];

//Void
function warnUser(): void {
    console.log("Let the person know!");
}

let unusable: void = undefined;
unusable = null;

//Null
let u: undefined = undefined;
let n: null = null;

//Never
function error(message: string): never {
    throw new Error(message);
}

function fail(): never {
    return error("Something failed")
}

function infiniteLoop(): never {
    while (true) {

    }
}

//object
declare function create(o: object | null): void;
create({ prop: 0 });
create(null);

let p: object = { name: "roy" }


//Type assertion
let someValue: string = "this is a string";
let strLength: number = (<string>someValue).length;


//Classes
class Greeter {
    greeting: string;

    constructor(message: string) {
        this.greeting = message;
    }
    greet() {
        return "Hello, " + this.greeting;
    }
}

let greeter = new Greeter("world");


//Interface
//Works like a method
function printLabel(labeledObj: { label: string }) {
    console.log(labeledObj.label);
}

let myObj = { size: 10, label: "Size 10 Object" };
printLabel(myObj);

//Works like C# interface.
interface LabeledValue {
    label: string;
}

function printLabel1(labelObj: LabeledValue) {
    console.log(labelObj.label);
}

let myObj1 = { size: 10, label: "Size 10 Object" };
printLabel(myObj1);

interface IPerson {
    name: string;
    gender: string;
}

//interface IEmployee extends IPerson {
//    empCode: number;
//}

//let empObj: IEmployee = {
//    empCode: 1,
//    name: "Bill",
//    gender: "Male"
//}

interface IEmployee {
    empCode: number;
    name: string;
    getSalary: (n: number) => number;
}

class Employee implements IEmployee {
    empCode: number;
    name: string;

    constructor(code: number, name: string) {
        this.empCode = code;
        this.name = name;
    }
    getSalary(empCode: number): number {
        return 2000;
    }
}

let emp = new Employee(1, "Roy");


//Inheritance
//class Animal {
//    move(distanceInMeters: number = 0) {
//        console.log(`Animal move ${distanceInMeters}m.`);
//    }
//}

//class Dog extends Animal {
//    bark() {
//        console.log("Woof! Woof!");
//    }
//

//const dog = new Dog();
//dog.bark();
//dog.move(10);
//dog.bark();

class Animal {
    name: string;
    constructor(theName: string) {
        this.name = theName;
    }
    move(distanceInMeters: number = 0) {
        console.log(`${this.name} moved ${distanceInMeters}m.`);
    }
}

class Snake extends Animal {
    constructor(name: string) {
        super(name);
    }
    move(distanceInMeters = 5) {
        console.log("Slithering...");
        super.move(distanceInMeters);
    }
}

class Horse extends Animal {
    constructor(name: string) {
        super(name);
    }
    move(distanceInMeters = 45) {
        console.log("Galloping...");
        super.move(distanceInMeters);
    }
}

let sam: Snake = new Snake("Sammy the Pyrhon");
let tom: Animal = new Horse("Tommy the Palomino");
sam.move();
tom.move();