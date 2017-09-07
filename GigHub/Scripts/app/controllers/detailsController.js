var DetailsController = function (followingsService) {
    var button;

    var init = function (container) {
        $(container).on("click", ".js-toggle-following", toggleFollowing);
    };

    var toggleFollowing = function (e) {
        button = $(e.target);

        var followeeId = button.attr("data-artist-id");

        if (button.hasClass("btn-default")) {
            followingsService.createFollowing(followeeId, done, fail);
        }
        else {
            followingsService.deleteFollowing(followeeId, done, fail);
        }
    };

    var done = function () {
        var text = (button.text() === "Following") ? "Following" : "Following?";
        button.toggleClass("btn-info").toggleClass("btn-default").text(text);
    };

    var fail = function () {
        alert("Something failed!");
    };

    return {
        init: init
    };
}(FollowingService);