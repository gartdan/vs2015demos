class HelloSayer {
    constructor(compiler, framework) {
        if (compiler instanceof HTMLElement) {
            this.compiler = compiler.textContent;
        }
        else {
            this.compiler = compiler;
        }
        this.framework = framework;
    }
    sayHello() {
        this.compiler = document.getElementById("compiler").value;
        this.framework = document.getElementById("framework").value;
        return `Hello from ${this.compiler} and ${this.framework}!`;
    }
}
function sayHello() {
    var sayer = new HelloSayer("Fizz", "Buzz");
    return sayer.sayHello();
}
//# sourceMappingURL=code.js.map