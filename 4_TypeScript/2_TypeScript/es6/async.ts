"use strict";

// printDelayed is a 'Promise<void>'

//async await
async function printDelayed(elements: string[] | IterableIterator<string>) {
    for (const element of elements) {
        await delay(2000);
        console.log(element);
    }
}

async function delay(milliseconds: number) {
    return new Promise<void>(resolve => {
        setTimeout(resolve, milliseconds);
    });
}

printDelayed(getWords()).then(() => {
    console.log();
    console.log("Printed every element!");
    //template strings
    var name = "TypeScript";
    var greeting = `Hello, ${name}! Your name has ${name.length} characters`;
});


//generators
function* getWords() {
    yield 'Hello';
    yield "Beautiful";
    yield 'Asynchronous';
    yield "World!";

}




function logWords(filename, text) {
    console.log(`File "${filename}" has ${text.split(' ').length} words`);
}

