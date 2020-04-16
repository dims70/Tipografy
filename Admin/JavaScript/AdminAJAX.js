$('#stats').click(function () {
    $('.main-r').html("<h1>Загрузка...</h1>");
    $.get("/Content/Statistic", function (data) {
        $('.main-r').html(data);
        window.location.hash = "Stats";
    });
});
$('#content').click(function () {
    $('.main-r').html("<h1>Загрузка...</h1>");
    $.get("/Content/Content", function (data) {
        $('.main-r').html(data);
        window.location.hash = "Content";
    });
});

$('.main-r').on("click", "#formatsketch", function () {
    var id = $('#formatsketch').attr('data-id');
    $.get("/Content/getSketch", { "id": id }, function (data) {
        $('#name').val(data.name);
        //ДОПИЛИТЬ ВЫВОД В РЕДАКТИРОВАНИЕ
    });
    $(".modal").css('display', 'flex');
});
$('#exitmodal').on("click",null, function () {
    $(".modal").css('display', 'none');
});

function SuccessAdd() {
    alert('Эскиз добавлен');
    $("form input").val('');
    $("[type='submit']").val('Сохранить');
    $.get("/Content/Content", function (data) {
        $('.main-r').html(data);
    });
}

