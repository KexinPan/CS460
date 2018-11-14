// set broing words and if the input is in it, just output it
var boringWords = ["I", "I'm", "my", "go", "going", "to", "and", "it", "where", "me", "we", "us", "those","you", "she", "he", "that", "which", "who","whom", "whose", "is", "neither", "but"];

$("#InputBox").bind("keypress", function (e) {

    if (e.key === ' ') {
        var value = $("#InputBox").val();
        var valueSpace = value.split(" ");
        var data = valueSpace[valueSpace.length - 1];
        var flag = false;
        for (var i = 0; i < boringWords.length; i++) {

            if (boringWords[i].toUpperCase() === data.toUpperCase()) {
               flag = true;
            }
        }
        if (flag) {
            $("#Image").append("<label>" + data + "&nbsp;</label></div>");
        }
        else {
            ajaxFuc(data);
        }
    }
});

// if not boring word, translate it through apiFunc
function ajaxFuc(data) {

        var source = "/Translate/TransLang/" + data;
        console.log(source);

        // Send an async request to our server, requesting JSON back
        $.ajax({
            type: "GET",
            dataType: "json",
            url: source,
            success: displayData,
            error: errorOnAjax
        });
    }

// Display the data that we've retrieved
function displayData(giphyData) {

    var imageUrl = giphyData.data.images.original_still.url;

    $("#Image").append("<img src='" + imageUrl + "' style='width:100px;height:100px; margin:15px;'/>");
}

function errorOnAjax() {
    console.log("error");
}

function clear() {
    $("InputBox").empty();
}
