//Load Data in Table when documents is ready  
$(document).ready(function () {
    loadData();
}); 
//Load Data function  
function loadData() {
    $.ajax({
        url: "/Home/List",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.oid + '</td>';
                html += '<td nowrap>' + item.oName + '</td>';
                html += '<td nowrap>' + item.oDoctor + '</td>';
                html += '<td nowrap><a href="#" class="btn btn-success me-3" onclick="return getbyID(' + item.oid + ')">修改</a> <a href="#"class="btn btn-danger" onclick="Delele(' + item.oid + ')">刪除</a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Add Data Function   
function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var optObj = {
        oid: $('#oid').val(),
        oName: $('#oName').val(),
        oDoctor: $('#oDoctor').val(),
    };
    $.ajax({
        url: "/Home/Add",
        data: JSON.stringify(optObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            window.location.reload();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}  

//Function for getting the Data Based upon ID  
function getbyID(oid) {
    $('#oName').css('border-color', 'lightgrey');
    $('#oDoctor').css('border-color', 'lightgrey');
    $.ajax({
        url: "/Home/getbyID/" + oid,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#oid').val(result.oid);
            $('#oName').val(result.oName);
            $('#oDoctor').val(result.oDoctor);
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
        oid: $('#oid').val(),
        oName: $('#oName').val(),
        oDoctor: $('#oDoctor').val(),
    };
    $.ajax({
        url: "/Home/Update",
        data: JSON.stringify(optObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            $('#oid').val("");
            $('#oName').val("");
            $('#oDoctor').val("");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}  

//function for deleting outpatient's data 
function Delele(ID) {
    var ans = confirm("確定要刪除這筆資料嗎??");
    if (ans) {
        $.ajax({
            url: "/Home/Delete/" + ID,
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

//Function for clearing the textboxes  
function clearTextBox() {
    $('#oid').val("");
    $('#oName').val("");
    $('#oDoctor').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#oName').css('border-color', 'lightgrey');
    $('#oDoctor').css('border-color', 'lightgrey');
}  

//Valdidation using jquery  
function validate() {
    var isValid = true;
    if ($('#oName').val().trim() == "") {
        $('#oName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#oName').css('border-color', 'lightgrey');
    }
    if ($('#oDoctor').val().trim() == "") {
        $('#oDoctor').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#oDoctor').css('border-color', 'lightgrey');
    }
    return isValid;
}  