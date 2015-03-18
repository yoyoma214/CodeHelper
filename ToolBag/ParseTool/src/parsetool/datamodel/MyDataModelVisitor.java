/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package parsetool.datamodel;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;
import java.util.Stack;
import org.antlr.v4.misc.OrderedHashMap;
import org.antlr.v4.runtime.misc.NotNull;
import org.antlr.v4.runtime.tree.ParseTree;
import org.antlr.v4.runtime.tree.TerminalNode;
import parsetool.datamodel.DataModelParser.AttributeContext;
import parsetool.datamodel.DataModelParser.ModelContext;
import parsetool.datamodel.DataModelParser.System_typeContext;
import parsetool.datamodel.models.Attribute;
import parsetool.datamodel.models.Field;
import parsetool.datamodel.models.Mapping;
import parsetool.datamodel.models.Model;
import parsetool.datamodel.models.Program;
import parsetool.models.common.AtomTokenPair;
import parsetool.models.common.Token;
import parsetool.utils.StackUtil;
import parsetool.utils.TreeUtil;
import parsetool.workflow.WorkflowParser.ProgramContext;

/**
 *
 * @author cqy
 */
public class MyDataModelVisitor extends DataModelBaseVisitor<Void> {
    Map<String,Object> props = new OrderedHashMap<String, Object>();
    StackUtil stack = new StackUtil();

    private Program modelDb = new Program();
    
    
    @Override public Void visitUsing(@NotNull DataModelParser.UsingContext ctx) 
    {         
        if ( ctx.children.size() > 1)
        {
            this.modelDb.getUsingNameSpaces().add(ctx.children.get(1).getText());
        }
        return null;   
    }
    
    @Override
    public Void visitSystem_type( System_typeContext ctx){
        return visitChildren(ctx);
}
         
    @Override
         public Void visitProgram(@NotNull DataModelParser.ProgramContext ctx) { 
        
        return visitChildren(ctx);
    }
    
    @Override public Void visitNamespace(@NotNull DataModelParser.NamespaceContext ctx) 
    { 
        String ns = TreeUtil.getChild(ctx,"long_name").getText();
        getModelDb().setNameSpace(ns);
        return visitChildren(ctx); 
    }
    
    /**
	 * {@inheritDoc}
	 * <p/>
	 * The default implementation returns the result of calling
	 * {@link #visitChildren} on {@code ctx}.
	 */
	@Override public Void visitField(@NotNull DataModelParser.FieldContext ctx) {   
                        
            Field fieldInfo = (Field)this.stack.peek();     
            String fieldName = ctx.ID().getText();                                         
            fieldInfo.setName(fieldName);                                
            //ModelInfo modelInfo = (ModelInfo)this.stack.peek();
            //modelInfo.getFields().add(fieldInfo);

	    fieldInfo.parse(ctx,this.stack.peekPrev());	            
            //this.stack.push(fieldInfo);            

            List<ParseTree> trees = TreeUtil.getChildren(ctx, "attribute");
            if ( trees != null )
            {
                for(int index = 0 ;index < trees.size() ; index ++)
                {
                    Attribute attribute = new Attribute();
                    fieldInfo.getAttributes().add(attribute);
                    this.stack.push(attribute);
                    this.visit(trees.get(index));
                    this.stack.pop();            
                }
            }
            //this.stack.push(attribute);
            ParseTree tree = TreeUtil.getChild(ctx, "filed_define");    
            this.visit(tree);
            //this.stack.pop(); 
            //this.stack.pop();
            return null;
        }

	/**
	 * {@inheritDoc}
	 * <p/>
	 * The default implementation returns the result of calling
	 * {@link #visitChildren} on {@code ctx}.
	 */
	@Override public Void visitDb_type(@NotNull DataModelParser.Db_typeContext ctx) 
        { return visitChildren(ctx); }

	/**
	 * {@inheritDoc}
	 * <p/>
	 * The default implementation returns the result of calling
	 * {@link #visitChildren} on {@code ctx}.
	 */
	@Override public Void visitModel(@NotNull DataModelParser.ModelContext ctx) { 
            //int filedIndex = 0;
           
            Model modelCtx = this.stack.peekCtx(Model.class);      
                     
            Model modelInfo = new Model();          
        
            modelInfo.parse(ctx,this.stack.peekPrev());
            
            this.stack.push(modelInfo);
            
            List<AttributeContext> trees =  ctx.attribute();
            for(int index = 0 ; index <trees.size() ; index ++)
            {
                Attribute attr = new Attribute();
                modelInfo.getAttributes().add(attr);
                this.stack.push(attr); 
                this.visit(trees.get(index));
                this.stack.pop();
            }
            
            String modelName = ctx.ID().getText();
            modelInfo.setName(modelName);            
            if ( modelCtx == null)
            {
                this.modelDb.AddModel(modelInfo);//after setName
            }
            else
            {
                //modelCtx.getModels().add(modelInfo);
            }
            //visitChildren(ctx);
            
            List<DataModelParser.FieldContext> fields = ctx.field();
            for(int index = 0 ; index <fields.size() ; index ++)
            {
                Field field = new Field();
                modelInfo.getFields().add(field);
                this.stack.push(field); 
                this.visit(fields.get(index));
                this.stack.pop();
            }
            
            List<ModelContext> models = ctx.model();
            for(int index = 0 ; index <models.size() ; index ++)
            {
                Model model = new Model();
                modelInfo.getModels().add(model);
                
                this.stack.push(model); 
                this.visit(models.get(index));
                this.stack.pop();
            }            
            this.stack.pop();
            return null;
        }

	/**
	 * {@inheritDoc}
	 * <p/>
	 * The default implementation returns the result of calling
	 * {@link #visitChildren} on {@code ctx}.
	 */
	@Override public Void visitIs_pk(@NotNull DataModelParser.Is_pkContext ctx) { return visitChildren(ctx); }

	/**
	 * {@inheritDoc}
	 * <p/>
	 * The default implementation returns the result of calling
	 * {@link #visitChildren} on {@code ctx}.
	 */
	@Override public Void visitLong_name(@NotNull DataModelParser.Long_nameContext ctx) { return visitChildren(ctx); }

	/**
	 * {@inheritDoc}
	 * <p/>
	 * The default implementation returns the result of calling
	 * {@link #visitChildren} on {@code ctx}.
	 */
	@Override public Void visitIs_null(@NotNull DataModelParser.Is_nullContext ctx) { return visitChildren(ctx); }

	/**
	 * {@inheritDoc}
	 * <p/>
	 * The default implementation returns the result of calling
	 * {@link #visitChildren} on {@code ctx}.
	 */
	@Override public Void visitRelation(@NotNull DataModelParser.RelationContext ctx) { return visitChildren(ctx); }

	/**
	 * {@inheritDoc}
	 * <p/>
	 * The default implementation returns the result of calling
	 * {@link #visitChildren} on {@code ctx}.
	 */
	@Override public Void visitFiled_define(@NotNull DataModelParser.Filed_defineContext ctx) {
            
            Field fieldInfo = (Field)this.stack.peek();
            fieldInfo.parse(ctx,this.stack.peekPrev());		           
            ParseTree n =  TreeUtil.getChild(ctx, "system_type");
            if ( n != null )
            {
                fieldInfo.setSystem_type(n.getText());
            }
                        
            n =  TreeUtil.getChild(ctx, "db_type");
            if ( n != null )
            {
                fieldInfo.setDb_type(n.getText());
            }
            
             n =  TreeUtil.getChild(ctx, "is_null");
            if ( n != null )
            {
                fieldInfo.setIs_null(Boolean.valueOf(n.getText()));
            }
            
            n =  TreeUtil.getChild(ctx, "is_pk");
            if ( n != null )
            {
                fieldInfo.setIs_pk(Boolean.valueOf(n.getText()));
            }
            
            //visitChildren(ctx);
            
            return null;
        }

	/**
	 * {@inheritDoc}
	 * <p/>
	 * The default implementation returns the result of calling
	 * {@link #visitChildren} on {@code ctx}.
	 */
	@Override public Void visitMapping(@NotNull DataModelParser.MappingContext ctx) { 
                    Mapping mapping = new Mapping();
             //this.stack.push(mapping);
                      List<TerminalNode> ids = ctx.ID();
                      if ( ids.size() > 0)
                      {
                          AtomTokenPair pair = new AtomTokenPair("FromModel",ids.get(0).getText());
                          pair.setBeginToken(new Token(ids.get(0).getSymbol()));
                          pair.setEndToken(new Token(ids.get(0).getSymbol()));                          
                          pair.setIs_Id(true);
                          mapping.setFromModel(pair);
                      }
                      if ( ids.size() > 1){
                          AtomTokenPair pair = new AtomTokenPair("FromField",ids.get(1).getText());
                          pair.setBeginToken(new Token(ids.get(1).getSymbol()));
                          pair.setEndToken(new Token(ids.get(1).getSymbol())); 
                          pair.setIs_Id(true);
                          mapping.setFromField(pair);                      
                      }
                      if ( ids.size() > 2)
                      {
                          AtomTokenPair pair = new AtomTokenPair("FromNavigateProperty",ids.get(2).getText());
                          pair.setBeginToken(new Token(ids.get(2).getSymbol()));
                          pair.setEndToken(new Token(ids.get(2).getSymbol())); 
                          pair.setIs_Id(true);
                          mapping.setFromNavigateProperty(pair);              
                      }
                      if ( ctx.long_name() != null )
                      {
                          AtomTokenPair pair = new AtomTokenPair("TargetModel",ctx.long_name().getText());
                          pair.setBeginToken(new Token(ctx.long_name().start));
                          pair.setEndToken(new Token(ctx.long_name().stop)); 
                          pair.setIs_Id(true);
                          mapping.setTargetModel(pair);                     
                      }
                      if ( ids.size() > 3){
                          AtomTokenPair pair = new AtomTokenPair("TargetField",ids.get(3).getText());
                          pair.setBeginToken(new Token(ids.get(3).getSymbol()));
                          pair.setEndToken(new Token(ids.get(3).getSymbol())); 
                          pair.setIs_Id(true);
                          mapping.setTargetField(pair);                  
                      }
                      if(ctx.relation() != null){
                          AtomTokenPair pair = new AtomTokenPair("Relation",ctx.relation().getText());
                          pair.setBeginToken(new Token(ctx.relation().start));
                          pair.setEndToken(new Token(ctx.relation().stop)); 
                          pair.setIs_Id(true);
                          mapping.setRelation(pair);                       
                      }
                      
                      for(int index = 4 ; index < ids.size() ; index ++ )
                      {
                          AtomTokenPair pair = new AtomTokenPair("ShowField",ids.get(index).getText());
                          pair.setBeginToken(new Token(ids.get(index).getSymbol()));
                          pair.setEndToken(new Token(ids.get(index).getSymbol())); 
                          pair.setIs_Id(true);
                          mapping.getShowFields().add(pair);                         
                      }
                      
                      DataModelParser.Split_tagContext tree = ctx.split_tag();
                      if ( tree != null )
                      {
                          AtomTokenPair pair = new AtomTokenPair("SplitTag",tree.getText());
                          pair.setBeginToken(new Token(tree.start));
                          pair.setEndToken(new Token(tree.stop)); 
                          pair.setIs_Id(true);
                          mapping.setSplitTag(pair);
                      }
                      /*
                      mapping.setFromModel(ctx.getChild(0).getText());
                      mapping.setFromField(ctx.getChild(4).getText());
                      String long_name = ctx.getChild(6).getText();
                      int index = long_name.lastIndexOf(".");
                      index = index == -1 ? 0 : index;
                      String targetModel = long_name.substring(0, index);
                      String targetField = long_name.substring(index+1);
                      mapping.setTargetModel(targetModel);
                      mapping.setTargetField(targetField);
                      mapping.setRelation(ctx.getChild(8).getText());
                      */
                      
            this.modelDb.getMapings().add(mapping);
            //visitChildren(ctx);
            //this.stack.pop();
            return null;       
        }

    /**
     * @return the modelDb
     */
    public Program getModelDb() {
        return modelDb;
    }
    
    @Override public Void visitAttribute(@NotNull DataModelParser.AttributeContext ctx) { 
        Attribute attribute = this.stack.peekCtx(Attribute.class);      
	attribute.parse(ctx,this.stack.peekPrev());			
            attribute.setName(ctx.ID().getText());
                        
            List<TerminalNode> parameters = ctx.STRING();
            if ( parameters != null )
            {
                for(int index = 0 ;index < parameters.size() ; index ++)
                {
                  attribute.getParameters().add(parameters.get(index).getText());
                }
            }        return null;
    }

}
