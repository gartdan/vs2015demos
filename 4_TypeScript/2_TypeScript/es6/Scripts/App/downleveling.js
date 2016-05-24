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