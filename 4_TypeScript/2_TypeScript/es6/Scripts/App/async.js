"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator.throw(value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : new P(function (resolve) { resolve(result.value); }).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments)).next());
    });
};
// printDelayed is a 'Promise<void>'
//async await
function printDelayed(elements) {
    return __awaiter(this, void 0, void 0, function* () {
        for (const element of elements) {
            yield delay(2000);
            console.log(element);
        }
    });
}
function delay(milliseconds) {
    return __awaiter(this, void 0, void 0, function* () {
        return new Promise(resolve => {
            setTimeout(resolve, milliseconds);
        });
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
//# sourceMappingURL=async.js.map