using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using CodeHelper.Xml.Extension;
using CodeHelper.Xml;
#foreach($ns in $model.UsingNameSpaces)
using $ns;
#end

#macro(attribute $attr)
    public event ProperyChanged<$attr.Type> On${attr.Name}_ProperyChanged;
#set($modifier=" ")
#if( $attr.Name =="Id")
    #set($modifier=" override ")
#end
    public$modifier$attr.Type $attr.Name
    {
      get
      {
        if ( this.Dom.Attributes["$attr.Name"] == null )
            return default($attr.Type);
        return this.Dom.Attributes["$attr.Name"].Value.ToT<$attr.Type>();
      }
      set
      {
        var attr = this.Dom.Attributes.OfType<XmlAttribute>()
          .FirstOrDefault(x => x.Name == "${attr.Name}");
        var oldValue = default($attr.Type);
        var newValue = value;
        if (attr == null)
        {
            attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("$attr.Name"));                    
        }
        else
        {
            oldValue = this.Dom.Attributes["$attr.Name"].Value.ToT<$attr.Type>();
        }

        if ( value != null )
            attr.Value = value.ToString();
		
        if ( On${attr.Name}_ProperyChanged != null && oldValue != newValue)
        {
            On${attr.Name}_ProperyChanged(oldValue,newValue);
        }
        this.FireAnyProperyChanged("${attr.Name}",oldValue,newValue);
        }
    }
#end
#macro(element $el)

  public class $el.Name
  : DataNode
  {
  public $el.Name
  () : base()
  {
  }

  public $el.Name
  (XmlNode dom) : base(dom)
  {
  }

  public $el.Name
  (Document document):base(document)
  {
  }

  public override string XML_TAG_NAME
  {
    get
    {
      return "$el.Name";
    }
    set
    {
      throw new Exception("cannot set");
    }
  }

#foreach($attr in $el.XmlAttributes)
#attribute($attr)
#end

#foreach($fld in $el.Fields)
#field($el $fld)
#end
#end
#macro(field $el $fld)
#if (${fld.IsGenricList})
#set ($key="${el.FullName}_Create${fld.TypeInfo.GenericParameterType.Name}")
#if (!$dict.ContainsKey($key))
 	public ${fld.TypeInfo.GenericParameterType.Name} Create${fld.TypeInfo.GenericParameterType.Name}()
	{
		return this.Dom.CreateNode<${fld.TypeInfo.GenericParameterType.Name}>();
	}
    $dict.Add($key,true)
#end
	public NodeList<${fld.TypeInfo.GenericParameterType.Name}> ${fld.Name}
	{
		get
		{			
            NodeList<${fld.TypeInfo.GenericParameterType.Name}> ${fld.VariableName} = null;
            XmlNode ${fld.VariableName}_node = null;

            foreach (XmlNode node in this.Dom.ChildNodes)
            {
                if (node.Name == "${fld.Name}")
                {
                    ${fld.VariableName}_node = node;
                    ${fld.VariableName} = new NodeList<${fld.TypeInfo.GenericParameterType.Name}>(node);
                    break;
                }
            }

            if (${fld.VariableName}_node != null)
            {
                foreach (XmlNode node in ${fld.VariableName}_node.ChildNodes)
                {
                    ${fld.VariableName}.AddChild(new ${fld.TypeInfo.GenericParameterType.Name}(node));
                }
            }
            else
            {
                ${fld.VariableName} = this.Dom.CreateNode<NodeList<${fld.TypeInfo.GenericParameterType.Name}>>("${fld.Name}");

                this.AddChild(${fld.VariableName});
            }
            return ${fld.VariableName};
		}
		set
		{
			throw new Exception("cannot set");
		}
	}
#else	
#set ($key="${el.FullName}_Create${fld.Type}")
#if (!$dict.ContainsKey($key))
public ${fld.Type} Create${fld.Type}()
	{
		return this.Dom.CreateNode<${fld.Type}>();
	}
    $dict.Add($key,true)
#end            
	public ${fld.Type} ${fld.Name}
	{
		get
		{
#if($fld.Type.IsPrimitive)
			return this.Dom.Attributes["${fld.Name}"].ToT${fld.Type}();
#else
            foreach (XmlNode node in this.Dom.ChildNodes)
            {
                if (node.Name == "${fld.Type}" && 
                    node.Attributes["variable"] != null &&
                    node.Attributes["variable"].Value == "${fld.Name}")
                {
                    return new ${fld.Type}(node);
                }
            }
            return null;
#end
		}
		set
		{	
            if (this.${fld.Name} != null)
            {
                this.${fld.Name}.RemoveSelf();
            }

            var attr = this.Dom.OwnerDocument.CreateAttribute("variable");
            attr.Value = "${fld.Name}";
            value.Dom.Attributes.Append(attr);                

            this.Dom.AppendChild(value.Dom);	
		}
	}			
#end
#end
namespace $model.NameSpace
{
#foreach( $el in $model.Elements)
#element($el)
}
#end
}