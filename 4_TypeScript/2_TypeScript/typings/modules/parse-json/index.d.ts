// Generated by typings
// Source: https://raw.githubusercontent.com/typed-typings/npm-parse-json/74152f9c8b831227fc4eb3533fcd01b8906e2694/index.d.ts
declare module '~parse-json/index' {
function parseJson (contents: string, reviver?: Function, filename?: string): any;

export = parseJson;
}
declare module 'parse-json/index' {
import alias = require('~parse-json/index');
export = alias;
}
declare module 'parse-json' {
import alias = require('~parse-json/index');
export = alias;
}
