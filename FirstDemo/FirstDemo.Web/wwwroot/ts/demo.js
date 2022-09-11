var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        if (typeof b !== "function" && b !== null)
            throw new TypeError("Class extends value " + String(b) + " is not a constructor or null");
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
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
var Animal = /** @class */ (function () {
    function Animal(theName) {
        this.name = theName;
    }
    Animal.prototype.move = function (distanceInMeters) {
        if (distanceInMeters === void 0) { distanceInMeters = 0; }
        console.log("".concat(this.name, " moved ").concat(distanceInMeters, "m."));
    };
    return Animal;
}());
var Snake = /** @class */ (function (_super) {
    __extends(Snake, _super);
    function Snake(name) {
        return _super.call(this, name) || this;
    }
    Snake.prototype.move = function (distanceInMeters) {
        if (distanceInMeters === void 0) { distanceInMeters = 5; }
        console.log("Slithering...");
        _super.prototype.move.call(this, distanceInMeters);
    };
    return Snake;
}(Animal));
var Horse = /** @class */ (function (_super) {
    __extends(Horse, _super);
    function Horse(name) {
        return _super.call(this, name) || this;
    }
    Horse.prototype.move = function (distanceInMeters) {
        if (distanceInMeters === void 0) { distanceInMeters = 45; }
        console.log("Galloping...");
        _super.prototype.move.call(this, distanceInMeters);
    };
    return Horse;
}(Animal));
var sam = new Snake("Sammy the Pyrhon");
var tom = new Horse("Tommy the Palomino");
sam.move();
tom.move();
//# sourceMappingURL=demo.js.map