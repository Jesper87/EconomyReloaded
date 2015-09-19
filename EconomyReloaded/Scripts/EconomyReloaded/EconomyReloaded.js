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

$("#btnAddReceipt").click(function () {
    $.ajax({
        url: $(this).data('url'),
        type: "GET",
        cache: false,
        success: function (result) {
            $("#addReceiptPartial").html(result);
        }
    });
    return false;
});

$('#addReceiptPartial').on('click', '#btnInsertReceipt', function (e) {
    $('#errorDate').hide();
    $('#errorName').hide();
    $('#errorTotal').hide();

    var name = $('#tbName').val();
    var total = $('#tbTotal').val();
    var date = $('#tbDate').val();

    if (!name || !total || !date) {
        if (!name) {
            $('#errorName').show();
        }
        if (!total) {
            $('#errorTotal').show();
        }
        if (!date) {
            $('#errorDate').show();
        }
        alert('shit is empty!');
        e.preventDefault();
    }
});