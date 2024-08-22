

$(document).ready(function () {

    $('#country').change(function () {

        var cid = $("#country").val();
        $("#state").removeAttr("disabled");

        debugger
        $.ajax({
            type: "POST",
            url: "/Home/GetStateList?country=" + cid,
            contentType: "html",
            success: function (response) {
                debugger
                $("#state").empty();
                $("#state").append(response);
                $("#state").val(cid);
            }
        });

    });


    $('#state').change(function () {


        var ctyid = $("#state").val();
        $("#city").removeAttr("disabled");
        $.ajax({
            type: "POST",
            url: "/Home/GetCityList?state=" + ctyid,
            contentType: "html",
            success: function (response) {
                debugger
                $("#city").empty();
                $("#city").append(response);
                $("#city").val(ctyid);
            }
        });


    });

});
