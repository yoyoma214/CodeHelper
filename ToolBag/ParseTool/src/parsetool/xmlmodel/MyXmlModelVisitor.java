/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.xmlmodel;

import java.util.List;
import java.util.Stack;
import org.antlr.v4.runtime.misc.NotNull;
import org.antlr.v4.runtime.tree.ErrorNode;
import org.antlr.v4.runtime.tree.ParseTree;
import parsetool.utils.StackUtil;
import parsetool.utils.TreeUtil;
import parsetool.xmlmodel.models.AttributeGroupInfo;
import parsetool.xmlmodel.models.AttributeInfo;
import parsetool.xmlmodel.models.ElementInfo;
import parsetool.xmlmodel.models.FieldGroupInfo;
import parsetool.xmlmodel.models.FieldInfo;
import parsetool.xmlmodel.models.ModelDB;


/**
 *
 * @author Administrator
 */
public class MyXmlModelVisitor extends XmlModelBaseVisitor<Void> {
    
     ModelDB modelDb = new ModelDB();
     StackUtil stack = new StackUtil();        
    
    @Override public Void visitUsing(@NotNull XmlModelParser.UsingContext ctx) 
    {         
        if ( ctx.children.size() > 1)
        {
            this.modelDb.getUsingNameSpaces().add(ctx.children.get(1).getText());
        }
        return null;   
    }
    
    @Override public Void visitNamespace(@NotNull XmlModelParser.NamespaceContext ctx) 
    { 
        if ( ctx.children.size() > 1)
        {
            this.modelDb.setNameSpace(ctx.children.get(1).getText());
        }
        return null;         
    }
    
     @Override public Void visitErrorNode(@NotNull ErrorNode en) {
         super.visitErrorNode(en);
         return null;
         
     }
        /**
     * @return the modelDb
     */
    public ModelDB getModelDb() {
        return modelDb;
    }
    
	@Override public Void visitGeneric(@NotNull XmlModelParser.GenericContext ctx)
        { 
            
            return visitChildren(ctx); }


	@Override public Void visitElement(@NotNull XmlModelParser.ElementContext ctx) 
        {                
            ElementInfo elementCtx = new ElementInfo();
            elementCtx.parse(ctx,this.stack.peekPrev());			                         
            this.stack.push(elementCtx);            
            String name = ctx.ID().getText();
            elementCtx.setName(name);
            
            List<XmlModelParser.Attr_groupContext> attrGroups = ctx.attr_group();
            if ( attrGroups != null && attrGroups.size() > 0 )
            {
                for(int index = 0 ; index <attrGroups.size(); index ++)
                {
                    AttributeGroupInfo attGroup = new AttributeGroupInfo();      
                    elementCtx.getAttrGroups().add(attGroup);
                    this.stack.push(attGroup);
                    this.visit(attrGroups.get(index));
                    this.stack.pop();  
                }
            }
            List<XmlModelParser.AttributeContext> attributes = ctx.attribute();
            if ( attributes != null && attributes.size() > 0 )
            {
                for(int index = 0 ; index <attributes.size(); index ++)
                {
                    AttributeInfo attribute = new AttributeInfo();      
                    elementCtx.getXmlAttributes().add(attribute);
                    this.stack.push(attribute);
                    this.visit(attributes.get(index));
                    this.stack.pop();  
                }
            }
            
            List<XmlModelParser.Field_groupContext> fldGroups = ctx.field_group();
            if ( fldGroups != null && fldGroups.size() > 0 )
            {
                for(int index = 0 ; index <fldGroups.size(); index ++)
                {
                    FieldGroupInfo fldGroup = new FieldGroupInfo();      
                    elementCtx.getFieldGroups().add(fldGroup);
                    this.stack.push(fldGroup);
                    this.visit(fldGroups.get(index));
                    this.stack.pop();  
                }
            }
            
            List<XmlModelParser.FieldContext> fields = ctx.field();
            if ( fields != null && fields.size() > 0 )
            {
                for(int index = 0 ; index <fields.size(); index ++)
                {
                    FieldInfo fld = new FieldInfo();      
                    elementCtx.getFields().add(fld);
                    this.stack.push(fld);
                    this.visit(fields.get(index));
                    this.stack.pop();  
                }
            }
            
            this.modelDb.AddElement(elementCtx);
            
             //visitChildren(ctx); 
             this.stack.pop();
             return null;
        }

	@Override public Void visitClz_cons_rank(@NotNull XmlModelParser.Clz_cons_rankContext ctx)
        { return visitChildren(ctx); }

	@Override public Void visitGroup_cons_order(@NotNull XmlModelParser.Group_cons_orderContext ctx) 
        { return visitChildren(ctx); }

	@Override public Void visitAttr_group(@NotNull XmlModelParser.Attr_groupContext ctx) 
        { 
             AttributeGroupInfo attrGroup = this.stack.peekCtx(AttributeGroupInfo.class);      
             attrGroup.parse(ctx,this.stack.peekPrev());
             //todo
             
              XmlModelParser.Group_cons_orderContext orderCtx = ctx.group_cons_order();
              if ( orderCtx != null )
              {
                  attrGroup.setIsOrder(orderCtx.BOOL().getText() == "true");
              }
                
                List<XmlModelParser.AttributeContext> attributes = ctx.attribute();
                if ( attributes!= null && attributes.size() > 0 )
                {
                    for(int index =0 ; index < attributes.size(); index ++)
                    {
                        AttributeInfo attribute = new AttributeInfo();
                        attrGroup.getAttributes().add(attribute);
                        this.stack.push(attribute);                    
                        this.visit(attributes.get(index));
                        this.stack.pop();
                    }
                }
               
         
            return null;
        }
        
    @Override public Void visitField_group(@NotNull XmlModelParser.Field_groupContext ctx) { 
            FieldGroupInfo fieldGroup = this.stack.peekCtx(FieldGroupInfo.class);      
            fieldGroup.parse(ctx,this.stack.peekPrev());
           
            XmlModelParser.Group_cons_orderContext orderCtx = ctx.group_cons_order();
              if ( orderCtx != null )
              {
                  fieldGroup.setIsOrder(orderCtx.BOOL().getText() == "true");
              }
              
            List<XmlModelParser.FieldContext> fields = ctx.field();
            if( fields != null && fields.size() > 0)
            {
                for(int index = 0 ; index < fields.size() ; index ++)
                {                    
                    FieldInfo field = new FieldInfo();
                    fieldGroup.getFields().add(field);
                    this.stack.push(field);
                    this.visit(fields.get(index));
                    this.stack.pop();  
                }
                
            }
            
    
            return null;
    }
	@Override public Void visitLong_name(@NotNull XmlModelParser.Long_nameContext ctx) 
        { return visitChildren(ctx); }

	@Override public Void visitProgram(@NotNull XmlModelParser.ProgramContext ctx) 
        {             
            return visitChildren(ctx); 
        }

	@Override public Void visitAttribute(@NotNull XmlModelParser.AttributeContext ctx) 
        { 
            if(ctx.children.size() != 4 && ctx.children.size() != 5)
            {
                return null;
            }
                        
            AttributeInfo attr = this.stack.peekCtx(AttributeInfo.class);      
            attr.parse(ctx,this.stack.peekPrev());	
                        
            ParseTree type =  TreeUtil.getChild(ctx, "long_name",0);
            if(type != null)
            {
                attr.setType(type.getText());
            }
            else
            {
                type = TreeUtil.getChild(ctx, "generic",0);
                if(type != null)
                {
                    attr.setType(type.getText());
                }
            }
            
            ParseTree name = ctx.children.get(2);
            attr.setName(name.getText());
            
            ParseTree defaultVal = TreeUtil.getChild(ctx, "default_value",0);
            if ( defaultVal != null )
            {
                attr.setDefaultValue(defaultVal.getChild(1).getText());
            }
                        
            return null;  
        }

	@Override public Void visitField(@NotNull XmlModelParser.FieldContext ctx) 
        { 
            if(ctx.children.size() != 3 && ctx.children.size() != 5)
            {
                return null;
            }
            
            FieldInfo field = this.stack.peekCtx(FieldInfo.class);      
	    field.parse(ctx,this.stack.peekPrev()); 
            
            ParseTree type =  TreeUtil.getChild(ctx, "long_name",0);
            if(type != null)
            {
                field.setType(type.getText());
            }
            else
            {
                type = TreeUtil.getChild(ctx, "generic",0);
                if(type != null)
                {
                    field.setType(type.getText());
                }
            }
	                        
            ParseTree name = ctx.children.get(1);
            field.setName(name.getText());
            
            ParseTree defaultVal = TreeUtil.getChild(ctx, "default_value",0);
            if ( defaultVal != null )
            {
                field.setDefaultValue(defaultVal.getChild(1).getText());
            }
                                    
            return null;
        }

	@Override public Void visitAttr_group_constraint(@NotNull XmlModelParser.Attr_group_constraintContext ctx) 
        { return visitChildren(ctx); }
        
        @Override public Void visitDefault_value(@NotNull XmlModelParser.Default_valueContext ctx) 
        {
            return visitChildren(ctx); 
        }
}
