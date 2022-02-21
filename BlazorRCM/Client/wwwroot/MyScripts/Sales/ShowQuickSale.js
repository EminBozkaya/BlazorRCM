$("#btnQuickSale").click(function () {

    $.ajax({
        url: '/Sales/QuickSale',
        type: 'POST',
        cache: false,
        async: true,
        dataType: "html"
        
    })
        .done(function (result) {
            
            $('#dashPage').html("");
            $('#dashPage').html(result);
            
        });
})
//$("#nvbQuickSale").click(function () {

//    $.ajax({
//        url: '/Sales/QuickSale',
//        type: 'POST',
//        cache: false,
//        async: true,
//        dataType: "html",
//        /* data: filters,*/
//        success: function (result) {

//            $('#dashPage').html("");
//            $('#dashPage').html(result);


//            //.done(function (result) {

//            //    $('#dashPage').html("");
//            //    $('#dashPage').html(result);
//            //});
//        }
//    });
//})