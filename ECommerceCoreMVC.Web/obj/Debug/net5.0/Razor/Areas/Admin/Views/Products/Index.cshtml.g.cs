#pragma checksum "C:\Users\Nadir\source\repos\ECommerceCoreMVC\ECommerceCoreMVC.Web\Areas\Admin\Views\Products\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6f2a13bfba587cadeb49c740d01730e82a47f797"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Products_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Products/Index.cshtml")]
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
#line 1 "C:\Users\Nadir\source\repos\ECommerceCoreMVC\ECommerceCoreMVC.Web\Areas\Admin\Views\_ViewImports.cshtml"
using ECommerceCoreMVC.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Nadir\source\repos\ECommerceCoreMVC\ECommerceCoreMVC.Web\Areas\Admin\Views\_ViewImports.cshtml"
using ECommerceCoreMVC.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Nadir\source\repos\ECommerceCoreMVC\ECommerceCoreMVC.Web\Areas\Admin\Views\_ViewImports.cshtml"
using ECommerceCoreMVC.Data.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6f2a13bfba587cadeb49c740d01730e82a47f797", @"/Areas/Admin/Views/Products/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e8725074e3c3c956871a3955a9622e9ed0e55a42", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Products_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "ViewHeaderPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "DatatablesPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Nadir\source\repos\ECommerceCoreMVC\ECommerceCoreMVC.Web\Areas\Admin\Views\Products\Index.cshtml"
  
    var entity = "Ürün";
    ViewData["Title"] = $"{entity} Tanımları";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"card card-default\">\r\n    <div class=\"card-body\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "6f2a13bfba587cadeb49c740d01730e82a47f7974408", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 7 "C:\Users\Nadir\source\repos\ECommerceCoreMVC\ECommerceCoreMVC.Web\Areas\Admin\Views\Products\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = entity;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        <table class=\"table table-striped table-bordered\" id=\"productTable\">\r\n        </table>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "6f2a13bfba587cadeb49c740d01730e82a47f7976231", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    <script src=""//cdn.jsdelivr.net/npm/sweetalert2@10""></script>
    <script>
        $(() => {
            $('#productTable').DataTable({
                'processing': true,
                'serverSide': true,
                'ajax': {
                    'url': '");
#nullable restore
#line 22 "C:\Users\Nadir\source\repos\ECommerceCoreMVC\ECommerceCoreMVC.Web\Areas\Admin\Views\Products\Index.cshtml"
                       Write(Url.Action("List", "Products"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"',
                    'method' : 'POST'
                },
                'language': {
                    'url': 'https://cdn.datatables.net/plug-ins/1.10.24/i18n/Turkish.json'
                },
                'initComplete': (s, j) => {
                    $('.remove-btn').on('click', (e) => {
                        Swal.fire({
                            html: `${$(e.currentTarget).attr(""data-name"")} isimli kayıt tamamen silinecektir. Silme işlemine devam etmek istiyormusunuz?`,
                            showCancelButton: true,
                            confirmButtonText: '<i class=""fa fa-trash""></i> Sil',
                            cancelButtonText: 'İptal',
                            icon: 'warning'
                        })
                            .then((result) => {
                                if (result.value) {
                                    location = $(e.currentTarget).attr(""href"");
                                }
                            });
     ");
                WriteLiteral(@"                   return false;
                    });
                },
                'order' : [[1, 'asc']],
                'columns': [
                    {
                        'title': 'Görsel',
                        'data': 'picture',
                        'sortable' : false,
                        'width': '60px',
                        'render': (data, type, row, meta) => {
                            return `<img src=""${data}"" class=""img-thumbnail"" />`;
                        }
                    },
                    {
                        'title' : 'Ürün Adı',
                        'data': 'name',
                    },
                    {
                        'title' : 'Kategori',
                        'data': 'categories',
                    },
                    {
                        'title' : 'Marka',
                        'data': 'brandName',
                    },
                    {
                        'title' : 'Kullanı");
                WriteLiteral(@"cı',
                        'data': 'userName',
                    },
                    {
                        'title' : 'Fiyat',
                        'data': 'price',
                    },
                    {
                        'title': 'Görüntülenme',
                        'data': 'reviews',
                    },
                    {
                        'title': 'Güncelle',
                        'data': 'id',
                        'sortable' : false,
                        'render': (data, type, row, meta) => {
                            return `<a href=""/admin/products/edit/${data}"" class=""btn btn-link mr-2"">
                                        <i class=""fa fa-edit""></i>
                                    </a>`;
                        }
                    },
                    {
                        'title': 'Sil',
                        'data': 'id',
                        'sortable' : false,
                        'render': (data, typ");
                WriteLiteral(@"e, row, meta) => {
                            return `<a href=""/admin/products/remove/${data}"" data-name=""${row['name']}"" class=""remove-btn btn btn-link mr-2"">
                                        <i class=""fa fa-trash""></i>
                                    </a>`;
                        }
                    },
                ]
            });
        });
    </script>
");
            }
            );
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
