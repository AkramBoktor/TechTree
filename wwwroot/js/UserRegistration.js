$(function () {


    var registerUserButton = $("#UserRegisterationModel button[name = 'register']").click(onUserRegisterClick);

    $("#UserRegisterationModel input[name = 'AcceptUserAgreement']").click(onAcceptUserArgeementClick);
    $("#UserRegisterationModel button[name = 'register']").prop("disabled", true);

    function onAcceptUserArgeementClick() {
        if ($(this).is(":checked")) {
            $("#UserRegisterationModel button[name = 'register']").prop("disabled", false);

        } else {
            $("#UserRegisterationModel button[name = 'register']").prop("disabled", true);

        }
    }

    //check user name exists or not in database
    $("#UserRegisterationModel input[name = 'Email']").blur(function () {

        var email = $("#UserRegisterationModel input[name='Email']").val();
        var url = "UserAuth/UserNameCheck?userName=" + email;

        $.ajax({
            type: "GET",
            url: url,
            success: function (data) {
                if (data == true) {

                    PresentClosableBootstrapAlert("#alert_placeholder_register", "warning", "Invalid Email", "This email address has already been registered");

                }
                else {
                    CloseAlert("#alert_placeholder_register");
                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                var errorText = "Status: " + xhr.status + " - " + xhr.statusText;

                PresentClosableBootstrapAlert("#alert_placeholder_register", "danger", "Error!", errorText);

                console.error(thrownError + '\r\n' + xhr.statusText + '\r\n' + xhr.responseText);

            }
        });

    });

    function onUserRegisterClick() {
        var url = "UserAuth/RegisterUser";

        var antiForgeryToken = $("#UserRegisterationModel input[name='__RequestVerificationToken']").val();
        var email = $("#UserRegisterationModel input[name='Email']").val();
        var password = $("#UserRegisterationModel input[name='Password']").val();
        var confirmPassword = $("#UserRegisterationModel input[name='ConfirmPassword']").val();
        var firstName = $("#UserRegisterationModel input[name='FirstName']").val();
        var lastName = $("#UserRegisterationModel input[name='LastName']").val();
        var address1 = $("#UserRegisterationModel input[name='Address1']").val();
        var address2 = $("#UserRegisterationModel input[name='Address2']").val();
        var postCode = $("#UserRegisterationModel input[name='PostCode']").val();
        var phoneNumber = $("#UserRegisterationModel input[name='PhoneNumber']").val();

        var user = {
            __RequestVerificationToken: antiForgeryToken,
            Email: email,
            Password: password,
            ConfirmPassword: confirmPassword,
            FirstName: firstName,
            LastName: lastName,
            Address1: address1,
            Address2: address2,
            PostCode: postCode,
            PhoneNumber: phoneNumber,
            AcceptUserAgreement: true
        };

        $.ajax({
            type: "POST",
            url: url,
            data: user,
            success: function (data) {

                var parsed = $.parseHTML(data);

                var hasErrors = $(parsed).find("input[name='RegistrationInValid']").val() == 'true';

                if (hasErrors) {

                    $("#UserRegisterationModel").html(data);
                    var registerUserButton = $("#UserRegisterationModel button[name = 'register']").click(onUserRegisterClick);
                    $("#UserRegisterationModel input[name = 'AcceptUserAgreement']").click(onAcceptUserAgreementClick);

                    $("#UserRegistrationForm").removeData("validator");
                    $("#UserRegistrationForm").removeData("unobtrusiveValidation");
                    $.validator.unobtrusive.parse("#UserRegistrationForm");
                }
                else {
                    location.href = '/Home/Index';
                }

            },
            error: function (xhr, ajaxOptions, thrownError) {
                var errorText = "Status: " + xhr.status + " - " + xhr.statusText;

                PresentClosableBootstrapAlert("#alert_placeholder_register", "danger", "Error!", errorText);

                console.error(thrownError + '\r\n' + xhr.statusText + '\r\n' + xhr.responseText);
            }

        });

    }

});