#pragma checksum "C:\Users\kubalone\Desktop\RSS\delete\Views\Default\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2c4f94eba9b8c56ae8af376f6bfc5611f3028168"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Default_Index), @"mvc.1.0.view", @"/Views/Default/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Default/Index.cshtml", typeof(AspNetCore.Views_Default_Index))]
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
#line 1 "C:\Users\kubalone\Desktop\RSS\delete\Views\_ViewImports.cshtml"
using delete;

#line default
#line hidden
#line 2 "C:\Users\kubalone\Desktop\RSS\delete\Views\_ViewImports.cshtml"
using delete.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2c4f94eba9b8c56ae8af376f6bfc5611f3028168", @"/Views/Default/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6576d15e23dc970d9d8e75299b63488b31b0a4b3", @"/Views/_ViewImports.cshtml")]
    public class Views_Default_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<RSS.Data.Model.RssFeed>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(44, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\kubalone\Desktop\RSS\delete\Views\Default\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(87, 29, true);
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(116, 37, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2c4f94eba9b8c56ae8af376f6bfc5611f30281684640", async() => {
                BeginContext(139, 10, true);
                WriteLiteral("Create New");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(153, 95, true);
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n               rer ");
            EndContext();
            BeginContext(249, 42, false);
#line 16 "C:\Users\kubalone\Desktop\RSS\delete\Views\Default\Index.cshtml"
              Write(Html.DisplayNameFor(model => model.IsRead));

#line default
#line hidden
            EndContext();
            BeginContext(291, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(347, 43, false);
#line 19 "C:\Users\kubalone\Desktop\RSS\delete\Views\Default\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.PubDate));

#line default
#line hidden
            EndContext();
            BeginContext(390, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(446, 39, false);
#line 22 "C:\Users\kubalone\Desktop\RSS\delete\Views\Default\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.URL));

#line default
#line hidden
            EndContext();
            BeginContext(485, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(541, 41, false);
#line 25 "C:\Users\kubalone\Desktop\RSS\delete\Views\Default\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Title));

#line default
#line hidden
            EndContext();
            BeginContext(582, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(638, 47, false);
#line 28 "C:\Users\kubalone\Desktop\RSS\delete\Views\Default\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
            EndContext();
            BeginContext(685, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 34 "C:\Users\kubalone\Desktop\RSS\delete\Views\Default\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(803, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(852, 41, false);
#line 37 "C:\Users\kubalone\Desktop\RSS\delete\Views\Default\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.IsRead));

#line default
#line hidden
            EndContext();
            BeginContext(893, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(949, 42, false);
#line 40 "C:\Users\kubalone\Desktop\RSS\delete\Views\Default\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.PubDate));

#line default
#line hidden
            EndContext();
            BeginContext(991, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1047, 41, false);
#line 43 "C:\Users\kubalone\Desktop\RSS\delete\Views\Default\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.URL.ID));

#line default
#line hidden
            EndContext();
            BeginContext(1088, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1144, 40, false);
#line 46 "C:\Users\kubalone\Desktop\RSS\delete\Views\Default\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Title));

#line default
#line hidden
            EndContext();
            BeginContext(1184, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1240, 46, false);
#line 49 "C:\Users\kubalone\Desktop\RSS\delete\Views\Default\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Description));

#line default
#line hidden
            EndContext();
            BeginContext(1286, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1341, 53, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2c4f94eba9b8c56ae8af376f6bfc5611f302816810470", async() => {
                BeginContext(1386, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 52 "C:\Users\kubalone\Desktop\RSS\delete\Views\Default\Index.cshtml"
                                       WriteLiteral(item.ID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1394, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(1414, 59, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2c4f94eba9b8c56ae8af376f6bfc5611f302816812800", async() => {
                BeginContext(1462, 7, true);
                WriteLiteral("Details");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 53 "C:\Users\kubalone\Desktop\RSS\delete\Views\Default\Index.cshtml"
                                          WriteLiteral(item.ID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1473, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(1493, 57, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2c4f94eba9b8c56ae8af376f6bfc5611f302816815136", async() => {
                BeginContext(1540, 6, true);
                WriteLiteral("Delete");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 54 "C:\Users\kubalone\Desktop\RSS\delete\Views\Default\Index.cshtml"
                                         WriteLiteral(item.ID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1550, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 57 "C:\Users\kubalone\Desktop\RSS\delete\Views\Default\Index.cshtml"
}

#line default
#line hidden
            BeginContext(1589, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<RSS.Data.Model.RssFeed>> Html { get; private set; }
    }
}
#pragma warning restore 1591
