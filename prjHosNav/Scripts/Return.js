//Add Data Function
function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var optObj = {
        RId: $('#RId').val(),
        MId: $('#MId').val(),
        RType: $('#RType').val(),
        RHospital: $('#RHospital').val(),
        RDate: $('#RDate').val(),
    };
    $.ajax({
        url: "/Return/Add",
        data: JSON.stringify(optObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            $('#myModal').modal('hide');
            window.location.reload();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

//Function for getting the Data Based upon ID  
function getbyID(RId) {
    $('#RType').css('border-color', 'lightgrey');
    $('#RHospital').css('border-color', 'lightgrey');
    $.ajax({
        url: "/Return/GetById/" + RId,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#RId').val(result.RId);
            $('#MId').val(result.RId);
            $('#RType').val(result.RType);
            $('#RHospital').val(result.RHospital);
            $('#RDate').val(result.RDate);
            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

//function for updating outpatient's data  
function Update() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var optObj = {
        RId: $('#RId').val(),
        MId: $('#MId').val(),
        RType: $('#RType').val(),
        RHospital: $('#RHospital').val(),
        RDate: $('#RDate').val(),
    };
    $.ajax({
        url: "/Return/Update",
        data: JSON.stringify(optObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            $('#myModal').modal('hide');
            $('#RId').val("");
            $('#RType').val("");
            $('#RHospital').val("");
            $('#RDate').val("");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//function for deleting outpatient's data 
function Delele(ID) {
    var ans = confirm("確認刪除?");
    if (ans) {
        $.ajax({
            url: "/Return/Delete/" + ID,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
            loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}



//Valdidation using jquery  
function validate() {
    var isValid = true;
    if ($('#RType').val().trim() == "") {
        $('#RType').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#RType').css('border-color', 'lightgrey');
    }
    if ($('#RHospital').val().trim() == "") {
        $('#RHospital').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#RHospital').css('border-color', 'lightgrey');
    }
    return isValid;
}