$(function () {

    var userLoginButton = $("#UserLoginModel button[name='login ']").click(onUserLoginClick);

    function onUserLoginClick() {
        var userUrl = 'UserAuth/Login';
        var antiForgeryToken = $("#UserLoginModal input[name='__RequestVerificationToken']").val();

        var email = $("#UserLoginModal input[name = 'Email']").val();
        var password = $("#UserLoginModal input[name = 'Password']").val();
        var rememberMe = $("#UserLoginModal input[name = 'RememberMe']").prop('checked');
    }

});