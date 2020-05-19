$('#stats').click(function () {
    $('.main-r').html("<h1>Загрузка<a id='dot1'>.</a><a id = 'dot2'>.</a ><a id='dot3'>.</a></h1>");
    let a = setInterval(() => loading(), 1500);
    $.get("/Content/Statistic", function (data) {
        clearInterval(a);
        $('.main-r').html(data);
        window.location.hash = "Stats";
    });
});
$('#content').click(function () {
    $('.main-r').html("<h1>Загрузка<a id='dot1'>.</a><a id='dot2'>.</a ><a id='dot3'>.</a></h1> ");
    let a = setInterval(() => loading(), 1500);
    loadsketchs();
    clearInterval(a);
    });

$('.main-r').on("click", "#formatsketch", function () {
    var id = $(this).attr('data-id');
    $.get("/Content/getSketch", { "id": id }, function (data) {
        $('#idsketch').val(data.Id);
        $('#name').val(data.name);
        $('#typesketch').val(data.idtypesketch);
        $('#material').val(data.material);
        $('#cost').val(data.cost);
        $('#desc').val(data.desc);
        $('#imgsketch').attr('src', "/Images/"+data.path);
        //ВЫВОД ДАННЫХ В МОДАЛКУ ДЛЯ РЕДАКТИРОВАНИЯ
    });
    $(".modal").css('display', 'flex');
});

//закрытие модалки
$('#exitmodal').on("click",null, function () {
    $(".modal").css('display', 'none');
});
//Удаление эскиза
$(".main-r").on('click', "#delsketch", function () {
    var id = $(this).attr('data-id');
    $.get("/Content/deletesketch", { "id": id}, function () {
        alert("Эскиз удален");
        loadsketchs();
    });
});

$('#typesk').click(function () {
    $('.main-r').html("<h1>Загрузка<a id='dot1'>.</a><a id='dot2'>.</a><a id='dot3'>.</a></h1>");
    let a = setInterval(() => loading(), 1500);
    $.get("/Content/typesketch", function (data) {
        clearInterval(a);
        $('.main-r').html(data);
        window.location.hash = "typesketch";
    });
});

$('#orders').click(function () {
    $.get("/Content/orders", function (data) {
        $('.main-r').html(data);
        window.location.hash = "orders";
    });
});

$('.main-r').on('click', '#userinfo', function () {
    var datauser = $(this).siblings('.data-user')
    $(datauser).slideToggle();
});

//Удаление ордера
$('.main-r').on('click', '.endorder', function () {
    let id = $(this).attr('data-id');
    $.get("/Content/finishOrder", { "id": id }, function (data) {
    data;
    });
});

$('#callback').click(function () {
    $.get("/Content/Callback", function (data) {
        $('.main-r').html(data);
    });
});

$('.main-r').on("click", "#answer", function () {
    var id = $(this).attr('data-id');
    $("body").append()
});

$('#exitmodal1').on("click", null, function () {
    $(".modal1").css('display','none');
});

$('.main-r').on('click', '#answer', function () {
    let thisel = $(this).attr('data-name');
    $('#mail').val('Здрувствуйте, ' + thisel)
    $(".modal1").css('display', 'flex');
});

$('.main-r').on('click','#seeimg',function () {
    var id = $(this).attr('data-id');
    if ($(`[data-img-id="${id}"]`).attr('src') == "") {
        $.ajax({
            type: "GET",
            url: "/Content/getSketch",
            data: { id: id }
        }).done(function (data) {
            $(`[data-img-id="${id}"]`).attr("src", "/Images/" + data.path);
        });
        $(`[data-div-id="${id}"]`).slideToggle();
    }
    else {
        $(`[data-div-id="${id}"]`).slideToggle();
    }
    
});
    

//при успешном добавлении эскиза
function SuccessAdd() {
    alert('Эскиз добавлен');
    $("form input").val('');
    $("[type='submit']").val('Сохранить');
    loadsketchs(); 
}

//функция при успешном изменении данных эскиза
function editsketch() {
    alert("Сохранено");
    setTimeout(() => $(".modal").css('display', 'none'), 1000);
    loadsketchs();
}
//Загрузка эскизов
function loadsketchs() {
    $.get("/Content/Content", function (data) {
        $('.main-r').html(data);
        window.location.hash = "Content";
    });
}
function AddTypeSkSuccess() {
    alert("Тип эскиза добавлен");
}
function Mess(text, idremove) {
    $("#" + idremove).remove();
    alert(text);
}

function loading() {
        setTimeout(() => changeDot('#dot1', '#dot2', "#dot3"), 0);
        setTimeout(() => changeDot('#dot2', '#dot1', "#dot3"), 500);
        setTimeout(() => changeDot('#dot3', '#dot1', "#dot2"), 1000);
}
function changeDot (active, inactive, inactive1) {
    $(active).css('color', 'red');
    $(inactive).css('color', 'black');
    $(inactive1).css('color', 'black');
}
function func() {

}

