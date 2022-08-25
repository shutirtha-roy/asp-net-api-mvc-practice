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
