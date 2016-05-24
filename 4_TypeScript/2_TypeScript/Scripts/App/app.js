/// <reference path="..\typings\node.d.ts"/>
"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator.throw(value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : new P(function (resolve) { resolve(result.value); }).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments)).next());
    });
};
import * as fs from "fs";
function readFile(filename) {
    return new Promise((resolve, reject) => {
        fs.readFile(filename, 'utf8', (err, data) => {
            err ? reject(err) : resolve(data);
        });
    });
}
function* getfiles() {
    yield '../node_modules/angular2/bundles/angular2.dev.js';
    yield "/temp/file1.txt";
    yield '../node_modules/angular2/bundles/http.dev.js';
    yield "/temp/file2a.txt";
    yield '../node_modules/angular2/bundles/router.dev.js';
    yield "/temp/file2.txt";
}
function foo(x) {
    if (x) {
        return 10;
    }
    else {
    }
    return 1;
}
function f() {
    return {
        x: "string"
    };
}
new UIElement().animate({ deltaX: 100, deltaY: 150, easing: "ease-out" });
function logWords(filename, text) {
    console.log(`File "${filename}" has ${text.split(' ').length} words`);
}
function run() {
    return __awaiter(this, void 0, void 0, function* () {
        for (let file of getfiles()) {
            try {
                var data = yield readFile(file);
                logWords(file, data);
            }
            catch (err) {
                console.log(`Failed to read file "${file}" with error: ${err}`);
            }
        }
    });
}
run();
function parallel_run() {
    return __awaiter(this, void 0, void 0, function* () {
        var work = [];
        for (let file of getfiles()) {
            let prom = readFile(file).then(data => { logWords(file, data); }, err => { console.log(`Failed to read file "${file}" with error: ${err}`); });
            work.push(prom);
        }
        console.log("Done");
    });
}
//parallel_run();
//# sourceMappingURL=app.js.map