/* ---------- On POST Actions: Forms ---------- */
/* ---- Manager: Invite Employee to Shift ---- */
/**
 * The .class selector selects all elements with the specific class.
 * The class refers to the class attribute of an HTML element.
 * The class attribute is used to set a particular style for several HTML elements.
 * 
 * Note: Do not start a class attribute with a number. It may cause problems in some browsers.
 * */
function InviteEmployeeById(empId)
{
    //Get & store ID
    var employeeID = empId;

    //Check if stored employee ID is not null
    if (employeeID != null)
    {
        /*
        //Display message
        alert("Alright !" +
            "\nThe input employee ID is not null" +
            "\nEmployee ID: " + employeeID
        );
        */

        //Print message
        console.log('Submitting form...');

        //Use Ajax to Post stored employee ID
        $.ajax
        ({
            //Set URL to Controller & Action
            //url: '@Url.Action("InviteEmployee", "ShiftInvitations", new { id = employeeID})',
            url: '/Controllers/EntitiesControllers/ShiftInvitations/InviteEmployee?id={employeeId}',

            //Pass employee ID in data
            data: employeeID,

            //Set content type
            //contentType: "application/json; charset=utf-8",
            contentType: '"application/json; charset=utf-8',

            //Set method type
            type: 'POST',

            //Set action on succes
            success: function (result)
            {
                //Set HTML content to pass
                $('#EmployeeID').html("JSON Data sent to server");

                //Display data
                alert("Data to pass to Controller" +
                    "\n- Employee ID: " + result
                );
            },
            failure: function (result)
            {
                //Display message
                alert("Error !" +
                    "\nAn error occurred while trying to Post employee ID to invite" +
                    "\n- Casue: " + result
                );
            }
        })
    }
    else
    {
        //Display message
        alert("Wait !" +
            "\nThe input employee ID is null"
        );
    }
}