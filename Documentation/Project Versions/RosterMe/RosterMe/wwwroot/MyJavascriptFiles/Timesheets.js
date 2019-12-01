function hideUpdateBtn(id) {
    $("#update").hide();
    $("#employeeId").val(id);
}

function validation() {
    var isValid = false;
    var approvalStatus = $("#approvalStatus").val().slice(" ");
    if ($("#employeeId").val() != "" || $("#shiftId").val() != "" || $("#timeIn").val() != "" || $("#timeOut").val() != "" || $("#attendanceDate").val() != "") {
        isValid = true;
    }
    if (approvalStatus == "Select Status")
    {
        isValid = false;
    }
    return isValid;
}

function closeModal() {
    location.reload();
}

function addRecords() {
    var isTrue = validation();
    if (isTrue==true) {
        var e = document.getElementById("approvalStatus");
        var approvalStatus = e.options[e.selectedIndex].value;
        $.ajax({
            url: "/Timesheets/addTimesheet/",
            data: {
                employeeId: $("#employeeId").val(),
                shiftId: $("#shiftId").val(),
                timeIn: $("#timeIn").val(),
                timeOut: $("#timeOut").val(),
                attendanceDate: $("#attendanceDate").val(),
                approvalStatus: approvalStatus
            },
            datatype: "json",
            type: "GET",
            success: function (data) {
                alert(data);
                $("#attendanceId").val("");
                $("#employeeId").val("");
                $("#shiftId").val("");
                $("#timeIn").val("");
                $("#timeOut").val("");
                $("#attendanceDate").val("");
                $("#approvedStatus").val("");
                $("#AddUpdate").modal("hide");
                location.reload();
            }
        });
    }
    else {
        alert("Please enter all fields!");
    }
}

function getTimesheetById(id) {
    $("#add").hide();
    $.ajax({
        url: "/Timesheets/getTimesheetById/",
        data: {
            id:id
        },
        datatype: "json",
        type: "GET",
        success: function (data) {
            var timeIn = calculateTime(data.timeIn);
            var timeOut = calculateTime(data.timeOut);
            $("#attendanceId").val(data.attendanceId);
            $("#employeeId").val(data.employeeId);
            $("#shiftId").val(data.shiftId);
            $("#timeIn").val(timeIn);
            $("#timeOut").val(timeOut);
            $("#attendanceDate").val(new Date(data.attendanceDate).toLocaleDateString());
            $("#approvalStatus").val(data.approvalStatus);
        }
    });
}

function getTimesheet(id) {
    $("#add").hide();
    $.ajax({
        url: "/Timesheets/getTimesheetById/",
        data: {
            id: id
        },
        datatype: "json",
        type: "GET",
        success: function (data) {
            var timeIn = calculateTime(data.timeIn);
            var timeOut = calculateTime(data.timeOut);
            $("#employeeId").val(data.employeeId);
            $("#shiftId").val(data.shiftId);
            $("#timeIn").val(timeIn);
            $("#timeOut").val(timeOut);
            $("#attendanceDate").val(new Date(data.attendanceDate).toLocaleDateString());
            $("#approvalStatus").val(data.approvalStatus);
        }
    });
}

//Update timesheet records
function updateRecords() {
    if (validation) {
        var e = document.getElementById("approvalStatus");
        var approvalStatus = e.options[e.selectedIndex].value;
        $.ajax({
            url: "/Timesheets/updateTimesheet/",
            data: {
                attendanceId: $("#attendanceId").val(),
                employeeId: $("#employeeId").val(),
                shiftId: $("#shiftId").val(),
                timeIn: $("#timeIn").val(),
                timeOut: $("#timeOut").val(),
                attendanceDate: $("#attendanceDate").val(),
                approvalStatus: approvalStatus
            },
            datatype: "json",
            type: "GET",
            success: function (data) {
                alert(data);
                $("#attendanceId").val("");
                $("#employeeId").val("");
                $("#shiftId").val("");
                $("#timeIn").val("");
                $("#timeOut").val("");
                $("#attendanceDate").val("");
                $("#approvedStatus").val("");
                $("#AddUpdate").modal("hide");
                location.reload();
            }
        });
    }
    else {
        alert("Please enter all fields!");
    }
}

function calculateTime(time) {
    var timeInHours = (time)["hours"];
    var timeInMinutes = (time)["minutes"];
    var timeInSeconds = (time)["seconds"];
    if (timeInHours < 10) { timeInHours = "0" + timeInHours; }
    if (timeInMinutes < 10) { timeInMinutes = "0" + timeInMinutes }
    if (timeInSeconds < 10) { timeInSeconds = "0" + timeInSeconds }
    var timeIn = timeInHours + ":" + timeInMinutes + ":" + timeInSeconds;
    timeIn = timeIn.toString();
    return timeIn;
}

function deleteRecords(id) {
    if (confirm("Are you sure you want to delete this records!")) {
        $.ajax({
            url: "/Timesheets/deleteTimesheet/",
            data: {
                id: id
            },
            datatype: "json",
            type: "GET",
            success: function (data) {
                alert(data);
                location.reload();
            }
        });
    }
    
}