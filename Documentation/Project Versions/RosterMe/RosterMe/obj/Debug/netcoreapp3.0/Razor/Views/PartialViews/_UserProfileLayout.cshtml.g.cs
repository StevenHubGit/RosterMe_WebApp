#pragma checksum "C:\ASPIRE2INTERNATIONAL\RosterMe\RosterMe_WebApp-master\RosterMe_WebApp-master\RosterMe\RosterMe\Views\PartialViews\_UserProfileLayout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "deca96a33d550569ae6f54db742fe0a954fc0ef8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PartialViews__UserProfileLayout), @"mvc.1.0.view", @"/Views/PartialViews/_UserProfileLayout.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\ASPIRE2INTERNATIONAL\RosterMe\RosterMe_WebApp-master\RosterMe_WebApp-master\RosterMe\RosterMe\Views\_ViewImports.cshtml"
using RosterMe;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\ASPIRE2INTERNATIONAL\RosterMe\RosterMe_WebApp-master\RosterMe_WebApp-master\RosterMe\RosterMe\Views\_ViewImports.cshtml"
using RosterMe.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"deca96a33d550569ae6f54db742fe0a954fc0ef8", @"/Views/PartialViews/_UserProfileLayout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"29801cad392238b273305db97a2efbda364fff73", @"/Views/_ViewImports.cshtml")]
    public class Views_PartialViews__UserProfileLayout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RosterMe.Models.Dashboard>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/original/man_icon_400x400.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/original/woman_icon_400x400.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!-- model RosterMe.Models.Dashboard -->\n");
#nullable restore
#line 3 "C:\ASPIRE2INTERNATIONAL\RosterMe\RosterMe_WebApp-master\RosterMe_WebApp-master\RosterMe\RosterMe\Views\PartialViews\_UserProfileLayout.cshtml"
  
    //Display Home Layout
    //Layout = "~/Views/Shared/_DashboardLayout.cshtml";

    //Set tab title
    //ViewData["Title"] = "Dashboard";

    //Store employee details as Model
    List<RosterMe.Models.Entities.Employee> employeeDetailsModel =
        (List<RosterMe.Models.Entities.Employee>)ViewData["EmployeeDetails"];

    //
    String position = "";

    //
    if (employeeDetailsModel != null)
    {
        /*
        <p>
            There are data in Employee Details model
            @for(int i = 0; i < employeeDetailsModel.Count; i++)
            {
                @employeeDetailsModel[i].FirstName
            }
        </p>
        */
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p>\n            No data in Employee Details Model\n        </p>\n");
#nullable restore
#line 35 "C:\ASPIRE2INTERNATIONAL\RosterMe\RosterMe_WebApp-master\RosterMe_WebApp-master\RosterMe\RosterMe\Views\PartialViews\_UserProfileLayout.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<!-- User Profile Section -->\n<section");
            BeginWriteAttribute("class", " class=\"", 873, "\"", 881, 0);
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 882, "\"", 887, 0);
            EndWriteAttribute();
            WriteLiteral(">\n    <div");
            BeginWriteAttribute("class", " class=\"", 898, "\"", 906, 0);
            EndWriteAttribute();
            WriteLiteral(">\n        <div class=\"row\">\n            <div class=\"column\">\n                <div");
            BeginWriteAttribute("class", " class=\"", 988, "\"", 996, 0);
            EndWriteAttribute();
            WriteLiteral(">\n                    <h2 class=\"title wow fadeInUp\">\n                        Your Details\n                    </h2>\n                    <div class=\"userDetailsPhoto\">\n");
#nullable restore
#line 48 "C:\ASPIRE2INTERNATIONAL\RosterMe\RosterMe_WebApp-master\RosterMe_WebApp-master\RosterMe\RosterMe\Views\PartialViews\_UserProfileLayout.cshtml"
                         foreach (var detail in employeeDetailsModel)
                        {
                            //Check gender
                            if (detail.Gender == "Male")
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "deca96a33d550569ae6f54db742fe0a954fc0ef86747", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n");
#nullable restore
#line 54 "C:\ASPIRE2INTERNATIONAL\RosterMe\RosterMe_WebApp-master\RosterMe_WebApp-master\RosterMe\RosterMe\Views\PartialViews\_UserProfileLayout.cshtml"
                            }
                            else if (detail.Gender == "Female")
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "deca96a33d550569ae6f54db742fe0a954fc0ef88185", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n");
#nullable restore
#line 58 "C:\ASPIRE2INTERNATIONAL\RosterMe\RosterMe_WebApp-master\RosterMe_WebApp-master\RosterMe\RosterMe\Views\PartialViews\_UserProfileLayout.cshtml"
                            }
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </div>
                </div>
            </div>
            <hr />
            <div class=""column"">
                <div class=""wow fadeInUp"" data-wow-delay=""0.5s"">
                    <table class=""userDetailsTable"">
                        <thead class=""userDetailsHeader"">
                            <tr>
                                <th style=""width: 300px;"">
                                    Profile
                                </th>
                                <th>

                                </th>
                            </tr>
                        </thead>
                        <tbody class=""userDetailsBody"">
                            <!-- #### User Details #### -->
");
#nullable restore
#line 79 "C:\ASPIRE2INTERNATIONAL\RosterMe\RosterMe_WebApp-master\RosterMe_WebApp-master\RosterMe\RosterMe\Views\PartialViews\_UserProfileLayout.cshtml"
                             for (int i = 0; i < employeeDetailsModel.Count(); i++)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\n                                    <td>\n                                        Name\n                                    </td>\n                                    <td>\n");
            WriteLiteral("                                            <p>\n                                                ");
#nullable restore
#line 88 "C:\ASPIRE2INTERNATIONAL\RosterMe\RosterMe_WebApp-master\RosterMe_WebApp-master\RosterMe\RosterMe\Views\PartialViews\_UserProfileLayout.cshtml"
                                           Write(employeeDetailsModel[i].FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 88 "C:\ASPIRE2INTERNATIONAL\RosterMe\RosterMe_WebApp-master\RosterMe_WebApp-master\RosterMe\RosterMe\Views\PartialViews\_UserProfileLayout.cshtml"
                                                                              Write(employeeDetailsModel[i].LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                            </p>\n");
            WriteLiteral(@"                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Job Title
                                    </td>
                                    <td>
");
            WriteLiteral("                                            <p>\n                                                ");
#nullable restore
#line 100 "C:\ASPIRE2INTERNATIONAL\RosterMe\RosterMe_WebApp-master\RosterMe_WebApp-master\RosterMe\RosterMe\Views\PartialViews\_UserProfileLayout.cshtml"
                                           Write(employeeDetailsModel[i].Position);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                            </p>\n");
            WriteLiteral(@"                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Department
                                    </td>
                                    <td>
");
            WriteLiteral("                                            <p>\n                                                ");
#nullable restore
#line 112 "C:\ASPIRE2INTERNATIONAL\RosterMe\RosterMe_WebApp-master\RosterMe_WebApp-master\RosterMe\RosterMe\Views\PartialViews\_UserProfileLayout.cshtml"
                                           Write(employeeDetailsModel[i].DepartmentId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                            </p>\n");
            WriteLiteral(@"                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Joining Date
                                    </td>
                                    <td>
");
            WriteLiteral("                                            <p>\n                                                ");
#nullable restore
#line 124 "C:\ASPIRE2INTERNATIONAL\RosterMe\RosterMe_WebApp-master\RosterMe_WebApp-master\RosterMe\RosterMe\Views\PartialViews\_UserProfileLayout.cshtml"
                                           Write(employeeDetailsModel[i].JoiningDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                            </p>\n");
            WriteLiteral(@"                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Contact
                                    </td>
                                    <td>
");
            WriteLiteral("                                            <p>\n                                                ");
#nullable restore
#line 136 "C:\ASPIRE2INTERNATIONAL\RosterMe\RosterMe_WebApp-master\RosterMe_WebApp-master\RosterMe\RosterMe\Views\PartialViews\_UserProfileLayout.cshtml"
                                           Write(employeeDetailsModel[i].PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                            </p>\n");
            WriteLiteral(@"                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Email
                                    </td>
                                    <td>
");
            WriteLiteral("                                            <p>\n                                                ");
#nullable restore
#line 148 "C:\ASPIRE2INTERNATIONAL\RosterMe\RosterMe_WebApp-master\RosterMe_WebApp-master\RosterMe\RosterMe\Views\PartialViews\_UserProfileLayout.cshtml"
                                           Write(employeeDetailsModel[i].Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                            </p>\n");
            WriteLiteral(@"                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Access Level
                                    </td>
                                    <td>
");
            WriteLiteral("                                            <p>\n                                                ");
#nullable restore
#line 160 "C:\ASPIRE2INTERNATIONAL\RosterMe\RosterMe_WebApp-master\RosterMe_WebApp-master\RosterMe\RosterMe\Views\PartialViews\_UserProfileLayout.cshtml"
                                           Write(employeeDetailsModel[i].UserRole);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                            </p>\n");
            WriteLiteral("                                    </td>\n                                </tr>\n");
#nullable restore
#line 165 "C:\ASPIRE2INTERNATIONAL\RosterMe\RosterMe_WebApp-master\RosterMe_WebApp-master\RosterMe\RosterMe\Views\PartialViews\_UserProfileLayout.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tbody>\n                    </table>\n                </div>\n            </div>\n        </div>\n        <div class=\"hidden-xs col-sm-6 col-md-offset-1\">\n            <img src=\"images/about-image.png\"");
            BeginWriteAttribute("alt", " alt=\"", 6761, "\"", 6767, 0);
            EndWriteAttribute();
            WriteLiteral(">\n        </div>\n    </div>\n</section>\n<!-- End: User Profile Section -->");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RosterMe.Models.Dashboard> Html { get; private set; }
    }
}
#pragma warning restore 1591