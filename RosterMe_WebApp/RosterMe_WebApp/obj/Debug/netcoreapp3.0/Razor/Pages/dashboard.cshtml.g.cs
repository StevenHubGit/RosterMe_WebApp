#pragma checksum "C:\Users\Aspire2 Student\Desktop\Projects\Assigments\Web Programming\RosterMe_WebApp\RosterMe_WebApp\RosterMe_WebApp\Pages\Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cb857b983fa8558aea079af31a596fb25d0ca18f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(RosterMe_WebApp.Pages.Pages_Dashboard), @"mvc.1.0.razor-page", @"/Pages/Dashboard.cshtml")]
namespace RosterMe_WebApp.Pages
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
#line 1 "C:\Users\Aspire2 Student\Desktop\Projects\Assigments\Web Programming\RosterMe_WebApp\RosterMe_WebApp\RosterMe_WebApp\Pages\_ViewImports.cshtml"
using RosterMe_WebApp;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cb857b983fa8558aea079af31a596fb25d0ca18f", @"/Pages/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"48efb183770eb3e8acb1438cff189d970bec6818", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Dashboard : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("    <!-- Type of data to show -->\r\n");
            WriteLiteral(@"
<!-- Dashboard content -->
<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Strict//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd"">
<!--
Design by TEMPLATED
http://templated.co
Released for free under the Creative Commons Attribution License

Name       : Breadth
Description: A two-column, fixed-width design with dark color scheme.
Version    : 1.0
Released   : 20140331

-->
<html xmlns=""http://www.w3.org/1999/xhtml"">
");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cb857b983fa8558aea079af31a596fb25d0ca18f3682", async() => {
                WriteLiteral("\r\n    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />\r\n    <title></title>\r\n    <meta name=\"keywords\"");
                BeginWriteAttribute("content", " content=\"", 668, "\"", 678, 0);
                EndWriteAttribute();
                WriteLiteral(" />\r\n    <meta name=\"description\"");
                BeginWriteAttribute("content", " content=\"", 712, "\"", 722, 0);
                EndWriteAttribute();
                WriteLiteral(@" />
    <link href=""http://fonts.googleapis.com/css?family=Source+Sans+Pro:200,300,400,600,700,900"" rel=""stylesheet"" />
    <link href=""default.css"" rel=""stylesheet"" type=""text/css"" media=""all"" />
    <link href=""fonts.css"" rel=""stylesheet"" type=""text/css"" media=""all"" />

    <!--[if IE 6]><link href=""default_ie6.css"" rel=""stylesheet"" type=""text/css"" /><![endif]-->

");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cb857b983fa8558aea079af31a596fb25d0ca18f5531", async() => {
                WriteLiteral(@"
    <div id=""header-wrapper"">
        <div id=""header"" class=""container"">
            <div id=""logo"">
                <h1><a href=""#"">Breadth</a></h1>
            </div>
            <div id=""menu"">
                <ul>
                    <li class=""current_page_item""><a href=""#"" accesskey=""1""");
                BeginWriteAttribute("title", " title=\"", 1417, "\"", 1425, 0);
                EndWriteAttribute();
                WriteLiteral(">Homepage</a></li>\r\n                    <li><a href=\"#\" accesskey=\"2\"");
                BeginWriteAttribute("title", " title=\"", 1495, "\"", 1503, 0);
                EndWriteAttribute();
                WriteLiteral(">Our Clients</a></li>\r\n                    <li><a href=\"#\" accesskey=\"3\"");
                BeginWriteAttribute("title", " title=\"", 1576, "\"", 1584, 0);
                EndWriteAttribute();
                WriteLiteral(">About Us</a></li>\r\n                    <li><a href=\"#\" accesskey=\"4\"");
                BeginWriteAttribute("title", " title=\"", 1654, "\"", 1662, 0);
                EndWriteAttribute();
                WriteLiteral(">Careers</a></li>\r\n                    <li><a href=\"#\" accesskey=\"5\"");
                BeginWriteAttribute("title", " title=\"", 1731, "\"", 1739, 0);
                EndWriteAttribute();
                WriteLiteral(@">Contact Us</a></li>
                </ul>
            </div>
        </div>
    </div>
    <div id=""header-featured""> </div>

    <div id=""wrapper"">
        <div id=""featured-wrapper"">
            <div id=""featured"" class=""container"">
                <div class=""column1"">
                    <span class=""icon icon-cogs""></span>
                    <div class=""title"">
                        <h2>Maecenas lectus sapien</h2>
                    </div>
                    <p>In posuere eleifend odio. Quisque semper augue mattis wisi. Pellentesque viverra vulputate enim. Aliquam erat volutpat.</p>
                </div>
                <div class=""column2"">
                    <span class=""icon icon-legal""></span>
                    <div class=""title"">
                        <h2>Praesent scelerisque</h2>
                    </div>
                    <p>In posuere eleifend odio. Quisque semper augue mattis wisi. Pellentesque viverra vulputate enim. Aliquam erat volutpat.</p>
             ");
                WriteLiteral(@"   </div>
                <div class=""column3"">
                    <span class=""icon icon-unlock""></span>
                    <div class=""title"">
                        <h2>Fusce ultrices fringilla</h2>
                    </div>
                    <p>In posuere eleifend odio. Quisque semper augue mattis wisi. Pellentesque viverra vulputate enim. Aliquam erat volutpat.</p>
                </div>
                <div class=""column4"">
                    <span class=""icon icon-wrench""></span>
                    <div class=""title"">
                        <h2>Etiam posuere augue</h2>
                    </div>
                    <p>In posuere eleifend odio. Quisque semper augue mattis wisi. Pellentesque viverra vulputate enim. Aliquam erat volutpat.</p>
                </div>
            </div>
        </div>
        <div id=""extra"" class=""container"">
            <h2>Maecenas vitae orci vitae tellus feugiat eleifend</h2>
            <span>Quisque dictum integer nisl risus, sagittis conval");
                WriteLiteral(@"lis, rutrum id, congue, and nibh</span>
            <p>This is <strong>Breadth</strong>, a free, fully standards-compliant CSS template designed by <a href=""http://templated.co"" rel=""nofollow"">TEMPLATED</a>. The photos in this template are from <a href=""http://fotogrph.com/""> Fotogrph</a>. This free template is released under the <a href=""http://templated.co/license"">Creative Commons Attribution</a> license, so you're pretty much free to do whatever you want with it (even use it commercially) provided you give us credit for it. Have fun :) </p>

            <a href=""#"" class=""button"">Etiam posuere</a>
        </div>
    </div>

    <div id=""copyright"" class=""container"">
        <p>&copy; Untitled. All rights reserved. | Photos by <a href=""http://fotogrph.com/"">Fotogrph</a> | Design by <a href=""http://templated.co"" rel=""nofollow"">TEMPLATED</a>.</p>
    </div>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RosterMe_WebApp.Pages.DashboardModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<RosterMe_WebApp.Pages.DashboardModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<RosterMe_WebApp.Pages.DashboardModel>)PageContext?.ViewData;
        public RosterMe_WebApp.Pages.DashboardModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591