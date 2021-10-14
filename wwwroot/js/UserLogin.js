
$(function () {
    var userLoginButton = $("#UserLoginModel button[name='login']").click(onUserLoginClick);

    function onUserLoginClick() {
 
        var userUrl = 'UserAuth/Login';
        var antiForgeryToken = $("#UserLoginModel input[name='__RequestVerificationToken']").val();

        var email = $("#UserLoginModel input[name = 'Email']").val();
        var password = $("#UserLoginModel input[name = 'Password']").val();
        var rememberMe = $("#UserLoginModel input[name = 'RememberMe']").prop('checked');
      
        var userInput = {
            __RequestVerificationToken: antiForgeryToken,
            Email: email,
            Password: password,
            RememberMe: rememberMe
        };

        $.ajax({
            type: "POST",
            url: userUrl,
            data: userInput,
            success: function (data) {
                var parsed = $.parseHTML(data);
                var hasErrors = $(parsed).find("input[name='LoginInValid']").val() == "true";

                if (hasErrors == true) {
                    $("#UserLoginModel").html(data);

                    userLoginButton = $("#UserLoginModel button[name='login']").click(onUserLoginClick);

                    var form = $("#UserLoginForm");

                    $(form).removeData("validator");
                    $(form).removeData("unobtrusiveValidation");
                    $.validator.unobtrusive.parse(form);

                }
                else {
                    location.href = 'Home/Index';

                }
            },
      
            error: function (xhr, ajaxOptions, thrownError) {
                debugger;
                var errorText = "Status: " + xhr.status + " - " + xhr.statusText;

               PresentClosableBootstrapAlert("#alert_placeholder_login", "danger", "Error!", errorText);

                console.error(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
            }

        });
    }

});