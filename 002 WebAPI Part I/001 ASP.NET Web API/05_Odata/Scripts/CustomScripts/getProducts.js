
$(document).ready(function () {

    $("#button").on("click", getProducts);

});

function getProducts() {

    var query = $("#query").val();

    $.ajax({
        url: "/api/products" + query,
        success: function (names) {

            var content = '<table>';

            $.each(names, function (key, value) {
                content += '<tr><th style="width:20px;">'
                    + value.Id +
                    '</th><td style="width:100px;">'
                    + value.Name +
                    '</td><td style="width:50px;">'
                    + value.Price +
                    "</td></tr>";
            });

            content += "</table>";

            $("#products").html(content);
        }
    });
};