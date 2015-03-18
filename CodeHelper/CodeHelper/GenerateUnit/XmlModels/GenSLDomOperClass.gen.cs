using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using CodeHelper.Xml.Extension;
using CodeHelper.Xml;

#foreach($ns in $model.UsingNameSpaces)
using $ns;
#end

#macro(attribute $attr)
public event ProperyChanged<$attr.Type> On${attr.Name}_ProperyChanged;
public $attr.Type $attr.Name
{
  get
  {
    if ( this.Dom.Attribute(XName.Get("$attr.Name")) == null )
    return default($attr.Type);
    return this.Dom.Attribute(XName.Get("$attr.Name")).Value.ToT<$attr.Type>();
  }
  set
  {
    var attr = this.Dom.Attribute(XName.Get("$attr.Name"));
    var oldValue = default($attr.Type);
    var newValue = value;
    if (attr == null)
    {       
        attr = new XAttribute(XName.Get("${attr.Name}"),"");
        this.Dom.Add(attr);              
    }
    else
    {        
        oldValue = this.Dom.Attribute(XName.Get("$attr.Name")).Value.ToT<$attr.Type>();
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
  (XElement dom) : base(dom)
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

#foreach($attr in $el.Attributes)
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
            XElement ${fld.VariableName}_node = null;

            foreach (XElement node in this.Dom.Nodes())
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
                //foreach (XElement node in ${fld.VariableName}_node.Nodes())
                //{
                //    ${fld.VariableName}.AddChild(new ${fld.TypeInfo.GenericParameterType.Name}(node));
                //}
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
			return this.Dom.Attribute(XName.Get"${fld.Name}").Value.ToT${fld.Type}();
#else

            foreach (XElement node in this.Dom.Nodes())
            {
                if (node.Name == "${fld.Type}" && 
                    node.Attribute(XName.Get("variable")) != null &&
                    node.Attribute(XName.Get("variable")).Value == "${fld.Name}")
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

            var attr = new XAttribute(XName.Get("variable"),null);
            attr.Value = "${fld.Name}";
            value.Dom.Add(attr);                

            this.Dom.Add(value.Dom);	
		}
	}	
		
#end
#end
	
namespace $model.NameSpace
{


#foreach( $el in $model.Elements.Values)

#element($el)

}
#end
}