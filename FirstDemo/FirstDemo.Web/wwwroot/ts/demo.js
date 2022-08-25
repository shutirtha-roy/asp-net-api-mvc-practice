//Variable declaration
var message = 'Hello World';
var x = 3;
var y = 3.2;
var s = 'test';
var condition = true;
//Array
var numbers = [1, 2, 3, 4, 5, 6];
var fruits = ["apple", "mango", "banana"];
var conditions = [true, false, true];
//Tuple
//Declaring a tuple type
//Correct way to initialize it, we can't initialize without declaring it
var coordinate;
//Initializing it
coordinate = [2, 4];
//Enum
//enum Color {
//    Red,
//    Green,
//    Blue
//}
var Color;
(function (Color) {
    Color[Color["Red"] = 1] = "Red";
    Color[Color["Green"] = 2] = "Green";
    Color[Color["Blue"] = 4] = "Blue";
})(Color || (Color = {}));
var g = Color.Green;
console.log(g);
var colorName = Color[2];
console.log(colorName); //Display according to it value as value of Green is 2
//Any
var notSure = 4;
notSure.ifItExists(); // okay, ifItExists might exist at runtime
notSure.toFixed(); // okay, toFixed exists (but the compiler doesn't check)
//toFixed doesn't work on Objects
notSure = "using a string";
notSure = true;
var anyNumbers = [1, 2, 4, 5];
anyNumbers = ['a', 'v', 'b'];
//# sourceMappingURL=demo.js.map