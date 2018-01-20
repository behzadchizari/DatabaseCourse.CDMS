$(document).ready(function () {
    $('#Loading').height($(window).height() + 'px');
    $('#loader').css({ "margin-top": $(window).height() / 2 - 120 + 'px' });
});

function ShowNoDataError(elemName, optInfo = '') {
    $(elemName).html('<p class="no-data">داده ای جهت نمایش یافت نشد!</p>' +
        '<code>' + optInfo + '</code>'
    );
}

function ShowLoading() {
    $('#Loading').show();
}

function HideLoading() {
    $('#Loading').hide();
}

function checkChar(string) {
    validChar = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890@.-_ ';
    strlen = string.length;
    string = string.toUpperCase();
    for (i = 0; i < strlen; i++) {
        if (validChar.indexOf(string.charAt(i)) < 0) {
            return false;
        }
    }
    return true;
}

function SetUnderScoreinsteadBlank(a) {
    setTimeout(function () {
        a.value = a.value.replace(' ','_');
    }, 1);
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
//onclick = "$(this).toggleClass("fa- plus - square");$(this).toggleClass("fa- minus - square");$("").toggle();"

function Expand(element) {
    debugger;
    var target = $(element).attr('data-toggle');
    $(element).toggleClass("fa-plus-square");
    $(element).toggleClass("fa-minus-square");
    $(target).toggle();
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
