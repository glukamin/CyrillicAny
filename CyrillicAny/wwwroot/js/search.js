$(document).ready(function () {
    $("form").submit(function (e) {
        e.preventDefault();
        $(this).validate();

        if (!$(this).valid()) {
            return;
        }

        $("#nyTimes").html("");
        let searchText = $("#SearchText").val();
        $.ajax({
            url: $(this).attr("action") + searchText + "&api-key=wlZVZwTsy0m3T8VwKzOofLyAao468ETT",
            contentType: "application/json",
            type: "GET",
            data: searchText,
            success: function (data) {

                var items = [];
                $.each(data.response.docs, function (idx, obj) {
                        items.push("<li class='article'><a href='" + obj.web_url + "'target='_blank'>" + obj.headline.main + "</a><p>" + obj.snippet + "</p></li>");
                    }
                );
                $("<ul/>",
                    {
                        "class": "list-group",
                        html: items.join("")
                    }
                ).appendTo($("#nyTimes"));

                var query = { SearchText: searchText };
                var t = $("input[name='__RequestVerificationToken']").val();
                $.ajax({
                    url: "/api/search",
                    headers:
                    {
                        "RequestVerificationToken": t
                    },
                    type: "POST",
                    data: query,
                    success: function (data) {
                        // either notify user or what ever needed
                    },
                    error: function (response) {
                        alert("An error occurred while saving search query");
                    }
                });

            },
            error: function (response) {
                alert("An error occurred");
            }
        });
    });
});