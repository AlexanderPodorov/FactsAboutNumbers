$(document).ready(function () {
    $("#ViewFact").click(function () {
        $.ajax({
            url: "api",
            type: "get", 
            data: {
                number: $("#InputNumber").val()
            },
            success: function (response) {
                $("#FactContent").text(response["fact"]);
            },
            error: function () {
                alert("An error occured!");
            }
        });
    });
    $("#AddFact").click(function () {
        $.ajax({
            url: "api",
            type: "post",            
            contentType: "application/json",
            data: JSON.stringify({
                number: $("#InputNumber").val(),
                fact: $("#InputFact").val()
            }),
            success: function () {
                alert('Fact has been added/updated successfully!')
            },
            error: function () {
                alert("An error occured!");
            }
        });
    });
});