$(document).ready(function () {
    if (location.pathname == "/Home/favorites") {
        $('.footer').css('position', 'fixed');
    }
    if (location.pathname == "/Home/Catalog") {
        $('#result').css("background","white");
    }
    if (location.pathname.includes("/Home/Buy")) {
        $('#result').css("background", getRandomColor());
    }
});
$('#result').on('click', '#favorites', function () {
    var id = $(this).attr('data-id');
    var thiselem = $(this);
    if (id != '') {
        $.post("/Home/AddToCart", { "id": id }, function (data) {
            if (data.CartCount == null) {
                alert(data.Error);
            }
            else {
                $('#countCart').text(data.CartCount);
                $(thiselem).css({'background': 'yellow','text-align':'center'}).text('добавлено');
            }   
        });
    };
});
$('#result').on('click', '#delfavorites', function () {
    var id = $(this).attr('data-id');
    if (id != '') {
        $.post("/Home/RemoveFav", { "id": id }, function (data) {
            if (data.cartCount == 0) {
                $('#result').html("<h1 style='color:black' align='center'>СПИСОК ПУСТ!</h1>");
                $('#countCart').text(0);
            }
            else {
                window.location.reload(true);
            }
        });
    };
});

$('#full').click(function () {
    $("html,body").animate({ scrollTop: $('.fa-fighter-jet').position().top},1000)
});
$('.topbody').on('click','#topbody',function () {
    $('html,body').animate({ scrollTop: $('.wrapper').position().top }, 1000);
});

function scrollHead() {
    $('html,body').animate({ scrollTop: $('.wrapper').position().top }, 1000);
}

$(window).scroll(function () {
    if ($(window).scrollTop() != 0) {
        $('.topbody').html("<span id='topbody'><i class='fa fa-angle-double-up' aria-hidden='true'></i></span>");
    }
    else {
        $('.topbody').html('<span style="color:white">2020</span>')
    }
});
$('#buyitem').click(function () {
    $('.infobuy').slideToggle();
    $('[name="date"]').val(getDate());
    if ($('.infobuy').is(":visible")) {
        $("html,body").animate({ scrollTop: $('[name="desc"]').position().top }, 1000);
    }
});
$(window).resize(function () {
    $('#result').css('height', 'max-content');
});

$("#formbuy").submit(function (e) {
    e.preventDefault();
    var b = $("#formbuy").serialize();
    $.post("/Home/Buy", b, function () { $(".infobuy").html("<h2 style='color:black'>Покупка оформлена успешно</h2>"); });
});
function getDate() {
    let c = new Date();
    let day = c.getDate();
    let month = c.getMonth();
    let year = c.getFullYear();
    return `${day}.${Number(month)+1}.${year}`;
}
function getRandomColor() {
    return '#' + Math.floor((Math.random() * 2 ** 24)).toString(16).padStart(0, 6);
}
function ifselect() {
    $('select').val() == 1 ? $('#deliv').text(500) : ($('select').val() == 2 ? $('#deliv').text(300) : $('#deliv').text(200));
}