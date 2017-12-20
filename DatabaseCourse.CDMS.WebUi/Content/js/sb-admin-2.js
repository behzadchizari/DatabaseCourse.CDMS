$(document).ready(function() {
    $('#Loading').height($(window).height() + 'px');
    $('#loader').css({ "margin-top": $(window).height() / 2 - 120 + 'px' });

});

function ShowLoading() {
    $('#Loading').show();
}

function HideLoading() {
    $('#Loading').hide();
}

function FilterTable() {
    var td, i;
    var input = document.getElementById("input-filter");
    var filter = input.value.toUpperCase();
    var table = document.getElementById("table-filter");
    var tr = table.getElementsByTagName("tr");
    for (i = 0; i < tr.length; i++) {
        var tds = tr[i].getElementsByTagName("td");
        for (var j = 0; j < tds.length; j++) {
            td = tds[j];
            if (td) {
                if (td.innerHTML.toUpperCase().indexOf(filter) > -1) {
                    tr[i].style.display = "";
                    break;
                } else {
                    tr[i].style.display = "none";
                }
            }
        }
    }
}













$(function () {
    $('#side-menu').metisMenu();
});

// Loads the correct sidebar on window load,
// collapses the sidebar on window resize.
// Sets the min-height of #page-wrapper to window size
$(function () {
    $(window).bind("load resize", function () {
        topOffset = 50;
        width = (this.window.innerWidth > 0) ? this.window.innerWidth : this.screen.width;
        if (width < 768) {
            $('div.navbar-collapse').addClass('collapse');
            topOffset = 100; // 2-row-menu
        } else {
            $('div.navbar-collapse').removeClass('collapse');
        }

        height = ((this.window.innerHeight > 0) ? this.window.innerHeight : this.screen.height) - 1;
        height = height - topOffset;
        if (height < 1) height = 1;
        if (height > topOffset) {
            $("#page-wrapper").css("min-height", (height) + "px");
        }
    });

    var url = window.location;
    var element = $('ul.nav a').filter(function () {
        return this.href == url || url.href.indexOf(this.href) == 0;
    }).addClass('active').parent().parent().addClass('in').parent();
    if (element.is('li')) {
        element.addClass('active');
    }

});
