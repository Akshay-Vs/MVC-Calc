$(document).ready(function () {

    const operation = [""];

    $("#sin").click(function () {
        operation.push("s");
        operation.push("i");
        operation.push("n");
        $("#display-primary").text(formate(operation));
    });

    $("#cos").click(function () {
        operation.push("c");
        operation.push("o");
        operation.push("s");
        $("#display-primary").text(formate(operation));
    });

    $("#tan").click(function () {
        operation.push("t");
        operation.push("a");
        operation.push("n");

        $("#display-primary").text(formate(operation));
    });

    $("#log").click(function () {
        operation.push("l");
        operation.push("o");
        operation.push("g");

        $("#display-primary").text(formate(operation));
    });

    $("#1").click(function () {
        operation.push("1");

        $("#display-primary").text(formate(operation));
    });

    $("#2").click(function () {
        operation.push("2");

        $("#display-primary").text(formate(operation));
    });

    $("#3").click(function () {
        operation.push("3");

        $("#display-primary").text(formate(operation));
    });

    $("#4").click(function () {
        operation.push("4");

        $("#display-primary").text(formate(operation));
    });

    $("#5").click(function () {
        operation.push("5");

        $("#display-primary").text(formate(operation));
    });

    $("#6").click(function () {
        operation.push("6");

        $("#display-primary").text(formate(operation));
    });

    $("#7").click(function () {
        operation.push("7");

        $("#display-primary").text(formate(operation));
    });

    $("#8").click(function () {
        operation.push("8");

        $("#display-primary").text(formate(operation));
    });

    $("#9").click(function () {
        operation.push("9");

        $("#display-primary").text(formate(operation));
    });

    $("#0").click(function () {
        operation.push("0");

        $("#display-primary").text(formate(operation));
    });

    $("#dot").click(function () {
        operation.push(".");

        $("#display-primary").text(formate(operation));
    });

    $("#coma").click(function () {
        operation.push(",");

        $("#display-primary").text(formate(operation));
    });

    $("#add").click(function () {
        operation.push("+");

        $("#display-primary").text(formate(operation));
    });

    $("#sub").click(function () {
        operation.push("-");

        $("#display-primary").text(formate(operation));
    });

    $("#mul").click(function () {
        operation.push("*");

        $("#display-primary").text(formate(operation));
    });

    $("#div").click(function () {
        operation.push("/");

        $("#display-primary").text(formate(operation));
    });

    $("#ac").click(function () {
        while (operation.length > 0) operation.pop();
        $("#display-primary").text(formate(operation));
        $("#display-secondary").text("= 0000000");
    });

    $("#del").click(function () {
        operation.pop();
        $("#display-primary").text(formate(operation));
    })

    $("#eq").click(function () {

        console.log("Equal button pressed");
        console.log(pack(operation));

        //ajax get request to controller
        $.ajax({
            url: "/Calc/Calculate",
            type: "GET",
            data: { operation: pack(operation) },
            success: function (result) {
                $("#display-secondary").text("= "+formate(result, max=10));
            },
            error: function (error) {
                console.log(error);
                $("#display-secondary").text("Error");
            }
        });
    })

    function formate(str, max=12) {

        let operationText = "", min = 0;
        if (str.length >= max) min = str.length - max;

        for (let i = min; i < str.length; i++) {
            operationText += str[i];
            console.log("formate");
        }
        return operationText;
    }
    
    function pack(data) {
        var payload = "";
        console.log("Payload data: " + data);
        data.forEach(function (item, index)
        {
            payload += item;
            console.log(payload);
        });
    return payload;

    }

});