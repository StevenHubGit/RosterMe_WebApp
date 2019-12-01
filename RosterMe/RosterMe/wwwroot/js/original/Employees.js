function getEmployeeById(id) {
    $.ajax({
        url: "/Employees/GetDetails/",
        data: { id: id },
        type: "GET",
        dataType: "json",
        success: function (data) {
            $("#firstName").val(data.firstName);
            $("#lastName").val(data.lastName);
            $("#gender").val(data.gender);
            $("#email").val(data.email);
            $("#role").val(data.userRole);
            $("#phNo").val(data.phoneNumber);
            $("#contract").val(data.contract);
            $("#dob").val(data.dob);
            $("#joiningDate").val(data.joiningDate);
            $("#managerId").val(data.reportingManagerId);
            $("#deptId").val(data.departmentId);
            $("#salary").val(data.hourlySalary);
            $("#position").val(data.position);
            $("#PP").attr("src", data.profilePicture);
            $("#DisplayDetails").modal("show");
        },
        error: function (e) {
            alert(e);
        }
    });
}
