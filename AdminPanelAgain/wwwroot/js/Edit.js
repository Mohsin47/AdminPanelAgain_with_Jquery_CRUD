function Editdata(id) {

    debugger;



    $("#AddUpdateModelLabel").text("Update Client Detail")
    //ClearAllInput();
    $.ajax({
        url: "/Register/EditDatas/" + id,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            debugger;
            $("#AddUpdateModelLabel").val("Update Client Detail")
            $('#Id').val(result.id);
            $('#username').val(result.userName);
            $('#fullname').val(result.fullName);
            $('#LastName').val(result.lastName);
            $('#Password').val(result.password);
            $('#ConfirmPassword').val(result.confirmPassword);
            $('#Address').val(result.address);


            $("#Dropdown option:selected").text(result.country.name);
             $('#checkbox:checked').val(result.isCsharp);
             $('#checkboxe:checked').val(result.isPyhton);
             $('#checkboxes:checked').val(result.isjava);

            //$('#Id').html(result.Id);
            //$('#username').html(result.UserName);
            //$('#fullname').html(result.FullName);
            //$('#LastName').html(result.LastName);
            //$('#Password').html(result.Password);
            //$('#ConfirmPassword').html(result.ConfirmPassword);
            //$('#Address').html(result.Address);


            $('#AddUpdateModel').modal('show');
            $('#btnUpdateClient').show();
            //$('#btnAddClient').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });



}

function UpdateClient() {

    debugger;

    var UserObj = {
        Id: $('#Id').val(),
        UserName: $('#username').val(),
        FullName: $('#fullname').val(),
        LastName: $('#LastName').val(),
        Password: $('#Password').val(),
        ConfirmPassword: $('#ConfirmPassword').val(),
        Address: $('#Address').val(),
        //Details: $('#txtDetails').val(),
    };
 
    debugger;

    $.ajax({
        type: "POST",
        //dataType: "json",
        url: "/Register/UpdateClient",
        data: UserObj,
        //contentType: "application/json;charset=utf-8",
        success: function (result) {

            alertify.alert("Your Record Has been Updated Succesfully");

            setTimeout(function () {// wait for 5 secs(2)
                location.reload(); // then reload the page.(3)
            }, 2000);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

