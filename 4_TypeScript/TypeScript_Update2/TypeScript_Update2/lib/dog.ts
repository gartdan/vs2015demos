export class Dog {
    element: HTMLElement;

    constructor(el: HTMLElement) {
        this.element = el;
    }

    Bark() {
        this.element.innerHTML = "Woof!";
    }

    BarkLoudly() {
        this.element.innerHTML = "<b>Woof!</b>";
    }

}