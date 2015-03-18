/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.dataview;

import java.util.List;
import org.antlr.v4.runtime.misc.NotNull;
import org.antlr.v4.runtime.tree.ParseTree;
import org.antlr.v4.runtime.tree.TerminalNodeImpl;
import parsetool.dataview.DataViewParser.Top_clauseContext;
import parsetool.dataview.models.*;
import parsetool.dataview.models.Search_Option;
import parsetool.dataview.models.condition.Between_Prior;
import parsetool.dataview.models.condition.Binary;
import parsetool.dataview.models.condition.Binary_Compare;
import parsetool.dataview.models.condition.Binary_Compare_Prior;
import parsetool.dataview.models.condition.Binary_Operater;
import parsetool.dataview.models.condition.Binary_Prior;
import parsetool.dataview.models.condition.Compare_Complex;
import parsetool.dataview.models.condition.Compare_Complex_Mix_And;
import parsetool.dataview.models.condition.Compare_Complex_Mix_Or;
import parsetool.dataview.models.condition.Compare_Complex_Prior;
import parsetool.dataview.models.condition.Condition_Clause;
import parsetool.dataview.models.condition.Condition_Clause_Full;
import parsetool.dataview.models.condition.Condition_Option;
import parsetool.dataview.models.condition.Predication;
import parsetool.dataview.models.condition.exists.Existed_Compare;
import parsetool.dataview.models.condition.exists.Existed_Compare_Prior;
import parsetool.dataview.models.condition.in.In_Expression;
import parsetool.dataview.models.condition.in.In_Expression_Prior;
import parsetool.dataview.models.condition.in.In_Keyword;
import parsetool.dataview.models.condition.in.In_List;
import parsetool.dataview.models.condition.in.In_Right_Value;
import parsetool.dataview.models.expression.Binary_Expression;
import parsetool.dataview.models.expression.Multiplicative_Expression;
import parsetool.dataview.models.expression.Positive_Expression;
import parsetool.dataview.models.expression.Unary_Operator;
import parsetool.dataview.models.fields.Field_Regular;
import parsetool.dataview.models.fields.Function_Field;
import parsetool.dataview.models.fields.Function_Parameter;
import parsetool.dataview.models.fields.Function_Parameter_List;
import parsetool.dataview.models.fields.Table_Field;
import parsetool.dataview.models.fields.Table_Field_Atom;
import parsetool.dataview.models.fields.Table_Field_Alias;
import parsetool.dataview.models.fields.casewhen.Case_Clause;
import parsetool.dataview.models.fields.casewhen.Case_Clause_Field;
import parsetool.dataview.models.fields.casewhen.Case_Clause_Prior;
import parsetool.dataview.models.fields.casewhen.Case_Else_Expression;
import parsetool.dataview.models.fields.casewhen.Case_Expression;
import parsetool.dataview.models.fields.casewhen.Case_Have_Target_Expression;
import parsetool.dataview.models.fields.casewhen.Case_Have_Target_When_Expression;
import parsetool.dataview.models.fields.casewhen.Case_When_Expression;
import parsetool.dataview.models.fields.casewhen.Result_Expression;
import parsetool.dataview.models.fields.casewhen.Result_Expression_Prior;
import parsetool.dataview.models.grouping.Group_Clause;
import parsetool.dataview.models.grouping.Group_Clause_Full;
import parsetool.dataview.models.grouping.Having_Clause;
import parsetool.dataview.models.grouping.Having_Clause_Full;
import parsetool.dataview.models.join.*;
import parsetool.dataview.models.lists.Select_List;
import parsetool.dataview.models.lists.Value_List;
import parsetool.dataview.models.option.*;
import parsetool.dataview.models.orders.Order_Clause;
import parsetool.dataview.models.orders.Order_Clause_Full;
import parsetool.dataview.models.orders.Order_Expression;
import parsetool.dataview.models.parameters.Parameter;
import parsetool.dataview.models.parameters.Parameter_Name;
import parsetool.utils.StackUtil;
import parsetool.utils.TreeUtil;

/**
 *
 * @author Administrator
 */
public class MyDataViewVisitor extends DataViewBaseVisitor<Void> {
    
        StackUtil stack = new StackUtil();
    
        public Program Root = new Program();
    
        @Override public Void visitProgram(@NotNull DataViewParser.ProgramContext ctx) {
        
            Program program = Root;
            program.parse(ctx,null);
            this.stack.push(program);

            ParseTree tree = TreeUtil.getChild(ctx, "search_option");
    
            if ( tree != null )
            {
                Search_Option option = new Search_Option();
                this.stack.push(option);
                program.setSearch_option(option);                
                this.visit(tree);                    
                this.stack.pop();
            }
            tree = TreeUtil.getChild(ctx, "select");
            if ( tree != null )
            {
                Select select = new Select();
                this.stack.push(select);
                program.setSelect(select);                
                this.visit(tree);                    
                this.stack.pop();
            }
            
            this.stack.pop();
               return null;
            //return visitChildren(ctx); 
        }
        
    	@Override public Void visitSearch_option(@NotNull DataViewParser.Search_optionContext ctx) {
            
            Search_Option search_option = this.stack.peekCtx(Search_Option.class);  
            search_option.parse(ctx,this.stack.peekPrev());
            ParseTree tree = TreeUtil.getChild(ctx, "option_expression");
            if ( tree != null )
            {
                Option_Expression option_expression = new Option_Expression();
                search_option.setOption_expression(option_expression);
                this.stack.push(option_expression);
                this.visit(tree);
                this.stack.pop();            
            }
            return null;
            //return visitChildren(ctx); 
        }

	@Override public Void visitCondition_clause_prior(@NotNull DataViewParser.Condition_clause_priorContext ctx) { 
            
            Condition_Clause_Prior condition_clause_prior = this.stack.peekCtx(Condition_Clause_Prior.class);  
            condition_clause_prior.parse(ctx,this.stack.peekPrev());
            ParseTree tree = TreeUtil.getChild(ctx, "condition_clause");
            if ( tree != null )
            {
                Condition_Clause condition_clause = new Condition_Clause();
                condition_clause_prior.setCondition_clause(condition_clause);
                this.stack.push(condition_clause);
                this.visit(tree);
                this.stack.pop();            
            }
            return null;
        }

	@Override public Void visitInner_join(@NotNull DataViewParser.Inner_joinContext ctx) { return visitChildren(ctx); }

	@Override public Void visitBinary_prior(@NotNull DataViewParser.Binary_priorContext ctx) {
            
            Binary_Prior binary_prior = this.stack.peekCtx(Binary_Prior.class);         
             binary_prior.parse(ctx,this.stack.peekPrev());
            ParseTree tree = TreeUtil.getChild(ctx, "binary");
            if ( tree != null )
            {
                Binary binary = new Binary();
                binary_prior.setBinary(binary);
                this.stack.push(binary);
                this.visit(tree);
                this.stack.pop();            
            }
            return null;
        }

	@Override public Void visitCase_have_target_expression(@NotNull DataViewParser.Case_have_target_expressionContext ctx) {
            
             Case_Have_Target_Expression case_have_target_expression =  this.stack.peekCtx(Case_Have_Target_Expression.class);         
             case_have_target_expression.parse(ctx,this.stack.peekPrev());
            ParseTree tree = ctx.table_field();
            if ( tree != null )
            {
                Table_Field field = new Table_Field();
                case_have_target_expression.setTable_field(field);
                this.stack.push(field);
                this.visit(tree);
                this.stack.pop();            
            }
            List<DataViewParser.Case_have_target_when_expressionContext> trees = ctx.case_have_target_when_expression();
            if ( trees != null)
            {
                for(int index = 0 ; index < trees.size() ; index ++)
                {
                    Case_Have_Target_When_Expression expression = new Case_Have_Target_When_Expression();
                    case_have_target_expression.getCase_have_target_when_expressions().add(expression);
                    this.stack.push(expression);
                    this.visit(trees.get(index));
                    this.stack.pop();          
                }
            }
            tree = ctx.case_else_expression();
            if  (tree != null)
            {
                Case_Else_Expression elseExpr = new Case_Else_Expression();
                case_have_target_expression.setCase_else_expression(elseExpr);
                this.stack.push(elseExpr);
                this.visit(tree);
                this.stack.pop();  
            }
            return null;
        }

	@Override public Void visitIn_keyword(@NotNull DataViewParser.In_keywordContext ctx) { 
            
            In_Keyword in_keyword = this.stack.peekCtx(In_Keyword.class);            
            in_keyword.parse(ctx,this.stack.peekPrev());
            int childCount = ctx.getChildCount();
            String text = "";
            if ( childCount == 1)
            {
                text = ctx.getChild(0).getText();
            }
            else if ( childCount == 2)
            {
                text = ctx.getChild(0).getText() + " " + ctx.getChild(1).getText();                
            }
            in_keyword.setKeyworkd(text);
            return null;
        }
        @Override public Void visitIn_right_value(@NotNull DataViewParser.In_right_valueContext ctx) {
            
            In_Right_Value in_right_value = this.stack.peekCtx(In_Right_Value.class);            
            in_right_value.parse(ctx,this.stack.peekPrev());
            ParseTree tree = TreeUtil.getChild(ctx, "parameter");
            if ( tree != null )
            {
                Parameter parameter = new Parameter();
                in_right_value.setParameter(parameter);
                this.stack.push(parameter);
                this.visit(tree);
                this.stack.pop();            
            }
            
            tree = TreeUtil.getChild(ctx, "in_list");
            if ( tree != null )
            {
                In_List list = new In_List();
                in_right_value.setList(list);
                this.stack.push(list);
                this.visit(tree);
                this.stack.pop();            
            }
            
            return null;
        }

        @Override public Void visitIn_list(@NotNull DataViewParser.In_listContext ctx) { 
            
            In_List in_list = this.stack.peekCtx(In_List.class);            
            in_list.parse(ctx,this.stack.peekPrev());
            
            ParseTree tree = TreeUtil.getChild(ctx, "select_list");
            if ( tree != null )
            {
                Select_List select_list = new Select_List();
                in_list.setSelect_list(select_list);
                this.stack.push(select_list);
                this.visit(tree);
                this.stack.pop();            
            }
            
            tree = TreeUtil.getChild(ctx, "value_list");
            if ( tree != null )
            {
                Value_List value_list = new Value_List();
                in_list.setValue_list(value_list);
                this.stack.push(value_list);
                this.visit(tree);
                this.stack.pop();            
            }
            
            return null;
        }
        
	@Override public Void visitValue_list(@NotNull DataViewParser.Value_listContext ctx) { 
            
            Value_List value_list = this.stack.peekCtx(Value_List.class);            
            value_list.parse(ctx,this.stack.peekPrev());
            
            List<ParseTree> trees = TreeUtil.getChildren(ctx, "value");
            if ( trees != null )
            {
                for(int index = 0 ;index < trees.size() ; index ++)
                {
                    Value value = new Value();
                    value_list.getValues().add(value);
                    this.stack.push(value);
                    this.visit(trees.get(index));
                    this.stack.pop();            
                }
            }
            
            return null;
            
        }

	@Override public Void visitResult_expression(@NotNull DataViewParser.Result_expressionContext ctx) { 
        
            Result_Expression result_expression = this.stack.peekCtx(Result_Expression.class);      
            result_expression.parse(ctx,this.stack.peekPrev());
            
            ParseTree tree = TreeUtil.getChild(ctx, "value");
            if ( tree != null )
            {
                Value value = new Value();
                result_expression.setValue(value);
                this.stack.push(value);
                this.visit(tree);
                this.stack.pop();            
            }
            /*
            tree = TreeUtil.getChild(ctx, "select");
            if ( tree != null )
            {
                Select_Atom select = new Select_Atom();
                result_expression.setSelect(select);
                this.stack.push(select);
                this.visit(tree);
                this.stack.pop();            
            }
            */
            return null;
        }
        @Override public Void visitCompare_complex_mix_or(@NotNull DataViewParser.Compare_complex_mix_orContext ctx)
        { 
            Compare_Complex_Mix_Or compare_complex_mix_or = this.stack.peekCtx(Compare_Complex_Mix_Or.class);       
            compare_complex_mix_or.parse(ctx,this.stack.peekPrev());
            
            List<ParseTree> trees = TreeUtil.getChildren(ctx, "compare_complex_mix_and");
            if ( trees != null )
            {  
                for(int index = 0 ;index < trees.size() ; index ++)
                {
                    Compare_Complex_Mix_And compare_complex_mix_and = new Compare_Complex_Mix_And();
                    compare_complex_mix_or.getCompare_complex_mix_ands().add(compare_complex_mix_and);
                    this.stack.push(compare_complex_mix_and);
                    this.visit(trees.get(index));
                    this.stack.pop();              
                }
            }
           
            return null;     
        }

        @Override public Void visitCompare_complex_mix_and(@NotNull DataViewParser.Compare_complex_mix_andContext ctx) 
        { 
            Compare_Complex_Mix_And compare_complex_mix_and = this.stack.peekCtx(Compare_Complex_Mix_And.class);       
            compare_complex_mix_and.parse(ctx,this.stack.peekPrev());
            
            List<ParseTree> trees = TreeUtil.getChildren(ctx, "compare_complex_prior");
            if ( trees != null )
            {  
                for(int index = 0 ;index < trees.size() ; index ++)
                {
                    Compare_Complex_Prior compare_complex_prior = new Compare_Complex_Prior();
                    compare_complex_mix_and.getCompare_complex_priors().add(compare_complex_prior);
                    this.stack.push(compare_complex_prior);
                    this.visit(trees.get(index));
                    this.stack.pop();              
                }
            }
           
            return null;   
        }
        
        @Override public Void visitPredication(@NotNull DataViewParser.PredicationContext ctx) 
        { 
            Predication predication = this.stack.peekCtx(Predication.class);            
            ParseTree tree = TreeUtil.getChild(ctx, "select");
            if ( tree != null )
            {
                Select select = new Select();
                predication.setSelect(select);
                this.stack.push(select);
                this.visit(tree);
                this.stack.pop();            
            }
            String text = ctx.getStart().getText();
            predication.setPredicate(text);
            
            return null;
        }
        
	@Override public Void visitCase_else_expression(@NotNull DataViewParser.Case_else_expressionContext ctx) {
        
            Case_Else_Expression case_else_expression = this.stack.peekCtx(Case_Else_Expression.class);     
             case_else_expression.parse(ctx,this.stack.peekPrev());
             
            ParseTree tree = TreeUtil.getChild(ctx, "result_expression_prior");
            if ( tree != null )
            {
                Result_Expression_Prior result_expression_prior = new Result_Expression_Prior();
                case_else_expression.setResult_expression_prior(result_expression_prior);
                this.stack.push(result_expression_prior);
                this.visit(tree);
                this.stack.pop();            
            }
            return null;
        }

	@Override public Void visitCase_clause_field(@NotNull DataViewParser.Case_clause_fieldContext ctx) { 
            
             Case_Clause_Field case_clause_field = this.stack.peekCtx(Case_Clause_Field.class);     
             case_clause_field.parse(ctx,this.stack.peekPrev());
             
            ParseTree tree = TreeUtil.getChild(ctx, "case_clause_prior");
            if ( tree != null )
            {
                Case_Clause_Prior case_clause_prior = new Case_Clause_Prior();
                case_clause_field.setCase_clause_prior(case_clause_prior);
                this.stack.push(case_clause_prior);
                this.visit(tree);
                this.stack.pop();            
            }
            return null;
        
        }

	@Override public Void visitBinary_compare(@NotNull DataViewParser.Binary_compareContext ctx) { 
            
            Binary_Compare binary_compare = this.stack.peekCtx(Binary_Compare.class);   
            binary_compare.parse(ctx,this.stack.peekPrev());
            
            ParseTree tree = TreeUtil.getChild(ctx, "table_field",0);
            if ( tree != null )
            {
                Table_Field table_field = new Table_Field();
                binary_compare.setLeft_table_field(table_field);
                this.stack.push(table_field);
                this.visit(tree);
                this.stack.pop();            
            }
            
            tree = TreeUtil.getChild(ctx, "binary_operater");
            if ( tree != null )
            {
                Binary_Operater binary_operater = new Binary_Operater();
                binary_compare.setBinary_operater(binary_operater);
                this.stack.push(binary_operater);
                this.visit(tree);
                this.stack.pop();            
            }
            
            tree = TreeUtil.getChild(ctx, "table_field",1);
            if ( tree != null )
            {
                Table_Field table_field = new Table_Field();
                binary_compare.setRight_table_field(table_field);
                this.stack.push(table_field);
                this.visit(tree);
                this.stack.pop();            
            }
            
            tree = TreeUtil.getChild(ctx, "predication");
            if ( tree != null )
            {
                Predication predication = new Predication();
                binary_compare.setPredication(predication);
                this.stack.push(predication);
                this.visit(tree);
                this.stack.pop();            
            }                        
            return null;
        }

	@Override public Void visitValue(@NotNull DataViewParser.ValueContext ctx) {
            
            Value value = this.stack.peekCtx(Value.class);       
            value.parse(ctx,this.stack.peekPrev());
            
            ParseTree tree = TreeUtil.getChild(ctx, "parameter");
            if ( tree != null )
            {
                Parameter parameter = new Parameter();
                value.setIs_parameter(true);
                value.setParameter(parameter);
                this.stack.push(parameter);
                this.visit(tree);   
                this.stack.pop();            
                return null;
            }
            tree = TreeUtil.getChild(ctx, "select_list");
            if ( tree != null )
            {
                Select_List select_list = new Select_List();
                value.setIs_select_list(true);
                value.setSelect_list(select_list);
                this.stack.push(select_list);
                this.visit(tree);
                this.stack.pop();            
                return null;
            }
            TerminalNodeImpl type = (TerminalNodeImpl) ctx.INT();
            if ( type != null)
            {
                value.setIs_int(true);
                value.setValue(type.getText());
                return null;
            }
            type = (TerminalNodeImpl) ctx.BOOL();
            if ( type != null)
            {
                value.setIs_bool(true);
                value.setValue(type.getText());
                return null;
            }
            type = (TerminalNodeImpl) ctx.CHAR();
            if ( type != null)
            {
                value.setIs_char(true);
                value.setValue(type.getText());
                return null;
            }
            type = (TerminalNodeImpl) ctx.FLOAT();
            if ( type != null)
            {
                value.setIs_float(true);
                value.setValue(type.getText());
                return null;
            }
            type = (TerminalNodeImpl) ctx.STRING();
            if ( type != null)
            {
                value.setIs_string(true);
                value.setValue(type.getText());
                return null;
            }
            type = (TerminalNodeImpl) ctx.OPTION_STRING();
             if ( type != null )
            {
                value.setIs_option_string(true);
                value.setValue(type.getText());
                return null;
            }
            return null;
        }

	@Override public Void visitParameter_name(@NotNull DataViewParser.Parameter_nameContext ctx) { return visitChildren(ctx); }

	@Override public Void visitOption(@NotNull DataViewParser.OptionContext ctx) { 
            
            Option option = this.stack.peekCtx(Option.class);            
            option.parse(ctx,this.stack.peekPrev());
                        
            ParseTree tree = TreeUtil.getChild(ctx, "option_name");
            if ( tree != null )
            {
                Option_Name option_name = new Option_Name();
                option.setOption_name(option_name);
                this.stack.push(option_name);
                this.visit(tree);
                this.stack.pop();            
            }
            
            tree = TreeUtil.getChild(ctx, "option_value");
            if ( tree != null )
            {
                Option_Value option_value = new Option_Value();
                option.setOption_value(option_value);
                this.stack.push(option_value);
                this.visit(tree);
                this.stack.pop();            
            }
            return null;
            //return visitChildren(ctx); 
        }

	@Override public Void visitCondition_clause(@NotNull DataViewParser.Condition_clauseContext ctx) { 
        
            Condition_Clause condition_clause = this.stack.peekCtx(Condition_Clause.class);       
            condition_clause.parse(ctx,this.stack.peekPrev());
            
            ParseTree tree = TreeUtil.getChild(ctx, "compare_complex_mix_or");
            if ( tree != null )
            {  
                Compare_Complex_Mix_Or compare_complex_mix_or = new Compare_Complex_Mix_Or();
                condition_clause.setCompare_complex_mix_or(compare_complex_mix_or);
                this.stack.push(compare_complex_mix_or);
                this.visit(tree);
                this.stack.pop();              
            }
           
            return null;                    
        }

	@Override public Void visitGroup_clause_full(@NotNull DataViewParser.Group_clause_fullContext ctx) { 
            
            Group_Clause_Full group_clause_full = this.stack.peekCtx(Group_Clause_Full.class);            
            group_clause_full.parse(ctx,this.stack.peekPrev());
            
            ParseTree tree = TreeUtil.getChild(ctx, "group_clause");
            if ( tree != null )
            {
                Group_Clause group_clause = new Group_Clause();
                group_clause_full.setGroup_clause(group_clause);
                this.stack.push(group_clause);
                this.visit(tree);
                this.stack.pop();            
            }
            return null;
        }

	@Override public Void visitSelect_clause(@NotNull DataViewParser.Select_clauseContext ctx) { 
            
            Select_Clause select_clause = this.stack.peekCtx(Select_Clause.class);          
            select_clause.parse(ctx,this.stack.peekPrev());
            
            List<ParseTree> trees = TreeUtil.getChildren(ctx, "table_field_alias");
            if ( trees != null && trees.size() > 0)
            {
                for(int i= 0 ;i < trees.size() ; i ++)
                {
                    Table_Field_Alias table_field_alias = new Table_Field_Alias();
                    select_clause.getTable_field_alias_list().add(table_field_alias);
                    this.stack.push(table_field_alias);
                    this.visit(trees.get(i));
                    this.stack.pop();        
                }
            }
            return null;
        }

	@Override public Void visitSelect(@NotNull DataViewParser.SelectContext ctx) {
            Select select = this.stack.peekCtx(Select.class);    
            select.parse(ctx,this.stack.peekPrev());
            
            if ( select != null )
            {                
                this.stack.push(select);  
            }
            else
            {
                select = new Select();
                this.stack.push(select);
            }
            
            List<ParseTree> trees = TreeUtil.getChildren(ctx, "select_atom");
            if(trees != null )
            {
                for(int index = 0 ;index < trees.size() ; index ++)
                {
                    Select_Atom select_atom = new Select_Atom();                    
                    select.getSelect_atoms().add(select_atom);
                    this.stack.push(select_atom);
                    this.visit(trees.get(index));
                    this.stack.pop();
                }
            }                       
            
            trees = TreeUtil.getChildren(ctx, "union_type");
            if(trees != null )
            {
                for(int index = 0 ;index < trees.size() ; index ++)
                {
                    Union_Type union_type = new Union_Type( );
                    select.getUnion_types().add(union_type);
                    this.stack.push(union_type);
                    this.visit(trees.get(index));
                    this.stack.pop();
                }
            }
            
            return null;
            //return visitChildren(ctx); 
        }
        
        @Override public Void visitUnion_type(@NotNull DataViewParser.Union_typeContext ctx) { 
            Union_Type union_type = this.stack.peekCtx(Union_Type.class);    
            union_type.parse(ctx,this.stack.peekPrev());
            
            union_type.setUnion_type(ctx.getText());
            
            return null;
        }
        
        @Override public Void visitSelect_atom(@NotNull DataViewParser.Select_atomContext ctx) { 
            Select_Atom select_atom = this.stack.peekCtx(Select_Atom.class);    
            select_atom.parse(ctx,this.stack.peekPrev());
            
            ParseTree tree = TreeUtil.getChild(ctx, "select");
            if(tree != null )
            {
                Select select = new Select( );
                select_atom.setSelect(select);
                this.stack.push(select);
                this.visit(tree);
                this.stack.pop();
                return null;
            }
      
            tree = TreeUtil.getChild(ctx, "select_clause_full");
            if(tree != null )
            {
                Select_Clause_Full select_clause_full = new Select_Clause_Full();                    
                select_atom.setSelect_clause_full(select_clause_full);
                this.stack.push(select_clause_full);
                this.visit(tree);
                this.stack.pop();
            }

            tree = TreeUtil.getChild(ctx, "from_clause_full");
            if(tree != null )
            {
                From_Clause_Full from_clause_full = new From_Clause_Full();
                select_atom.setFrom_clause_full(from_clause_full);
                this.stack.push(from_clause_full);
                this.visit(tree);
                this.stack.pop();
            }

            tree = TreeUtil.getChild(ctx, "join_clause_full");
            if(tree != null )
            {     
                Join_Clause_Full join_clause_full = new Join_Clause_Full( );
                select_atom.setJoin_clause_full(join_clause_full);
                this.stack.push(join_clause_full);
                this.visit(tree);
                this.stack.pop();
            }

            tree = TreeUtil.getChild(ctx, "condition_clause_full");
            if(tree != null )
            {
                Condition_Clause_Full condition_clause_full = new Condition_Clause_Full( );
                select_atom.setConditon_clause_full(condition_clause_full);
                this.stack.push(condition_clause_full);
                this.visit(tree);
                this.stack.pop();
            }

            tree = TreeUtil.getChild(ctx, "group_clause_full");
            if(tree != null )
            {
                Group_Clause_Full group_clause_full = new Group_Clause_Full( );
                select_atom.setGroup_clause_full(group_clause_full);
                this.stack.push(group_clause_full);
                this.visit(tree);
                this.stack.pop();
            }

            tree = TreeUtil.getChild(ctx, "order_clause_full");
            if(tree != null )
            {
                Order_Clause_Full order_clause_full = new Order_Clause_Full( );
                select_atom.setOrder_clause_full(order_clause_full);
                this.stack.push(order_clause_full);
                this.visit(tree);
                this.stack.pop();
            }              
            
            return null;
        }
        
	@Override public Void visitFunction_parameter(@NotNull DataViewParser.Function_parameterContext ctx) { 
            Function_Parameter function_parameter = this.stack.peekCtx(Function_Parameter.class);         
            function_parameter.parse(ctx,this.stack.peekPrev());
            
            ParseTree tree = TreeUtil.getChild(ctx, "table_field");
            if ( tree != null )
            {
                Table_Field table_field = new Table_Field();
                function_parameter.setTable_field(table_field);
                this.stack.push(table_field);
                this.visit(tree);
                this.stack.pop();            
            }
            return null; 
        }

	@Override public Void visitCase_when_expression(@NotNull DataViewParser.Case_when_expressionContext ctx) { 
            
            Case_When_Expression case_when_expression = this.stack.peekCtx(Case_When_Expression.class);  
            case_when_expression.parse(ctx,this.stack.peekPrev());
            
            ParseTree tree = TreeUtil.getChild(ctx, "condition_clause_prior");
            if ( tree != null )
            {
                Condition_Clause_Prior condition_clause_prior = new Condition_Clause_Prior();
                case_when_expression.setCondition_clause_prior(condition_clause_prior);
                this.stack.push(condition_clause_prior);
                this.visit(tree);
                this.stack.pop();            
            }
            tree = TreeUtil.getChild(ctx, "result_expression_prior");
            if ( tree != null )
            {
                Result_Expression_Prior result_expression_prior = new Result_Expression_Prior();
                case_when_expression.setResult_expression_prior(result_expression_prior);
                this.stack.push(result_expression_prior);
                this.visit(tree);
                this.stack.pop();            
            }
            return null;            
        }

	@Override public Void visitOrder_expression(@NotNull DataViewParser.Order_expressionContext ctx) { 
            
            Order_Expression order_expression = this.stack.peekCtx(Order_Expression.class);   
            order_expression.parse(ctx,this.stack.peekPrev());
            
            ParseTree tree = TreeUtil.getChild(ctx, "field_regular");
            if ( tree != null )
            {
                Field_Regular field_regular = new Field_Regular();
                order_expression.setField_regular(field_regular);
                this.stack.push(field_regular);
                this.visit(tree);
                this.stack.pop();            
            }
            
            if ( ctx.getChildCount() > 1)
            {
                if ( ctx.getChild(1).getText().equalsIgnoreCase("desc"))
                {
                    order_expression.setIs_desc(true);
                }
            }
            return null;
        }

	@Override public Void visitTable(@NotNull DataViewParser.TableContext ctx) { 
        
            Table table = this.stack.peekCtx(Table.class);    
            table.parse(ctx,this.stack.peekPrev());
            
            if ( !ctx.isEmpty())
            {
                table.setText(ctx.getText());
            }
            return null;
        }

	@Override public Void visitSelect_alias(@NotNull DataViewParser.Select_aliasContext ctx) { 
            
            Select_Alias select_alias = this.stack.peekCtx(Select_Alias.class);   
            select_alias.parse(ctx,this.stack.peekPrev());
            
            ParseTree tree = TreeUtil.getChild(ctx, "select");
            if ( tree != null )
            {
                Select_Atom select = new Select_Atom();
                select_alias.setSelect(select);
                this.stack.push(select);
                this.visit(tree);
                this.stack.pop();            
            }
            
            int childCount = ctx.getChildCount();
            if ( childCount> 1)
            {
                String alias = ctx.getChild(1).getText();
                if ( alias.compareToIgnoreCase("as") == 0 )
                {
                    if ( childCount > 2 )
                    {alias = ctx.getChild(2).getText();}
                }
                select_alias.setAlias(alias);
            }
            
            return null;
        }

	@Override public Void visitSelect_clause_full(@NotNull DataViewParser.Select_clause_fullContext ctx) { 
        
            Select_Clause_Full select_clause_full = this.stack.peekCtx(Select_Clause_Full.class); 
            select_clause_full.parse(ctx,this.stack.peekPrev());
            
            Top_clauseContext top = ctx.top_clause();
            if ( top != null ){
                Top_Clause topClause = new Top_Clause();
                select_clause_full.setTop_clause(topClause);
                this.stack.push(topClause);
                this.visit(top);
                this.stack.pop(); 
            }
            
            ParseTree tree = TreeUtil.getChild(ctx, "select_clause");
            if ( tree != null )
            {
                Select_Clause select_clause = new Select_Clause();
                select_clause_full.setSelect_clause(select_clause);
                this.stack.push(select_clause);
                this.visit(tree);
                this.stack.pop();            
            }
            return null;
        }
        
        public Void visitTop_clause(@NotNull DataViewParser.Top_clauseContext ctx) {            
            Top_Clause topClause = this.stack.peekCtx(Top_Clause.class); 
            topClause.parse(ctx,this.stack.peekPrev());
            
            DataViewParser.ValueContext valCtx = ctx.value();
            if ( valCtx != null )
            {
                Value val = new Value();
                topClause.setValue(val);
                this.stack.push(val);
                this.visit(valCtx);
                this.stack.pop();            
            }
            return null;
        }
  /*
	 public Void visitCompare_complex_mix(@NotNull DataViewParser.Compare_complex_mixContext ctx) { 
         return null;
       
            Compare_Complex_Mix compare_complex_mix  = this.stack.peekCtx(Compare_Complex_Mix.class);       
            compare_complex_mix.parse(ctx,this.stack.peekPrev());
            
            List<ParseTree> trees = TreeUtil.getChildren(ctx, "compare_complex");
            if ( trees != null )
            {
                for(int index = 0 ; index < trees.size() ;index ++)
                {
                    Compare_Complex compare_complex = new Compare_Complex();
                    compare_complex_mix.getCompare_complexs().add(compare_complex);
                    this.stack.push(compare_complex);
                    this.visit(trees.get(index));
                    this.stack.pop();
                }
            }
            for(int index = 0 ; index < ctx.getChildCount() ; index ++)
            {
                String r = ctx.getChild(index).getText().toLowerCase();
                if ( r.equalsIgnoreCase("and") || r.equalsIgnoreCase("or"))
                {
                    compare_complex_mix.getRelations().add(r);
                }
            }
            return null;
        
        }
 */
	@Override public Void visitOption_list(@NotNull DataViewParser.Option_listContext ctx) {
            
           Option_List option_list = this.stack.peekCtx(Option_List.class);
           option_list.parse(ctx,this.stack.peekPrev());
                       
            List<ParseTree> trees = TreeUtil.getChildren(ctx, "option");
            if ( trees != null && trees.size() > 0)
            {
                for(int i = 0 ; i< trees.size();i ++)
                {
                    Option option = new Option();
                    option_list.getOptions().add(option);
                    this.stack.push(option);
                    this.visit(trees.get(i));
                    this.stack.pop();     
                }
            }
            return null;
        }

	@Override public Void visitOption_expression(@NotNull DataViewParser.Option_expressionContext ctx) { 
            
            Option_Expression option_expression = this.stack.peekCtx(Option_Expression.class);
            option_expression.parse(ctx,this.stack.peekPrev());
                       
            ParseTree tree = TreeUtil.getChild(ctx, "option_list");
            if ( tree != null )
            {
                Option_List option_list = new Option_List();
                option_expression.setOption_list(option_list);
                this.stack.push(option_list);
                this.visit(tree);
                this.stack.pop();            
            }
            return null;
            //return visitChildren(ctx); 
        }

	@Override public Void visitFrom_clause(@NotNull DataViewParser.From_clauseContext ctx) { 
            From_Clause from_clause = this.stack.peekCtx(From_Clause.class);
            from_clause.parse(ctx,this.stack.peekPrev());
            
            ParseTree tree = TreeUtil.getChild(ctx, "select_alias");
            if(tree != null )
            {
                Select_Alias select_alias = new Select_Alias();
                from_clause.setSelect_alias(select_alias);
                this.stack.push(select_alias);
                this.visit(tree);
                this.stack.pop();
                return null;
            }
            
            List<ParseTree> trees = TreeUtil.getChildren(ctx, "table_alias");
            if(trees != null && trees.size() > 0)
            {
                for(int i = 0 ; i < trees.size() ; i ++)
                {
                    Table_Alias table_alias = new Table_Alias();
                    from_clause.getTable_alias_list().add(table_alias);
                    this.stack.push(table_alias);
                    this.visit(trees.get(i));
                    this.stack.pop();
                }
            }
            return null;
        }

	@Override public Void visitTable_field(@NotNull DataViewParser.Table_fieldContext ctx) { 
            
            Table_Field table_field = this.stack.peekCtx(Table_Field.class);   
            table_field.parse(ctx,this.stack.peekPrev());
            
            ParseTree tree = TreeUtil.getChild(ctx, "table_field_atom");
            if ( tree != null )
            {
                Table_Field_Atom table_field_atom = new Table_Field_Atom();
                table_field.setTable_field_atom(table_field_atom);
                this.stack.push(table_field_atom);
                this.visit(tree);
                this.stack.pop();            
            }
            tree = TreeUtil.getChild(ctx, "binary_expression");
            if ( tree != null )
            {
                Binary_Expression binary_expression = new Binary_Expression();
                table_field.setBinary_expression(binary_expression);
                this.stack.push(binary_expression);
                this.visit(tree);
                this.stack.pop();            
            }
                                  
            return null;
        }           
        
        @Override public Void visitBinary_expression(@NotNull DataViewParser.Binary_expressionContext ctx) { 
            Binary_Expression binary_expression = this.stack.peekCtx(Binary_Expression.class);    
            binary_expression.parse(ctx,this.stack.peekPrev());
            
            List<ParseTree> trees = TreeUtil.getChildren(ctx, "multiplicative_expression");
            if ( trees != null )
            {
                for(int index = 0 ;index < trees.size() ; index ++)
                {
                    Multiplicative_Expression multiplicative_expression = new Multiplicative_Expression();
                    binary_expression.getMultiplicative_expressions().add(multiplicative_expression);
                    this.stack.push(multiplicative_expression);
                    this.visit(trees.get(index));
                    this.stack.pop();            
                }
            }
            for(int index = 0 ;index < ctx.getChildCount() ; index ++)
            {
                String text = ctx.getChild(index).getText();                
                if ( text == "+" || text == "-" || text == "&" || text == "^" || text == "|")
                {
                    binary_expression.getOperators().add(text);
                }
            }
            
            return null;  
        }
        
        @Override public Void visitMultiplicative_expression(@NotNull DataViewParser.Multiplicative_expressionContext ctx) { 
            Multiplicative_Expression multiplicative_expression = this.stack.peekCtx(Multiplicative_Expression.class);    
            multiplicative_expression.parse(ctx,this.stack.peekPrev());
            
            List<ParseTree> trees = TreeUtil.getChildren(ctx, "multiplicative_expression");
            if ( trees != null )
            {
                for(int index = 0 ;index < trees.size() ; index ++)
                {
                    Positive_Expression positive_expression = new Positive_Expression();
                    multiplicative_expression.getPositive_expressions().add(positive_expression);
                    this.stack.push(positive_expression);
                    this.visit(trees.get(index));
                    this.stack.pop();            
                }
            }
            
            for(int index = 0 ;index < ctx.getChildCount() ; index ++)
            {
                String text = ctx.getChild(index).getText();                
                if ( text == "*" || text == "/" || text == "%" )
                {
                    multiplicative_expression.getOperators().add(text);
                }
            }
            
            return null;  
        }        
        
        @Override public Void visitPositive_expression(@NotNull DataViewParser.Positive_expressionContext ctx) {
            Positive_Expression positive_expression = this.stack.peekCtx(Positive_Expression.class);    
            positive_expression.parse(ctx,this.stack.peekPrev());
            
            ParseTree tree = TreeUtil.getChild(ctx, "unary_operator");
            if ( tree != null )
            {
      
                Unary_Operator unary_operator = new Unary_Operator();
                positive_expression.setUnary_operator(unary_operator);
                this.stack.push(unary_operator);
                this.visit(tree);
                this.stack.pop();            
            }
            
            for(int index = 0 ;index < ctx.getChildCount() ; index ++)
            {
                String text = ctx.getChild(index).getText();                
                if ( text == "+" || text == "-")
                {
                    positive_expression.setOperator(text);
                    break;
                }
            }
            
            return null;  
        }
        
        @Override public Void visitUnary_operator(@NotNull DataViewParser.Unary_operatorContext ctx) { 
            Unary_Operator unary_operator = this.stack.peekCtx(Unary_Operator.class);    
            unary_operator.parse(ctx,this.stack.peekPrev());
            
            ParseTree tree = TreeUtil.getChild(ctx, "table_field_atom");
            if ( tree != null )
            {      
                Table_Field_Atom table_field_atom = new Table_Field_Atom();
                unary_operator.setTable_field_atom(table_field_atom);
                this.stack.push(table_field_atom);
                this.visit(tree);
                this.stack.pop();            
            }
            
            for(int index = 0 ;index < ctx.getChildCount() ; index ++)
            {
                String text = ctx.getChild(index).getText();                
                if ( text == "~" )
                {
                    unary_operator.setOperator(text);
                    break;
                }
            }
            
            return null;   
        }                    
        @Override public Void visitTable_field_atom(@NotNull DataViewParser.Table_field_atomContext ctx) 
        { 
            Table_Field_Atom table_field = this.stack.peekCtx(Table_Field_Atom.class);   
            table_field.parse(ctx,this.stack.peekPrev());
            
            ParseTree tree = TreeUtil.getChild(ctx, "value");
            if ( tree != null )
            {
                Value value = new Value();
                table_field.setValue(value);
                this.stack.push(value);
                this.visit(tree);
                this.stack.pop();            
            }
            tree = TreeUtil.getChild(ctx, "all_field");
            if ( tree != null )
            {
                All_Field all_field = new All_Field();
                table_field.setAll_field(all_field);
                this.stack.push(all_field);
                this.visit(tree);
                this.stack.pop();            
            }
            tree = TreeUtil.getChild(ctx, "table");
            if ( tree != null )
            {
                Table table = new Table();
                Table_All_Field table_all_field = new Table_All_Field();
                table_field.setTable_all_field(table_all_field);
                this.stack.push(table);
                this.visit(tree);
                table_all_field.setName(table.getText());
                this.stack.pop();            
            }
            tree = TreeUtil.getChild(ctx, "field_regular");
            if ( tree != null )
            {
                Field_Regular field_regular = new Field_Regular();
                table_field.setField_regular(field_regular);
                this.stack.push(field_regular);
                this.visit(tree);
                this.stack.pop();            
            }
            tree = TreeUtil.getChild(ctx, "case_clause_field");
            if ( tree != null )
            {
                Case_Clause_Field case_clause_field = new Case_Clause_Field();
                table_field.setCase_clause_field(case_clause_field);
                this.stack.push(case_clause_field);
                this.visit(tree);
                this.stack.pop();            
            }
            tree = TreeUtil.getChild(ctx, "function_field");
            if ( tree != null )
            {
                Function_Field function_field = new Function_Field();
                table_field.setFunction_field(function_field);
                this.stack.push(function_field);
                this.visit(tree);
                this.stack.pop();            
            }
            tree = TreeUtil.getChild(ctx, "binary_expression");
            if ( tree != null )
            {
                Binary_Expression binary_expression = new Binary_Expression();
                table_field.setBinary_expression(binary_expression);
                this.stack.push(binary_expression);
                this.visit(tree);
                this.stack.pop();            
            }
            return null;
        }

	@Override public Void visitCondition_clause_full(@NotNull DataViewParser.Condition_clause_fullContext ctx) { 
            
            Condition_Clause_Full condition_clause_full =  this.stack.peekCtx(Condition_Clause_Full.class);    
            condition_clause_full.parse(ctx,this.stack.peekPrev());
            
            ParseTree tree = TreeUtil.getChild(ctx, "condition_clause");
            if ( tree != null )
            {
                Condition_Clause condition_clause = new Condition_Clause();
                condition_clause_full.setCondition_clause(condition_clause);
                this.stack.push(condition_clause);
                this.visit(tree);
                this.stack.pop();            
            }
            return null;
        }

	@Override public Void visitCompare_complex(@NotNull DataViewParser.Compare_complexContext ctx) { 
        
            Compare_Complex compare_complex  = this.stack.peekCtx(Compare_Complex.class);  
            compare_complex.parse(ctx,this.stack.peekPrev());
            
            ParseTree tree = TreeUtil.getChild(ctx, "between_prior");
            if ( tree != null )
            {
                Between_Prior between_prior = new Between_Prior();
                compare_complex.setBetween_prior(between_prior);
                this.stack.push(between_prior);
                this.visit(tree);
                this.stack.pop();            
            }
            tree = TreeUtil.getChild(ctx, "binary_prior");
            if ( tree != null )
            {
                Binary_Prior binary_prior = new Binary_Prior();
                compare_complex.setBianary_prior(binary_prior);
                this.stack.push(binary_prior);
                this.visit(tree);
                this.stack.pop();            
            }
            tree = TreeUtil.getChild(ctx, "in_expression_prior");
            if ( tree != null )
            {
                In_Expression_Prior in_expression_prior = new In_Expression_Prior();
                compare_complex.setIn_expression_prior(in_expression_prior);
                this.stack.push(in_expression_prior);
                this.visit(tree);
                this.stack.pop();            
            }
            tree = TreeUtil.getChild(ctx, "existed_compare_prior");
            if ( tree != null )
            {
                Existed_Compare_Prior existed_compare_prior = new Existed_Compare_Prior();
                compare_complex.setExisted_compare_prior(existed_compare_prior);
                this.stack.push(existed_compare_prior);
                this.visit(tree);
                this.stack.pop();            
            }
            return null;
        }

	@Override public Void visitBinary_operater(@NotNull DataViewParser.Binary_operaterContext ctx) { 
            
            Binary_Operater binary_operater = this.stack.peekCtx(Binary_Operater.class);    
            binary_operater.parse(ctx,this.stack.peekPrev());
            
            binary_operater.setOperater(ctx.getText());
            return null;            
        }

	@Override public Void visitHaving_clause_full(@NotNull DataViewParser.Having_clause_fullContext ctx) { 
            
            Having_Clause_Full having_clause_full = this.stack.peekCtx(Having_Clause_Full.class);     
            having_clause_full.parse(ctx,this.stack.peekPrev());
            
            ParseTree tree = TreeUtil.getChild(ctx, "having_clause");
            if ( tree != null )
            {
                Having_Clause having_clause = new Having_Clause();
                having_clause_full.setHaving_clause(having_clause);
                this.stack.push(having_clause);
                this.visit(tree);
                this.stack.pop();            
            }
            return null;
        }

	@Override public Void visitCase_clause_prior(@NotNull DataViewParser.Case_clause_priorContext ctx) { 
            
            Case_Clause_Prior case_clause_prior = this.stack.peekCtx(Case_Clause_Prior.class);   
            case_clause_prior.parse(ctx,this.stack.peekPrev());
            
            ParseTree tree = TreeUtil.getChild(ctx, "case_clause");
            if ( tree != null )
            {
                Case_Clause case_clause = new Case_Clause();
                case_clause_prior.setCase_clause(case_clause);
                this.stack.push(case_clause);
                this.visit(tree);
                this.stack.pop();            
            }
            return null;
        
        }

	@Override public Void visitTable_alias(@NotNull DataViewParser.Table_aliasContext ctx) { 
            Table_Alias table_alias = this.stack.peekCtx(Table_Alias.class);   
            table_alias.parse(ctx,this.stack.peekPrev());
            
            ParseTree tree = TreeUtil.getChild(ctx, "table");
            if(tree != null)
            {                
                Table table = new Table();
                table_alias.setTable(table);
                this.stack.push(table);
                this.visit(tree);
                this.stack.pop();
             }            
            int childCount = ctx.getChildCount();
            if ( childCount> 1)
            {
                String alias = ctx.getChild(1).getText();
                if ( alias.compareToIgnoreCase("as") == 0 )
                {
                    if ( childCount > 2 )
                    {alias = ctx.getChild(2).getText();}
                }
                table_alias.setAlias(alias);
            }
            return null;
        }

	@Override public Void visitParameter_options(@NotNull DataViewParser.Parameter_optionsContext ctx) { return visitChildren(ctx); }

	@Override public Void visitTable_field_alias(@NotNull DataViewParser.Table_field_aliasContext ctx) { 
            
            Table_Field_Alias table_field_alias  = this.stack.peekCtx(Table_Field_Alias.class);      
            table_field_alias.parse(ctx,this.stack.peekPrev());
            
            ParseTree tree = TreeUtil.getChild(ctx, "table_field");
            if ( tree != null )
            {
                Table_Field table_field = new Table_Field();
                table_field_alias.setTable_field(table_field);
                this.stack.push(table_field);
                this.visit(tree);
                this.stack.pop();            
            }
            
            int childCount = ctx.getChildCount();
            if ( childCount > 1)
            {
               String alias = ctx.getChild(1).getText();
               if ( alias.compareToIgnoreCase("as") == 0 )
               {
                   if ( childCount > 2 )
                   {alias = ctx.getChild(2).getText();}
               }
               table_field_alias.setAlias(alias);
            }            
            
            return null;
        }

	@Override public Void visitFrom_clause_full(@NotNull DataViewParser.From_clause_fullContext ctx) {
            
            From_Clause_Full from_clause_full = this.stack.peekCtx(From_Clause_Full.class);
            from_clause_full.parse(ctx,this.stack.peekPrev());
            
            ParseTree tree = TreeUtil.getChild(ctx, "from_clause");
            if(tree != null )
            {
                From_Clause from_clause = new From_Clause();
                from_clause_full.setFrom_clause(from_clause);
                this.stack.push(from_clause);
                this.visit(tree);
                this.stack.pop();
            }
            return null;
        }

	@Override public Void visitOrder_clause(@NotNull DataViewParser.Order_clauseContext ctx) { 
            
            Order_Clause order_clause = this.stack.peekCtx(Order_Clause.class);   
            order_clause.parse(ctx,this.stack.peekPrev());
            
            List<ParseTree> trees = TreeUtil.getChildren(ctx, "order_expression");
            if ( trees != null )
            {
                for(int index = 0 ;index < trees.size() ; index ++)
                {
                    Order_Expression order_expression = new Order_Expression();
                    order_clause.getOrder_expressions().add(order_expression);
                    this.stack.push(order_expression);
                    this.visit(trees.get(index));
                    this.stack.pop();            
                }
            }
            return null;   
        }

	@Override public Void visitBinary(@NotNull DataViewParser.BinaryContext ctx) { 

            Binary binary = this.stack.peekCtx(Binary.class);            
            binary.parse(ctx,this.stack.peekPrev());
            
            ParseTree tree = TreeUtil.getChild(ctx, "binary_compare_prior");
            if ( tree != null )
            {
                Binary_Compare_Prior binary_compare_prior = new Binary_Compare_Prior();
                binary.setBinary_compare_prior(binary_compare_prior);
                this.stack.push(binary_compare_prior);
                this.visit(tree);
                this.stack.pop();            
            }
            return null;

        }

	@Override public Void visitOrder_clause_full(@NotNull DataViewParser.Order_clause_fullContext ctx) { 
            
            Order_Clause_Full order_clause_full = this.stack.peekCtx(Order_Clause_Full.class);     
            order_clause_full.parse(ctx,this.stack.peekPrev());
            
            ParseTree tree = TreeUtil.getChild(ctx, "order_clause");
            if ( tree != null )
            {
                Order_Clause order_clause = new Order_Clause();
                order_clause_full.setOrder_clause(order_clause);
                this.stack.push(order_clause);
                this.visit(tree);
                this.stack.pop();            
            }
            return null;
        }

	@Override public Void visitJoin_on_clause(@NotNull DataViewParser.Join_on_clauseContext ctx) {
            
            Join_On_Clause join_on_clause = this.stack.peekCtx(Join_On_Clause.class);    
            join_on_clause.parse(ctx,this.stack.peekPrev());
            
            ParseTree tree = TreeUtil.getChild(ctx, "condition_clause");
            if ( tree != null )
            {
                Condition_Clause condition_clause = new Condition_Clause();
                join_on_clause.setCondition_clause(condition_clause);
                this.stack.push(condition_clause);
                this.visit(tree);
                this.stack.pop();            
            }
            return null;
        }

	@Override public Void visitRight_outer_join(@NotNull DataViewParser.Right_outer_joinContext ctx) { return visitChildren(ctx); }

	@Override public Void visitCase_have_target_when_expression(@NotNull DataViewParser.Case_have_target_when_expressionContext ctx) { 
           Case_Have_Target_When_Expression case_have_target_when_expression = this.stack.peekCtx(Case_Have_Target_When_Expression.class);    
            case_have_target_when_expression.parse(ctx,this.stack.peekPrev());
            
            ParseTree tree = ctx.value();
            if ( tree != null )
            {
                Value val = new Value();
                case_have_target_when_expression.setValue(val);
                this.stack.push(val);
                this.visit(tree);
                this.stack.pop();            
            }
            tree = ctx.result_expression_prior();
            if ( tree != null )
            {
                Result_Expression_Prior result_expression_prior = new Result_Expression_Prior();
                case_have_target_when_expression.setResult_expression_prior(result_expression_prior);
                this.stack.push(result_expression_prior);
                this.visit(tree);
                this.stack.pop();            
            }
            
            return null;
        }

	@Override public Void visitBetween_prior(@NotNull DataViewParser.Between_priorContext ctx) { return visitChildren(ctx); }

	@Override public Void visitParameter(@NotNull DataViewParser.ParameterContext ctx) { 
        
            Parameter paramter = this.stack.peekCtx(Parameter.class);            
            ParseTree tree = TreeUtil.getChild(ctx, "parameter_name");
            if ( tree != null )
            {
                Parameter_Name parameter_name = new Parameter_Name();
                parameter_name.setText(tree.getText());
                paramter.setParameter_name(parameter_name);
                //this.stack.push(parameter_name);
                //this.visit(tree);
                //this.stack.pop();            
            }
            return null;        
        }
        
        @Override public Void visitHaving_clause(@NotNull DataViewParser.Having_clauseContext ctx) {
            
            Having_Clause having_clause = this.stack.peekCtx(Having_Clause.class);         
            having_clause.parse(ctx,this.stack.peekPrev());
            
            ParseTree tree = TreeUtil.getChild(ctx, "condition_clause");
            if ( tree != null )
            {
                Condition_Clause condition_clause = new Condition_Clause();
                having_clause.setCondition(condition_clause);
                this.stack.push(condition_clause);
                this.visit(tree);
                this.stack.pop();            
            }
            return null;
        }

	@Override public Void visitLong_name(@NotNull DataViewParser.Long_nameContext ctx) { 
        
            Long_Name long_name = this.stack.peekCtx(Long_Name.class);        
            long_name.parse(ctx,this.stack.peekPrev());
            long_name.setText(ctx.getText());
            
            return null;
        }

	@Override public Void visitResult_expression_prior(@NotNull DataViewParser.Result_expression_priorContext ctx) {
          
            Result_Expression_Prior result_expression_prior = this.stack.peekCtx(Result_Expression_Prior.class);    
            result_expression_prior.parse(ctx,this.stack.peekPrev());
            
            ParseTree tree = TreeUtil.getChild(ctx, "result_expression");
            if ( tree != null )
            {
                Result_Expression result_expression = new Result_Expression();
                result_expression_prior.setResult_expression(result_expression);
                this.stack.push(result_expression);
                this.visit(tree);
                this.stack.pop();            
            }
           
            return null;
        }

	@Override public Void visitField_regular(@NotNull DataViewParser.Field_regularContext ctx) {
            
            Field_Regular field_regular = this.stack.peekCtx(Field_Regular.class);  
            field_regular.parse(ctx,this.stack.peekPrev());
            
            ParseTree tree = TreeUtil.getChild(ctx, "long_name");
            if ( tree != null )
            {
                Long_Name long_name = new Long_Name();
                field_regular.setLong_name(long_name);
                this.stack.push(long_name);
                this.visit(tree);
                this.stack.pop();            
            }
            return null;
        
        }        

	@Override public Void visitExisted_compare(@NotNull DataViewParser.Existed_compareContext ctx) {
            
            Existed_Compare existed_compare = this.stack.peekCtx(Existed_Compare.class);          
            existed_compare.parse(ctx,this.stack.peekPrev());
            
            String p1 = ctx.getChild(0).getText();
            if ( p1.equalsIgnoreCase("exists"))
            {
                existed_compare.setIs_existed(true);
            }
            else
            {
                existed_compare.setIs_not_existed(true);
            }
            
            ParseTree tree = TreeUtil.getChild(ctx, "select");
            if ( tree != null )
            {
                Select_Atom select = new Select_Atom();
                existed_compare.setSelect(select);
                this.stack.push(select);
                this.visit(tree);
                this.stack.pop();            
            }
            return null; 
        }

        /*
	 public Void visitCompare_complex_mix_prior(@NotNull DataViewParser.Compare_complex_mix_priorContext ctx) {
            
            Compare_Complex_Mix_Prior compare_complex_mix_prior  = this.stack.peekCtx(Compare_Complex_Mix_Prior.class);  
            compare_complex_mix_prior.parse(ctx,this.stack.peekPrev());
            
            List<ParseTree> trees = TreeUtil.getChildren(ctx, "compare_complex_prior");
            if ( trees != null )
            {
                for(int i = 0 ; i < trees.size() ; i ++)
                {
                    Compare_Complex_Prior compare_complex_prior = new Compare_Complex_Prior();
                    compare_complex_mix_prior.getCompare_complex_priors().add(compare_complex_prior);
                    this.stack.push(compare_complex_prior);
                    this.visit(trees.get(i));
                    this.stack.pop();            
                }
            }
            for(int i = 0 ; i < ctx.getChildCount() ; i ++)
            {
                String r = ctx.getChild(i).getText().toLowerCase();
                if ( r.equalsIgnoreCase("and") || r.equalsIgnoreCase("or"))
                {
                    compare_complex_mix_prior.getRelations().add(r);
                }
            }    
            return null;
        
        }
        * */
        @Override public Void visitCompare_complex_prior(@NotNull DataViewParser.Compare_complex_priorContext ctx) 
        { 
            Compare_Complex_Prior compare_complex_prior  = this.stack.peekCtx(Compare_Complex_Prior.class);             
            compare_complex_prior.parse(ctx,this.stack.peekPrev());
            
            ParseTree tree = TreeUtil.getChild(ctx, "compare_complex_mix_or");
            if ( tree != null )
            {
                Compare_Complex_Mix_Or compare_complex_mix_or = new Compare_Complex_Mix_Or();
                compare_complex_prior.setCompare_complex_mix_or(compare_complex_mix_or);
                this.stack.push(compare_complex_mix_or);
                this.visit(tree);
                this.stack.pop();            
            }
            tree = TreeUtil.getChild(ctx, "compare_complex");
            if ( tree != null )
            {
                Compare_Complex compare_complex = new Compare_Complex();
                compare_complex_prior.setCompare_complex(compare_complex);
                this.stack.push(compare_complex);
                this.visit(tree);
                this.stack.pop();            
            }
            tree = TreeUtil.getChild(ctx, "search_option");
            if ( tree != null )
            {
                Search_Option search_option = new Search_Option();
                compare_complex_prior.setSearch_option(search_option);
                this.stack.push(search_option);
                this.visit(tree);
                this.stack.pop();            
            } 
            return null; 
        }
	@Override public Void visitCondition_option(@NotNull DataViewParser.Condition_optionContext ctx) { 
            
            Condition_Option condition_option = this.stack.peekCtx(Condition_Option.class);     
            condition_option.parse(ctx,this.stack.peekPrev());
            
            condition_option.setOption(ctx.getText());
            return null;
        
        }

	@Override public Void visitBetween(@NotNull DataViewParser.BetweenContext ctx) { return visitChildren(ctx); }

	@Override public Void visitAll_join(@NotNull DataViewParser.All_joinContext ctx) { return visitChildren(ctx); }

	@Override public Void visitLeft_join(@NotNull DataViewParser.Left_joinContext ctx) { return visitChildren(ctx); }

	@Override public Void visitLeft_outer_join(@NotNull DataViewParser.Left_outer_joinContext ctx) { return visitChildren(ctx); }

	@Override public Void visitExisted_compare_prior(@NotNull DataViewParser.Existed_compare_priorContext ctx) {
            
            Existed_Compare_Prior existed_compare_prior = this.stack.peekCtx(Existed_Compare_Prior.class);         
            existed_compare_prior.parse(ctx,this.stack.peekPrev());
            
            ParseTree tree = TreeUtil.getChild(ctx, "existed_compare");
            if ( tree != null )
            {
                Existed_Compare existed_compare = new Existed_Compare();
                existed_compare_prior.setExisted_compare(existed_compare);
                this.stack.push(existed_compare);
                this.visit(tree);
                this.stack.pop();            
            }
            return null;  
        }

        @Override public Void visitIn_expression_prior(@NotNull DataViewParser.In_expression_priorContext ctx) {
            
            In_Expression_Prior in_expression_prior = this.stack.peekCtx(In_Expression_Prior.class); 
            in_expression_prior.parse(ctx,this.stack.peekPrev());
            
            ParseTree tree = TreeUtil.getChild(ctx, "in_expression");
            if ( tree != null )
            {
                In_Expression in_expression = new In_Expression();
                in_expression_prior.setIn_expression(in_expression);
                this.stack.push(in_expression);
                this.visit(tree);
                this.stack.pop();            
            }
            return null;            
        }
        
	@Override public Void visitIn_expression(@NotNull DataViewParser.In_expressionContext ctx) { 
        
            In_Expression in_expression = this.stack.peekCtx(In_Expression.class); 
            in_expression.parse(ctx,this.stack.peekPrev());
            
            ParseTree tree = TreeUtil.getChild(ctx, "table_field");
            if ( tree != null )
            {
                Table_Field table_field = new Table_Field();
                in_expression.setTable_field(table_field);
                this.stack.push(table_field);
                this.visit(tree);
                this.stack.pop();            
            }
            tree = TreeUtil.getChild(ctx, "in_keyword");
            if ( tree != null )
            {
                In_Keyword in_keyword = new In_Keyword();
                in_expression.setIn_keyword(in_keyword);
                this.stack.push(in_keyword);
                this.visit(tree);
                this.stack.pop();            
            }
            tree = TreeUtil.getChild(ctx, "in_right_value");
            if ( tree != null )
            {
                In_Right_Value right_value_in = new In_Right_Value();
                in_expression.setIn_right_value(right_value_in);
                this.stack.push(right_value_in);
                this.visit(tree);
                this.stack.pop();            
            }
            return null; 
        }

	@Override public Void visitOption_name(@NotNull DataViewParser.Option_nameContext ctx) { 
            Option_Name option_name = this.stack.peekCtx(Option_Name.class);     
            option_name.parse(ctx,this.stack.peekPrev());
            
            if ( ctx.children.size() > 0 )
            {
                option_name.setText(ctx.children.get(0).getText());
            }
            /*
            ParseTree tree = TreeUtil.getChild(ctx, "parameter_name");
            if ( tree != null )
            {
                option_name.setText(tree.getText());
            }
            tree = TreeUtil.getChild(ctx, "STRING");
            if ( tree != null )
            {
                option_name.setText(tree.getText());
            }
            */
            return null;
            //return visitChildren(ctx); 
        }

	@Override public Void visitCase_clause(@NotNull DataViewParser.Case_clauseContext ctx) { 
            
            Case_Clause case_clause = this.stack.peekCtx(Case_Clause.class);           
            case_clause.parse(ctx,this.stack.peekPrev());
            
            ParseTree tree = TreeUtil.getChild(ctx, "case_have_target_expression");
            if ( tree != null )
            {
                Case_Have_Target_Expression case_have_target_expression = new Case_Have_Target_Expression();
                case_clause.setCase_have_target_expression(case_have_target_expression);
                this.stack.push(case_have_target_expression);
                this.visit(tree);
                this.stack.pop();            
            }
            tree = TreeUtil.getChild(ctx, "case_expression");
            if ( tree != null )
            {
                Case_Expression case_expression = new Case_Expression();
                case_clause.setCase_expression(case_expression);
                this.stack.push(case_expression);
                this.visit(tree);
                this.stack.pop();            
            }
            return null;
        
        }

        /*
	@Override public Void visitIn_list(@NotNull DataViewParser.In_listContext ctx) { 
            In_Right_Value in_right_value = this.stack.peekCtx(In_Right_Value.class);            
            
            ParseTree tree = TreeUtil.getChild(ctx, "parameter");
            if ( tree != null )
            {
                Parameter parameter = new Parameter();
                in_right_value.setParameter(parameter);
                this.stack.push(parameter);
                this.visit(tree);
                this.stack.pop();            
            }
            
            tree = TreeUtil.getChild(ctx, "list");
            if ( tree != null )
            {
                Value_List list = new Value_List();
                in_right_value.setList(list);
                this.stack.push(list);
                this.visit(tree);
                this.stack.pop();            
            }
            
            return null;
        }
*/
	@Override public Void visitJoin(@NotNull DataViewParser.JoinContext ctx) { return visitChildren(ctx); }

	@Override public Void visitRight_join(@NotNull DataViewParser.Right_joinContext ctx) { return visitChildren(ctx); }

	@Override public Void visitBinary_compare_prior(@NotNull DataViewParser.Binary_compare_priorContext ctx) {
        
           Binary_Compare_Prior binary_compare_prior = this.stack.peekCtx(Binary_Compare_Prior.class);      
           binary_compare_prior.parse(ctx,this.stack.peekPrev());
           
            ParseTree tree = TreeUtil.getChild(ctx, "binary_compare");
            if ( tree != null )
            {
                Binary_Compare binary_compare = new Binary_Compare();
                binary_compare_prior.setBinary_compare(binary_compare);
                this.stack.push(binary_compare);
                this.visit(tree);
                this.stack.pop();            
            }
            tree = TreeUtil.getChild(ctx, "condition_option");
            if ( tree != null )
            {
                Condition_Option condition_option = new Condition_Option();
                binary_compare_prior.setCondition_option(condition_option);
                this.stack.push(condition_option);
                this.visit(tree);
                this.stack.pop();            
            }
            tree = TreeUtil.getChild(ctx, "search_option");
            if ( tree != null )
            {
                Search_Option search_option = new Search_Option();
                binary_compare_prior.setSearch_option(search_option);
                this.stack.push(search_option);
                this.visit(tree);
                this.stack.pop();            
            }
            return null;
        }

	@Override public Void visitFunction_field(@NotNull DataViewParser.Function_fieldContext ctx) { 
            
            Function_Field function_field = this.stack.peekCtx(Function_Field.class);         
            function_field.parse(ctx,this.stack.peekPrev());
            
            int childCount = ctx.getChildCount();
            if ( childCount> 0)
            {
                String name = ctx.getChild(0).getText();
                function_field.setName(name);
            }
            
            ParseTree tree = TreeUtil.getChild(ctx, "function_parameter_list");
            if ( tree != null )
            {
                Function_Parameter_List function_parameter_list = new Function_Parameter_List();
                function_field.setFunction_parameter_list(function_parameter_list);
                this.stack.push(function_parameter_list);
                this.visit(tree);
                this.stack.pop();            
            }
            return null; 
        }

        @Override public Void visitJoin_clause_full(@NotNull DataViewParser.Join_clause_fullContext ctx) { 
            
            Join_Clause_Full join_clause_full = this.stack.peekCtx(Join_Clause_Full.class);
            join_clause_full.parse(ctx,this.stack.peekPrev());
            
            List<ParseTree> trees = TreeUtil.getChildren(ctx, "join_clause");
            if ( trees != null )
            {
                for(int index = 0 ; index < trees.size() ; index ++ )
                {
                    Join_Clause join_clause = new Join_Clause();
                    join_clause_full.getJoin_clause_list().add(join_clause);
                    this.stack.push(join_clause);
                    this.visit(trees.get(index));
                    this.stack.pop(); 
                }                          
            }
            return null;
        }
        
	@Override public Void visitJoin_clause(@NotNull DataViewParser.Join_clauseContext ctx) {
            
            Join_Clause join_clause = this.stack.peekCtx(Join_Clause.class);
            join_clause.parse(ctx,this.stack.peekPrev());
            
            ParseTree tree = TreeUtil.getChild(ctx, "all_join");
            if ( tree != null )
            {
                All_Join all_join = new All_Join();
                join_clause.setJoin_type(tree.getText());
                this.stack.push(all_join);
                this.visit(tree);
                this.stack.pop();            
            }
            tree = TreeUtil.getChild(ctx, "table_alias");
            if ( tree != null )
            {
                Table_Alias table_alias = new Table_Alias();
                join_clause.setTable_alias(table_alias);
                this.stack.push(table_alias);
                this.visit(tree);
                this.stack.pop();            
            }
            tree = TreeUtil.getChild(ctx, "join_on_clause");
            if ( tree != null )
            {
                Join_On_Clause join_on_clause = new Join_On_Clause();
                join_clause.setJoin_on_clause(join_on_clause);
                this.stack.push(join_on_clause);
                this.visit(tree);
                this.stack.pop();            
            }
            return null;
        }

	@Override public Void visitCase_expression(@NotNull DataViewParser.Case_expressionContext ctx) { 
            
            Case_Expression case_expression = this.stack.peekCtx(Case_Expression.class);     
            case_expression.parse(ctx,this.stack.peekPrev());
            
            List<ParseTree> trees = TreeUtil.getChildren(ctx, "case_when_expression");
            if ( trees != null && trees.size() > 0)
            {
                for(int index = 0 ; index < trees.size() ; index ++ )
                {
                    Case_When_Expression case_when_expression = new Case_When_Expression();
                    case_expression.getCase_when_expressions().add(case_when_expression);
                    this.stack.push(case_when_expression);
                    this.visit(trees.get(index));
                    this.stack.pop();            
                }
            }
            
            ParseTree tree = TreeUtil.getChild(ctx, "case_else_expression");
            if ( tree != null )
            {
                Case_Else_Expression case_else_expression = new Case_Else_Expression();
                case_expression.setCase_else_expression(case_else_expression);
                this.stack.push(case_else_expression);
                this.visit(tree);
                this.stack.pop();            
            }
            return null;
        }

	@Override public Void visitSelect_list(@NotNull DataViewParser.Select_listContext ctx) { 
        
            Select_List select_list = this.stack.peekCtx(Select_List.class);            
            select_list.parse(ctx,this.stack.peekPrev());
            
            ParseTree tree = TreeUtil.getChild(ctx, "select");
            if ( tree != null )
            {
                Select select = new Select();
                select_list.setSelect(select);
                this.stack.push(select);
                this.visit(tree);
                this.stack.pop();            
            }

            return null;
        }

	@Override public Void visitFunction_parameter_list(@NotNull DataViewParser.Function_parameter_listContext ctx) { 
            
            Function_Parameter_List function_parameter_list = this.stack.peekCtx(Function_Parameter_List.class);         
            function_parameter_list.parse(ctx,this.stack.peekPrev());                      
            
            List<ParseTree> trees = TreeUtil.getChildren(ctx, "function_parameter");
            if ( trees != null )
            {
                for(int index = 0 ; index < trees.size() ;index ++ )
                {
                    Function_Parameter function_parameter = new Function_Parameter();
                    function_parameter_list.getFunction_parameters().add(function_parameter);
                    this.stack.push(function_parameter);
                    this.visit(trees.get(index));
                    this.stack.pop();            
                }
            }
            return null; 
        }

	@Override public Void visitOption_value(@NotNull DataViewParser.Option_valueContext ctx) { 
        
            Option_Value option_value = this.stack.peekCtx(Option_Value.class);       
            option_value.parse(ctx,this.stack.peekPrev());  
            
            if ( ctx.children.size() > 0 )
            {
                option_value.setText(ctx.children.get(0).getText());
            }
            return null;
            //return visitChildren(ctx); 
        }

	@Override public Void visitGroup_clause(@NotNull DataViewParser.Group_clauseContext ctx) {
            
            Group_Clause group_clause = this.stack.peekCtx(Group_Clause.class); 
            group_clause.parse(ctx,this.stack.peekPrev());  
            
             List<ParseTree> trees = TreeUtil.getChildren(ctx, "field_regular");
            if ( trees != null )
            {
                for(int index = 0 ;index < trees.size() ; index ++)
                {
                    Field_Regular field_regular = new Field_Regular();
                    group_clause.getField_Regulars().add(field_regular);
                    this.stack.push(field_regular);
                    this.visit(trees.get(index));
                    this.stack.pop();            
                }
            }
            
            ParseTree tree = TreeUtil.getChild(ctx, "having_clause_full");
            if ( tree != null )
            {
                Having_Clause_Full having_clause_full = new Having_Clause_Full();
                group_clause.setHaving_clause_full(having_clause_full);
                this.stack.push(having_clause_full);
                this.visit(tree);
                this.stack.pop();            
            }
            return null;
        }

	@Override public Void visitAll_field(@NotNull DataViewParser.All_fieldContext ctx) { return visitChildren(ctx); }
  }

