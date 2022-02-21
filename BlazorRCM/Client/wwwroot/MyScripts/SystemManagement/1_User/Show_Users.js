$("#btnUsers").click(function () {

    $.ajax({
        url: "/ManageUser/LoadUsers",
        method: "post",
        datatype: "json",
        success: function (response) {
            if (response.Result) {

                //window.location.href = "/ManageUser/ShowUsers"

                //$.ajax({
                //    url: '/ManageUser/ShowUsers',
                //    type: 'POST',
                //    cache: false,
                //    async: true,
                //    dataType: "html",
                //    /* data: filters,*/

                //}).done(function (result) {

                //    $('#dashPage').html(result);

                //    insertDatatablesAndDropdownSettings();
                //})



                Swal.fire({
                    icon: 'error',
                    //title: response.Title,
                    text: "ok"
                });


            }
            else {
                Swal.fire({
                    icon: 'error',
                    title: response.Title,
                    html: response.Message
                });
            }
        }
    })
})







//function insertDatatablesAndDropdownSettings() {
//    $('.select2bs4').select2({
//        theme: 'bootstrap4'
//    })

//    $('#tblUsers').DataTable({

//        "columnDefs": [{
//            "targets": [-1],
//            "orderable": false
//        }],
//        "language": {
//            "sDecimal": ",",
//            "sEmptyTable": "Tabloda herhangi bir veri mevcut değil",
//            "sInfo": "_TOTAL_ kayıttan _START_ - _END_ arasındaki kayıtlar gösteriliyor",
//            "sInfoEmpty": "Kayıt yok",
//            "sInfoFiltered": "(_MAX_ kayıt içerisinden bulunan)",
//            "sInfoPostFix": "",
//            "sInfoThousands": ".",
//            "sLengthMenu": "Sayfada _MENU_ kayıt göster",
//            "sLoadingRecords": "Yükleniyor...",
//            "sProcessing": "İşleniyor...",
//            "sSearch": "Ara:",
//            "sZeroRecords": "Eşleşen kayıt bulunamadı",
//            "oPaginate": {
//                "sFirst": "İlk",
//                "sLast": "Son",
//                "sNext": "Sonraki",
//                "sPrevious": "Önceki"
//            }
//        },
//        "buttons": ["copy", "excel", "pdf", "print", "colvis"]
//    }).buttons().container().appendTo('#tblUsers_wrapper .col-md-6:eq(0)');
//}

    ///////////////////////////////
    //var $dashdiv = $('#dashPage'),
    //    url = $(this).data('url');
    //$.get(url, function (data) {
    //    $dashdiv.replaceWith(data);
    //});
