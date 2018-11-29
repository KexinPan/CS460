//get the id from the url: window.location.href....
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

    function displayData(list) {
        $("#bidIndex dt").remove();
        $("#bidIndex dd").remove();
        // for each item in list, run the function
        $.each(list, function (_i, item) {
            //remove the original one first
            // .remove()
            //windows.onload() load the bids when the page open, don't have to wait 5 seconds first
            //bidIndex += "<dt>Buyer Name:</dt>" + "<dd>" + item.BuyerName + "</dd>" + "<dt> Price:</dt>" + "<dd>" + "$" + item.Price + "</dd>";
            $("#bidIndex").append("<dt>Buyer Name:</dt>" + "<dd>" + item.BuyerName + "</dd>" + "<dt> Price:</dt>" + "<dd>" + "$" + item.Price + "</dd>");
        });
        //$("#bidIndex").html(bidIndex);
    }

    function errorOnAjax() {
        console.log("error");
    }

    var interval = 5000; // where X is your timer interval in X seconds

    window.setInterval(ajax_call, interval);
});

