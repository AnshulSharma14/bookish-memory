#pragma checksum "D:\btech\MyProjectsOp\ProjectBookShoping\ProjectBookShoping\Areas\Customerr\Views\Home\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4fda06dab57e13b38a14db75029aabf6ba0ed881"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Customerr_Views_Home_Details), @"mvc.1.0.view", @"/Areas/Customerr/Views/Home/Details.cshtml")]
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
#line 1 "D:\btech\MyProjectsOp\ProjectBookShoping\ProjectBookShoping\Areas\Customerr\_ViewImports.cshtml"
using ProjectBookShoping;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\btech\MyProjectsOp\ProjectBookShoping\ProjectBookShoping\Areas\Customerr\_ViewImports.cshtml"
using ProjectBookShoping.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4fda06dab57e13b38a14db75029aabf6ba0ed881", @"/Areas/Customerr/Views/Home/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9784b7da958bdd1e20b808a9cac49cc57855b1ff", @"/Areas/Customerr/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Customerr_Views_Home_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProjectBookSolution_.Model.ShoppingCart>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success form-control "), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("height:50px;text-align:center; font-size:1.2rem;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"container\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4fda06dab57e13b38a14db75029aabf6ba0ed8815438", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "4fda06dab57e13b38a14db75029aabf6ba0ed8815700", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("hidden", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
#nullable restore
#line 4 "D:\btech\MyProjectsOp\ProjectBookShoping\ProjectBookShoping\Areas\Customerr\Views\Home\Details.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.ProductId);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <div class=\"pt-4\">\r\n    <div class=\"card container \">\r\n        <div class=\"card-header bg-primary text-light ml-0  row \">\r\n            <div class=\"col-12 col-md-6\">\r\n                <h1 class=\"text-white\">");
#nullable restore
#line 9 "D:\btech\MyProjectsOp\ProjectBookShoping\ProjectBookShoping\Areas\Customerr\Views\Home\Details.cshtml"
                                  Write(Model.product.Title);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h1>\r\n                <p class=\"text-warning\">by ");
#nullable restore
#line 10 "D:\btech\MyProjectsOp\ProjectBookShoping\ProjectBookShoping\Areas\Customerr\Views\Home\Details.cshtml"
                                      Write(Model.product.Author);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n            </div>\r\n            <div class=\"col-12 col-md-6 text-end pt-4\">\r\n                <span class=\"badge bg-warning pt-2\" style=\"height:2rem; width:7rem; font-size:.6rem;\">");
#nullable restore
#line 13 "D:\btech\MyProjectsOp\ProjectBookShoping\ProjectBookShoping\Areas\Customerr\Views\Home\Details.cshtml"
                                                                                                 Write(Model.product.Category.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</span>
            </div>
        </div>
        <div class=""card-body row container"">
            <div class=""container rounded p-2"">
                <div class=""row"">
                    <div class=""col-8 col-lg-8"">
                        <div class=""row pl-2"">
                            <h5 class=""text-muted pb-2"">List Price: <strike>");
#nullable restore
#line 21 "D:\btech\MyProjectsOp\ProjectBookShoping\ProjectBookShoping\Areas\Customerr\Views\Home\Details.cshtml"
                                                                       Write(Model.product.ListPrice.ToString("c"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</strike></h5>
                        </div>
                        <div class=""row text-center pl-2"">
                            <div class=""p-1 col-lg-2 col-4 bg-dark text-light border-bottom"">
                                <div>Quantity</div>
                            </div>
                            <div class=""p-1 col-lg-2 col-4 bg-warning border-bottom"">
                                <div>1-50</div>
                            </div>
                            <div class=""p-1 col-lg-2 col-4 bg-warning border-bottom"">
                                <div>51-100</div>
                            </div>
                        </div>
                        <div class=""row text-center pl-2"" style=""color:maroon; font-weight:bold"">
                            <div class=""p-1 col-lg-2 col-4 bg-light"">
                                <div>Price</div>
                            </div>
                            <div class=""p-1 col-lg-2 col-4 bg-light"">
                           ");
                WriteLiteral("     <div>");
#nullable restore
#line 39 "D:\btech\MyProjectsOp\ProjectBookShoping\ProjectBookShoping\Areas\Customerr\Views\Home\Details.cshtml"
                                Write(Model.product.Price.ToString("c"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n                            </div>\r\n                            <div class=\"p-1 col-lg-2 col-4 bg-light\">\r\n                                <div>");
#nullable restore
#line 42 "D:\btech\MyProjectsOp\ProjectBookShoping\ProjectBookShoping\Areas\Customerr\Views\Home\Details.cshtml"
                                Write(Model.product.Price50.ToString("c"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"row pl-2\">\r\n                            <p class=\"text-secondary\">");
#nullable restore
#line 46 "D:\btech\MyProjectsOp\ProjectBookShoping\ProjectBookShoping\Areas\Customerr\Views\Home\Details.cshtml"
                                                 Write(Html.Raw(Model.product.Description));

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                        </div>\r\n                        <div class=\"row pl-2\">\r\n                            <div class=\"col-lg-2 text-primary\"><h4>Count</h4></div>\r\n                            <div class=\"col-lg-2\">");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "4fda06dab57e13b38a14db75029aabf6ba0ed88112196", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 50 "D:\btech\MyProjectsOp\ProjectBookShoping\ProjectBookShoping\Areas\Customerr\Views\Home\Details.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Count);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("</div>\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"col-3 col-lg-3 offset-lg-1 text-center\">\r\n                        <img");
                BeginWriteAttribute("src", " src=\"", 2949, "\"", 2978, 1);
#nullable restore
#line 54 "D:\btech\MyProjectsOp\ProjectBookShoping\ProjectBookShoping\Areas\Customerr\Views\Home\Details.cshtml"
WriteAttributeValue("", 2955, Model.product.ImageUrl, 2955, 23, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" width=""100%"" class=""rounded detailsprdimg"" />
                    </div>
                </div>
            </div>
        </div>
        <div class=""card-footer"">
            <div class=""row"">
                <div class=""col-12 col-md-6 pb-1"">
                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4fda06dab57e13b38a14db75029aabf6ba0ed88114661", async() => {
                    WriteLiteral(@"
                            <svg xmlns=""http://www.w3.org/2000/svg"" width=""16"" height=""16"" fill=""currentColor"" class=""bi bi-arrow-left"" viewBox=""0 0 16 16"">
                                <path fill-rule=""evenodd"" d=""M15 8a.5.5 0 0 0-.5-.5H2.707l3.147-3.146a.5.5 0 1 0-.708-.708l-4 4a.5.5 0 0 0 0 .708l4 4a.5.5 0 0 0 .708-.708L2.707 8.5H14.5A.5.5 0 0 0 15 8z"" />
                            </svg> Home
                        ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                </div>
                <div class=""col-12 col-md-6 pb-1"">
                    <button type=""submit"" value=""Add to Cart"" class=""btn btn-primary form-control"" style=""height:50px;font-size:1.2rem;"">Add to Cart</button>
                </div>
            </div>
        </div>
    </div>
    </div>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProjectBookSolution_.Model.ShoppingCart> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591