(function (factory) {
    if (typeof module === 'object' && typeof module.exports === 'object') {
        var v = factory(require, exports); if (v !== undefined) module.exports = v;
    }
    else if (typeof define === 'function' && define.amd) {
        define(["require", "exports"], factory);
    }
})(function (require, exports) {
    "use strict";
    var BasicCalculator = (function () {
        function BasicCalculator(value) {
            if (value === void 0) { value = 0; }
            this.value = value;
        }
        BasicCalculator.prototype.currentValue = function () {
            return this.value;
        };
        BasicCalculator.prototype.add = function (operand) {
            this.value += operand;
            return this;
        };
        BasicCalculator.prototype.subtract = function (operand) {
            this.value -= operand;
            return this;
        };
        BasicCalculator.prototype.multiply = function (operand) {
            this.value *= operand;
            return this;
        };
        BasicCalculator.prototype.divide = function (operand) {
            this.value /= operand;
            return this;
        };
        return BasicCalculator;
    }());
    Object.defineProperty(exports, "__esModule", { value: true });
    exports.default = BasicCalculator;
});
//# sourceMappingURL=basiccalculator.js.map