//------------------------------Edit and Change Scripts----------------------------
//---------------------------------------------------------------------------------

//----------------------------------Change User Profile--------------

//var UserId = document.getElementById("activeUserInfo").getAttribute("userid");
//var UserName = "";
//var Email = "";
//var Password = "";

//var newBranchName = "";

////---set current user info to modal
//$("#btnupdate").click(function (e) {
//    e.preventDefault();
//    $('#userEditMenu').hide();

//    $.ajax({
//        method: 'post',
//        url: "/UserInfo/GetActiveUserInfo/" + UserId,
//        async: true,
//        success: function (response) {
//            if (response.Result) {
//                $("#txtProfileUserName").val(response.UserName);
//                $("#txtProfileEmail").val(response.Email);
//                $("#txtProfilePassword").val(response.Passwd);

//                $("#divChangeUserProfile").modal('show');

//                UserName = response.UserName;
//                Email = response.Email;
//                Password = response.Passwd;
//            }
//            else {
//                Swal.fire({
//                    icon: 'warning',
//                    title: response.Title,
//                    html: response.Message
//                })
//            }
//        }
//    });
//});

////----------update new value----
//$("#btnUpdateUser").click(function (e) {
//    e.preventDefault();

//    var mdlUserInfoForm = $("#mdlUserInfoForm");
//    if (mdlUserInfoForm.valid()) {

//        if ($("#txtProfileUserName").val() != UserName || $("#txtProfileEmail").val() != Email || $("#txtProfilePassword").val() != Password) {

//            //------------to need old password for accept changes------------------------------------
//            (async function () {
//                const { value: password } = await Swal.fire({
//                    title: 'Eski Şifre ?',
//                    input: 'password',
//                    inputLabel: 'Değişikliklerin onaylanması için eski şifrenizi girmelisiniz',
//                    inputPlaceholder: 'şifre..',
//                    inputAttributes: {
//                        maxlength: 10,
//                        autocapitalize: 'off',
//                        autocorrect: 'off'
//                    },
//                });
//                if (password == Password) {
                    

//                    var vm =
//                    {
//                        Id: UserId,
//                        UserName: $("#txtProfileUserName").val(),
//                        Email: $("#txtProfileEmail").val(),
//                        Password: $("#txtProfilePassword").val()
//                    }
//                    $.ajax({
//                        method: 'post',
//                        url: "/UserInfo/UpdateUserProfile/",
//                        async: true,
//                        data: vm,
//                        success: function (response) {
//                            if (response.Result) {
//                                Swal.fire({
//                                    icon: 'success',
//                                    title: 'İşlem Başarılı',
//                                    text: response.Message
//                                }).then((result) => {
                                    
//                                    $("#mdlUserInfoForm")[0].reset();
//                                    $("#divChangeUserProfile").modal('hide');
//                                    window.location.href = "/DashBoard/Index";
//                                });
//                            }
//                            else {

//                                Swal.fire({
//                                    icon: 'error',
//                                    title: response.Title,
//                                    html: response.Message
//                                })
//                            }
//                        }
//                    });
//                }
//                else {
//                    Swal.fire(`Eski Şifrenizi Hatalı Girdiniz !`)
//                }
//            })();

//            //-----------/--------------------

//        }
//        else {
//            $("#mdlUserInfoForm")[0].reset();
//            $("#divChangeUserProfile").modal('hide');
//    }


//    }
//    else {
//        result = mdlUserInfoForm.validate();
//        var htmlMessage = "";

//        for (var i = 0; i < result.errorList.length; i++) {
//            htmlMessage += result.errorList[i].message + "<br />";
            
//        }

//        Swal.fire({
//            icon: 'error',
            
//            html: htmlMessage
//        });
//    }



//});
////-----------------------------------------/user profile----------------------------------

////--------------------------change branch---------------------------------
//$("#btnAcceptBranch").click(function (e) {
//    e.preventDefault();
//    var selectedValue = $('select[name=mySelection] option').filter(':selected').val();
//    var selectedText = $('select[name=mySelection] option').filter(':selected').text();
    
//    var selectedActiveauthrtyId = $('#branchList').find('option:selected').attr('authrtyid')
//    var activeBrnchId = document.getElementById("activeUserInfo").getAttribute("userBrnchId");
//    newBranchName = selectedText;

//    if (selectedValue != 0 && selectedValue != activeBrnchId) {
//        var vm =
//        {
//            ActiveBranchId: selectedValue,
//            ActiveBranchName: selectedText,
//            ActiveAuthorityId: selectedActiveauthrtyId
//        }
//        $.ajax({
//            method: 'post',
//            url: "/UserInfo/ChangeActiveBranchInfo/",
//            async: true,
//            data: vm,
//            success: function (response) {
//                if (response.Result) {
                    
//                    $('#userEditMenu').hide();

//                    window.location.href = "/DashBoard/Index";
                   
//                }
//                else {

//                    Swal.fire({
//                        icon: 'error',
//                        title: response.Title,
//                        html: response.Message
//                    })
//                }
//            }
//        });
//    }
//});

////---------------- to triger toast-------------
//function processToast() {
//    var Toast = Swal.mixin({
//        toast: true,
        
//        showConfirmButton: true,
        
//    });
//    Toast.fire({
//        icon: 'warning',
//        title: 'İşlemlerinize ' + newBranchName + ' şubesi ile devam edilecek!'
//    }).then((result) => {
//        window.location.href = "/DashBoard/Index";
//    });
    
//}










//--------------------------------------------------------------------------------------------
//---------------------------- / Edit and Change Scripts--------------------------------------



//------------------to Use Dropdown in DropdwnList Working Properly (hide/show change/attributes ..etc)----------
window.onload = function () {
    /*$(document).ready(function () {*/
    var clicked;
    var clickedClassName;

    $("#inputID").on('click', function (e) {
        e.stopPropagation();

        setDefaultMyDropDownList();

        changeAcceptButtonStyle();

        var userDiv = document.getElementById("userEditMenu");
        $(userDiv).is(":hidden") ? $(userDiv).show() : $(userDiv).hide();
    });

    document.addEventListener('click', (e) => clicked = e.target);

    $(document).click(function (event) {
        event.stopPropagation();
        var el = document.getElementById("inputID");
        var myel = document.querySelector("[dir='ltr']");
        var classname = $(myel)[0].className;
        var spanClassName = "select2 select2-container select2-container--bootstrap4 select2-container--below select2-container--open";

        var $target = $(event.target);
        if (!$target.closest('#userEditMenu').length && (clicked != el) && $('#userEditMenu').is(":visible") && (classname != spanClassName)) {
            $('#userEditMenu').hide();
        }

    });


    document.querySelectorAll('.select2').forEach(item => {
        item.setAttribute("onclick", "setClass($(this).attr('class'));");
    });

    function setClass(className) {
        clickedClassName = className;
    }


    $("#branchList").change(function (e) {
        e.preventDefault();
        changeAcceptButtonStyle();
    });


    function changeAcceptButtonStyle() {
        var selectedValue = $('select[name=mySelection] option').filter(':selected').val();
        var activeBrnchId = document.getElementById("activeUserInfo").getAttribute("userBrnchId");

        selectedValue != 0 && selectedValue != activeBrnchId ? $("#btnAcceptBranch").attr("style", "color: white; background-color:#17a2b8") : $("#btnAcceptBranch").attr("style", "color: lightslategrey; background-color:white");
    }

    function setDefaultMyDropDownList() {
        $("#branchList").val($("#branchList option:first").val());
        document.getElementById("select2-branchList-container").innerHTML = "Şube Değiştir";
    }

    /*})*/
}
//--------------------------------/-------------------------------------



