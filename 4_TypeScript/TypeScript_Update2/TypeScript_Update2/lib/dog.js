(function (factory) {
    if (typeof module === 'object' && typeof module.exports === 'object') {
        var v = factory(require, exports); if (v !== undefined) module.exports = v;
    }
    else if (typeof define === 'function' && define.amd) {
        define(["require", "exports"], factory);
    }
})(function (require, exports) {
    "use strict";
    var Dog = (function () {
        function Dog(el) {
            this.element = el;
        }
        Dog.prototype.Bark = function () {
            this.element.innerHTML = "Woof!";
        };
        Dog.prototype.BarkLoudly = function () {
            this.element.innerHTML = "<b>Woof!</b>";
        };
        return Dog;
    }());
    exports.Dog = Dog;
});
//# sourceMappingURL=dog.js.map