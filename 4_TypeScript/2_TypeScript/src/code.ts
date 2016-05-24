
class HelloSayer {
    private compiler: string;
    private framework: string;


    constructor(compiler: (string | HTMLElement), framework: string) {
        if (compiler instanceof HTMLElement) {
            this.compiler = compiler.textContent;
        } else {
            this.compiler = compiler;
        }
        
        this.framework = framework;
    }

    sayHello(): string {
        this.compiler = (document.getElementById("compiler") as HTMLInputElement).value;
        this.framework = (document.getElementById("framework") as HTMLInputElement).value;
        return `Hello from ${this.compiler} and ${this.framework}!`;
    }
}

function sayHello() {
    var sayer = new HelloSayer("Fizz", "Buzz");
    sayer.sayHello();
}