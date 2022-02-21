////---------------My datatable version : 1.10.24 --------------
$(document).ready(function () {

    //----------------------ADD NEW USER------------------------


    $("body").on("click", "#btnSave", function () {

        var frmCreateUser = $("#frmCreateUser");

        if (frmCreateUser.valid()) {
            var vm =
            {
                FirstName: $("#txtFirstName").val(),
                LastName: $("#txtLastName").val(),
                Phone: $("#txtPhone").val(),
                Email: $("#txtEmail").val(),
                BranchID: $('#allbranchList').val(),
                AuthrtyID: $('#allauthrtyList').val()
            };

            $.ajax({
                url: "/ManageUser/CreateNewUser",
                method: "post",
                datatype: "json",
                data: vm,
                success: function (response) {
                    if (response.Result) {

                        Swal.fire({
                            icon: 'success',
                            title: 'İşlem Başarılı',
                            text: response.Message
                        }).
                            then((result) => {

                                var mytable = $('#tblUsers').DataTable();
                                var usertable = document.getElementById("tblUsers");

                                var row = usertable.insertRow(1);
                                $(row).attr('adminId', response.Lastid);

                                var idnumer = row.insertCell(0);
                                var firstname = row.insertCell(1);
                                var lastname = row.insertCell(2);
                                var username = row.insertCell(3);
                                var phone = row.insertCell(4);
                                var email = row.insertCell(5);
                                var password = row.insertCell(6);
                                var isactive = row.insertCell(7);
                                var created = row.insertCell(8);
                                var modified = row.insertCell(9);
                                var editcell = row.insertCell(10);

                                var today = new Date();
                                var dd = String(today.getDate()).padStart(2, '0');
                                var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
                                var yyyy = today.getFullYear();

                                today = dd + '.' + mm + '.' + yyyy;


                                idnumer.innerHTML = "<span id=\"spnId\">" + response.Lastid;
                                //fullname.innerHTML = vm.FullName;
                                firstname.innerHTML = "<span id=\"spnFirstName\">" + vm.FirstName + "</span>";
                                lastname.innerHTML = "<span id=\"spnLastName\">" + vm.LastName + "</span>";
                                username.innerHTML = "<span id=\"spnUserName\">" + response.Username + "</span>";
                                phone.innerHTML = "<span id=\"spnPhone\">" + vm.Phone + "</span>";
                                //email.innerHTML = vm.Email;
                                email.innerHTML = "<span id=\"spnEmail\">" + vm.Email + "</span>";
                                password.innerHTML = "<span id=\"spnPassword\">" + response.Password + "</span>";
                                //isactive.innerHTML = "Aktif";
                                isactive.innerHTML = "<span id=\"spnIsActive\" class=\"badge bg-success\" isactive =\"true\">" + "Aktif" + "</span>";
                                created.innerHTML = "<span id=\"spnCrtdate\">" + today + "</span>";
                                modified.innerHTML = "<span id=\"spnMdfdate\">" + " - " + "</span>";
                                //editcell.innerHTML = "Yeni kayıt";
                                editcell.innerHTML = "<a href=\"#myedit\"><img id=\"imgEdit\" class=\"imgedit\" title=\"Değiştir\" src=\"/MyImages/DataTable/Edit.ico\" style=\"width: 25px;\"  adminid=\"" + response.Lastid + "\"/></a><span>&nbsp;&nbsp;</span><a href=\"#mydelete\"><img id=\"imgDelete\" class=\"imgdelete\" title=\"Sil\" src=\"/MyImages/DataTable/Delete.ico\" style=\"width: 30px;\"  adminid=\"" + response.Lastid + "\"/></a>";

                                mytable.rows.add($(row)).draw();
                                document.getElementById("frmCreateUser").reset();
                                

                                /* window.location.reload();*/
                            })
                    }

                    else {
                        Swal.fire({
                            icon: 'error',
                            title: response.Title,
                            html: response.Message
                        });
                    }

                },
                error: function () {

                }
            });

        }
        else {
            result = frmCreateUser.validate();
            var htmlMessage = "";

            for (var i = 0; i < result.errorList.length; i++) {
                htmlMessage += result.errorList[i].message + "<br />";
                //result.errorList[i].element.style.border = "1px solid #f00";
            }

            Swal.fire({
                icon: 'error',
                //title: 'Lütfen Bilgileri Eksiksiz ve Doğru Girin',
                html: htmlMessage
            });
        }

    });

    //----------------------DELETE USER------------------------
    $("body").on("click", "#imgDelete", function () {

        var table = $('#tblUsers').DataTable();
        var Id = $(this).attr("adminId");
        //var selected = $('td[adminId="Id"]');
        var selected = $(this);

        Swal.fire({
            title: 'Emin misiniz?',
            text: "Kullanıcı sistemden silinecektir!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Evet!',
            cancelButtonText: 'VAZGEÇ'
        }).then((result) => {
            if (result.value) {
                $.ajax({
                    method: 'post',
                    url: "/ManageUser/DeleteUser/" + Id,
                    async: true,
                    success: function (response) {
                        if (response.Result) {
                            Swal.fire({
                                icon: 'success',
                                title: 'İşlem Başarılı',
                                text: "Kullanıcı başarıyla silindi"
                            }).
                                then((result) => {

                                    table
                                        .row(selected.parents('tr'))
                                        .remove()
                                        .draw();
                                });
                        }
                        else {
                            Swal.fire({
                                icon: 'warning',
                                title: response.Title,
                                html: response.Message
                            })
                        }
                    }
                });
            }
        })
    });

    //----------------------UPDATE USER------------------------
    var selectedRow;
    var firstName;
    var lastName;
    var userName;
    var phone;
    var email;
    var password;
    var isActive;
    var radioBtnstate;
    //------show Model with current user data
    $("body").on("click", "#imgEdit", function () {

        //$('#divEdit').on('hidden.bs.modal', function (e) {
        //    $("#modalForm")[0].reset();
        //});
        var mytable = $('#tblUsers').DataTable();
        var adminId = $(this).attr("adminId");
        //console.log(adminId);
        var tr = $(this).closest("tr");
        selectedRow = tr;
        //var rowindex = tr.index();
        //console.log(rowindex);


        firstName = tr.find("#spnFirstName").html();
        lastName = tr.find("#spnLastName").html();
        userName = tr.find("#spnUserName").html();
        phone = tr.find("#spnPhone").html();
        email = tr.find("#spnEmail").html();
        password = tr.find("#spnPassword").html();
        isActive = tr.find("span.badge").attr("isActive");

        $("#hfAdminIdEdit").val(adminId);
        $("#txtFirstNameEdit").val(firstName);
        $("#txtLastNameEdit").val(lastName);
        $("#txtUserNameEdit").val(userName);
        $("#txtPhoneEdit").val(phone);
        $("#txtEmailEdit").val(email);
        $("#txtPasswordEdit").val(password);

        isActive == "true" ? $("#rdbActive").prop("checked", true) : $("#rdbPassive").prop("checked", true);
        isActive == "true" ? radioBtnstate = 1 : radioBtnstate = 0;

        $("#divEditUser").modal('show');

        //---------------user edit---------------

    });

    //------ updating on Model 
    $("body").on("click", "#btnEdituser", function () {

        var frmUpdateUser = $("#modalForm");

        if (frmUpdateUser.valid())
        {
            var radioBtnchckd;
            var radioBtns = document.getElementsByName('IsActive');
            if (radioBtns[0].checked) radioBtnchckd = 1;
            if (radioBtns[1].checked) radioBtnchckd = 0;

            if ($("#txtFirstNameEdit").val() != firstName ||
                $("#txtLastNameEdit").val() != lastName ||
                $("#txtUserNameEdit").val() != userName ||
                $("#txtPhoneEdit").val() != phone ||
                $("#txtEmailEdit").val() != email ||
                $("#txtPasswordEdit").val() != password ||
                radioBtnstate != radioBtnchckd)
            {
                var table = $('#tblUsers').DataTable();
                //var rowindex = $("#rowIndex").val();
                //var rowNode = table.find("tbody tr:eq(rowindex)").get(0);
                //var tr = table.row( rowindex );
                //console.log(tr);
                var id = $("#hfAdminIdEdit").val();

                var vm =
                {
                    Id: id,
                    FirstName: $("#txtFirstNameEdit").val(),
                    LastName: $("#txtLastNameEdit").val(),
                    UserName: $("#txtUserNameEdit").val(),
                    Phone: $("#txtPhoneEdit").val(),
                    Email: $("#txtEmailEdit").val(),
                    Password: $("#txtPasswordEdit").val(),
                    State: $("#rdbActive").is(":checked")
                };

                $.ajax({
                    url: "/ManageUser/UpdateUser",
                    method: "post",
                    datatype: "json",
                    //async=false,
                    data: vm,
                    success: function (response) {
                        if (response.Result) {
                            Swal.fire({
                                icon: 'success',
                                title: 'İşlem Başarılı',
                                text: response.Message
                            }).then((result) => {

                                var today = new Date();
                                var dd = String(today.getDate()).padStart(2, '0');
                                var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
                                var yyyy = today.getFullYear();

                                today = dd + '.' + mm + '.' + yyyy;

                                var cellDataTrue = "<span class=\"badge bg-success\" isActive=\"true\">" + "Aktif" + "</span>";
                                var cellDataFalse = "<span class=\"badge bg-danger\" isActive=\"false\">" + "Pasif" + "</span>";

                                table.cell(selectedRow, 1).data("<span id=\"spnFirstName\">" + vm.FirstName + "</span>").draw();
                                table.cell(selectedRow, 2).data("<span id=\"spnLastName\">" + vm.LastName + "</span>").draw();
                                table.cell(selectedRow, 3).data("<span id=\"spnUserName\">" + vm.UserName + "</span>").draw();
                                table.cell(selectedRow, 4).data("<span id=\"spnPhone\">" + vm.Phone + "</span>").draw();
                                table.cell(selectedRow, 5).data("<span id=\"spnEmail\">" + vm.Email + "</span>").draw();
                                table.cell(selectedRow, 6).data("<span id=\"spnPassword\">" + vm.Password + "</span>").draw();
                                vm.State ? table.cell(selectedRow, 7).data(cellDataTrue).draw() : table.cell(selectedRow, 7).data(cellDataFalse).draw();
                                table.cell(selectedRow, 9).data("<span>" + today + "</span>").draw();

                                $("#modalForm")[0].reset();
                                $("#divEditUser").modal('hide');

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
                });
            }
            else {
                $("#divEditUser").modal('hide');
            }
        }
        else {
            result = frmUpdateUser.validate();
            var htmlMessage = "";

            for (var i = 0; i < result.errorList.length; i++) {
                htmlMessage += result.errorList[i].message + "<br />";
                //result.errorList[i].element.style.border = "1px solid #f00";
            }

            Swal.fire({
                icon: 'error',
                //title: 'Lütfen Bilgileri Eksiksiz ve Doğru Girin',
                html: htmlMessage
            });
        }
        
    });
    //---------------------/UPDATE USER---------------------------




    //function include(file) {

    //    var script = document.createElement('script');
    //    script.src = file;
    //    script.type = 'text/javascript';
    //    script.defer = true;

    //    document.getElementsByTagName('head').item(0).appendChild(script);

    //}

    ///* Include Many js files */

    //include('~/Scripts/jquery.validate.js');
    //include('~/Scripts/jquery.validate.unobtrusive.js');


})
