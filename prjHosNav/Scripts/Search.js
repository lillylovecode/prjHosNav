//Load Data in Table when documents is ready  
$(document).ready(function () {
    loadData();
}); 
//Load Data function  
function loadData() {
    $.ajax({
        url: "/Home/SearchList",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.SId + '</td>';
                html += '<td>' + item.SType + '</td>';
                html += '<td>' + item.SDisease + '</td>';
                html += '<td>' + item.SSymptom + '</td>';
                html += '<td><a href="#" class="btn btn-success" onclick="return getbyID(' + item.SId + ')">Edit</a> <a href="#"class="btn btn-danger" onclick="Delele(' + item.SId + ')">Delete</a></td>';
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
        SId: $('#SId').val(),
        SType: $('#SType').val(),
        SDisease: $('#SDisease').val(),
        SSymptom: $('#SSymptom').val(),
    };
    $.ajax({
        url: "/Home/SearchAdd",
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
function getbyID(SId) {
    $('#SType').css('border-color', 'lightgrey');
    $('#SDisease').css('border-color', 'lightgrey');
    $.ajax({
        url: "/Home/SearchGetById/" + SId,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#SId').val(result.SId);
            $('#SType').val(result.SType);
            $('#SDisease').val(result.SDisease);
            $('#SSymptom').val(result.SSymptom);
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
        SId: $('#SId').val(),
        SType: $('#SType').val(),
        SDisease: $('#SDisease').val(),
        SSymptom: $('#SSymptom').val(),
    };
    $.ajax({
        url: "/Home/SearchUpdate",
        data: JSON.stringify(optObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            $('#SId').val("");
            $('#SType').val("");
            $('#SDisease').val("");
            $('#SSymptom').val("");
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
            url: "/Home/SearchDelete/" + ID,
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
    $('#SId').val("");
    $('#SType').val("");
    $('#SDisease').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#SType').css('border-color', 'lightgrey');
    $('#SDisease').css('border-color', 'lightgrey');
    $('#SearchDelete').css('border-color', 'lightgrey');
}  

//Valdidation using jquery  
function validate() {
    var isValid = true;
    if ($('#SType').val().trim() == "") {
        $('#SType').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#SType').css('border-color', 'lightgrey');
    }
    if ($('#SDisease').val().trim() == "") {
        $('#SDisease').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#SDisease').css('border-color', 'lightgrey');
    }
    return isValid;
}  