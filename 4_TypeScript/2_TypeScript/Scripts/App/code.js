var HelloSayer = (function () {
    function HelloSayer(compiler, framework) {
        if (compiler instanceof HTMLElement) {
            this.compiler = compiler.textContent;
        }
        else {
            this.compiler = compiler;
        }
        this.framework = framework;
    }
    HelloSayer.prototype.sayHello = function () {
        this.compiler = document.getElementById("compiler").value;
        this.framework = document.getElementById("framework").value;
        return "Hello from " + this.compiler + " and " + this.framework + "!";
    };
    return HelloSayer;
}());
function sayHello() {
    var sayer = new HelloSayer("Fizz", "Buzz");
    sayer.sayHello();
}
//# sourceMappingURL=code.js.map