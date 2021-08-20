function Details(id) {
    debugger;

    $("#DetailModelLabel").text("Details of Employee")

    debugger;

    $.ajax({

        url: "/Register/Detaisl/" + id,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {

            debugger;
            $("#DetailModelLabel").val("Details Of Employee")
            //$('#Id').val(result.Id);
            $('#user').val(result.userName);
            $('#full').val(result.fullName);
            $('#Last').val(result.lastName);
            $('#Pass').val(result.password);
            $('#Confirm').val(result.confirmPassword);
            $('#Add').val(result.address);


            $("#Drop option:selected").text(result.country.name);
            $('#checkbo:checked').text(result.isCsharp);
            $('#checkboo:checked').val(result.isPyhton);
            $('#checkbooo:checked').val(result.isjava);



            $('#DetailsModels').modal('show');
            $('#btnUpdateClient').show();

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}