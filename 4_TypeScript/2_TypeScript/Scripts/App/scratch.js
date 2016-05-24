Object.defineProperty(window, "MySweetApp", { value: "v1.0.0", writable: false });
function deliveryMethod() {
    // TODO
    return "overnight";
}
function shipWeight() {
    return parseInt(document.getElementById('weight').textContent);
}
/*
 * @param {(string | string[])} emailAddr - An email address of array of email addresses
 */
function sendUpdates(emailAddr) {
    function sendEmail(addr) {
        // Default to standard delivery if empty
        console.log("Shipping to " + addr + " via " + (deliveryMethod() || "standard") + " delivery");
        if (shipWeight() > 100) {
            console.log("WARNING: Oversize package");
        }
    }
    // If its an array, loop over it
    if (Array.isArray(emailAddr)) {
        emailAddr.forEach(function (val, idx) {
            sendEmail(val.trim());
        });
    }
    else {
        sendEmail(emailAddr.trim());
    }
}
//# sourceMappingURL=scratch.js.map