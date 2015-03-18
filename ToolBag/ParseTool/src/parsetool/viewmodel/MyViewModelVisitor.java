/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package parsetool.viewmodel;

import java.util.HashSet;
import java.util.List;
import java.util.Set;
import org.antlr.v4.runtime.misc.NotNull;
import org.antlr.v4.runtime.tree.ParseTree;
import org.antlr.v4.runtime.tree.TerminalNodeImpl;
import parsetool.utils.StackUtil;
import parsetool.utils.TreeUtil;
import parsetool.viewmodel.models.Attribute;
import parsetool.viewmodel.models.Field;
import parsetool.viewmodel.models.Model;
import parsetool.viewmodel.models.Option;
import parsetool.viewmodel.models.Option_List;
import parsetool.viewmodel.models.Program;
import parsetool.viewmodel.models.State;
import parsetool.viewmodel.models.expressions.Additive_Expression;
import parsetool.viewmodel.models.expressions.And_Expression;
import parsetool.viewmodel.models.expressions.Argument_Expression_List;
import parsetool.viewmodel.models.expressions.Assignment_Expression;
import parsetool.viewmodel.models.expressions.Cast_Expression;
import parsetool.viewmodel.models.expressions.Conditional_Expression;
import parsetool.viewmodel.models.expressions.Constant;
import parsetool.viewmodel.models.expressions.Equality_Expression;
import parsetool.viewmodel.models.expressions.Exclusive_Or_Expression;
import parsetool.viewmodel.models.expressions.Expression;
import parsetool.viewmodel.models.expressions.Inclusive_Or_Expression;
import parsetool.viewmodel.models.expressions.Logical_And_Expression;
import parsetool.viewmodel.models.expressions.Logical_Or_Expression;
import parsetool.viewmodel.models.expressions.Multiplicative_Expression;
import parsetool.viewmodel.models.expressions.Postfix_Expression;
import parsetool.viewmodel.models.expressions.Postfix_Part;
import parsetool.viewmodel.models.expressions.Postfix_Part_Decrease;
import parsetool.viewmodel.models.expressions.Postfix_Part_Empty_Function;
import parsetool.viewmodel.models.expressions.Postfix_Part_Function;
import parsetool.viewmodel.models.expressions.Postfix_Part_Increase;
import parsetool.viewmodel.models.expressions.Postfix_Part_Index;
import parsetool.viewmodel.models.expressions.Postfix_Part_Long_Name;
import parsetool.viewmodel.models.expressions.Primary_Expression;
import parsetool.viewmodel.models.expressions.Relational_Expression;
import parsetool.viewmodel.models.expressions.Shift_Expression;
import parsetool.viewmodel.models.expressions.Unary_Expression;
import parsetool.viewmodel.models.expressions.Unary_Expression_One_Char;
import parsetool.viewmodel.models.expressions.Unary_Expression_Two_Char;
import parsetool.viewmodel.models.statements.Declare;
import parsetool.viewmodel.models.statements.Declare_Statement;
import parsetool.viewmodel.models.statements.Pull;
import parsetool.viewmodel.models.statements.Push;
import parsetool.viewmodel.models.statements.Statement;

/**
 *
 * @author cqy
 */
public class MyViewModelVisitor extends ViewModelBaseVisitor<Void> {

    StackUtil stack = new StackUtil();
    public Program Root = new Program();

    @Override
    public Void visitExpression(@NotNull ViewModelParser.ExpressionContext ctx) {
        Expression expression = this.stack.peekCtx(Expression.class);
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

    @Override
    public Void visitInclusive_or_expression(@NotNull ViewModelParser.Inclusive_or_expressionContext ctx) {
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
    public Void visitModel(@NotNull ViewModelParser.ModelContext ctx) {
        Model model = this.stack.peekCtx(Model.class);
        model.parse(ctx, this.stack.peekPrev());
        ParseTree tree = TreeUtil.getChild(ctx, "model_area");
        if (tree != null) {
            model.setArea(tree.getText());
        }
        List<ParseTree> trees = TreeUtil.getChildren(ctx, "attribute");
        if (trees != null) {
            for (int index = 0; index < trees.size(); index++) {
                Attribute attribute = new Attribute();
                model.getAttributes().add(attribute);
                this.stack.push(attribute);
                this.visit(trees.get(index));
                this.stack.pop();
            }
        }
        tree = TreeUtil.getChild(ctx, "model_name");
        if (tree != null) {
            model.setName(tree.getText());
        }

        trees = TreeUtil.getChildren(ctx, "field");
        if (trees != null) {
            for (int index = 0; index < trees.size(); index++) {
                Field field = new Field();
                model.getFields().add(field);
                this.stack.push(field);
                this.visit(trees.get(index));
                this.stack.pop();
            }
        }

        tree = TreeUtil.getChild(ctx, "state");
        if (tree != null) {
            State state = new State();
            model.setState(state);
            this.stack.push(state);
            this.visit(tree);
            this.stack.pop();
        }

        return null;
    }

    @Override
    public Void visitPull(@NotNull ViewModelParser.PullContext ctx) {
        Pull pull = this.stack.peekCtx(Pull.class);
        pull.parse(ctx, this.stack.peekPrev());
        ParseTree tree = TreeUtil.getChild(ctx, "lvalue");
        if (tree != null) {
            pull.setLvalue(tree.getText());
        }
        tree = TreeUtil.getChild(ctx, "expression");
        if (tree != null) {
            Expression expression = new Expression();
            pull.setExpression(expression);
            this.stack.push(expression);
            this.visit(tree);
            this.stack.pop();
        }
        return null;
    }

    @Override
    public Void visitAssignment_expression(@NotNull ViewModelParser.Assignment_expressionContext ctx) {

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
    public Void visitState(@NotNull ViewModelParser.StateContext ctx) {
        State state = this.stack.peekCtx(State.class);
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
    public Void visitConstant_expression(@NotNull ViewModelParser.Constant_expressionContext ctx) {
        return visitChildren(ctx);
    }

    @Override
    public Void visitMultiplicative_expression(@NotNull ViewModelParser.Multiplicative_expressionContext ctx) {
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
    public Void visitRelational_expression(@NotNull ViewModelParser.Relational_expressionContext ctx) {
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
    public Void visitPush(@NotNull ViewModelParser.PushContext ctx) {
        Push push = this.stack.peekCtx(Push.class);
        push.parse(ctx, this.stack.peekPrev());
        ParseTree tree = TreeUtil.getChild(ctx, "expression");
        if (tree != null) {
            Expression expression = new Expression();
            push.setExpression(expression);
            this.stack.push(expression);
            this.visit(tree);
            this.stack.pop();
        }
        tree = TreeUtil.getChild(ctx, "state");
        if (tree != null) {
            State state = new State();
            push.setState(state);
            this.stack.push(state);
            this.visit(tree);
            this.stack.pop();
        }
        return null;
    }

    @Override
    public Void visitCast_expression(@NotNull ViewModelParser.Cast_expressionContext ctx) {
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

        tree = TreeUtil.getChild(ctx, "type_name");
        if (tree != null) {
            cast_expression.setType_name(tree.getText());
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
    public Void visitPostfix_expression(@NotNull ViewModelParser.Postfix_expressionContext ctx) {
        Postfix_Expression postfix_expression = this.stack.peekCtx(Postfix_Expression.class);
        postfix_expression.parse(ctx, this.stack.peekPrev());
        ParseTree tree = TreeUtil.getChild(ctx, "primary_expression");
        if (tree != null) {
            Primary_Expression primary_expression = new Primary_Expression();
            postfix_expression.setPrimary_expression(primary_expression);
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
    public Void visitPostfix_part(@NotNull ViewModelParser.Postfix_partContext ctx) {
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
    public Void visitPostfix_part_decrease(@NotNull ViewModelParser.Postfix_part_decreaseContext ctx) {
        return visitChildren(ctx);
    }

    @Override
    public Void visitPostfix_part_increase(@NotNull ViewModelParser.Postfix_part_increaseContext ctx) {
        return visitChildren(ctx);
    }

    @Override
    public Void visitPostfix_part_empty_function(@NotNull ViewModelParser.Postfix_part_empty_functionContext ctx) {
        return visitChildren(ctx);
    }

    @Override
    public Void visitPostfix_part_function(@NotNull ViewModelParser.Postfix_part_functionContext ctx) {
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
    public Void visitPostfix_part_index(@NotNull ViewModelParser.Postfix_part_indexContext ctx) {
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
    public Void visitPostfix_part_long_name(@NotNull ViewModelParser.Postfix_part_long_nameContext ctx) {
        return visitChildren(ctx);
    }

    public Void visitEquality_expression(@NotNull ViewModelParser.Equality_expressionContext ctx) {

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
    public Void visitAssignment_operator(@NotNull ViewModelParser.Assignment_operatorContext ctx) {
        return visitChildren(ctx);
    }

    @Override
    public Void visitUnary_expression(@NotNull ViewModelParser.Unary_expressionContext ctx) {
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
    public Void visitUnary_expression_one_char(@NotNull ViewModelParser.Unary_expression_one_charContext ctx) {
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
    public Void visitUnary_expression_two_char(@NotNull ViewModelParser.Unary_expression_two_charContext ctx) {
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
    public Void visitDeclare_statement(@NotNull ViewModelParser.Declare_statementContext ctx) {
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
    public Void visitOption(@NotNull ViewModelParser.OptionContext ctx) {

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
    public Void visitConstant(@NotNull ViewModelParser.ConstantContext ctx) {
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
            constant.setIs_decimal(true);
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

    //@Override public Void visitAssgin_statement(@NotNull ViewModelParser.Assgin_statementContext ctx) { return visitChildren(ctx); }
    @Override
    public Void visitExclusive_or_expression(@NotNull ViewModelParser.Exclusive_or_expressionContext ctx) {
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
    public Void visitDeclare(@NotNull ViewModelParser.DeclareContext ctx) {
        Declare declare = this.stack.peekCtx(Declare.class);
        declare.parse(ctx, this.stack.peekPrev());
        ParseTree tree = TreeUtil.getChild(ctx, "type_name");
        if (tree != null) {
            declare.setType_name(tree.getText());
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

    @Override
    public Void visitStatement(@NotNull ViewModelParser.StatementContext ctx) {
        Statement statement = this.stack.peekCtx(Statement.class);
        statement.parse(ctx, this.stack.peekPrev());
        ParseTree tree = TreeUtil.getChild(ctx, "expression");
        if (tree != null) {
            Expression expression = new Expression();
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
        tree = TreeUtil.getChild(ctx, "push");
        if (tree != null) {
            Push push = new Push();
            statement.setPush(push);
            this.stack.push(push);
            this.visit(tree);
            this.stack.pop();
        }
        tree = TreeUtil.getChild(ctx, "pull");
        if (tree != null) {
            Pull pull = new Pull();
            statement.setPull(pull);
            this.stack.push(pull);
            this.visit(tree);
            this.stack.pop();
        }
        return null;
    }

    @Override
    public Void visitField(@NotNull ViewModelParser.FieldContext ctx) {

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
    public Void visitLogical_and_expression(@NotNull ViewModelParser.Logical_and_expressionContext ctx) {
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
    public Void visitAdditive_expression(@NotNull ViewModelParser.Additive_expressionContext ctx) {
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
    public Void visitOption_list(@NotNull ViewModelParser.Option_listContext ctx) {

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
    public Void visitConditional_expression(@NotNull ViewModelParser.Conditional_expressionContext ctx) {
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
    public Void visitLvalue(@NotNull ViewModelParser.LvalueContext ctx) {
        return visitChildren(ctx);
    }

    @Override
    public Void visitUnary_operator(@NotNull ViewModelParser.Unary_operatorContext ctx) {
        return visitChildren(ctx);
    }

    @Override
    public Void visitAnd_expression(@NotNull ViewModelParser.And_expressionContext ctx) {
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
    public Void visitPrimary_expression(@NotNull ViewModelParser.Primary_expressionContext ctx) {
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
        primary_expression.setId(ctx.getText());
        primary_expression.setIsId(true);

        return null;
    }

    @Override
    public Void visitShift_expression(@NotNull ViewModelParser.Shift_expressionContext ctx) {
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
    public Void visitProgram(@NotNull ViewModelParser.ProgramContext ctx) {

        List<ParseTree> trees = TreeUtil.getChildren(ctx, "model");
        this.Root.parse(ctx, this.stack.peekPrev());
        if (trees != null) {
            for (int index = 0; index < trees.size(); index++) {
                Model model = new Model();
                this.Root.getModels().add(model);
                this.stack.push(model);
                this.visit(trees.get(index));
                this.stack.pop();
            }
        }
        return null;

    }

    @Override
    public Void visitLogical_or_expression(@NotNull ViewModelParser.Logical_or_expressionContext ctx) {
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
    public Void visitType_name(@NotNull ViewModelParser.Type_nameContext ctx) {
        return visitChildren(ctx);
    }

    @Override
    public Void visitAttribute(@NotNull ViewModelParser.AttributeContext ctx) {

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
    public Void visitArgument_expression_list(@NotNull ViewModelParser.Argument_expression_listContext ctx) {
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
