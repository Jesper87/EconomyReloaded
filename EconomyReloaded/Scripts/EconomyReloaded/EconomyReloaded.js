$(".info-more").click(function () {
    var btn = $(this);
    var id = $(this).attr("data-userId");

    if (btn.hasClass("more")) {
        $.ajax({
            url: "http://economyreloadedapi/api/economy/getuserdetails/" + id,
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            type: "GET",
            success: function (data) {
                var infoDiv = $(".info-" + id);
                infoDiv.append("<p>" + data.FirstName + " </p>");
                infoDiv.append("<p>" + data.LastName + " </p>");
                infoDiv.append("<p>" + data.Email + " </p>");
                infoDiv.append("<p>" + data.UserId + " </p>");
                infoDiv.append('<a class="economy-list">Goto Economy</a>');
                var atag = $(".economy-list");
                atag.attr("href", "/Home/Economy?userId=" + id);

                btn.attr("value", "-");
                btn.removeClass("more");
                btn.addClass("less");
            }
        });
    }

    else if (btn.hasClass("less")) {
        btn.removeClass("less");
        btn.addClass("more");
        btn.attr("value", "+");
        $(".info-" + id).empty();
    }
});
