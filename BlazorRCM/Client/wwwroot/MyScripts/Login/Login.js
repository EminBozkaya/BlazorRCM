$(document).ready(function () {

    if (localStorage.getItem("userName") != "") {
        $("#txtUsername").val(localStorage.getItem("userName"));
        $("#chkRememberMe").prop("checked", false);
    }
    //if (localStorage.getItem("password") != "") {
    //    $("#txtPassword").val(localStorage.getItem("password"));
    //    $("#chkRememberMe").prop("checked", false);
    //}
    var clickCounter = 0;
    var enterKeyUpCounter = 0;

    $("#btnLogIn").click(function (e) {
        clickCounter++;
        processLogin();
    });

    $("#btnSendPassword").click(function () {
        processSendPassword();
    });

    $("#txtPassword").keyup(function (e) {
        if (e.keyCode == 13) {
            enterKeyUpCounter++;
            processLogin();
        }
    });

    $("#txtEmailForgotPassword").keyup(function (f) {
        if (f.keyCode == 13) {
            processSendPassword();
        }
    });

    function processLogin() {

        var frmLogIn = $("#myLoginForm");

        if (frmLogIn.valid()) {

            if (clickCounter == 1 || enterKeyUpCounter == 1)
            {
                var mybutton = document.getElementById("btnLogIn");
                var waitDiv = "<div id=\"waitDiv\" style=\"background-color: white; color: tomato; font-size:medium; padding-top:20px; width: 130px\">Lütfen bekleyin..</div>";
                
                document.getElementById("btnLogIn").remove();
                $("#mydiv").prepend(waitDiv);
                
                $("#loginWait").show();

                var vm =
                {
                    Username: $("#txtUsername").val(),
                    Password: $("#txtPassword").val()
                };

                if ($("#chkRememberMe").is(':checked')) {
                    localStorage.setItem("userName", vm.Username);
                    //localStorage.setItem("password", vm.Password);
                }
                //----to clear select list of modal(which created before)-------------------
                var div = document.getElementById('myParent');
                while (div.firstChild) {
                    div.removeChild(div.firstChild);
                }
                $.ajax({
                    url: "/Home/LogIn",
                    method: "post",
                    datatype: "json",
                    data: vm,
                    success: function (response) {

                        if (response.Result) {

                            if (response.UserBranchNames.length > 1) {

                                var myParent = document.getElementById("myParent");

                                //Create and append select list
                                var selectList = document.createElement("select");

                                selectList.id = "slctBranchList";
                                selectList.className = "form-control select2bs4"
                                myParent.appendChild(selectList);

                                var selectedOption = document.createElement("option");
                                selectedOption.value = 0;
                                selectedOption.text = "---Şube Seçiniz---";
                                selectList.appendChild(selectedOption);

                                $('select option[value="0"]').attr("selected", true);

                                //Create and append the options
                                for (var i = 0; i < response.UserBranchNames.length; i++) {
                                    var option = document.createElement("option");
                                    option.value = response.UserBranchIds[i];
                                    option.text = response.UserBranchNames[i];
                                    selectList.appendChild(option);
                                }

                                document.getElementById("slctBranchList").setAttribute("style", "width: 100%;");

                                //to Show Dropdwn search bar 
                                $(function () {
                                    //Initialize Select2 Elements
                                    $('.select2bs4').select2({
                                        theme: 'bootstrap4'
                                    })
                                });

                                $("#loginWait").hide();
                                $('#mdlSelectBranch').modal('show');
                                clickCounter = 0;
                                enterKeyUpCounter = 0;

                                document.getElementById("waitDiv").remove();
                                $("#mydiv").prepend(mybutton);

                                $("#btnEdituser").click(function () {
                                    var branchID = $('#slctBranchList').val();
                                    if (branchID == 0)
                                        processToast();
                                    else {

                                        $("#loginWait").show();

                                        var indx = response.UserBranchIds.indexOf(parseInt(branchID));
                                        var authrtyTypID = response.AuthorityTypeIds[indx];
                                        var brnchName = response.UserBranchNames[indx];

                                        var VM =
                                        {
                                            activeBranchId: branchID,
                                            activeAuthrtyTypID: authrtyTypID,
                                            activeBranchName: brnchName
                                        };
                                        $.ajax({
                                            url: "/Home/LogInDefineBranchIdAndAuthorityTypeId",
                                            method: "post",
                                            datatype: "json",
                                            data: VM,
                                            success: function (response) {
                                                if (response.Result) {
                                                    $("#loginWait").hide();
                                                    window.location.href = "/DashBoard/Index";
                                                };
                                            }
                                        });
                                    }
                                });
                            }
                            else {
                                var branchID = response.UserBranchIds[0];
                                var authrtyTypID = response.AuthorityTypeIds[0];
                                var brnchName = response.UserBranchNames[0];

                                var VM =
                                {
                                    activeBranchId: branchID,
                                    activeAuthrtyTypID: authrtyTypID,
                                    activeBranchName: brnchName
                                };
                                $.ajax({
                                    url: "/Home/LogInDefineBranchIdAndAuthorityTypeId",
                                    method: "post",
                                    datatype: "json",
                                    data: VM,
                                    success: function (response) {
                                        if (response.Result) {
                                            $("#loginWait").hide();
                                            window.location.href = "/DashBoard/Index";
                                        };
                                    }
                                });
                            }

                            //-------------------to triger TOAST-----------------------------
                            $("#btnExitModel").click(function () {
                                processToast();
                            });

                            $("#btnCloseModel").click(function () {
                                processToast();
                            });

                            $("#mdlSelectBranch").click(function (event) {

                                if ($(event.target).attr("id") === "mdlSelectBranch") {
                                    processToast();
                                }
                            });
                            //----------------------/toast------------------------------------
                        }
                        else {
                            $("#loginWait").hide();
                            Swal.fire({
                                icon: 'error',
                                title: response.Title,
                                html: response.Message,
                            }).then((result) => {
                                
                                clickCounter = 0;
                                enterKeyUpCounter = 0;
                                document.getElementById("waitDiv").remove();
                                $("#mydiv").prepend(mybutton);
                            });
                        }
                    },
                    error: function () {
                    }
                });
            }
            
        }
        else {
            clickCounter = 0;
            enterKeyUpCounter = 0;

            result = frmLogIn.validate();
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
    }


    function processSendPassword() {
        var formForgat = $("#frmForgotPassword");

        if (formForgat.valid()) {

            $("#mailsend").show();

            var vm =
            {
                FirstName: $("#txtFirstNameForgotPassword").val(),
                LastName: $("#txtLastNameForgotPassword").val(),
                Email: $("#txtEmailForgotPassword").val()
            };

            $.ajax({
                url: "/Home/ForgotPassword",
                method: "post",
                datatype: "json",
                data: vm,
                success: function (response) {

                    $("#mailsend").hide();

                    Swal.fire({
                        icon: response.Result ? "success" : "error",
                        title: response.Result ? "İşlem Başarılı" : response.Title,
                        html: response.Message
                    }).then((result) => {
                        $('#divForgotPassword').modal('hide');
                    });
                },
                error: function () {
                    $("#mailsend").hide();
                }
            });
        }

        else {
            var result = formForgat.validate();
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
            //    .then((result) => {
            //    window.location.reload();
            //});
        }
    }


    function processToast() {
        var Toast = Swal.mixin({
            toast: true,
            position: 'top-end',
            showConfirmButton: false,
            timer: 4000
        });

        Toast.fire({
            icon: 'warning',
            title: 'Sisteme giriş yapabilmek için şube seçmelisiniz'
        })
    }
});
