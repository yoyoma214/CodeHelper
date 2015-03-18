// Generated from D:\workspace\20140311\ToolBag\ParseTool\src\parsetool\viewmodel\ViewModel.g4 by ANTLR 4.1
package parsetool.viewmodel;
import org.antlr.v4.runtime.misc.NotNull;
import org.antlr.v4.runtime.tree.ParseTreeListener;

/**
 * This interface defines a complete listener for a parse tree produced by
 * {@link ViewModelParser}.
 */
public interface ViewModelListener extends ParseTreeListener {
	/**
	 * Enter a parse tree produced by {@link ViewModelParser#expression}.
	 * @param ctx the parse tree
	 */
	void enterExpression(@NotNull ViewModelParser.ExpressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#expression}.
	 * @param ctx the parse tree
	 */
	void exitExpression(@NotNull ViewModelParser.ExpressionContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#equality_expression_operator}.
	 * @param ctx the parse tree
	 */
	void enterEquality_expression_operator(@NotNull ViewModelParser.Equality_expression_operatorContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#equality_expression_operator}.
	 * @param ctx the parse tree
	 */
	void exitEquality_expression_operator(@NotNull ViewModelParser.Equality_expression_operatorContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#pull}.
	 * @param ctx the parse tree
	 */
	void enterPull(@NotNull ViewModelParser.PullContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#pull}.
	 * @param ctx the parse tree
	 */
	void exitPull(@NotNull ViewModelParser.PullContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#assignment_expression}.
	 * @param ctx the parse tree
	 */
	void enterAssignment_expression(@NotNull ViewModelParser.Assignment_expressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#assignment_expression}.
	 * @param ctx the parse tree
	 */
	void exitAssignment_expression(@NotNull ViewModelParser.Assignment_expressionContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#multiplicative_expression}.
	 * @param ctx the parse tree
	 */
	void enterMultiplicative_expression(@NotNull ViewModelParser.Multiplicative_expressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#multiplicative_expression}.
	 * @param ctx the parse tree
	 */
	void exitMultiplicative_expression(@NotNull ViewModelParser.Multiplicative_expressionContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#cast_expression}.
	 * @param ctx the parse tree
	 */
	void enterCast_expression(@NotNull ViewModelParser.Cast_expressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#cast_expression}.
	 * @param ctx the parse tree
	 */
	void exitCast_expression(@NotNull ViewModelParser.Cast_expressionContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#equality_expression}.
	 * @param ctx the parse tree
	 */
	void enterEquality_expression(@NotNull ViewModelParser.Equality_expressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#equality_expression}.
	 * @param ctx the parse tree
	 */
	void exitEquality_expression(@NotNull ViewModelParser.Equality_expressionContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#postfix_part_empty_function}.
	 * @param ctx the parse tree
	 */
	void enterPostfix_part_empty_function(@NotNull ViewModelParser.Postfix_part_empty_functionContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#postfix_part_empty_function}.
	 * @param ctx the parse tree
	 */
	void exitPostfix_part_empty_function(@NotNull ViewModelParser.Postfix_part_empty_functionContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#postfix_part}.
	 * @param ctx the parse tree
	 */
	void enterPostfix_part(@NotNull ViewModelParser.Postfix_partContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#postfix_part}.
	 * @param ctx the parse tree
	 */
	void exitPostfix_part(@NotNull ViewModelParser.Postfix_partContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#postfix_part_decrease}.
	 * @param ctx the parse tree
	 */
	void enterPostfix_part_decrease(@NotNull ViewModelParser.Postfix_part_decreaseContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#postfix_part_decrease}.
	 * @param ctx the parse tree
	 */
	void exitPostfix_part_decrease(@NotNull ViewModelParser.Postfix_part_decreaseContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#option}.
	 * @param ctx the parse tree
	 */
	void enterOption(@NotNull ViewModelParser.OptionContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#option}.
	 * @param ctx the parse tree
	 */
	void exitOption(@NotNull ViewModelParser.OptionContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#exclusive_or_expression}.
	 * @param ctx the parse tree
	 */
	void enterExclusive_or_expression(@NotNull ViewModelParser.Exclusive_or_expressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#exclusive_or_expression}.
	 * @param ctx the parse tree
	 */
	void exitExclusive_or_expression(@NotNull ViewModelParser.Exclusive_or_expressionContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#unary_expression_two_char}.
	 * @param ctx the parse tree
	 */
	void enterUnary_expression_two_char(@NotNull ViewModelParser.Unary_expression_two_charContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#unary_expression_two_char}.
	 * @param ctx the parse tree
	 */
	void exitUnary_expression_two_char(@NotNull ViewModelParser.Unary_expression_two_charContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#declare_statement}.
	 * @param ctx the parse tree
	 */
	void enterDeclare_statement(@NotNull ViewModelParser.Declare_statementContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#declare_statement}.
	 * @param ctx the parse tree
	 */
	void exitDeclare_statement(@NotNull ViewModelParser.Declare_statementContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#declare}.
	 * @param ctx the parse tree
	 */
	void enterDeclare(@NotNull ViewModelParser.DeclareContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#declare}.
	 * @param ctx the parse tree
	 */
	void exitDeclare(@NotNull ViewModelParser.DeclareContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#statement}.
	 * @param ctx the parse tree
	 */
	void enterStatement(@NotNull ViewModelParser.StatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#statement}.
	 * @param ctx the parse tree
	 */
	void exitStatement(@NotNull ViewModelParser.StatementContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#attribute_value}.
	 * @param ctx the parse tree
	 */
	void enterAttribute_value(@NotNull ViewModelParser.Attribute_valueContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#attribute_value}.
	 * @param ctx the parse tree
	 */
	void exitAttribute_value(@NotNull ViewModelParser.Attribute_valueContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#logical_and_expression}.
	 * @param ctx the parse tree
	 */
	void enterLogical_and_expression(@NotNull ViewModelParser.Logical_and_expressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#logical_and_expression}.
	 * @param ctx the parse tree
	 */
	void exitLogical_and_expression(@NotNull ViewModelParser.Logical_and_expressionContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#additive_expression}.
	 * @param ctx the parse tree
	 */
	void enterAdditive_expression(@NotNull ViewModelParser.Additive_expressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#additive_expression}.
	 * @param ctx the parse tree
	 */
	void exitAdditive_expression(@NotNull ViewModelParser.Additive_expressionContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#variable_name}.
	 * @param ctx the parse tree
	 */
	void enterVariable_name(@NotNull ViewModelParser.Variable_nameContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#variable_name}.
	 * @param ctx the parse tree
	 */
	void exitVariable_name(@NotNull ViewModelParser.Variable_nameContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#option_list}.
	 * @param ctx the parse tree
	 */
	void enterOption_list(@NotNull ViewModelParser.Option_listContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#option_list}.
	 * @param ctx the parse tree
	 */
	void exitOption_list(@NotNull ViewModelParser.Option_listContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#unary_operator}.
	 * @param ctx the parse tree
	 */
	void enterUnary_operator(@NotNull ViewModelParser.Unary_operatorContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#unary_operator}.
	 * @param ctx the parse tree
	 */
	void exitUnary_operator(@NotNull ViewModelParser.Unary_operatorContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#lvalue}.
	 * @param ctx the parse tree
	 */
	void enterLvalue(@NotNull ViewModelParser.LvalueContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#lvalue}.
	 * @param ctx the parse tree
	 */
	void exitLvalue(@NotNull ViewModelParser.LvalueContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#shift_expression}.
	 * @param ctx the parse tree
	 */
	void enterShift_expression(@NotNull ViewModelParser.Shift_expressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#shift_expression}.
	 * @param ctx the parse tree
	 */
	void exitShift_expression(@NotNull ViewModelParser.Shift_expressionContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#program}.
	 * @param ctx the parse tree
	 */
	void enterProgram(@NotNull ViewModelParser.ProgramContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#program}.
	 * @param ctx the parse tree
	 */
	void exitProgram(@NotNull ViewModelParser.ProgramContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#logical_or_expression}.
	 * @param ctx the parse tree
	 */
	void enterLogical_or_expression(@NotNull ViewModelParser.Logical_or_expressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#logical_or_expression}.
	 * @param ctx the parse tree
	 */
	void exitLogical_or_expression(@NotNull ViewModelParser.Logical_or_expressionContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#type_name}.
	 * @param ctx the parse tree
	 */
	void enterType_name(@NotNull ViewModelParser.Type_nameContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#type_name}.
	 * @param ctx the parse tree
	 */
	void exitType_name(@NotNull ViewModelParser.Type_nameContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#unary_expression_operator}.
	 * @param ctx the parse tree
	 */
	void enterUnary_expression_operator(@NotNull ViewModelParser.Unary_expression_operatorContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#unary_expression_operator}.
	 * @param ctx the parse tree
	 */
	void exitUnary_expression_operator(@NotNull ViewModelParser.Unary_expression_operatorContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#argument_expression_list}.
	 * @param ctx the parse tree
	 */
	void enterArgument_expression_list(@NotNull ViewModelParser.Argument_expression_listContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#argument_expression_list}.
	 * @param ctx the parse tree
	 */
	void exitArgument_expression_list(@NotNull ViewModelParser.Argument_expression_listContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#inclusive_or_expression}.
	 * @param ctx the parse tree
	 */
	void enterInclusive_or_expression(@NotNull ViewModelParser.Inclusive_or_expressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#inclusive_or_expression}.
	 * @param ctx the parse tree
	 */
	void exitInclusive_or_expression(@NotNull ViewModelParser.Inclusive_or_expressionContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#model}.
	 * @param ctx the parse tree
	 */
	void enterModel(@NotNull ViewModelParser.ModelContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#model}.
	 * @param ctx the parse tree
	 */
	void exitModel(@NotNull ViewModelParser.ModelContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#state}.
	 * @param ctx the parse tree
	 */
	void enterState(@NotNull ViewModelParser.StateContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#state}.
	 * @param ctx the parse tree
	 */
	void exitState(@NotNull ViewModelParser.StateContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#constant_expression}.
	 * @param ctx the parse tree
	 */
	void enterConstant_expression(@NotNull ViewModelParser.Constant_expressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#constant_expression}.
	 * @param ctx the parse tree
	 */
	void exitConstant_expression(@NotNull ViewModelParser.Constant_expressionContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#attribute}.
	 * @param ctx the parse tree
	 */
	void enterAttribute(@NotNull ViewModelParser.AttributeContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#attribute}.
	 * @param ctx the parse tree
	 */
	void exitAttribute(@NotNull ViewModelParser.AttributeContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#shift_expression_operator}.
	 * @param ctx the parse tree
	 */
	void enterShift_expression_operator(@NotNull ViewModelParser.Shift_expression_operatorContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#shift_expression_operator}.
	 * @param ctx the parse tree
	 */
	void exitShift_expression_operator(@NotNull ViewModelParser.Shift_expression_operatorContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#relational_expression}.
	 * @param ctx the parse tree
	 */
	void enterRelational_expression(@NotNull ViewModelParser.Relational_expressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#relational_expression}.
	 * @param ctx the parse tree
	 */
	void exitRelational_expression(@NotNull ViewModelParser.Relational_expressionContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#multiplicative_expression_operator}.
	 * @param ctx the parse tree
	 */
	void enterMultiplicative_expression_operator(@NotNull ViewModelParser.Multiplicative_expression_operatorContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#multiplicative_expression_operator}.
	 * @param ctx the parse tree
	 */
	void exitMultiplicative_expression_operator(@NotNull ViewModelParser.Multiplicative_expression_operatorContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#model_name}.
	 * @param ctx the parse tree
	 */
	void enterModel_name(@NotNull ViewModelParser.Model_nameContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#model_name}.
	 * @param ctx the parse tree
	 */
	void exitModel_name(@NotNull ViewModelParser.Model_nameContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#push}.
	 * @param ctx the parse tree
	 */
	void enterPush(@NotNull ViewModelParser.PushContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#push}.
	 * @param ctx the parse tree
	 */
	void exitPush(@NotNull ViewModelParser.PushContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#postfix_part_function}.
	 * @param ctx the parse tree
	 */
	void enterPostfix_part_function(@NotNull ViewModelParser.Postfix_part_functionContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#postfix_part_function}.
	 * @param ctx the parse tree
	 */
	void exitPostfix_part_function(@NotNull ViewModelParser.Postfix_part_functionContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#relational_expression_operator}.
	 * @param ctx the parse tree
	 */
	void enterRelational_expression_operator(@NotNull ViewModelParser.Relational_expression_operatorContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#relational_expression_operator}.
	 * @param ctx the parse tree
	 */
	void exitRelational_expression_operator(@NotNull ViewModelParser.Relational_expression_operatorContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#postfix_expression}.
	 * @param ctx the parse tree
	 */
	void enterPostfix_expression(@NotNull ViewModelParser.Postfix_expressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#postfix_expression}.
	 * @param ctx the parse tree
	 */
	void exitPostfix_expression(@NotNull ViewModelParser.Postfix_expressionContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#postfix_part_index}.
	 * @param ctx the parse tree
	 */
	void enterPostfix_part_index(@NotNull ViewModelParser.Postfix_part_indexContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#postfix_part_index}.
	 * @param ctx the parse tree
	 */
	void exitPostfix_part_index(@NotNull ViewModelParser.Postfix_part_indexContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#assignment_operator}.
	 * @param ctx the parse tree
	 */
	void enterAssignment_operator(@NotNull ViewModelParser.Assignment_operatorContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#assignment_operator}.
	 * @param ctx the parse tree
	 */
	void exitAssignment_operator(@NotNull ViewModelParser.Assignment_operatorContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#unary_expression}.
	 * @param ctx the parse tree
	 */
	void enterUnary_expression(@NotNull ViewModelParser.Unary_expressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#unary_expression}.
	 * @param ctx the parse tree
	 */
	void exitUnary_expression(@NotNull ViewModelParser.Unary_expressionContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#postfix_part_increase}.
	 * @param ctx the parse tree
	 */
	void enterPostfix_part_increase(@NotNull ViewModelParser.Postfix_part_increaseContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#postfix_part_increase}.
	 * @param ctx the parse tree
	 */
	void exitPostfix_part_increase(@NotNull ViewModelParser.Postfix_part_increaseContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#model_area}.
	 * @param ctx the parse tree
	 */
	void enterModel_area(@NotNull ViewModelParser.Model_areaContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#model_area}.
	 * @param ctx the parse tree
	 */
	void exitModel_area(@NotNull ViewModelParser.Model_areaContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#constant}.
	 * @param ctx the parse tree
	 */
	void enterConstant(@NotNull ViewModelParser.ConstantContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#constant}.
	 * @param ctx the parse tree
	 */
	void exitConstant(@NotNull ViewModelParser.ConstantContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#option_name}.
	 * @param ctx the parse tree
	 */
	void enterOption_name(@NotNull ViewModelParser.Option_nameContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#option_name}.
	 * @param ctx the parse tree
	 */
	void exitOption_name(@NotNull ViewModelParser.Option_nameContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#attribute_name}.
	 * @param ctx the parse tree
	 */
	void enterAttribute_name(@NotNull ViewModelParser.Attribute_nameContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#attribute_name}.
	 * @param ctx the parse tree
	 */
	void exitAttribute_name(@NotNull ViewModelParser.Attribute_nameContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#field}.
	 * @param ctx the parse tree
	 */
	void enterField(@NotNull ViewModelParser.FieldContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#field}.
	 * @param ctx the parse tree
	 */
	void exitField(@NotNull ViewModelParser.FieldContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#conditional_expression}.
	 * @param ctx the parse tree
	 */
	void enterConditional_expression(@NotNull ViewModelParser.Conditional_expressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#conditional_expression}.
	 * @param ctx the parse tree
	 */
	void exitConditional_expression(@NotNull ViewModelParser.Conditional_expressionContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#and_expression}.
	 * @param ctx the parse tree
	 */
	void enterAnd_expression(@NotNull ViewModelParser.And_expressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#and_expression}.
	 * @param ctx the parse tree
	 */
	void exitAnd_expression(@NotNull ViewModelParser.And_expressionContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#primary_expression}.
	 * @param ctx the parse tree
	 */
	void enterPrimary_expression(@NotNull ViewModelParser.Primary_expressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#primary_expression}.
	 * @param ctx the parse tree
	 */
	void exitPrimary_expression(@NotNull ViewModelParser.Primary_expressionContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#additive_expression_operator}.
	 * @param ctx the parse tree
	 */
	void enterAdditive_expression_operator(@NotNull ViewModelParser.Additive_expression_operatorContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#additive_expression_operator}.
	 * @param ctx the parse tree
	 */
	void exitAdditive_expression_operator(@NotNull ViewModelParser.Additive_expression_operatorContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#option_value}.
	 * @param ctx the parse tree
	 */
	void enterOption_value(@NotNull ViewModelParser.Option_valueContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#option_value}.
	 * @param ctx the parse tree
	 */
	void exitOption_value(@NotNull ViewModelParser.Option_valueContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#unary_expression_one_char}.
	 * @param ctx the parse tree
	 */
	void enterUnary_expression_one_char(@NotNull ViewModelParser.Unary_expression_one_charContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#unary_expression_one_char}.
	 * @param ctx the parse tree
	 */
	void exitUnary_expression_one_char(@NotNull ViewModelParser.Unary_expression_one_charContext ctx);

	/**
	 * Enter a parse tree produced by {@link ViewModelParser#postfix_part_long_name}.
	 * @param ctx the parse tree
	 */
	void enterPostfix_part_long_name(@NotNull ViewModelParser.Postfix_part_long_nameContext ctx);
	/**
	 * Exit a parse tree produced by {@link ViewModelParser#postfix_part_long_name}.
	 * @param ctx the parse tree
	 */
	void exitPostfix_part_long_name(@NotNull ViewModelParser.Postfix_part_long_nameContext ctx);
}