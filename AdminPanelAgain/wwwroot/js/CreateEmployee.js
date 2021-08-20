function AddNewClient() {
    debugger;

    





    var formData = new FormData();
    filepath = "";
    if (File != "") {
        var HoldNameofFile = "";
        var totalFiles = document.getElementById("Reportimage").files.length;
        for (var i = 0; i < totalFiles; i++) {
            var file = document.getElementById("Reportimage").files[i];
            HoldNameofFile = file.name;
            formData.append("Reportimage", file);

        }
    }


        var Obj = {};
        //// Obj.file_data = $('#file').prop('files')[0];
        //Obj.Image = new FormData();
        //Obj.Image.append('#file'/*, file_data*/);
        //////Obj.Image.append('#file', file_data);

        Obj.UserName = $("#username").val();
        Obj.FullName = $("#fullname").val();
        Obj.LastName = $("#LastName").val();
        Obj.Password = $("#Password").val();
        Obj.ConfirmPassword = $("#ConfirmPassword").val();
        Obj.Address = $("#Address").val();
        Obj.Country = $("#Dropdown option:selected").val();
        //Obj.IsCsharp = $('#checkboxes').val();
        Obj.IsCsharp = $('#checkbox:checked').val();
        Obj.IsPython = $('#checkboxe:checked').val();
        Obj.IsJava = $('#checkboxes:checked').val();
        //IsPython: $('#checkboxes').val(),
        /*IsJava: $('#checkboxes').val(),*/

        $.ajax({

            type: "POST",
            dataType: 'json',
            url: "/Register/CreateTest",
            data: Obj,


            success: function (Obj) {
         

            },
            error: function () {
                //your code here
            }
        });
        alertify.alert('Data Is Inserted!');
        $('#form1 input[type="text"]').val('');


    
}