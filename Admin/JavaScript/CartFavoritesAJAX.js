$('#result').on('click','#favorites',function () {
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
