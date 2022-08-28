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
console.log(coordinate[0]);
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
//Void
function warnUser() {
    console.log("Let the person know!");
}
var unusable = undefined;
unusable = null;
//Null
var u = undefined;
var n = null;
//Never
function error(message) {
    throw new Error(message);
}
function fail() {
    return error("Something failed");
}
function infiniteLoop() {
    while (true) {
    }
}
create({ prop: 0 });
create(null);
var p = { name: "roy" };
//Type assertion
var someValue = "this is a string";
var strLength = someValue.length;
//Classes
var Greeter = /** @class */ (function () {
    function Greeter(message) {
        this.greeting = message;
    }
    Greeter.prototype.greet = function () {
        return "Hello, " + this.greeting;
    };
    return Greeter;
}());
var greeter = new Greeter("world");
//Interface
//Works like a method
function printLabel(labeledObj) {
    console.log(labeledObj.label);
}
var myObj = { size: 10, label: "Size 10 Object" };
printLabel(myObj);
function printLabel1(labelObj) {
    console.log(labelObj.label);
}
var myObj1 = { size: 10, label: "Size 10 Object" };
printLabel(myObj1);
var Employee = /** @class */ (function () {
    function Employee(code, name) {
        this.empCode = code;
        this.name = name;
    }
    Employee.prototype.getSalary = function (empCode) {
        return 2000;
    };
    return Employee;
}());
var emp = new Employee(1, "Roy");
//# sourceMappingURL=demo.js.map