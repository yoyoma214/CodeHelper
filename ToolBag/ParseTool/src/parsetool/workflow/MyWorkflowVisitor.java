/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package parsetool.workflow;

import java.util.List;
import org.antlr.v4.runtime.misc.NotNull;
import org.antlr.v4.runtime.tree.ParseTree;
import org.antlr.v4.runtime.tree.TerminalNode;
import org.antlr.v4.runtime.tree.TerminalNodeImpl;
import parsetool.utils.StackUtil;
import parsetool.utils.TreeUtil;
import parsetool.workflow.models.Action;
import parsetool.workflow.models.AfterAction;
import parsetool.workflow.models.Attribute;
import parsetool.workflow.models.BeforeAction;
import parsetool.workflow.models.Clz;
import parsetool.workflow.models.Execute_Line;
import parsetool.workflow.models.Field;
import parsetool.workflow.models.Form;
import parsetool.workflow.models.Generic_Type;
import parsetool.workflow.models.Init;
import parsetool.workflow.models.Long_Name;
import parsetool.workflow.models.Node;
import parsetool.workflow.models.Option;
import parsetool.workflow.models.Option_List;
import parsetool.workflow.models.Parallel;
import parsetool.workflow.models.Program;
import parsetool.workflow.models.Ref_Workflow;
import parsetool.workflow.models.State;
import parsetool.workflow.models.Translation;
import parsetool.workflow.models.Unit;
import parsetool.workflow.models.Variable;
import parsetool.workflow.models.expressions.Additive_Expression;
import parsetool.workflow.models.expressions.And_Expression;
import parsetool.workflow.models.expressions.Argument_Expression_List;
import parsetool.workflow.models.expressions.Assignment_Expression;
import parsetool.workflow.models.expressions.CaseExpression;
import parsetool.workflow.models.expressions.Cast_Expression;
import parsetool.workflow.models.expressions.Conditional_Expression;
import parsetool.workflow.models.expressions.Constant;
import parsetool.workflow.models.expressions.Creator;
import parsetool.workflow.models.expressions.Equality_Expression;
import parsetool.workflow.models.expressions.Exclusive_Or_Expression;
import parsetool.workflow.models.expressions.Expression;
import parsetool.workflow.models.expressions.Inclusive_Or_Expression;
import parsetool.workflow.models.expressions.Logical_And_Expression;
import parsetool.workflow.models.expressions.Logical_Or_Expression;
import parsetool.workflow.models.expressions.Multiplicative_Expression;
import parsetool.workflow.models.expressions.Postfix_Expression;
import parsetool.workflow.models.expressions.Postfix_Part;
import parsetool.workflow.models.expressions.Postfix_Part_Decrease;
import parsetool.workflow.models.expressions.Postfix_Part_Empty_Function;
import parsetool.workflow.models.expressions.Postfix_Part_Function;
import parsetool.workflow.models.expressions.Postfix_Part_Increase;
import parsetool.workflow.models.expressions.Postfix_Part_Index;
import parsetool.workflow.models.expressions.Postfix_Part_Long_Name;
import parsetool.workflow.models.expressions.Primary_Expression;
import parsetool.workflow.models.expressions.Relational_Expression;
import parsetool.workflow.models.expressions.Shift_Expression;
import parsetool.workflow.models.expressions.Unary_Expression;
import parsetool.workflow.models.expressions.Unary_Expression_One_Char;
import parsetool.workflow.models.expressions.Unary_Expression_Two_Char;
import parsetool.workflow.models.statements.BreakStatement;
import parsetool.workflow.models.statements.ContinueStatement;
import parsetool.workflow.models.statements.Declare;
import parsetool.workflow.models.statements.Declare_Statement;
import parsetool.workflow.models.statements.DoWhileStatement;
import parsetool.workflow.models.statements.Expression_Statement;
import parsetool.workflow.models.statements.ForEachStatement;
import parsetool.workflow.models.statements.ForStatement;
import parsetool.workflow.models.statements.GotoStatement;
import parsetool.workflow.models.statements.IfStatement;
import parsetool.workflow.models.statements.Statement;
import parsetool.workflow.models.statements.SwitchStatement;
import parsetool.workflow.models.statements.Translation_statement;
import parsetool.workflow.models.statements.WhileStatement;

/**
 *
 * @author Administrator
 */
public class MyWorkflowVisitor extends WorkflowBaseVisitor<Void> {

    StackUtil stack = new StackUtil();
    public Program Root = new Program();
    public State Statements = null;
    public Expression Expression = null;
    
    @Override
    public Void visitExpression(@NotNull WorkflowParser.ExpressionContext ctx) {
        Expression expression = this.stack.peekCtx(Expression.class);
        if(expression == null && Expression != null)
        {
            expression = Expression;
            this.stack.push(expression);
        }
        expression.parse(ctx, this.stack.peekPrev());
        List<ParseTree> trees = TreeUtil.getChildren(ctx, "assignment_expression");
        if (trees != null) {
            for (int index = 0; index < trees.size(); index++) {
                Assignment_Expression assignment_expression = new Assignment_Expression();
                expression.getAssignment_expressions().add(assignment_expression);
                this.stack.push(assignment_expression);
                this.visit(trees.get(index));
                this.stack.pop();
            }
        }
        return null;
    }

    @Override public Void visitGeneric_type(@NotNull WorkflowParser.Generic_typeContext ctx) { 
        Generic_Type generic_type = this.stack.peekCtx(Generic_Type.class);
        generic_type.parse(ctx, this.stack.peekPrev());
        
        ParseTree tree = TreeUtil.getChild(ctx, "long_name");
        if (tree != null) {
            generic_type.setLong_name(tree.getText()); 
            return null;
        }
        
        List<ParseTree> trees = TreeUtil.getChildren(ctx, "generic_type");
        if (trees != null) {
            for (int index = 0; index < trees.size(); index++) {
                Generic_Type genric = new Generic_Type();
                if ( index == 0 ){
                    generic_type.setHeader(genric);
                }
                else
                {
                    generic_type.getParameters().add(genric);                    
                }
                this.stack.push(genric);
                this.visit(trees.get(index));
                this.stack.pop();
            }
        }
        return null;
    }
    
    @Override
    public Void visitInclusive_or_expression(@NotNull WorkflowParser.Inclusive_or_expressionContext ctx) {
        Inclusive_Or_Expression inclusive_or_expression = this.stack.peekCtx(Inclusive_Or_Expression.class);
        inclusive_or_expression.parse(ctx, this.stack.peekPrev());
        List<ParseTree> trees = TreeUtil.getChildren(ctx, "exclusive_or_expression");
        if (trees != null) {
            for (int index = 0; index < trees.size(); index++) {
                Exclusive_Or_Expression exclusive_or_expression = new Exclusive_Or_Expression();
                inclusive_or_expression.getExclusive_or_expressions().add(exclusive_or_expression);
                this.stack.push(exclusive_or_expression);
                this.visit(trees.get(index));
                this.stack.pop();
            }
        }
        return null;
    }

    @Override
    public Void visitClz(@NotNull WorkflowParser.ClzContext ctx) {
        Clz clz = this.stack.peekCtx(Clz.class);
        clz.parse(ctx, this.stack.peekPrev());

        ParseTree tree = TreeUtil.getChild(ctx, "clz_name");
        if (tree != null) {
            clz.setName(tree.getText());
        }

        List<ParseTree> trees = TreeUtil.getChildren(ctx, "field");

        if (trees != null) {
            for (int index = 0; index < trees.size(); index++) {
                Field field = new Field();
                clz.getFields().add(field);
                this.stack.push(field);
                this.visit(trees.get(index));
                this.stack.pop();
            }
        }
        return null;
    }

    @Override
    public Void visitInit(@NotNull WorkflowParser.InitContext ctx) {
        Init init = this.stack.peekCtx(Init.class);
        init.parse(ctx, this.stack.peekPrev());

        ParseTree tree = TreeUtil.getChild(ctx, "state");
        if (tree != null) {
            State state = new State();
            init.setState(state);
            this.stack.push(state);
            this.visit(tree);
            this.stack.pop();

        }
        return null;
    }

    @Override
    public Void visitForm(@NotNull WorkflowParser.FormContext ctx) {
        Form form = this.stack.peekCtx(Form.class);
        form.parse(ctx, this.stack.peekPrev());

        ParseTree tree = ctx.STRING_LITERAL();
        if (tree != null) {
            form.setId(tree.getText());
        }
        tree = ctx.IDENTIFIER();
        if (tree != null) {
            form.setDataId(tree.getText());
        }
        return null;
    }

    @Override
    public Void visitTranslation(@NotNull WorkflowParser.TranslationContext ctx) {
        Translation translation = this.stack.peekCtx(Translation.class);
        translation.parse(ctx, this.stack.peekPrev());

        List<ParseTree> trees = TreeUtil.getChildren(ctx, "translation_statement");

        if (trees != null) {
            for (int index = 0; index < trees.size(); index++) {
                Translation_statement translation_statement = new Translation_statement();
                translation.getTranslation_statements().add(translation_statement);
                this.stack.push(translation_statement);
                this.visit(trees.get(index));
                this.stack.pop();
            }
        }
        return null;
    }

    @Override
    public Void visitTranslation_statement(@NotNull WorkflowParser.Translation_statementContext ctx) {
        Translation_statement translation_statement = this.stack.peekCtx(Translation_statement.class);
        translation_statement.parse(ctx, this.stack.peekPrev());

        ParseTree tree = TreeUtil.getChild(ctx, "expression");
        if (tree != null) {
            Expression expression = new Expression();
            translation_statement.setExpression(expression);
            this.stack.push(expression);
            this.visit(tree);
            this.stack.pop();
        }

        translation_statement.setNodeId(ctx.IDENTIFIER().getText());

        return null;
    }

    @Override
    public Void visitAction(@NotNull WorkflowParser.ActionContext ctx) {
        Action action = this.stack.peekCtx(Action.class);
        action.parse(ctx, this.stack.peekPrev());

        ParseTree tree = TreeUtil.getChild(ctx, "before");
        if (tree != null) {
            BeforeAction before = new BeforeAction();
            action.setBefore(before);
            this.stack.push(before);
            this.visit(tree);
            this.stack.pop();

        }
        tree = TreeUtil.getChild(ctx, "after");
        if (tree != null) {
            AfterAction after = new AfterAction();
            action.setAfter(after);
            this.stack.push(after);
            this.visit(tree);
            this.stack.pop();

        }
        return null;
    }

    @Override
    public Void visitAfter(@NotNull WorkflowParser.AfterContext ctx) {
        AfterAction after = this.stack.peekCtx(AfterAction.class);
        after.parse(ctx, this.stack.peekPrev());

        ParseTree tree = TreeUtil.getChild(ctx, "state");
        if (tree != null) {
            State state = new State();
            after.setState(state);
            this.stack.push(state);
            this.visit(tree);
            this.stack.pop();

        }
        return null;
    }

    @Override
    public Void visitBefore(@NotNull WorkflowParser.BeforeContext ctx) {
        BeforeAction before = this.stack.peekCtx(BeforeAction.class);
        before.parse(ctx, this.stack.peekPrev());

        ParseTree tree = TreeUtil.getChild(ctx, "state");
        if (tree != null) {
            State state = new State();
            before.setState(state);
            this.stack.push(state);
            this.visit(tree);
            this.stack.pop();

        }
        return null;
    }

    @Override
    public Void visitVariable(@NotNull WorkflowParser.VariableContext ctx) {
        Variable variable = this.stack.peekCtx(Variable.class);
        variable.parse(ctx, this.stack.peekPrev());

        List<ParseTree> trees = TreeUtil.getChildren(ctx, "field");
        if (trees != null) {
            for (int index = 0; index < trees.size(); index++) {
                Field field = new Field();
                variable.getFields().add(field);
                this.stack.push(field);
                this.visit(trees.get(index));
                this.stack.pop();
            }
        }

        trees = TreeUtil.getChildren(ctx, "clz");
        if (trees != null) {
            for (int index = 0; index < trees.size(); index++) {
                Clz clz = new Clz();
                variable.getClzes().add(clz);
                this.stack.push(clz);
                this.visit(trees.get(index));
                this.stack.pop();
            }
        }

        return null;
    }

    @Override
    public Void visitVariable_name(@NotNull WorkflowParser.Variable_nameContext ctx) {
        return visitChildren(ctx);
    }

    @Override
    public Void visitClz_name(@NotNull WorkflowParser.Clz_nameContext ctx) {
        return visitChildren(ctx);
    }

    @Override
    public Void visitAssignment_expression(@NotNull WorkflowParser.Assignment_expressionContext ctx) {

        Assignment_Expression assignment_expression = this.stack.peekCtx(Assignment_Expression.class);
        assignment_expression.parse(ctx, this.stack.peekPrev());

        ParseTree tree = TreeUtil.getChild(ctx, "conditional_expression");
        if (tree != null) {
            Conditional_Expression conditional_expression = new Conditional_Expression();
            assignment_expression.setConditional_expression(conditional_expression);
            this.stack.push(conditional_expression);
            this.visit(tree);
            this.stack.pop();
            return null;
        }

        tree = TreeUtil.getChild(ctx, "lvalue");
        if (tree != null) {
            assignment_expression.setLvalue(tree.getText());
        }
        tree = TreeUtil.getChild(ctx, "assignment_operator");
        if (tree != null) {
            assignment_expression.setOperator(tree.getText());
        }
        tree = TreeUtil.getChild(ctx, "assignment_expression");
        if (tree != null) {
            Assignment_Expression assignment_expression2 = new Assignment_Expression();
            assignment_expression.setAssignment_expression(assignment_expression2);
            this.stack.push(assignment_expression2);
            this.visit(tree);
            this.stack.pop();
        }

        return null;

    }

    @Override
    public Void visitState(@NotNull WorkflowParser.StateContext ctx) {
        State state = this.stack.peekCtx(State.class);
        if(state == null && Statements != null)
        {
           state = Statements;
            this.stack.push(state);
        }
        
        state.parse(ctx, this.stack.peekPrev());
        List<ParseTree> trees = TreeUtil.getChildren(ctx, "statement");
        if (trees != null) {
            for (int index = 0; index < trees.size(); index++) {
                Statement statement = new Statement();
                state.getStatements().add(statement);
                this.stack.push(statement);
                this.visit(trees.get(index));
                this.stack.pop();
            }
        }
        return null;
    }

    @Override
    public Void visitConstant_expression(@NotNull WorkflowParser.Constant_expressionContext ctx) {
        return visitChildren(ctx);
    }

    @Override
    public Void visitMultiplicative_expression(@NotNull WorkflowParser.Multiplicative_expressionContext ctx) {
        Multiplicative_Expression multiplicative_expression = this.stack.peekCtx(Multiplicative_Expression.class);
        multiplicative_expression.parse(ctx, this.stack.peekPrev());
        List<ParseTree> trees = TreeUtil.getChildren(ctx, "cast_expression");
        if (trees != null) {
            for (int index = 0; index < trees.size(); index++) {
                Cast_Expression cast_expressions = new Cast_Expression();
                multiplicative_expression.getCast_expressions().add(cast_expressions);
                this.stack.push(cast_expressions);
                this.visit(trees.get(index));
                this.stack.pop();
            }
        }
        trees = TreeUtil.getChildren(ctx, "multiplicative_expression_operator");
        if (trees != null) {
            for (int index = 0; index < trees.size(); index++) {
                multiplicative_expression.getOperators().add(trees.get(index).getText());
            }
        }
        return null;
    }

    @Override
    public Void visitRelational_expression(@NotNull WorkflowParser.Relational_expressionContext ctx) {
        Relational_Expression relational_expression = this.stack.peekCtx(Relational_Expression.class);
        relational_expression.parse(ctx, this.stack.peekPrev());
        List<ParseTree> trees = TreeUtil.getChildren(ctx, "shift_expression");
        if (trees != null) {
            for (int index = 0; index < trees.size(); index++) {
                Shift_Expression shift_expression = new Shift_Expression();
                relational_expression.getShift_expressions().add(shift_expression);
                this.stack.push(shift_expression);
                this.visit(trees.get(index));
                this.stack.pop();
            }
        }
        trees = TreeUtil.getChildren(ctx, "relational_expression_operator");
        if (trees != null) {
            for (int index = 0; index < trees.size(); index++) {
                relational_expression.getOperators().add(trees.get(index).getText());
            }
        }
        return null;
    }

    @Override
    public Void visitCast_expression(@NotNull WorkflowParser.Cast_expressionContext ctx) {
        Cast_Expression cast_expression = this.stack.peekCtx(Cast_Expression.class);
        cast_expression.parse(ctx, this.stack.peekPrev());
        ParseTree tree = TreeUtil.getChild(ctx, "unary_expression");
        if (tree != null) {
            Unary_Expression unary_expression = new Unary_Expression();
            cast_expression.setUnary_expression(unary_expression);
            this.stack.push(unary_expression);
            this.visit(tree);
            this.stack.pop();
            return null;
        }

        tree = TreeUtil.getChild(ctx, "generic_type");
        if (tree != null) {
            Generic_Type generic_type = new Generic_Type();
            cast_expression.setGeneric_type(generic_type);
            this.stack.push(generic_type);
            this.visit(tree);
            this.stack.pop();
        }
        tree = TreeUtil.getChild(ctx, "cast_expression");
        if (tree != null) {
            Cast_Expression cast_expression2 = new Cast_Expression();
            cast_expression.setCast_expression(cast_expression2);
            this.stack.push(cast_expression2);
            this.visit(tree);
            this.stack.pop();
        }
        return null;
    }

    @Override
    public Void visitPostfix_expression(@NotNull WorkflowParser.Postfix_expressionContext ctx) {
        Postfix_Expression postfix_expression = this.stack.peekCtx(Postfix_Expression.class);
        postfix_expression.parse(ctx, this.stack.peekPrev());
        ParseTree tree = TreeUtil.getChild(ctx, "primary_expression");
        if (tree != null) {
            Primary_Expression primary_expression = new Primary_Expression();
            postfix_expression.setPrimary_expression(primary_expression);//.setPrimary_expression(primary_expression);
            this.stack.push(primary_expression);
            this.visit(tree);
            this.stack.pop();
        }

        List<ParseTree> trees = TreeUtil.getChildren(ctx, "postfix_part");
        if (trees != null) {
            for (int index = 0; index < trees.size(); index++) {
                Postfix_Part postfix_part = new Postfix_Part();
                postfix_expression.getPostfix_parts().add(postfix_part);
                this.stack.push(postfix_part);
                this.visit(trees.get(index));
                this.stack.pop();
            }
        }
        return null;
    }

    @Override
    public Void visitPostfix_part(@NotNull WorkflowParser.Postfix_partContext ctx) {
        Postfix_Part postfix_part = this.stack.peekCtx(Postfix_Part.class);
        postfix_part.parse(ctx, this.stack.peekPrev());
        ParseTree tree = TreeUtil.getChild(ctx, "postfix_part_index");
        if (tree != null) {
            Postfix_Part_Index postfix_part_index = new Postfix_Part_Index();
            postfix_part.setPostfix_part_index(postfix_part_index);
            this.stack.push(postfix_part_index);
            this.visit(tree);
            this.stack.pop();
        }
        tree = TreeUtil.getChild(ctx, "postfix_part_empty_function");
        if (tree != null) {
            Postfix_Part_Empty_Function postfix_part_empty_function = new Postfix_Part_Empty_Function();
            postfix_part.setPostfix_part_empty_function(postfix_part_empty_function);
        }

        tree = TreeUtil.getChild(ctx, "postfix_part_function");
        if (tree != null) {
            Postfix_Part_Function postfix_part_function = new Postfix_Part_Function();
            postfix_part.setPostfix_part_function(postfix_part_function);
            this.stack.push(postfix_part_function);
            this.visit(tree);
            this.stack.pop();
        }
        tree = TreeUtil.getChild(ctx, "postfix_part_long_name");
        if (tree != null) {
            Postfix_Part_Long_Name postfix_part_long_name = new Postfix_Part_Long_Name();
            postfix_part.setPostfix_part_long_name(postfix_part_long_name);
            postfix_part_long_name.setText(tree.getText());
            /*
             this.stack.push(postfix_part_long_name);
             this.visit(tree);
             this.stack.pop();
             */
        }
        tree = TreeUtil.getChild(ctx, "postfix_part_increase");
        if (tree != null) {
            Postfix_Part_Increase postfix_part_increase = new Postfix_Part_Increase();
            postfix_part.setPostfix_part_increase(postfix_part_increase);
        }
        tree = TreeUtil.getChild(ctx, "postfix_part_decrease");
        if (tree != null) {
            Postfix_Part_Decrease postfix_part_decrease = new Postfix_Part_Decrease();
            postfix_part.setPostfix_part_decrease(postfix_part_decrease);
        }
        return null;
    }

    @Override
    public Void visitPostfix_part_decrease(@NotNull WorkflowParser.Postfix_part_decreaseContext ctx) {
        return visitChildren(ctx);
    }

    @Override
    public Void visitPostfix_part_increase(@NotNull WorkflowParser.Postfix_part_increaseContext ctx) {
        return visitChildren(ctx);
    }

    @Override
    public Void visitPostfix_part_empty_function(@NotNull WorkflowParser.Postfix_part_empty_functionContext ctx) {
        return visitChildren(ctx);
    }

    @Override
    public Void visitPostfix_part_function(@NotNull WorkflowParser.Postfix_part_functionContext ctx) {
        Postfix_Part_Function postfix_part_function = this.stack.peekCtx(Postfix_Part_Function.class);
        postfix_part_function.parse(ctx, this.stack.peekPrev());
        ParseTree tree = TreeUtil.getChild(ctx, "argument_expression_list");
        if (tree != null) {
            Argument_Expression_List argument_expression_list = new Argument_Expression_List();
            postfix_part_function.setArgument_expression_list(argument_expression_list);
            this.stack.push(argument_expression_list);
            this.visit(tree);
            this.stack.pop();
        }
        return null;
    }

    @Override
    public Void visitPostfix_part_index(@NotNull WorkflowParser.Postfix_part_indexContext ctx) {
        Postfix_Part_Index postfix_part_index = this.stack.peekCtx(Postfix_Part_Index.class);
        postfix_part_index.parse(ctx, this.stack.peekPrev());
        ParseTree tree = TreeUtil.getChild(ctx, "expression");
        if (tree != null) {
            Expression expression = new Expression();
            postfix_part_index.setExpression(expression);
            this.stack.push(expression);
            this.visit(tree);
            this.stack.pop();
        }
        return null;
    }

    @Override
    public Void visitPostfix_part_long_name(@NotNull WorkflowParser.Postfix_part_long_nameContext ctx) {
        return visitChildren(ctx);
    }

    public Void visitEquality_expression(@NotNull WorkflowParser.Equality_expressionContext ctx) {

        Equality_Expression equality_expression = this.stack.peekCtx(Equality_Expression.class);
        equality_expression.parse(ctx, this.stack.peekPrev());
        List<ParseTree> trees = TreeUtil.getChildren(ctx, "relational_expression");
        if (trees != null) {
            for (int index = 0; index < trees.size(); index++) {
                Relational_Expression relational_expression = new Relational_Expression();
                equality_expression.getRelational_expressions().add(relational_expression);
                this.stack.push(relational_expression);
                this.visit(trees.get(index));
                this.stack.pop();
            }
        }
        trees = TreeUtil.getChildren(ctx, "equality_expression_operator");
        if (trees != null) {
            for (int index = 0; index < trees.size(); index++) {
                equality_expression.getOperators().add(trees.get(index).getText());
            }
        }
        return null;
    }

    @Override
    public Void visitAssignment_operator(@NotNull WorkflowParser.Assignment_operatorContext ctx) {
        return visitChildren(ctx);
    }

    @Override
    public Void visitUnary_expression(@NotNull WorkflowParser.Unary_expressionContext ctx) {
        Unary_Expression unary_expression = this.stack.peekCtx(Unary_Expression.class);
        unary_expression.parse(ctx, this.stack.peekPrev());
        ParseTree tree = TreeUtil.getChild(ctx, "postfix_expression");
        if (tree != null) {
            Postfix_Expression postfix_expression = new Postfix_Expression();
            unary_expression.setPostfix_expression(postfix_expression);
            this.stack.push(postfix_expression);
            this.visit(tree);
            this.stack.pop();
            return null;
        }
        tree = TreeUtil.getChild(ctx, "unary_expression_two_char");
        if (tree != null) {
            Unary_Expression_Two_Char unary_expression_two_char = new Unary_Expression_Two_Char();
            unary_expression.setUnary_expression_two_char(unary_expression_two_char);
            this.stack.push(unary_expression_two_char);
            this.visit(tree);
            this.stack.pop();
            return null;
        }
        tree = TreeUtil.getChild(ctx, "unary_expression_one_char");
        if (tree != null) {
            Unary_Expression_One_Char unary_expression_one_char = new Unary_Expression_One_Char();
            unary_expression.setUnary_expression_one_char(unary_expression_one_char);
            this.stack.push(unary_expression_one_char);
            this.visit(tree);
            this.stack.pop();
        }
        return null;
    }

    @Override
    public Void visitUnary_expression_one_char(@NotNull WorkflowParser.Unary_expression_one_charContext ctx) {
        Unary_Expression_One_Char unary_expression_one_char = this.stack.peekCtx(Unary_Expression_One_Char.class);
        unary_expression_one_char.parse(ctx, this.stack.peekPrev());
        ParseTree tree = TreeUtil.getChild(ctx, "unary_operator");
        if (tree != null) {
            unary_expression_one_char.setOperator(tree.getText());
        }
        tree = TreeUtil.getChild(ctx, "cast_expression");
        if (tree != null) {
            Cast_Expression cast_expression = new Cast_Expression();
            unary_expression_one_char.setCast_expression(cast_expression);
            this.stack.push(cast_expression);
            this.visit(tree);
            this.stack.pop();
        }
        return null;
    }

    @Override
    public Void visitUnary_expression_two_char(@NotNull WorkflowParser.Unary_expression_two_charContext ctx) {
        Unary_Expression_Two_Char unary_expression_two_char = this.stack.peekCtx(Unary_Expression_Two_Char.class);
        unary_expression_two_char.parse(ctx, this.stack.peekPrev());
        ParseTree tree = TreeUtil.getChild(ctx, "unary_expression_operator");
        if (tree != null) {
            unary_expression_two_char.setOperator(tree.getText());
        }
        tree = TreeUtil.getChild(ctx, "unary_expression");
        if (tree != null) {
            Unary_Expression unary_expression = new Unary_Expression();
            unary_expression_two_char.setUnary_expression(unary_expression);
            this.stack.push(unary_expression);
            this.visit(tree);
            this.stack.pop();
        }
        return null;
    }

    @Override
    public Void visitDeclare_statement(@NotNull WorkflowParser.Declare_statementContext ctx) {
        Declare_Statement declare_statement = this.stack.peekCtx(Declare_Statement.class);
        declare_statement.parse(ctx, this.stack.peekPrev());
        ParseTree tree = TreeUtil.getChild(ctx, "declare");
        if (tree != null) {
            Declare declare = new Declare();
            declare_statement.setDeclare(declare);
            this.stack.push(declare);
            this.visit(tree);
            this.stack.pop();
        }
        return null;
    }

    @Override
    public Void visitOption(@NotNull WorkflowParser.OptionContext ctx) {

        Option option = this.stack.peekCtx(Option.class);
        option.parse(ctx, this.stack.peekPrev());
        ParseTree tree = TreeUtil.getChild(ctx, "option_name");
        if (tree != null) {
            option.setName(tree.getText());
        }
        tree = TreeUtil.getChild(ctx, "option_value");
        if (tree != null) {
            option.setValue(tree.getText());
        }
        return null;
    }

    @Override
    public Void visitConstant(@NotNull WorkflowParser.ConstantContext ctx) {
        Constant constant = this.stack.peekCtx(Constant.class);
        constant.parse(ctx, this.stack.peekPrev());

        TerminalNodeImpl type = (TerminalNodeImpl) ctx.CHARACTER_LITERAL();
        if (type != null) {
            constant.setIs_char(true);
            constant.setValue(type.getText());
            return null;
        }
        type = (TerminalNodeImpl) ctx.DECIMAL_LITERAL();
        if (type != null) {
            constant.setIs_int(true);
            constant.setValue(type.getText());
            return null;
        }
        type = (TerminalNodeImpl) ctx.FLOATING_POINT_LITERAL();
        if (type != null) {
            constant.setIs_float(true);
            constant.setValue(type.getText());
            return null;
        }
        type = (TerminalNodeImpl) ctx.HEX_LITERAL();
        if (type != null) {
            constant.setIs_hex(true);
            constant.setValue(type.getText());
            return null;
        }
        type = (TerminalNodeImpl) ctx.OCTAL_LITERAL();
        if (type != null) {
            constant.setIs_octal(true);
            constant.setValue(type.getText());
            return null;
        }
        type = (TerminalNodeImpl) ctx.STRING_LITERAL();
        if (type != null) {
            constant.setIs_string(true);
            constant.setValue(type.getText());
            return null;
        }
        type = (TerminalNodeImpl) ctx.BOOL_LITERAL();
        if (type != null) {
            constant.setIs_bool(true);
            constant.setValue(type.getText());
            return null;
        }
        return null;
    }

    //@Override public Void visitAssgin_statement(@NotNull WorkflowParser.Assgin_statementContext ctx) { return visitChildren(ctx); }
    @Override
    public Void visitExclusive_or_expression(@NotNull WorkflowParser.Exclusive_or_expressionContext ctx) {
        Exclusive_Or_Expression exclusive_or_expression = this.stack.peekCtx(Exclusive_Or_Expression.class);
        exclusive_or_expression.parse(ctx, this.stack.peekPrev());
        List<ParseTree> trees = TreeUtil.getChildren(ctx, "and_expression");
        if (trees != null) {
            for (int index = 0; index < trees.size(); index++) {
                And_Expression and_expression = new And_Expression();
                exclusive_or_expression.getAnd_expressions().add(and_expression);
                this.stack.push(and_expression);
                this.visit(trees.get(index));
                this.stack.pop();
            }
        }
        return null;
    }

    @Override
    public Void visitDeclare(@NotNull WorkflowParser.DeclareContext ctx) {
        Declare declare = this.stack.peekCtx(Declare.class);
        declare.parse(ctx, this.stack.peekPrev());
        ParseTree tree = TreeUtil.getChild(ctx, "generic_type");
        if (tree != null) {
            Generic_Type generic_type = new Generic_Type();
            declare.setGeneric_type(generic_type);
            this.stack.push(generic_type);
            this.visit(tree);
            this.stack.pop();
        }
        tree = TreeUtil.getChild(ctx, "variable_name");
        if (tree != null) {
            declare.setName(tree.getText());
        }
        tree = TreeUtil.getChild(ctx, "expression");
        if (tree != null) {
            Expression expression = new Expression();
            declare.setDefault_value(expression);
            this.stack.push(expression);
            this.visit(tree);
            this.stack.pop();
        }
        return null;
    }

    @Override public Void visitCreator(@NotNull WorkflowParser.CreatorContext ctx) { 
        Creator creator = this.stack.peekCtx(Creator.class);
        creator.parse(ctx, this.stack.peekPrev());

        ParseTree tree = TreeUtil.getChild(ctx, "generic_type");
        if (tree != null) {      
            Generic_Type generic_type = new Generic_Type();
            creator.setGeneric_type(generic_type);
            this.stack.push(generic_type);
            this.visit(tree);
            this.stack.pop();
        }
        tree = TreeUtil.getChild(ctx, "argument_expression_list");
        if (tree != null) {
            Argument_Expression_List args = new Argument_Expression_List();
            //assignment_expression.setConditional_expression(conditional_expression);
            this.stack.push(args);
            this.visit(tree);
            this.stack.pop();
            
            creator.setAssignment_expressions(args.getAssignment_expressions());
        }
        
	return null;
    }
    
    @Override
    public Void visitStatement(@NotNull WorkflowParser.StatementContext ctx) {
        Statement statement = this.stack.peekCtx(Statement.class);
        statement.parse(ctx, this.stack.peekPrev());
        ParseTree tree = TreeUtil.getChild(ctx, "expression_statement");
        if (tree != null) {
            Expression_Statement expression = new Expression_Statement();
            statement.setExpression(expression);
            this.stack.push(expression);
            this.visit(tree);
            this.stack.pop();
        }
        tree = TreeUtil.getChild(ctx, "declare_statement");
        if (tree != null) {
            Declare_Statement declare_statement = new Declare_Statement();
            statement.setDeclare_statement(declare_statement);
            this.stack.push(declare_statement);
            this.visit(tree);
            this.stack.pop();
        }
        tree = TreeUtil.getChild(ctx, "ifStatement");
        if (tree != null) {
            IfStatement s = new IfStatement();
            statement.setIfStatement(s);
            this.stack.push(s);
            this.visit(tree);
            this.stack.pop();
        }
        tree = TreeUtil.getChild(ctx, "switchStatement");
        if (tree != null) {
            SwitchStatement s = new SwitchStatement();
            statement.setSwitchStatement(s);
            this.stack.push(s);
            this.visit(tree);
            this.stack.pop();
        }
        tree = TreeUtil.getChild(ctx, "whileStatement");
        if (tree != null) {
            WhileStatement whileStatement = new WhileStatement();
            statement.setWhileStatement(whileStatement);
            this.stack.push(whileStatement);
            this.visit(tree);
            this.stack.pop();
        }
        tree = TreeUtil.getChild(ctx, "doWhileStatement");
        if (tree != null) {
            DoWhileStatement doWhileStatement = new DoWhileStatement();
            statement.setDoWhileStatement(doWhileStatement);
            this.stack.push(doWhileStatement);
            this.visit(tree);
            this.stack.pop();
        }
        tree = TreeUtil.getChild(ctx, "forStatement");
        if (tree != null) {
            ForStatement forStatement = new ForStatement();
            statement.setForStatement(forStatement);
            this.stack.push(forStatement);
            this.visit(tree);
            this.stack.pop();
        }
        tree = TreeUtil.getChild(ctx, "forEachStatement");
        if (tree != null) {
            ForEachStatement forEachStatement = new ForEachStatement();
            statement.setForEachStatement(forEachStatement);
            this.stack.push(forEachStatement);
            this.visit(tree);
            this.stack.pop();
        }

        tree = TreeUtil.getChild(ctx, "gotoStatement");
        if (tree != null) {
            GotoStatement gotoStatement = new GotoStatement();
            statement.setGotoStatement(gotoStatement);
            this.stack.push(gotoStatement);
            this.visit(tree);
            this.stack.pop();
        }

        tree = TreeUtil.getChild(ctx, "breakStatement");
        if (tree != null) {
            BreakStatement breakStatement = new BreakStatement();
            statement.setBreakStatement(breakStatement);
            this.stack.push(breakStatement);
            this.visit(tree);
            this.stack.pop();
        }

        tree = TreeUtil.getChild(ctx, "continueStatement");
        if (tree != null) {
            ContinueStatement continueStatement = new ContinueStatement();
            statement.setContinueStatement(continueStatement);
            this.stack.push(continueStatement);
            this.visit(tree);
            this.stack.pop();
        }
        return null;
    }
    
    @Override public Void visitExpression_statement(@NotNull WorkflowParser.Expression_statementContext ctx) { 
         Expression_Statement expression_statement = this.stack.peekCtx(Expression_Statement.class);
        expression_statement.parse(ctx, this.stack.peekPrev());

        ParseTree tree = TreeUtil.getChild(ctx, "expression");
        if (tree != null) {
            Expression expression = new Expression();
            expression_statement.setExpression(expression);
            this.stack.push(expression);
            this.visit(tree);
            this.stack.pop();
            
        }
	return null;
    }
    
    @Override
    public Void visitForStatement(@NotNull WorkflowParser.ForStatementContext ctx) {
        ForStatement forStatement = this.stack.peekCtx(ForStatement.class);
        forStatement.parse(ctx, this.stack.peekPrev());

        ParseTree tree = TreeUtil.getChild(ctx, "declare_statement");
        if (tree != null) {
            Declare_Statement declare_statement = new Declare_Statement();
            forStatement.setDeclare_statement(declare_statement);
            this.stack.push(declare_statement);
            this.visit(tree);
            this.stack.pop();

        }
        tree = TreeUtil.getChild(ctx, "logical_or_expression");
        if (tree != null) {
            Logical_Or_Expression logical_or_expression = new Logical_Or_Expression();
            forStatement.setLogical_or_expression(logical_or_expression);
            this.stack.push(logical_or_expression);
            this.visit(tree);
            this.stack.pop();

        }
        tree = TreeUtil.getChild(ctx, "expression");
        if (tree != null) {
            Expression expression = new Expression();
            forStatement.setExpression(expression);
            this.stack.push(expression);
            this.visit(tree);
            this.stack.pop();

        }
        tree = TreeUtil.getChild(ctx, "state");
        if (tree != null) {
            State state = new State();
            forStatement.setState(state);
            this.stack.push(state);
            this.visit(tree);
            this.stack.pop();

        }
        return null;
    }

    @Override
    public Void visitForEachStatement(@NotNull WorkflowParser.ForEachStatementContext ctx) {
        ForEachStatement forEachStatement = this.stack.peekCtx(ForEachStatement.class);
        forEachStatement.parse(ctx, this.stack.peekPrev());

        ParseTree tree = TreeUtil.getChild(ctx, "generic_type");
        if (tree != null) {
            Generic_Type generic_type = new Generic_Type();
            forEachStatement.setGeneric_type(generic_type);
            this.stack.push(generic_type);
            this.visit(tree);
            this.stack.pop();        ;
        }
        
        forEachStatement.setVar(ctx.IDENTIFIER().getText());

        tree = TreeUtil.getChild(ctx, "expression");
        if (tree != null) {
            Expression expression = new Expression();
            forEachStatement.setInExpression(expression);
            this.stack.push(expression);
            this.visit(tree);
            this.stack.pop();
        }
        tree = TreeUtil.getChild(ctx, "state");
        if (tree != null) {
            State state = new State();
            forEachStatement.setState(state);
            this.stack.push(state);
            this.visit(tree);
            this.stack.pop();
        }
        return null;
    }

    @Override
    public Void visitSwitchStatement(@NotNull WorkflowParser.SwitchStatementContext ctx) {
        SwitchStatement switchStatement = this.stack.peekCtx(SwitchStatement.class);
        switchStatement.parse(ctx, this.stack.peekPrev());

        ParseTree tree = TreeUtil.getChild(ctx, "expression");
        if (tree != null) {
            Expression expression = new Expression();
            switchStatement.setKey(expression);
            this.stack.push(expression);
            this.visit(tree);
            this.stack.pop();
        }
        List<ParseTree> trees = TreeUtil.getChildren(ctx, "caseExpression");

        if (trees != null) {
            for (int index = 0; index < trees.size(); index++) {
                CaseExpression caseExpression = new CaseExpression();
                switchStatement.getCaseExpressions().add(caseExpression);
                this.stack.push(caseExpression);
                this.visit(trees.get(index));
                this.stack.pop();
            }
        }
        return null;
    }

    @Override
    public Void visitCaseExpression(@NotNull WorkflowParser.CaseExpressionContext ctx) {
        CaseExpression caseExpression = this.stack.peekCtx(CaseExpression.class);
        caseExpression.parse(ctx, this.stack.peekPrev());
        
        if ( ctx.start.getText().equalsIgnoreCase("default" ))
        {
            caseExpression.setIsDefault(Boolean.TRUE);
        }
        ParseTree tree = TreeUtil.getChild(ctx, "constant");
        if (tree != null) {
            Constant constant = new Constant();
            caseExpression.setConstant(constant);
            this.stack.push(constant);
            this.visit(tree);
            this.stack.pop();
        }
        tree = TreeUtil.getChild(ctx, "state");
        if (tree != null) {
            State state = new State();
            caseExpression.setState(state);
            this.stack.push(state);
            this.visit(tree);
            this.stack.pop();
        }
        return null;
    }

    @Override
    public Void visitWhileStatement(@NotNull WorkflowParser.WhileStatementContext ctx) {
        WhileStatement whileStatement = this.stack.peekCtx(WhileStatement.class);
        whileStatement.parse(ctx, this.stack.peekPrev());

        ParseTree tree = TreeUtil.getChild(ctx, "expression");
        if (tree != null) {
            Expression expression = new Expression();
            whileStatement.setCondition(expression);
            this.stack.push(expression);
            this.visit(tree);
            this.stack.pop();
        }
        tree = TreeUtil.getChild(ctx, "state");
        if (tree != null) {
            State state = new State();
            whileStatement.setState(state);
            this.stack.push(state);
            this.visit(tree);
            this.stack.pop();
        }
        return null;
    }

    @Override
    public Void visitDoWhileStatement(@NotNull WorkflowParser.DoWhileStatementContext ctx) {

        DoWhileStatement doWhileStatement = this.stack.peekCtx(DoWhileStatement.class);
        doWhileStatement.parse(ctx, this.stack.peekPrev());

        ParseTree tree = TreeUtil.getChild(ctx, "expression");
        if (tree != null) {
            Expression expression = new Expression();
            doWhileStatement.setCondition(expression);
            this.stack.push(expression);
            this.visit(tree);
            this.stack.pop();
        }
        tree = TreeUtil.getChild(ctx, "state", 0);
        if (tree != null) {
            State state = new State();
            doWhileStatement.setState(state);
            this.stack.push(state);
            this.visit(tree);
            this.stack.pop();
        }
        return null;
    }

    @Override
    public Void visitGotoStatement(@NotNull WorkflowParser.GotoStatementContext ctx) {
        GotoStatement gotoStatement = this.stack.peekCtx(GotoStatement.class);
        gotoStatement.parse(ctx, this.stack.peekPrev());

        TerminalNode tree = ctx.IDENTIFIER();
        if (tree != null) {
            gotoStatement.setTarget(ctx.IDENTIFIER().getText());
        }

        return null;
    }

    @Override
    public Void visitIfStatement(@NotNull WorkflowParser.IfStatementContext ctx) {
        IfStatement ifStatement = this.stack.peekCtx(IfStatement.class);
        ifStatement.parse(ctx, this.stack.peekPrev());

        ParseTree tree = TreeUtil.getChild(ctx, "expression");
        if (tree != null) {
            Expression expression = new Expression();
            ifStatement.setCondition(expression);
            this.stack.push(expression);
            this.visit(tree);
            this.stack.pop();
        }
        tree = TreeUtil.getChild(ctx, "state", 0);
        if (tree != null) {
            State state = new State();
            ifStatement.setTrueState(state);
            this.stack.push(state);
            this.visit(tree);
            this.stack.pop();
        }
        tree = TreeUtil.getChild(ctx, "ifStatement");
        if (tree != null) {
            IfStatement ifStatement2 = new IfStatement();
            ifStatement.setElseIf(ifStatement2);
            this.stack.push(ifStatement2);
            this.visit(tree);
            this.stack.pop();
        }
        tree = TreeUtil.getChild(ctx, "state", 1);
        if (tree != null) {
            State state = new State();
            ifStatement.setElseState(state);
            this.stack.push(state);
            this.visit(tree);
            this.stack.pop();
        }
        return null;
    }

    @Override
    public Void visitField(@NotNull WorkflowParser.FieldContext ctx) {

        Field field = this.stack.peekCtx(Field.class);
        field.parse(ctx, this.stack.peekPrev());
        ParseTree tree = TreeUtil.getChild(ctx, "declare");
        if (tree != null) {
            Declare declare = new Declare();
            field.setDeclare(declare);
            this.stack.push(declare);
            this.visit(tree);
            this.stack.pop();
        }
        tree = TreeUtil.getChild(ctx, "option_list");
        if (tree != null) {
            Option_List option_list = new Option_List();

            this.stack.push(option_list);
            this.visit(tree);
            this.stack.pop();

            field.setOptions(option_list.getOptions());
        }
        return null;
    }

    @Override
    public Void visitLogical_and_expression(@NotNull WorkflowParser.Logical_and_expressionContext ctx) {
        Logical_And_Expression logical_and_expression = this.stack.peekCtx(Logical_And_Expression.class);
        logical_and_expression.parse(ctx, this.stack.peekPrev());
        List<ParseTree> trees = TreeUtil.getChildren(ctx, "inclusive_or_expression");
        if (trees != null) {
            for (int index = 0; index < trees.size(); index++) {
                Inclusive_Or_Expression inclusive_or_expression = new Inclusive_Or_Expression();
                logical_and_expression.getInclusive_or_expressions().add(inclusive_or_expression);
                this.stack.push(inclusive_or_expression);
                this.visit(trees.get(index));
                this.stack.pop();
            }
        }
        return null;
    }

    @Override
    public Void visitAdditive_expression(@NotNull WorkflowParser.Additive_expressionContext ctx) {
        Additive_Expression additive_expression = this.stack.peekCtx(Additive_Expression.class);
        additive_expression.parse(ctx, this.stack.peekPrev());
        List<ParseTree> trees = TreeUtil.getChildren(ctx, "multiplicative_expression");
        if (trees != null) {
            for (int index = 0; index < trees.size(); index++) {
                Multiplicative_Expression multiplicative_expression = new Multiplicative_Expression();
                additive_expression.getMultiplicative_expressions().add(multiplicative_expression);
                this.stack.push(multiplicative_expression);
                this.visit(trees.get(index));
                this.stack.pop();
            }
        }
        trees = TreeUtil.getChildren(ctx, "additive_expression_operator");
        if (trees != null) {
            for (int index = 0; index < trees.size(); index++) {
                additive_expression.getOperators().add(trees.get(index).getText());
            }
        }
        return null;
    }

    @Override
    public Void visitOption_list(@NotNull WorkflowParser.Option_listContext ctx) {

        Option_List option_list = this.stack.peekCtx(Option_List.class);
        option_list.parse(ctx, this.stack.peekPrev());
        List<ParseTree> trees = TreeUtil.getChildren(ctx, "option");
        if (trees != null) {
            for (int index = 0; index < trees.size(); index++) {
                Option option = new Option();
                option_list.getOptions().add(option);
                this.stack.push(option);
                this.visit(trees.get(index));
                this.stack.pop();
            }
        }
        return null;
    }

    @Override
    public Void visitConditional_expression(@NotNull WorkflowParser.Conditional_expressionContext ctx) {
        Conditional_Expression conditional_expression = this.stack.peekCtx(Conditional_Expression.class);
        conditional_expression.parse(ctx, this.stack.peekPrev());
        ParseTree tree = TreeUtil.getChild(ctx, "logical_or_expression");
        if (tree != null) {
            Logical_Or_Expression logical_or_expression = new Logical_Or_Expression();
            conditional_expression.setLogical_or_expression(logical_or_expression);
            this.stack.push(logical_or_expression);
            this.visit(tree);
            this.stack.pop();
        }
        tree = TreeUtil.getChild(ctx, "expression");
        if (tree != null) {
            Expression expression = new Expression();
            conditional_expression.setSecond_expression(expression);
            this.stack.push(expression);
            this.visit(tree);
            this.stack.pop();
        }

        tree = TreeUtil.getChild(ctx, "conditional_expression");
        if (tree != null) {
            Conditional_Expression third_expression = new Conditional_Expression();
            conditional_expression.setThird_expression(third_expression);
            this.stack.push(third_expression);
            this.visit(tree);
            this.stack.pop();
        }
        return null;
    }

    @Override
    public Void visitLvalue(@NotNull WorkflowParser.LvalueContext ctx) {
        return visitChildren(ctx);
    }

    @Override
    public Void visitUnary_operator(@NotNull WorkflowParser.Unary_operatorContext ctx) {
        return visitChildren(ctx);
    }

    @Override
    public Void visitAnd_expression(@NotNull WorkflowParser.And_expressionContext ctx) {
        And_Expression and_expression = this.stack.peekCtx(And_Expression.class);
        and_expression.parse(ctx, this.stack.peekPrev());
        List<ParseTree> trees = TreeUtil.getChildren(ctx, "equality_expression");
        if (trees != null) {
            for (int index = 0; index < trees.size(); index++) {
                Equality_Expression equality_expression = new Equality_Expression();
                and_expression.getEquality_expressions().add(equality_expression);
                this.stack.push(equality_expression);
                this.visit(trees.get(index));
                this.stack.pop();
            }
        }
        return null;
    }

    @Override
    public Void visitPrimary_expression(@NotNull WorkflowParser.Primary_expressionContext ctx) {
        Primary_Expression primary_expression = this.stack.peekCtx(Primary_Expression.class);
        primary_expression.parse(ctx, this.stack.peekPrev());
        ParseTree tree = TreeUtil.getChild(ctx, "constant");
        if (tree != null) {
            Constant constant = new Constant();
            primary_expression.setConstant(constant);
            primary_expression.setIsConstant(true);
            this.stack.push(constant);
            this.visit(tree);
            this.stack.pop();
            return null;
        }

        tree = TreeUtil.getChild(ctx, "expression");
        if (tree != null) {
            Expression expression = new Expression();
            primary_expression.setExpression(expression);
            primary_expression.setIsExpression(true);
            this.stack.push(expression);
            this.visit(tree);
            this.stack.pop();
            return null;
        }
        
        tree = TreeUtil.getChild(ctx, "creator");
        if (tree != null) {
            Creator creator = new Creator();
            primary_expression.setCreator(creator);
            primary_expression.setIsCreator(true);
            this.stack.push(creator);
            this.visit(tree);
            this.stack.pop();
            return null;
        }
        
        primary_expression.setId(ctx.getText());
        primary_expression.setIsId(true);

        return null;
    }

    @Override
    public Void visitShift_expression(@NotNull WorkflowParser.Shift_expressionContext ctx) {
        Shift_Expression shift_expression = this.stack.peekCtx(Shift_Expression.class);
        shift_expression.parse(ctx, this.stack.peekPrev());
        List<ParseTree> trees = TreeUtil.getChildren(ctx, "additive_expression");
        if (trees != null) {
            for (int index = 0; index < trees.size(); index++) {
                Additive_Expression additive_expression = new Additive_Expression();
                shift_expression.getAdditive_expressions().add(additive_expression);
                this.stack.push(additive_expression);
                this.visit(trees.get(index));
                this.stack.pop();
            }
        }
        trees = TreeUtil.getChildren(ctx, "shift_expression_operator");
        if (trees != null) {
            for (int index = 0; index < trees.size(); index++) {
                shift_expression.getOperators().add(trees.get(index).getText());
            }
        }
        return null;
    }

    @Override
    public Void visitProgram(@NotNull WorkflowParser.ProgramContext ctx) {
        ParseTree tree = TreeUtil.getChild(ctx, "nameSpace");
        this.Root.parse(ctx, this.stack.peekPrev());        
        if ( tree != null )
        {            
            String ns = tree.getText();
            if ( ns != null)
            {                
                if(ns.startsWith("namespace"))
                    ns = ns.substring(9);
                
                ns = ns.replace(";", "").trim();
                
                this.Root.setNameSpace(ns);
            }
        }
        tree = TreeUtil.getChild(ctx, "variable");
        this.Root.parse(ctx, this.stack.peekPrev());
        if (tree != null) {

            Variable variable = new Variable();
            this.Root.setVariable(variable);
            this.stack.push(variable);
            this.visit(tree);
            this.stack.pop();
        }

        tree = TreeUtil.getChild(ctx, "init");
        this.Root.parse(ctx, this.stack.peekPrev());
        if (tree != null) {
            Init init = new Init();
            this.Root.setInit(init);
            this.stack.push(init);
            this.visit(tree);
            this.stack.pop();
        }

        List<ParseTree> trees = TreeUtil.getChildren(ctx, "unit");
        this.Root.parse(ctx, this.stack.peekPrev());
        if (trees != null) {
            for (int index = 0; index < trees.size(); index++) {
                Unit unit = new Unit();
                this.Root.getUnits().add(unit);
                this.stack.push(unit);
                this.visit(trees.get(index));
                this.stack.pop();
            }
        }
        return null;

    }

    @Override public Void visitParallel(@NotNull WorkflowParser.ParallelContext ctx) {
        
        Parallel parallel = this.stack.peekCtx(Parallel.class);
        parallel.parse(ctx, this.stack.peekPrev());
        TerminalNode name = ctx.IDENTIFIER();
        if (name != null) {
            parallel.setName(name.getText());
        }
        ParseTree tree = TreeUtil.getChild(ctx, "variable");
        if (tree != null) {
            Variable variable = new Variable();
            parallel.setVariable(variable);
            this.stack.push(variable);
            this.visit(tree);
            this.stack.pop();

        }
        tree = TreeUtil.getChild(ctx, "init");
        if (tree != null) {
            Init init = new Init();
            parallel.setInit(init);
            this.stack.push(init);
            this.visit(tree);
            this.stack.pop();

        }
        tree = TreeUtil.getChild(ctx, "action");
        if (tree != null) {
            Action action = new Action();
            parallel.setAction(action);
            this.stack.push(action);
            this.visit(tree);
            this.stack.pop();

        }
        tree = TreeUtil.getChild(ctx, "translation");
        if (tree != null) {
            Translation translation = new Translation();
            parallel.setTranslation(translation);
            this.stack.push(translation);
            this.visit(tree);
            this.stack.pop();

        }
        
        List<ParseTree> trees = TreeUtil.getChildren(ctx, "execute_line");
        if ( trees != null )
        {
            for(int index = 0 ;index < trees.size() ; index ++)
            {
                Execute_Line execute_line = new Execute_Line();
                parallel.getExecute_Lines().add(execute_line);
                this.stack.push(execute_line);
                this.visit(trees.get(index));
                this.stack.pop();            
            }
        }
        
        return null; 
    }
    
    @Override public Void visitExecute_line(@NotNull WorkflowParser.Execute_lineContext ctx) 
    { 
        Execute_Line execute_line = this.stack.peekCtx(Execute_Line.class);
        execute_line.parse(ctx, this.stack.peekPrev());
        TerminalNode name = ctx.IDENTIFIER();
        if (name != null) {
            execute_line.setName(name.getText());
        }
        
        List<ParseTree> trees = TreeUtil.getChildren(ctx, "unit");
        if ( trees != null )
        {
            for(int index = 0 ;index < trees.size() ; index ++)
            {
                Unit unit = new Unit();
                execute_line.getUnits().add(unit);
                this.stack.push(unit);
                this.visit(trees.get(index));
                this.stack.pop();            
            }
        }
        
        return null; 
    }
    
    @Override public Void visitUnit(@NotNull WorkflowParser.UnitContext ctx) { 
        
        Unit unit = this.stack.peekCtx(Unit.class);
        unit.parse(ctx, this.stack.peekPrev());
       
        ParseTree tree = TreeUtil.getChild(ctx, "node");
        if (tree != null) {
            Node node = new Node();
            unit.setNode(node);
            this.stack.push(node);
            this.visit(tree);
            this.stack.pop();
        }
        tree = TreeUtil.getChild(ctx, "parallel");
        if (tree != null) {
            Parallel parallel = new Parallel();
            unit.setParallel(parallel);
            this.stack.push(parallel);
            this.visit(tree);
            this.stack.pop();
        }
        return null;
    }
    @Override public Void visitRef_workflow(@NotNull WorkflowParser.Ref_workflowContext ctx) { 
    
        Ref_Workflow node = this.stack.peekCtx(Ref_Workflow.class);
        node.parse(ctx, this.stack.peekPrev());
        TerminalNode name = ctx.STRING_LITERAL();
        if (name != null) {
            node.setTarget(name.getText());
        }
        return null;
    }
    
    @Override
    public Void visitNode(@NotNull WorkflowParser.NodeContext ctx) {
        Node node = this.stack.peekCtx(Node.class);
        node.parse(ctx, this.stack.peekPrev());
        TerminalNode name = ctx.IDENTIFIER();
        if (name != null) {
            node.setName(name.getText());
        }
        ParseTree tree = TreeUtil.getChild(ctx, "ref_workflow");
        if (tree != null) {
            Ref_Workflow ref = new Ref_Workflow();
            node.setRef_Workflow(ref);
            this.stack.push(ref);
            this.visit(tree);
            this.stack.pop();

        }
        tree = TreeUtil.getChild(ctx, "variable");
        if (tree != null) {
            Variable variable = new Variable();
            node.setVariable(variable);
            this.stack.push(variable);
            this.visit(tree);
            this.stack.pop();

        }
        tree = TreeUtil.getChild(ctx, "init");
        if (tree != null) {
            Init init = new Init();
            node.setInit(init);
            this.stack.push(init);
            this.visit(tree);
            this.stack.pop();

        }
        tree = TreeUtil.getChild(ctx, "form");
        if (tree != null) {
            Form form = new Form();
            node.setForm(form);
            this.stack.push(form);
            this.visit(tree);
            this.stack.pop();

        }
        tree = TreeUtil.getChild(ctx, "action");
        if (tree != null) {
            Action action = new Action();
            node.setAction(action);
            this.stack.push(action);
            this.visit(tree);
            this.stack.pop();

        }
        tree = TreeUtil.getChild(ctx, "translation");
        if (tree != null) {
            Translation translation = new Translation();
            node.setTranslation(translation);
            this.stack.push(translation);
            this.visit(tree);
            this.stack.pop();

        }
        return null;
    }

    @Override
    public Void visitLogical_or_expression(@NotNull WorkflowParser.Logical_or_expressionContext ctx) {
        Logical_Or_Expression logical_or_expression = this.stack.peekCtx(Logical_Or_Expression.class);
        logical_or_expression.parse(ctx, this.stack.peekPrev());
        List<ParseTree> trees = TreeUtil.getChildren(ctx, "logical_and_expression");
        if (trees != null) {
            for (int index = 0; index < trees.size(); index++) {
                Logical_And_Expression logical_and_expression = new Logical_And_Expression();
                logical_or_expression.getLogical_and_expressions().add(logical_and_expression);
                this.stack.push(logical_and_expression);
                this.visit(trees.get(index));
                this.stack.pop();
            }
        }
        return null;
    }

    @Override
    public Void visitAttribute(@NotNull WorkflowParser.AttributeContext ctx) {

        Attribute attribute = this.stack.peekCtx(Attribute.class);
        attribute.parse(ctx, this.stack.peekPrev());
        ParseTree tree = TreeUtil.getChild(ctx, "attribute_name");
        if (tree != null) {
            attribute.setName(tree.getText());
        }
        tree = TreeUtil.getChild(ctx, "attribute_value");
        if (tree != null) {
            attribute.setValue(tree.getText());
        }
        return null;

    }

    @Override
    public Void visitArgument_expression_list(@NotNull WorkflowParser.Argument_expression_listContext ctx) {
        Argument_Expression_List argument_expression_list = this.stack.peekCtx(Argument_Expression_List.class);
        argument_expression_list.parse(ctx, this.stack.peekPrev());
        List<ParseTree> trees = TreeUtil.getChildren(ctx, "assignment_expression");
        if (trees != null) {
            for (int index = 0; index < trees.size(); index++) {
                Assignment_Expression assignment_expression = new Assignment_Expression();
                argument_expression_list.getAssignment_expressions().add(assignment_expression);
                this.stack.push(assignment_expression);
                this.visit(trees.get(index));
                this.stack.pop();
            }
        }
        return null;
    }
}
