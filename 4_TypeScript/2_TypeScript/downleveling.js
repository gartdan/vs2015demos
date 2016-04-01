var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, Promise, generator) {
    return new Promise(function (resolve, reject) {
        generator = generator.call(thisArg, _arguments);
        function cast(value) { return value instanceof Promise && value.constructor === Promise ? value : new Promise(function (resolve) { resolve(value); }); }
        function onfulfill(value) { try { step("next", value); } catch (e) { reject(e); } }
        function onreject(value) { try { step("throw", value); } catch (e) { reject(e); } }
        function step(verb, value) {
            var result = generator[verb](value);
            result.done ? resolve(result.value) : cast(result.value).then(onfulfill, onreject);
        }
        step("next", void 0);
    });
};
//ES6 only
function* g() {
    for (var i = 0; i < 100; i++) {
        if (i % 2 == 0) {
            yield "hello";
        }
        else {
            yield "world";
        }
    }
}
function oddRawStrings(strs, n1, n2) {
    return strs.raw.filter((raw, index) => index % 2 === 1);
}
oddRawStrings `Hello \n${123} \t ${456}\n world`;
//# sourceMappingURL=downleveling.js.map