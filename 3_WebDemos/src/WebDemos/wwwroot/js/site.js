// Write your Javascript code.
var foo = {
    bar: "baz",
    qux: "quux",   /*error Unexpected trailing comma.*/
};

var arr = [1, 2, ];  /*error Unexpected trailing comma.*/

if (foo.bar == "baz") {
    doSomething("lets", "do", "this");
}

var customer = {
    FirstName: "Dan",
    LastName: "Gartner",
    City: "Chicago",
    State: "IL",
    "City": "Hinsdale"
}

function doSomething(a, b, c)
{
    var isSomething = true;
    if(!isSomething) 
    {
        console.trace("Doing something");
    }
}

var colors = ["red", , "blue"];
