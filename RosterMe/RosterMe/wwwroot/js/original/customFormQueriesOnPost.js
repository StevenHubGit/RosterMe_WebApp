/* ---------- On POST Actions: Forms ---------- */
/* ---- Manager: Invite Employee to Shift ---- */
/**
 * The .class selector selects all elements with the specific class.
 * The class refers to the class attribute of an HTML element.
 * The class attribute is used to set a particular style for several HTML elements.
 * 
 * Note: Do not start a class attribute with a number. It may cause problems in some browsers.
 * */
/* ---- JQuery & Ajax function: Retrieve employee ID & redirect to invitation view ---- */
function EmployeeInvitation(empID, event)
{
    /**
     * Definition and Usage
     * The preventDefault() method cancels the event if it is cancelable, meaning that the default 
     * action that belongs to the event will not occur.
     * 
     * For example, this can be useful when:
     * - Clicking on a "Submit" button, prevent it from submitting a form
     * - Clicking on a link, prevent the link from following the URL
     * 
     * Note: Not all events are cancelable. Use the cancelable property to find out if an event is 
     * cancelable.
     * Note: The preventDefault() method does not prevent further propagation of an event through the DOM. 
     * Use the stopPropagation() method to handle this.
     * */
    event.preventDefault();

    //Check if input employee ID is null
    if (empID != null)
    {
        /**
         * Javascript Try/Catch/Finally syntax:
         * try 
         * {
         *      tryCode - Block of code to try
         * }
         * catch(err) 
         * {
         *      catchCode - Block of code to handle errors
         * }
         * finally 
         * {
         *      finallyCode - Block of code to be executed regardless of the try / catch result
         * }
         * */
        try
        {
            //Store input
            var empId = empID;

            //Define & store URL to Action in Controller
            var action = 'Url.Action("InviteEmployeeToShift")';
            var controllerAction = 'Url.Action("InviteEmployeeToShift", "Dashboard")';
            var urlWithVariable = "/Dashboard/InviteEmployeeToShift";
            var urlToAction = urlWithVariable;

            //Display message
            alert("Alright !" +
                "\nThe Employee Invitation JQuery method is reached" +
                "\nInformation to pass in Ajax" +
                "\n- URL: " + urlToAction +
                "\n- Data: " + empId
            );

            //Use Ajax to Post stored employee ID
            $.ajax
            ({
                /**
                    * URL: (Default: The current page)
                    * Type: String
                    * A string containing the URL to which the request is sent.
                    * */
                url: urlToAction + "?employeeID=" + empId,
                //url: urlToAction,
                //url: urlToAction + "/" + empId,

                /**
                    * Data: 
                    * Type: PlainObject or String or Array
                    * Data to be sent to the server. It is converted to a query string, if not 
                    * already a string.
                    * */
                data: { employeeID: empId },

                /**
                    * Async: (Default: true)
                    * Type: Boolean
                    * By default, all requests are sent asynchronously 
                    * (i.e. this is set to true by default).
                    * */
                async: false,

                /**
                    * Cache: (Default: true, false for dataType 'script' and 'jsonp')
                    * Type: Boolean
                    * If set to false, it will force requested pages not to be cached by the browser. 
                    * 
                    * Note: Setting cache to false will only work correctly with HEAD and GET requests.
                    * */
                cache: true,

                /**
                    * Content Type: (Default: 'application/x-www-form-urlencoded; charset=UTF-8')
                    * Type: Boolean or String
                    * When sending data to the server, use this content type. 
                    * Default is "application/x-www-form-urlencoded; charset=UTF-8", which is fine 
                    * for most cases. 
                    * 
                    * If you explicitly pass in a content-type to $.ajax(), then it is always sent 
                    * to the server (even if no data is sent).
                    * */
                contentType: "application/json; charset=utf-8",

                /**
                    * Type: (Default: 'GET')
                    * Type: String
                    * A set of key/value pairs that configure the Ajax request. 
                    * All settings are optional.
                    * */
                type: 'POST',

                /**
                    * Accepts: (Default: depends on dataType)
                    * Type: PlainObject
                    * A set of key/value pairs that map a given dataType to its MIME type, 
                    * which gets sent in the Accept request header. 
                    * 
                    * This header tells the server what kind of response it will accept in return
                    * */
                accepts: "application/json",

                /**
                    * Traditional:
                    * Type: Boolean
                    * Set this to true if you wish to use the traditional style of param serialization
                    * */
                traditional: true,

                //Set action on succes
                success: function (response)
                {
                    //Display message
                    alert("Alright !" +
                        "\nThe POST is a success" +
                        "\n- Input data: " + empId +
                        "\n- Data to pass: " + response.data
                    );

                    //Check if data to pass is not null
                    if (response != null && response.result == 'Redirect')
                    {
                        //Print message
                        console.log("Manager Dashboard View message: Invite employee" +
                            "\nThe employee ID to pass is not null" +
                            "\n- Employee ID: " + empId
                        );

                        //Display message
                        alert("Okay !" +
                            "\nThe data to pass is not null" +
                            "\n- Data: " + response.data +
                            "\n- Employee ID: " + empId +
                            "\n\nRedirection to URL" +
                            "\n- URL: " + response.url
                        );

                        //Redirect to page
                        //location.href = urlToAction + "?employeeID=" + empId;
                        window.location = response.url;
                    }
                },
                failure: function (response)
                {
                    //Display message
                    alert("Error !" +
                        "\nAn error occurred while trying to Post employee ID to invite" +
                        "\n- Casue: " + response + "\n"
                    );
                }
            });
        }
        catch (error)
        {
            //Print message
            console.log("Error !" +
                "\nAn error occurred while trying to POST employee to invite" +
                "\n- Cause: " + error.message
            );
        }
    }
    else
    {
        //Display message
        alert("Wait !" +
            "\nThe input employee ID is null"
        );
    }
}