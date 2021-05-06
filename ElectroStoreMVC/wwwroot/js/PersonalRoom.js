$(document).ready(function () {

    $("#editBtn1").click(function () {
        if ($("#div1").attr('class') == 'btn-group') {

            $("#div1").removeClass('btn-group');
            $("#inp1").addClass('dispNone');
            $("#inp2").addClass('dispNone');
        }
        else {
            $("#div1").attr('class', 'btn-group');
            $("#inp1").removeClass('dispNone');
            $("#inp2").removeClass('dispNone');

            $("[name =  PhoneNumber]").focus();
        }
    });

    $("#editBtn2").click(function () {
        if ($("#div2").attr('class') == 'btn-group') {
            $("#div2").removeClass('btn-group');
            $("#inp3").addClass('dispNone');
            $("#inp4").addClass('dispNone');
        }
        else {
            $("#div2").attr('class', 'btn-group');
            $("#inp3").removeClass('dispNone');
            $("#inp4").removeClass('dispNone');

            $("[name =  Email]").focus();
        }
    });

    $("#editBtn3").click(function () {
        if ($("#div3").attr('class') == 'btn-group') {
            $("#div3").removeClass('btn-group');
            $("#inp5").addClass('dispNone');
            $("#inp6").addClass('dispNone');
        }
        else {
            $("#div3").attr('class', 'btn-group');
            $("#inp5").removeClass('dispNone');
            $("#inp6").removeClass('dispNone');

            $("[name =  Address]").focus();
        }
    });

});
