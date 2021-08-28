#pragma checksum "C:\Users\Nadir\source\repos\ECommerceCoreMVC\ECommerceCoreMVC.Web\Areas\Admin\Views\Shared\ProductPicturePartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9f86f2d8bd4d7862cbd722faf698cbd43a0769c4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Shared_ProductPicturePartial), @"mvc.1.0.view", @"/Areas/Admin/Views/Shared/ProductPicturePartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9f86f2d8bd4d7862cbd722faf698cbd43a0769c4", @"/Areas/Admin/Views/Shared/ProductPicturePartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e8725074e3c3c956871a3955a9622e9ed0e55a42", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Shared_ProductPicturePartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<script>
    $(() => {
        $('#PictureFile').on('change', (e) => {
            var reader = new FileReader();
            reader.onloadend = (evt) => {
                $('#picturePreview').attr('src', reader.result);
            };
            reader.readAsDataURL(document.getElementById('PictureFile').files[0]);
        });
        $('#PictureFiles').on('change', (e) => {
            $('.picture-file-preview').remove();
            for (var i = 0; i < document.getElementById('PictureFiles').files.length; i++) {
                var reader = new FileReader();
                reader.onloadend = (evt) => {
                    $('#pictureFilesPanel').append(`<div class=""m-2 p-2 border shadow-sm picture-file-preview""><img height=""80"" src=""${evt.currentTarget.result}"" /></div>`);
                }
                reader.readAsDataURL(document.getElementById('PictureFiles').files[i]);
            }
        });
        $('#clearPictureFilePreviews').on('click', (e) => {
            $('#Picture");
            WriteLiteral("Files\').val(null);\r\n            $(\'.picture-file-preview\').remove();\r\n        });\r\n    });\r\n</script>");
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
