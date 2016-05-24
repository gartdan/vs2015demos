/// <reference path="..\typings\node.d.ts"/>


"use strict";

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

function foo(x: boolean) {
    if (x) {
        return 10;
    } else {
        //throw new Error();
    }
    return 1;
}

function f() {
    return {
        x: "string"
    }
}

declare class UIElement {
    animate(options: AnimationOptions): void;
}

interface AnimationOptions {
    deltaX: number;
    deltaY: number;
    easing: "ease-in" | "ease-out" | "ease-in-outerHeight";
}

new UIElement().animate({ deltaX: 100, deltaY: 150, easing: "ease-out"});

function logWords(filename, text) {
    console.log(`File "${filename}" has ${text.split(' ').length} words`);
}

async function run() {
    for (let file of getfiles()) {
        try {
            var data = await readFile(file);
            logWords(file, data);
        }
        catch (err) {
            console.log(`Failed to read file "${file}" with error: ${err}`);
        }
    }
}

run();

async function parallel_run() {
    var work = [];
    for (let file of getfiles()) {
        let prom = readFile(file).then(
            data => { logWords(file, data) },
            err => { console.log(`Failed to read file "${file}" with error: ${err}`); }
        );
        work.push(prom);
    }
    console.log("Done");
}

//parallel_run();
