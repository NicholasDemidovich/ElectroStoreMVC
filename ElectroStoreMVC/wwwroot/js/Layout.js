$(document).ready(function () {

    $(".fa-search").click(function () {
        $(".wrap, .input").toggleClass("active");
        $("input[type='text']").focus();
        $("div#navbarsExampleDefault").children("ul#ulListId").children("li").css('opacity', '0').css('transition', 'all ease 0.8s');
        $("div#searchId").css('margin-left', '-24%');
        $("#navbarId").css('opacity', '0').css('transition', 'all ease 0.8s');

        if ($("div#navbarsExampleDefault").children("ul#ulListId").children("li#mainLi").css('opacity') == '0') {
            $("div#navbarsExampleDefault").children("ul#ulListId").children("li").css('opacity', '1').css('transition', 'all ease 0.8s');
            $("#navbarId").css('opacity', '1').css('transition', 'all ease 0.8s');
            $("div#searchId").css('margin-left', '4%');           
        }
    });

    $("span#spanListId").click(function () {
        if ($("button#buttonListId").attr('aria-expanded') == 'true') {
            $("button#buttonListId").attr('class', 'navbar-toggler collapsed');
            $("button#buttonListId").attr('aria-expanded', 'false');
            $("div#navbarsExampleDefault").attr('class', 'collapse navbar-collapse');
            $(".fa, .fa-search").css('display', 'inline');
            $(".wrap, .input").toggleClass("active");
        } else {
            if ($(".wrap, .input").attr('class') == 'wrap active') {
                $(".wrap, .input").toggleClass("active");
                $("div#navbarsExampleDefault").children("ul#ulListId").children("li").css('opacity', '1').css('transition', 'all ease 0.8s');
                $("#navbarId").css('opacity', '1').css('transition', 'all ease 0.8s');
                $("div#searchId").css('margin-left', '4%'); 
            }
            $(".wrap, .input").toggleClass("active");
            $(".fa, .fa-search").css('display', 'none');
            $("button#buttonListId").attr('class', 'navbar-toggler');
            $("button#buttonListId").attr('aria-expanded', 'true');
            $("div#navbarsExampleDefault").attr('class', 'collapse navbar-collapse show');
        }       
    });

    $("a#dropdown05").click(function () { 
        if ($("a#dropdown05").attr('class') == 'nav-link dropdown-toggle show') {
            $("ul#ulDropdownMenuId").removeAttr('data-bs-popper');
            $("ul#ulDropdownMenuId").attr('class', 'dropdown-menu');
            $("a#dropdown05").attr('aria-expanded', 'false');
            $("a#dropdown05").attr('class', 'nav-link dropdown-toggle');
        } else {
            $("a#dropdown05").attr('class', 'nav-link dropdown-toggle show');
            $("a#dropdown05").attr('aria-expanded', 'true');
            $("ul#ulDropdownMenuId").attr('class', 'dropdown-menu show');
            $("ul#ulDropdownMenuId").attr('data-bs-popper', 'none');
        }
    });

});