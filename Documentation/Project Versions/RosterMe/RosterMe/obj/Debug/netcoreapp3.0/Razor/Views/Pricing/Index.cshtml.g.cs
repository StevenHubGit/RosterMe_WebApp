#pragma checksum "C:\ASPIRE2INTERNATIONAL\RosterMe\RosterMe_WebApp-master\RosterMe_WebApp-master\RosterMe\RosterMe\Views\Pricing\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "329d7d290c6091b9ea68bf97adba3f4138dc0baa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pricing_Index), @"mvc.1.0.view", @"/Views/Pricing/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"329d7d290c6091b9ea68bf97adba3f4138dc0baa", @"/Views/Pricing/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"29801cad392238b273305db97a2efbda364fff73", @"/Views/_ViewImports.cshtml")]
    public class Views_Pricing_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\ASPIRE2INTERNATIONAL\RosterMe\RosterMe_WebApp-master\RosterMe_WebApp-master\RosterMe\RosterMe\Views\Pricing\Index.cshtml"
  
    ViewData["Title"] = "Pricing";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- Start: Price-Area -->
<section class=""section-padding gray-bg"" id=""price-area"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-xs-12 col-sm-8 col-sm-offset-2"">
                <div class=""page-title text-center"">
                    <h2 class=""title"">Pricing Plan</h2>
                    <p>There are many variations of passages of Lorem Ipsum available.</p>
                </div>
            </div>
        </div>
        <div class=""row"">
            <div class=""col-xs-12"">
                <ul class=""price-tabs"">
                    <li class=""active""><a data-toggle=""pill"" href=""#monthly"">Monthly</a></li>
                    <li><a data-toggle=""pill"" href=""#yearly"">Yearly</a></li>
                </ul>
            </div>
        </div>
        <div class=""row prices tab-content"">
            <div id=""monthly"" class=""tab-pane fade in active"">
                <div class=""col-xs-6 col-md-3 wow fadeInLeft"" data-wow-delay=""0.2s"">
                    <div class=""price-box"">
");
            WriteLiteral(@"                        <h4>Basic</h4>
                        <h3 class=""amount"">&#36;10 /<span>Month</span></h3>
                        <ul class=""price-list"">
                            <li>Free Useable</li>
                            <li>Easily can useable 10GB</li>
                            <li>Free Secuirity Service</li>
                            <li>Dedicated Useable Account</li>
                        </ul>
                        <a href=""#"" class=""bttn bttn-sm bttn-default"">Purchase Now</a>
                    </div>
                </div>
                <div class=""col-xs-6 col-md-3 wow fadeInLeft"" data-wow-delay=""0.4s"">
                    <div class=""price-box active"">
                        <h4>Premium</h4>
                        <h3 class=""amount"">&#36;50 /<span>Month</span></h3>
                        <ul class=""price-list"">
                            <li>Free Useable</li>
                            <li>Easily can useable 10GB</li>
                            <li>Free Secuirity S");
            WriteLiteral(@"ervice</li>
                            <li>Dedicated Useable Account</li>
                        </ul>
                        <a href=""#"" class=""bttn bttn-sm bttn-default"">Purchase Now</a>
                    </div>
                </div>
                <div class=""col-xs-6 col-md-3 wow fadeInLeft"" data-wow-delay=""0.6s"">
                    <div class=""price-box"">
                        <h4>Business</h4>
                        <h3 class=""amount"">&#36;80 /<span>Month</span></h3>
                        <ul class=""price-list"">
                            <li>Free Useable</li>
                            <li>Easily can useable 10GB</li>
                            <li>Free Secuirity Service</li>
                            <li>Dedicated Useable Account</li>
                        </ul>
                        <a href=""#"" class=""bttn bttn-sm bttn-default"">Purchase Now</a>
                    </div>
                </div>
                <div class=""col-xs-6 col-md-3 wow fadeInLeft"" data-wow-delay=""0.8s"">
 ");
            WriteLiteral(@"                   <div class=""price-box"">
                        <h4>Ultimate</h4>
                        <h3 class=""amount"">&#36;100 /<span>Month</span></h3>
                        <ul class=""price-list"">
                            <li>Free Useable</li>
                            <li>Easily can useable 10GB</li>
                            <li>Free Secuirity Service</li>
                            <li>Dedicated Useable Account</li>
                        </ul>
                        <a href=""#"" class=""bttn bttn-sm bttn-default"">Purchase Now</a>
                    </div>
                </div>
            </div>
            <div id=""yearly"" class=""tab-pane fade"">
                <div class=""col-xs-6 col-md-3 wow fadeInLeft"" data-wow-delay=""0.2s"">
                    <div class=""price-box"">
                        <h4>Basic</h4>
                        <h3 class=""amount"">&#36;10 /<span>Year</span></h3>
                        <ul class=""price-list"">
                            <li>Free Useable</li>
 ");
            WriteLiteral(@"                           <li>Easily can useable 10GB</li>
                            <li>Free Secuirity Service</li>
                            <li>Dedicated Useable Account</li>
                        </ul>
                        <a href=""#"" class=""bttn bttn-sm bttn-default"">Purchase Now</a>
                    </div>
                </div>
                <div class=""col-xs-6 col-md-3 wow fadeInLeft"" data-wow-delay=""0.4s"">
                    <div class=""price-box active"">
                        <h4>Premium</h4>
                        <h3 class=""amount"">&#36;50 /<span>Year</span></h3>
                        <ul class=""price-list"">
                            <li>Free Useable</li>
                            <li>Easily can useable 10GB</li>
                            <li>Free Secuirity Service</li>
                            <li>Dedicated Useable Account</li>
                        </ul>
                        <a href=""#"" class=""bttn bttn-sm bttn-default"">Purchase Now</a>
                    </d");
            WriteLiteral(@"iv>
                </div>
                <div class=""col-xs-6 col-md-3 wow fadeInLeft"" data-wow-delay=""0.6s"">
                    <div class=""price-box"">
                        <h4>Business</h4>
                        <h3 class=""amount"">&#36;80 /<span>Year</span></h3>
                        <ul class=""price-list"">
                            <li>Free Useable</li>
                            <li>Easily can useable 10GB</li>
                            <li>Free Secuirity Service</li>
                            <li>Dedicated Useable Account</li>
                        </ul>
                        <a href=""#"" class=""bttn bttn-sm bttn-default"">Purchase Now</a>
                    </div>
                </div>
                <div class=""col-xs-6 col-md-3 wow fadeInLeft"" data-wow-delay=""0.8s"">
                    <div class=""price-box"">
                        <h4>Ultimate</h4>
                        <h3 class=""amount"">&#36;100 /<span>Year</span></h3>
                        <ul class=""price-list"">
       ");
            WriteLiteral(@"                     <li>Free Useable</li>
                            <li>Easily can useable 10GB</li>
                            <li>Free Secuirity Service</li>
                            <li>Dedicated Useable Account</li>
                        </ul>
                        <a href=""#"" class=""bttn bttn-sm bttn-default"">Purchase Now</a>
                    </div>
                </div>
            </div>

        </div>
    </div>
</section>
<!-- End: Price-Area -->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591