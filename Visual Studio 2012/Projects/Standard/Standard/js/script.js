var Lucidia = Lucidia || {};
Lucidia.Restaurant = {
    init: function () {
        /* Bind a click event for the a.menuTypeHead */
        $(".menuTypeHead").on("click", this.toggleExpand);
    },
    toggleExpand: function () {
        /* Toggle the inside class */
        $(this).next().toggle(1000);

        if ($(this).children("a.expand").css("display") == "block") {
            $(this).children("a.expand").css("display", "none");
            $(this).children("a.collapse").css("display", "block");
        } else {
            $(this).children("a.expand").css("display", "block");
            $(this).children("a.collapse").css("display", "none");
        }
    }
};

$(function () {
    Lucidia.Restaurant.init();
});
