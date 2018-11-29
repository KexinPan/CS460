console.log("in js file");
var id = window.location.href.split("/").slice(-1)[0];
$(document).ready(function () {

    var source = "/Bids/Details/" + id;

    var ajax_call = function () {
        $.ajax({
            type: "GET",
            dataType: "json",
            url: source,
            success: displayData,
            error: errorOnAjax
        });
    };

    var interval = 5000; // where X is your timer interval in X seconds

    window.setInterval(ajax_call, interval);

    function displayData(list) {
        $("#bidIndex dt").remove();
        $("#bidIndex dd").remove();
        // for each item in list, run the function
        $.each(list, function (_i,item) {
            $("#bidIndex").append("<dt>Buyer Name:</dt>" + "<dd>" + item.BuyerName + "</dd>" + "<dt> Price:</dt>" + "<dd>" + "$" + item.Price + "</dd>");
        });
    }

    function errorOnAjax() {
        console.log("error");
    }
});

