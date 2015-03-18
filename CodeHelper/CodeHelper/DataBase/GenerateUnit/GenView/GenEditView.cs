using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project;
using CodeHelper.DataBaseHelper.Items.DBItems;

namespace CodeHelper.DataBaseHelper.GenerateUnit.GenView
{
    class GenEditView: BaseGen
    {
        ModelType Model = null;
        ColumnSetNode ColumnSetNode = null;
        public GenEditView(ModelType model, ColumnSetNode columnSetNode)
        {
            this.Model = model;
            this.ColumnSetNode = columnSetNode;
        }

        public override void Generate(StringBuilder builder)
        {
            var modelType = "Edit" + this.Model.Name + "Model";
            modelType = CodeHelper.DataBaseHelper.Common.Helper.GetClassName(modelType);

            var modelName = CodeHelper.DataBaseHelper.Common.Helper.GetClassName(this.Model.Name);

            builder.AppendLine("@model " + modelType);
            builder.AppendLine("@{");
            builder.AppendLine("\tLayout = \"~/Views/Shared/_SimpleLayout.cshtml\";");
            builder.AppendLine();

            builder.AppendLine("\tif(this.Model.Id.HasValue){");
            builder.AppendLine("\t\tViewBag.Title = \"Edit Item\";");
            builder.AppendLine("\t}");
            builder.AppendLine("\telse{");
            builder.AppendLine("\t\tViewBag.Title = \"Add Item\";");
            builder.AppendLine("\t}");
            builder.AppendLine("}");
            builder.AppendLine();

            builder.AppendLine("@section js{");
            builder.AppendLine("<script src=\"../../Scripts/jquery.validate.js\" type=\"text/javascript\"></script>");
            builder.AppendLine("<script src=\"../../Scripts/msgbox.js\" type=\"text/javascript\"></script>");
            builder.AppendLine("<script language = \"javascript\" type=\"text/javascript\">");
            builder.AppendLine(@"        function OnClose(refresh) {
            if (parent.MsgBox != undefined) {

                if (refresh) {
                    if (parent.MsgBox.Callback != null) {
                        parent.MsgBox.Callback();
                        parent.MsgBox.Callback = null;
                    }
                }
                parent.MsgBox.Callback = null;

                parent.MsgBox.Close();

            }
            else {
                window.close();
            }
        }
        
        $(function () {

            if (parent.MsgBox != undefined) {
                parent.MsgBox.CancelCallback = true;
            }

            $('#btnSaveAndClose').click(function () {

                $('#IsSave').val(true);

                $('#editForm').submit();

            });

            $('#btnCancel').click(function () {

                OnClose();

            });

            if ($('#IsSave').val() == 'True') {
                var msg = $('#ErrorMsg').val();
                if (msg == '') {
                    jAlert('Save Success','Tip',function(){
                        OnClose(true);
                    });                    
                }
                else {
                    jAlert(msg);
                }
            }

            $('#somecontrolId').attr('readonly','true').addClass('readonly');

            $('select').each(function(){
                            $(this).val($(this).attr('_value'));
            });
");
            //validate script
            builder.AppendLine(@"            var validator = $('#editForm').validate({
                debug: true,       //调试模式取消submit的默认提交功能  
                errorClass: 'error', //默认为错误的样式类为：error  
                focusInvalid: false,
                onkeyup: false,
                submitHandler: function (form) {   //表单提交句柄,为一回调函数，带一个参数：form  
                    //alert('提交表单');
                    form.submit();   //提交表单  
                },
                rules: {           //定义验证规则,其中属性名为表单的name属性      ");
            var i = 0;
            foreach (var f in this.Model.Fields)
            {
                var name = CodeHelper.DataBaseHelper.Common.Helper.GetClassName(f.Name);

                if (name.Equals("id", StringComparison.OrdinalIgnoreCase))
                    continue;

                builder.AppendFormat(string.Format("                    {0}:", name));
                builder.AppendLine("{");                

                if (!f.NullAble)
                {
                    builder.AppendLine("                    \trequired: true,");
                }
                if (f.SystemType == "Decimal" || f.SystemType == "float" || f.SystemType == "Double")
                {
                    builder.AppendLine("                    \tnumber: true,");                    
                }
                if (f.SystemType == "int" || f.SystemType == "long")
                {
                    builder.AppendLine("                    \tdigits: true,");
                }
                if (name.EndsWith("email", StringComparison.OrdinalIgnoreCase))
                {
                    builder.AppendLine("                    \temail: true,");
                }
                builder.Append("                    }");
                i++;
                if (i < this.Model.Fields.Count -1)
                    builder.Append(",");

                builder.AppendLine();
            }

            builder.AppendLine();
            builder.AppendLine("				},");
            builder.AppendLine(@"
                messages: {       //自定义验证消息  
                    PurchasePlan: {
                        //required: 'required !',
                        //minlength: $.format('用户名至少要{0}个字符！'),
                        //remote: $.format('{0}已经被占用')
                    },                   
                },
               errorPlacement: function (error, element) {
                    var noHtml = '<div class=""notification error"" for=""' + error.attr('for') + '"">' +
                            ""<a class=\""close\"" ><img alt=\""close\"" title=\""Close this notification\"" src=\""/Content/images/cross_grey_small.png\""></a>"" +
                            '<div>' + error.html() + '</div>' + '</div>';
                    var notification = element.parent().find('div');
                    if (notification.length > 0) {
                        notification.remove();
                    }
                    element.parent().find('span').hide();
                    $(noHtml).appendTo(element.parent());
                    error.html('');
                    error.appendTo(element.parent());
                },
                highlight: function (element, errorClass) {  //针对验证的表单设置高亮  
                    //$(element).addClass(errorClass);
                },
                success: function (element) {
                    element.parent().find('span').show();
                    element.parent().find('div.error,label.validateError').remove();
                }});
        });
    </script>
");
            builder.AppendLine("}");
            builder.AppendLine();

            builder.AppendLine("@section css{");
            //builder.AppendLine("\t<link href=\"@Url.Content(\"~/Content/css/base/jquery.ui.all.css\")\" rel=\"stylesheet\" type=\"text/css\" />");
            builder.AppendLine(@"     
    <style type=""text/css"">   
    body
    {
        background: none;
    }
    .field
    {
        vertical-align: middle;
        clear: both;
        padding-left: 5px;
        padding-top: 5px;
        padding-bottom: 5px;
    }
    .field_name
    {
        width: 160px;
        float: left;
        padding-right: 10px;
        padding-top: 10px;
        margin: 0 auto;
    }
    .field_value
    {
        width: 260px;
        float: left;
    }
    custom-combobox input
    {
        width: 120px;
    }
    .operation
    {
        margin-top: 20px;
        padding-top: 20px;
        clear: both;
    }
    input
    {
        width: 206px;
    }
    select
    {
        width: 220px;
    }
    .readonly
    {
        background-color: #e6e6e6;
    }
    </style>
");
            builder.AppendLine("}");
            builder.AppendLine();

            builder.AppendLine("\t<div class=\"tabmini-content\">");
            builder.AppendLine(string.Format("\t\t<form method=\"post\" id=\"editForm\" class=\"form\" action=\"/xxx/Edit{0}Item\">", modelName));
            builder.AppendLine(@"
    <input type='hidden' id='Id' name='Id' value='@Model.Id' />
    <input type='hidden' id='IsPostBack' name='IsPostBack' value='true' />    
    <input type='hidden' id='IsSave' name='IsSave' value='@Model.IsSave' />
    <input type='hidden' id='ErrorMsg' name='ErrorMsg' value='@Model.ErrorMsg' />
");
            builder.AppendLine("\t\t<fieldset  class=\"ConfigArea\">");
            var pkCol = "";
            foreach (var col in this.ColumnSetNode.Columns)
            {
                if (col.IsPK)
                {
                    pkCol = col.Name;
                    break;
                }
            }

            foreach (var f in this.Model.Fields)
            {
                if (f.Name.Equals(pkCol, StringComparison.OrdinalIgnoreCase))
                    continue;

                var fieldName = CodeHelper.DataBaseHelper.Common.Helper.GetClassName(f.Name);
                builder.AppendLine("\t\t\t<div class=\"field\">");
                builder.AppendLine("\t\t\t\t<div class=\"field_name\">");
                builder.AppendLine(string.Format("\t\t\t\t\t<label>{0}:</label>", fieldName));
                builder.AppendLine("\t\t\t\t</div>");

                builder.AppendLine("\t\t\t\t<div class=\"field_value\">");
                if (f.SystemType.Equals("Guid", StringComparison.OrdinalIgnoreCase))
                {
                    var defaultFkName = fieldName.EndsWith("id", StringComparison.OrdinalIgnoreCase) ? fieldName.Substring(0, fieldName.Length - 2) :
                       fieldName;

                    builder.AppendLine(string.Format("\t\t\t\t\t<select id=\"{0}\" name=\"{0}\" _value=\"@Model.{0}\">", fieldName));
                    builder.AppendLine("\t\t\t\t\t\t<option value=\"\">--Please Select--</option>");
                    builder.AppendLine(string.Format("\t\t\t\t\t@foreach(var item in Model.{0}_List)", defaultFkName));
                    builder.AppendLine("\t\t\t\t\t\t{");
                    //builder.AppendLine("\t\t\t\t\t\t\tvar selected = \"\";");
                    //builder.AppendLine(string.Format("\t\t\t\t\t\t\tif (Model.{0} == item.Id)", fieldName));
                    //builder.AppendLine("\t\t\t\t\t\t\t{");
                    //builder.AppendLine("\t\t\t\t\t\t\t\tselected = \"selected = 'true'\";");
                    //builder.AppendLine("\t\t\t\t\t\t\t}");

                    builder.AppendLine(string.Format("\t\t\t\t\t\t\t<option value=\"@item.Id\">@item.{0}</option>", defaultFkName));
                    //builder.AppendLine("\t\t\t\t\t\t\t");                   
                    builder.AppendLine("\t\t\t\t\t\t}");
                    builder.AppendLine("\t\t\t\t\t</select>");
                }
                else if (f.SystemType.Equals("DateTime", StringComparison.OrdinalIgnoreCase))
                {
                    builder.AppendLine(string.Format("\t\t\t\t\t<input type=\"text\" name=\"{0}\" id=\"{0}\" value=\"@Model.{0}\"/>", fieldName));
                }
                else if (f.SystemType.Equals("Boolean", StringComparison.OrdinalIgnoreCase))
                {
                    builder.AppendLine(string.Format("\t\t\t\t\t<input type=\"checkbox\" name=\"{0}\" id=\"{0}\" value=\"@Model.{0}\"/>", fieldName));
                }
                else //default use textbox
                {
                    builder.AppendLine(string.Format("\t\t\t\t\t<input type=\"text\" name=\"{0}\" id=\"{0}\" value=\"@Model.{0}\"/>", fieldName));
                }

                builder.AppendLine("\t\t\t\t</div>");

                builder.AppendLine("\t\t\t</div>");
            }
            builder.AppendLine(@"        <div class='operation'>
            <a class='button blue' id='btnSaveAndClose'>Save&Close</a> <a class='button blue'
                id='btnCancel'>Cancel</a>
        </div>");
            builder.AppendLine("\t\t</fieldset>");

            builder.AppendLine("\t</form>");
            builder.AppendLine("</div>");
            //builder.AppendLine("");
            //builder.AppendLine("");
            //builder.AppendLine("");
            //builder.AppendLine("");
            //builder.AppendLine("");
            //builder.AppendLine("");
        }
    }
}
