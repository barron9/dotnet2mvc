#pragma checksum "C:\Users\berkin.tatlisu\source\repos\WebApplication3\WebApplication3\Views\Api\Do.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e4dab5441f8e78fc4ccd406c8c2ae0a532a9c2d7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Api_Do), @"mvc.1.0.view", @"/Views/Api/Do.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Api/Do.cshtml", typeof(AspNetCore.Views_Api_Do))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e4dab5441f8e78fc4ccd406c8c2ae0a532a9c2d7", @"/Views/Api/Do.cshtml")]
    public class Views_Api_Do : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\berkin.tatlisu\source\repos\WebApplication3\WebApplication3\Views\Api\Do.cshtml"
  
    ViewData["Title"] = "Do";

#line default
#line hidden
            BeginContext(40, 508, true);
            WriteLiteral(@"
<h2>Do</h2>
<h2>login page</h2>

<p>giriş yapınız</p>

<form action=""/api/register"" enctype=""application/x-www-form-urlencoded"">
    İsim:<br>
    <input type=""text"" name=""name"" value="""" placeholder=""isim..."">
    <br>
    id:<br>
    <input type=""text"" name=""id"" value="""" placeholder=""id..."">

    <input hidden type=""text"" name=""token"" value=""1"">

    <input hidden type=""text"" name=""isAuth"" value=""2"">
    <br><br>
    <input type=""submit"" value=""giriş"">
    <br />


</form>



");
            EndContext();
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
