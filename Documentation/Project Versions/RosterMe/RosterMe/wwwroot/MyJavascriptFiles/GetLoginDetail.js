var userRole = "";
var employeeId = 0;

function openTimesheetsDetails() {
    userRole = $("#uRole").val();
    employeeId = $("#empId").val();
    $.post({
        url: "/Timesheets/List/",
        data: {
            userRole: userRole,
            employeeId: employeeId
        },
        success: function (data) {
            window.location = data;
        }
    });
}

function openEmployeesDetails() {
    userRole = $("#uRole").val();
    employeeId = $("#empId").val();
    $.post({
        url: "/Employees/List/",
        data: {
            userRole:userRole
        },
        success: function (data) {
            window.location = data;
        }
    });
}
