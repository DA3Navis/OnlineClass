// JavaScript source code<script type="text/javascript">
function getDateValue(value, format) {
    var arrFormatParts = format.toLowerCase().split('/'),
        arrValueParts = value.split('/');

    var date = new Date();
    for (var i = 0; i < arrFormatParts.length; i++) {
        if (arrFormatParts[i].indexOf('d') != -1)
            date.setDate(parseInt(arrValueParts[i]));
        else if (arrFormatParts[i].indexOf('m') != -1)
            date.setMonth(parseInt(arrValueParts[i]) - 1);
        else
            date.setYear(parseInt(arrValueParts[i]));
    }
    return date;
}

$(document).ready(function () {
    //$('#btn-login').bind('click', function () {
    //    var txtUserName = $('#login-username'),
    //        txtPassword = $('#login-password');
    //    if ($.trim(txtUserName.val()) == '') {
    //        txtUserName.focus();
    //        $('#login-alert').html('Bạn chưa nhập <b>Tên tài khoản</b> đăng nhập.').show();
    //        return false;
    //    }
    //    else if ($.trim(txtPassword.val()) == '') {
    //        txtPassword.focus();
    //        $('#login-alert').html('Bạn chưa nhập <b>Mật khẩu</b> để đăng nhập.').show();
    //    }
    //    else
    //        return true;
    //});

    $('#login-remember').bind('click', function () {
        $('#hfRemember').val($(this).is(':checked'));
    });

    $('#datetimepicker').datetimepicker({
        format: 'DD/MM/YYYY'
    });


    $(".dropdown-menu li a").click(function () {
        $(".dropdown-value", $(this).closest('div')).text($(this).text());
        $(".dropdown-value", $(this).closest('div')).attr('value', $(this).attr('value'));
    });

    $('#ddlYear').find('a')
        .bind('click', function () {
            var selectedValue = $(this).attr('value');
            if (selectedValue) {
                $('#ddlClass').find('.dropdown-menu').empty();

                $(".dropdown-value", $('#ddlClass')).text('Chọn lớp học');
                $(".dropdown-value", $('#ddlClass')).removeAttr('value');

                $.client.ajax({
                    type: 'POST',
                    url: baseUrl + 'Class/getClassByYear',
                    data: { yearId: selectedValue },
                    success: function (data) {
                        if (data) {
                            $.each(data, function (i, v) {
                                var $li = $('<li/>').appendTo($('.dropdown-menu', $('#ddlClass')));
                                var $a = $('<a href="javascript:" value="' + v.ID + '">' + v.Name + '</a>').appendTo($li);
                                $($a).bind('click', function () {
                                    $(".dropdown-value", $(this).closest('div')).text($(this).text());
                                    $(".dropdown-value", $(this).closest('div')).attr('value', $(this).attr('value'));
                                });
                            })
                        }
                    }
                })
            }
        });

    //$('#btn-signup').bind('click', function () {
    //    var $modal = $('#notifyModal');
    //    //Change title for modal
    //    $('.modal-title', $modal).text('Đăng ký tài khoản');
    //    //Check validate conditions
    //    var selectedClass = $('.dropdown-value', $('#ddlClass')).attr('value'),
    //        userName = $('#txtUserName').val(),
    //        email = $('#txtEmail').val(),
    //        password = $('#txtRegPassword').val(),
    //        confirmpassword = $('#txtConfirmPassword').val(),
    //        fullName = $('#txtFullName').val(),
    //        birthDay = $('#txtBirthday').val();
    //    var isValid = true;
    //    if (!selectedClass) {
    //        $('.modal-body').find('.alert').html('Hãy chọn thông tin về <b>Lớp học</b> của bạn.');
    //        isValid = false;
    //    }
    //    else if (!userName || userName == '') {
    //        $('.modal-body').find('.alert').html('Hãy nhập tên <b>Tài khoản</b> muốn đăng ký.');
    //        isValid = false;
    //    }
    //    else if (password == '' || confirmpassword == '' || password != confirmpassword) {
    //        $('.modal-body').find('.alert').html('<b>Mật khẩu</b> hoặc <b>Xác nhận mật khẩu</b> không hợp lệ.');
    //        isValid = false;
    //    }
    //    else if (!email || email == '') {
    //        $('.modal-body').find('.alert').html('Hãy nhập địa chỉ E-mail cho Tài khoản muốn đăng ký.');
    //        isValid = false;
    //    }
    //    else if (!fullName || fullName == '') {
    //        $('.modal-body').find('.alert').html('Hãy nhập <b>Họ và Tên</b> của bạn để đăng ký tài khoản.');
    //        isValid = false;
    //    }
    //    else if (!birthDay || birthDay == '') {
    //        $('.modal-body').find('.alert').html('Hãy nhập <b>Ngày sinh</b> của bạn để đăng ký tài khoản.');
    //        isValid = false;
    //    }

    //    if (isValid == false) {
    //        $modal.modal('show');
    //    }
    //    else {
    //        //Check username is used or not
    //        $.ajax({
    //            type: 'POST',
    //            url: baseUrl + 'Student/CheckAvaibleUserName',
    //            data: { 'UserName': userName },
    //            beforeSend: function () {
    //                //Show loading
    //                $('#loadingModal').modal('show');
    //            },
    //            success: function (data) {
    //                if (data.isUsed == true) {
    //                    $('#loadingModal').modal('hide');
    //                    $('.modal-body').find('.alert').html('<b>Tài khoản</b> của bạn đã được sử dụng. Hãy chọn một tên khác');
    //                    $modal.modal('show');
    //                }
    //                else {
    //                    $.ajax({
    //                        type: 'POST',
    //                        url: baseUrl + 'Student/CheckAvaiableEmail',
    //                        data: { 'Email': email },
    //                        success: function (data) {
    //                            if (data.isUsed == true) {
    //                                $('#loadingModal').modal('hide');
    //                                $('.modal-body').find('.alert').html('<b>E-mail "' + email + '"</b> đã được sử dụng. Hãy sử dụng một E-mail khác, hoặc sử dụng chức năng quên mật khẩu để lấy lại Password');
    //                                $modal.modal('show');
    //                            }
    //                            else {
    //                                // Save student info
    //                                var studentInfo = {
    //                                    ClassID: parseInt(selectedClass),
    //                                    UserName: userName,
    //                                    Password: password,
    //                                    Email: email,
    //                                    AvatarPath: '',
    //                                    FullName: fullName,
    //                                    Sex: $('#ddlGender').find('.dropdown-value').attr('value'),
    //                                    BirthDay: getDateValue(birthDay, 'dd/mm/yyyy').toJSON(),
    //                                    MobilePhone: $.trim($('#txtMobilePhone').val()),
    //                                    SchoolName: $.trim($('#txtSchoolName').val()),
    //                                    CurrentJob: $.trim($('#txtCurrentJob').val()),
    //                                    FacebookUrl: $.trim($('#txtFacebookLink').val())
    //                                }

    //                                $.ajax({
    //                                    type: 'POST',
    //                                    url: baseUrl + 'Account/SaveAccount',
    //                                    data: studentInfo,
    //                                    success: function (data) {
    //                                        if (data.result == false) {
    //                                            $('.modal-body').find('.alert').html(data.msg);
    //                                            $modal.modal('show');
    //                                        }
    //                                        else {
    //                                            $('.modal-body').find('.alert').html('Tài khoản <b>' + userName + '</b> đã được khởi tạo thành công. Bạn hãy kiểm tra E-mail để đặt mật khẩu');
    //                                            $('#loadingModal').modal('hide');
    //                                            $modal.modal('show');

    //                                            filesToUpload[0].formData = { UserName: userName };
    //                                            filesToUpload[0].submit();


    //                                            $modal.find('.btn-primary').bind('click', function () {
    //                                                $('#signupbox').hide(); $('#forgetBox').hide(); $('#loginbox').show()
    //                                            });
    //                                        }
    //                                    }
    //                                });
    //                            }
    //                        }
    //                    });
    //                }
    //            }
    //        });

    //    }
    //});

    var filesToUpload = [];
    $('#fileupload').fileupload({
        url: baseUrl + 'Account/UploadCV',
        dataType: 'json',
        formData: {},
        autoUpload: false
    }).on('fileuploadadd', function (e, data) {
        var dispalyName = $('<div/>').appendTo('#files');
        $.each(data.files, function (index, file) {
            var node = $('<p/>')
                .append($('<span/>').text(file.name));
            if (!index) {
                node
                    .append('<br>');
            }
            node.appendTo(dispalyName);
        });
        filesToUpload.push(data)
    }).on('fileuploaddone', function (e, data) {
        $.each(data.result.files, function (index, file) {
            if (file.url) {
                var link = $('<a>')
                    .attr('target', '_blank')
                    .prop('href', file.url);
                $(data.context.children()[index])
                    .wrap(link);
            } else if (file.error) {
                var error = $('<span class="text-danger"/>').text(file.error);
                $(data.context.children()[index])
                    .append('<br>')
                    .append(error);
            }
        });
    }).on('fileuploadfail', function (e, data) {
        $.each(data.files, function (index) {
            var error = $('<span class="text-danger"/>').text('File upload failed.');
            $(data.context.children()[index])
                .append('<br>')
                .append(error);
        });
    });
});
