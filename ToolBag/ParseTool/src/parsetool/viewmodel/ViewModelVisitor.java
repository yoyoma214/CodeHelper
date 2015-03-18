// Generated from D:\workspace\20140311\ToolBag\ParseTool\src\parsetool\viewmodel\ViewModel.g4 by ANTLR 4.1
package parsetool.viewmodel;
import org.antlr.v4.runtime.misc.NotNull;
import org.antlr.v4.runtime.tree.ParseTreeVisitor;

/**
 * This interface defines a complete generic visitor for a parse tree produced
 * by {@link ViewModelParser}.
 *
 * @param <T> The return type of the visit operation. Use {@link Void} for
 * operations with no return type.
 */
public interface ViewModelVisitor<T> extends ParseTreeVisitor<T> {
	/**
	 * Visit a parse tree produced by {@link ViewModelParser#expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitExpression(@NotNull ViewModelParser.ExpressionContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#equality_expression_operator}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitEquality_expression_operator(@NotNull ViewModelParser.Equality_expression_operatorContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#pull}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitPull(@NotNull ViewModelParser.PullContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#assignment_expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAssignment_expression(@NotNull ViewModelParser.Assignment_expressionContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#multiplicative_expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitMultiplicative_expression(@NotNull ViewModelParser.Multiplicative_expressionContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#cast_expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitCast_expression(@NotNull ViewModelParser.Cast_expressionContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#equality_expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitEquality_expression(@NotNull ViewModelParser.Equality_expressionContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#postfix_part_empty_function}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitPostfix_part_empty_function(@NotNull ViewModelParser.Postfix_part_empty_functionContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#postfix_part}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitPostfix_part(@NotNull ViewModelParser.Postfix_partContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#postfix_part_decrease}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitPostfix_part_decrease(@NotNull ViewModelParser.Postfix_part_decreaseContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#option}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitOption(@NotNull ViewModelParser.OptionContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#exclusive_or_expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitExclusive_or_expression(@NotNull ViewModelParser.Exclusive_or_expressionContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#unary_expression_two_char}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitUnary_expression_two_char(@NotNull ViewModelParser.Unary_expression_two_charContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#declare_statement}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitDeclare_statement(@NotNull ViewModelParser.Declare_statementContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#declare}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitDeclare(@NotNull ViewModelParser.DeclareContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#statement}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitStatement(@NotNull ViewModelParser.StatementContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#attribute_value}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAttribute_value(@NotNull ViewModelParser.Attribute_valueContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#logical_and_expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitLogical_and_expression(@NotNull ViewModelParser.Logical_and_expressionContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#additive_expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAdditive_expression(@NotNull ViewModelParser.Additive_expressionContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#variable_name}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitVariable_name(@NotNull ViewModelParser.Variable_nameContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#option_list}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitOption_list(@NotNull ViewModelParser.Option_listContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#unary_operator}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitUnary_operator(@NotNull ViewModelParser.Unary_operatorContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#lvalue}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitLvalue(@NotNull ViewModelParser.LvalueContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#shift_expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitShift_expression(@NotNull ViewModelParser.Shift_expressionContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#program}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitProgram(@NotNull ViewModelParser.ProgramContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#logical_or_expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitLogical_or_expression(@NotNull ViewModelParser.Logical_or_expressionContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#type_name}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitType_name(@NotNull ViewModelParser.Type_nameContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#unary_expression_operator}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitUnary_expression_operator(@NotNull ViewModelParser.Unary_expression_operatorContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#argument_expression_list}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitArgument_expression_list(@NotNull ViewModelParser.Argument_expression_listContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#inclusive_or_expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitInclusive_or_expression(@NotNull ViewModelParser.Inclusive_or_expressionContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#model}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitModel(@NotNull ViewModelParser.ModelContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#state}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitState(@NotNull ViewModelParser.StateContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#constant_expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitConstant_expression(@NotNull ViewModelParser.Constant_expressionContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#attribute}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAttribute(@NotNull ViewModelParser.AttributeContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#shift_expression_operator}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitShift_expression_operator(@NotNull ViewModelParser.Shift_expression_operatorContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#relational_expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitRelational_expression(@NotNull ViewModelParser.Relational_expressionContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#multiplicative_expression_operator}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitMultiplicative_expression_operator(@NotNull ViewModelParser.Multiplicative_expression_operatorContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#model_name}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitModel_name(@NotNull ViewModelParser.Model_nameContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#push}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitPush(@NotNull ViewModelParser.PushContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#postfix_part_function}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitPostfix_part_function(@NotNull ViewModelParser.Postfix_part_functionContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#relational_expression_operator}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitRelational_expression_operator(@NotNull ViewModelParser.Relational_expression_operatorContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#postfix_expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitPostfix_expression(@NotNull ViewModelParser.Postfix_expressionContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#postfix_part_index}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitPostfix_part_index(@NotNull ViewModelParser.Postfix_part_indexContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#assignment_operator}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAssignment_operator(@NotNull ViewModelParser.Assignment_operatorContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#unary_expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitUnary_expression(@NotNull ViewModelParser.Unary_expressionContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#postfix_part_increase}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitPostfix_part_increase(@NotNull ViewModelParser.Postfix_part_increaseContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#model_area}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitModel_area(@NotNull ViewModelParser.Model_areaContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#constant}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitConstant(@NotNull ViewModelParser.ConstantContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#option_name}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitOption_name(@NotNull ViewModelParser.Option_nameContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#attribute_name}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAttribute_name(@NotNull ViewModelParser.Attribute_nameContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#field}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitField(@NotNull ViewModelParser.FieldContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#conditional_expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitConditional_expression(@NotNull ViewModelParser.Conditional_expressionContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#and_expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAnd_expression(@NotNull ViewModelParser.And_expressionContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#primary_expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitPrimary_expression(@NotNull ViewModelParser.Primary_expressionContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#additive_expression_operator}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAdditive_expression_operator(@NotNull ViewModelParser.Additive_expression_operatorContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#option_value}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitOption_value(@NotNull ViewModelParser.Option_valueContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#unary_expression_one_char}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitUnary_expression_one_char(@NotNull ViewModelParser.Unary_expression_one_charContext ctx);

	/**
	 * Visit a parse tree produced by {@link ViewModelParser#postfix_part_long_name}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitPostfix_part_long_name(@NotNull ViewModelParser.Postfix_part_long_nameContext ctx);
}