function refreshLocation() {
    location.reload();
}

function validation() {
    var isValid = false;
    var userEmail = $("#userEmail").val();
    var emailFormat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    if (userEmail.match(emailFormat) && userEmail != "") {
        isValid = true;
    }
    
    return isValid;
}

function sendLink() {
    if (validation) {
        $.ajax({
            url: "/Logins/sendLink/",
            data: {
                email: $("#userEmail").val(),
                firstName: $("#firstName").val(),
                lastName: $("#lastName").val()
            },
            datatype: "json",
            type: "GET",
            success: function (data) {
                alert(data);
                $("#userEmail").val("");
                $("#firstName").val("");
                $("#lastName").val("");
                refreshLocation();
            }
        })
    }
}