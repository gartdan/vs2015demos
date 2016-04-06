/// <reference path="typings/d3/d3.d.ts" />
/// <reference path="typings/jquery/jquery.d.ts" />
Object.defineProperty(window, "MySweetApp", { value: "v1.0.0", writable: false });

function deliveryMethod() {
    // TODO
    return "overnight";
}

function shipWeight() {
    return parseInt($("#weight").text());
}

/*
 * @param {(string | string[])} emailAddr - An email address of array of email addresses
 */
function sendUpdates(emailAddr: (string | string[])) {
    function sendEmail(addr) {
        // Default to standard delivery if empty
        console.log(`Shipping to ${addr} via ${deliveryMethod() || "standard"} delivery`);

        if (shipWeight() > 100) {
            console.log("WARNING: Oversize package");
        }
    }
    // If its an array, loop over it
    if (Array.isArray(emailAddr)) {
        emailAddr.forEach((val, idx) => {
            sendEmail(val.trim());
        });
    } else {
        sendEmail(emailAddr.trim());
    }
}
