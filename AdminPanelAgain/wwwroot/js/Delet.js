function DeleteRecord(Id) {
    debugger;
    var ans = confirm("Are you sure you want to delete?");
    if (ans) {
        $.ajax({
            url: "Register/Delet/" + Id,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                debugger;
                alertify.alert("Your Record Has been Deleted Succesfully");

                setTimeout(function () {// wait for 5 secs(2)
                    location.reload(); // then reload the page.(3)
                }, 2000);
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}











////function DeleteRecord(Id) {


////    debugger;

////    $("#DeleteModelLabel").text("Delete Record")
////    debugger;
////    $.ajax({
      
////        url: "Register/Delet/" + Id,
////        dataType: "Json",
////        method: "GET",
////        contentType: "application/json;charset=UTF-8",
////        success: function (result) {
////            debugger;

////            $('#DeleteModels').modal('show');
////            $('#DeleteRecordbtn').show();


////            //debugger;
////            //alertify.alert("Your Record Has been Deleted Succesfully");

////            //setTimeout(function () {// wait for 5 secs(2)
////            //    location.reload(); // then reload the page.(3)
////            //}, 2000);

////        },
////        error: function (errormessage) {
////            alert(errormessage.responseText);
////        }




////    });
////}



