// Generated from D:\workspace\20140311\ToolBag\ParseTool\src\parsetool\workflow\Workflow.g4 by ANTLR 4.1
package parsetool.workflow;
import org.antlr.v4.runtime.misc.NotNull;
import org.antlr.v4.runtime.tree.ParseTreeListener;

/**
 * This interface defines a complete listener for a parse tree produced by
 * {@link WorkflowParser}.
 */
public interface WorkflowListener extends ParseTreeListener {
	/**
	 * Enter a parse tree produced by {@link WorkflowParser#expression}.
	 * @param ctx the parse tree
	 */
	void enterExpression(@NotNull WorkflowParser.ExpressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#expression}.
	 * @param ctx the parse tree
	 */
	void exitExpression(@NotNull WorkflowParser.ExpressionContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#equality_expression_operator}.
	 * @param ctx the parse tree
	 */
	void enterEquality_expression_operator(@NotNull WorkflowParser.Equality_expression_operatorContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#equality_expression_operator}.
	 * @param ctx the parse tree
	 */
	void exitEquality_expression_operator(@NotNull WorkflowParser.Equality_expression_operatorContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#assignment_expression}.
	 * @param ctx the parse tree
	 */
	void enterAssignment_expression(@NotNull WorkflowParser.Assignment_expressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#assignment_expression}.
	 * @param ctx the parse tree
	 */
	void exitAssignment_expression(@NotNull WorkflowParser.Assignment_expressionContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#multiplicative_expression}.
	 * @param ctx the parse tree
	 */
	void enterMultiplicative_expression(@NotNull WorkflowParser.Multiplicative_expressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#multiplicative_expression}.
	 * @param ctx the parse tree
	 */
	void exitMultiplicative_expression(@NotNull WorkflowParser.Multiplicative_expressionContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#after}.
	 * @param ctx the parse tree
	 */
	void enterAfter(@NotNull WorkflowParser.AfterContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#after}.
	 * @param ctx the parse tree
	 */
	void exitAfter(@NotNull WorkflowParser.AfterContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#cast_expression}.
	 * @param ctx the parse tree
	 */
	void enterCast_expression(@NotNull WorkflowParser.Cast_expressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#cast_expression}.
	 * @param ctx the parse tree
	 */
	void exitCast_expression(@NotNull WorkflowParser.Cast_expressionContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#equality_expression}.
	 * @param ctx the parse tree
	 */
	void enterEquality_expression(@NotNull WorkflowParser.Equality_expressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#equality_expression}.
	 * @param ctx the parse tree
	 */
	void exitEquality_expression(@NotNull WorkflowParser.Equality_expressionContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#clz_name}.
	 * @param ctx the parse tree
	 */
	void enterClz_name(@NotNull WorkflowParser.Clz_nameContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#clz_name}.
	 * @param ctx the parse tree
	 */
	void exitClz_name(@NotNull WorkflowParser.Clz_nameContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#nameSpace}.
	 * @param ctx the parse tree
	 */
	void enterNameSpace(@NotNull WorkflowParser.NameSpaceContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#nameSpace}.
	 * @param ctx the parse tree
	 */
	void exitNameSpace(@NotNull WorkflowParser.NameSpaceContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#postfix_part_empty_function}.
	 * @param ctx the parse tree
	 */
	void enterPostfix_part_empty_function(@NotNull WorkflowParser.Postfix_part_empty_functionContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#postfix_part_empty_function}.
	 * @param ctx the parse tree
	 */
	void exitPostfix_part_empty_function(@NotNull WorkflowParser.Postfix_part_empty_functionContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#action}.
	 * @param ctx the parse tree
	 */
	void enterAction(@NotNull WorkflowParser.ActionContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#action}.
	 * @param ctx the parse tree
	 */
	void exitAction(@NotNull WorkflowParser.ActionContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#role}.
	 * @param ctx the parse tree
	 */
	void enterRole(@NotNull WorkflowParser.RoleContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#role}.
	 * @param ctx the parse tree
	 */
	void exitRole(@NotNull WorkflowParser.RoleContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#postfix_part_decrease}.
	 * @param ctx the parse tree
	 */
	void enterPostfix_part_decrease(@NotNull WorkflowParser.Postfix_part_decreaseContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#postfix_part_decrease}.
	 * @param ctx the parse tree
	 */
	void exitPostfix_part_decrease(@NotNull WorkflowParser.Postfix_part_decreaseContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#postfix_part}.
	 * @param ctx the parse tree
	 */
	void enterPostfix_part(@NotNull WorkflowParser.Postfix_partContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#postfix_part}.
	 * @param ctx the parse tree
	 */
	void exitPostfix_part(@NotNull WorkflowParser.Postfix_partContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#ref_workflow}.
	 * @param ctx the parse tree
	 */
	void enterRef_workflow(@NotNull WorkflowParser.Ref_workflowContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#ref_workflow}.
	 * @param ctx the parse tree
	 */
	void exitRef_workflow(@NotNull WorkflowParser.Ref_workflowContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#option}.
	 * @param ctx the parse tree
	 */
	void enterOption(@NotNull WorkflowParser.OptionContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#option}.
	 * @param ctx the parse tree
	 */
	void exitOption(@NotNull WorkflowParser.OptionContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#form}.
	 * @param ctx the parse tree
	 */
	void enterForm(@NotNull WorkflowParser.FormContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#form}.
	 * @param ctx the parse tree
	 */
	void exitForm(@NotNull WorkflowParser.FormContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#translation_statement}.
	 * @param ctx the parse tree
	 */
	void enterTranslation_statement(@NotNull WorkflowParser.Translation_statementContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#translation_statement}.
	 * @param ctx the parse tree
	 */
	void exitTranslation_statement(@NotNull WorkflowParser.Translation_statementContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#init}.
	 * @param ctx the parse tree
	 */
	void enterInit(@NotNull WorkflowParser.InitContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#init}.
	 * @param ctx the parse tree
	 */
	void exitInit(@NotNull WorkflowParser.InitContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#execute_line}.
	 * @param ctx the parse tree
	 */
	void enterExecute_line(@NotNull WorkflowParser.Execute_lineContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#execute_line}.
	 * @param ctx the parse tree
	 */
	void exitExecute_line(@NotNull WorkflowParser.Execute_lineContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#exclusive_or_expression}.
	 * @param ctx the parse tree
	 */
	void enterExclusive_or_expression(@NotNull WorkflowParser.Exclusive_or_expressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#exclusive_or_expression}.
	 * @param ctx the parse tree
	 */
	void exitExclusive_or_expression(@NotNull WorkflowParser.Exclusive_or_expressionContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#unary_expression_two_char}.
	 * @param ctx the parse tree
	 */
	void enterUnary_expression_two_char(@NotNull WorkflowParser.Unary_expression_two_charContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#unary_expression_two_char}.
	 * @param ctx the parse tree
	 */
	void exitUnary_expression_two_char(@NotNull WorkflowParser.Unary_expression_two_charContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#declare_statement}.
	 * @param ctx the parse tree
	 */
	void enterDeclare_statement(@NotNull WorkflowParser.Declare_statementContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#declare_statement}.
	 * @param ctx the parse tree
	 */
	void exitDeclare_statement(@NotNull WorkflowParser.Declare_statementContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#declare}.
	 * @param ctx the parse tree
	 */
	void enterDeclare(@NotNull WorkflowParser.DeclareContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#declare}.
	 * @param ctx the parse tree
	 */
	void exitDeclare(@NotNull WorkflowParser.DeclareContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#long_name2}.
	 * @param ctx the parse tree
	 */
	void enterLong_name2(@NotNull WorkflowParser.Long_name2Context ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#long_name2}.
	 * @param ctx the parse tree
	 */
	void exitLong_name2(@NotNull WorkflowParser.Long_name2Context ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#attribute_value}.
	 * @param ctx the parse tree
	 */
	void enterAttribute_value(@NotNull WorkflowParser.Attribute_valueContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#attribute_value}.
	 * @param ctx the parse tree
	 */
	void exitAttribute_value(@NotNull WorkflowParser.Attribute_valueContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#statement}.
	 * @param ctx the parse tree
	 */
	void enterStatement(@NotNull WorkflowParser.StatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#statement}.
	 * @param ctx the parse tree
	 */
	void exitStatement(@NotNull WorkflowParser.StatementContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#logical_and_expression}.
	 * @param ctx the parse tree
	 */
	void enterLogical_and_expression(@NotNull WorkflowParser.Logical_and_expressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#logical_and_expression}.
	 * @param ctx the parse tree
	 */
	void exitLogical_and_expression(@NotNull WorkflowParser.Logical_and_expressionContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#node}.
	 * @param ctx the parse tree
	 */
	void enterNode(@NotNull WorkflowParser.NodeContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#node}.
	 * @param ctx the parse tree
	 */
	void exitNode(@NotNull WorkflowParser.NodeContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#variable_name}.
	 * @param ctx the parse tree
	 */
	void enterVariable_name(@NotNull WorkflowParser.Variable_nameContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#variable_name}.
	 * @param ctx the parse tree
	 */
	void exitVariable_name(@NotNull WorkflowParser.Variable_nameContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#additive_expression}.
	 * @param ctx the parse tree
	 */
	void enterAdditive_expression(@NotNull WorkflowParser.Additive_expressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#additive_expression}.
	 * @param ctx the parse tree
	 */
	void exitAdditive_expression(@NotNull WorkflowParser.Additive_expressionContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#option_list}.
	 * @param ctx the parse tree
	 */
	void enterOption_list(@NotNull WorkflowParser.Option_listContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#option_list}.
	 * @param ctx the parse tree
	 */
	void exitOption_list(@NotNull WorkflowParser.Option_listContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#lvalue}.
	 * @param ctx the parse tree
	 */
	void enterLvalue(@NotNull WorkflowParser.LvalueContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#lvalue}.
	 * @param ctx the parse tree
	 */
	void exitLvalue(@NotNull WorkflowParser.LvalueContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#unary_operator}.
	 * @param ctx the parse tree
	 */
	void enterUnary_operator(@NotNull WorkflowParser.Unary_operatorContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#unary_operator}.
	 * @param ctx the parse tree
	 */
	void exitUnary_operator(@NotNull WorkflowParser.Unary_operatorContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#shift_expression}.
	 * @param ctx the parse tree
	 */
	void enterShift_expression(@NotNull WorkflowParser.Shift_expressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#shift_expression}.
	 * @param ctx the parse tree
	 */
	void exitShift_expression(@NotNull WorkflowParser.Shift_expressionContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#program}.
	 * @param ctx the parse tree
	 */
	void enterProgram(@NotNull WorkflowParser.ProgramContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#program}.
	 * @param ctx the parse tree
	 */
	void exitProgram(@NotNull WorkflowParser.ProgramContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#logical_or_expression}.
	 * @param ctx the parse tree
	 */
	void enterLogical_or_expression(@NotNull WorkflowParser.Logical_or_expressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#logical_or_expression}.
	 * @param ctx the parse tree
	 */
	void exitLogical_or_expression(@NotNull WorkflowParser.Logical_or_expressionContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#clz}.
	 * @param ctx the parse tree
	 */
	void enterClz(@NotNull WorkflowParser.ClzContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#clz}.
	 * @param ctx the parse tree
	 */
	void exitClz(@NotNull WorkflowParser.ClzContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#generic_type}.
	 * @param ctx the parse tree
	 */
	void enterGeneric_type(@NotNull WorkflowParser.Generic_typeContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#generic_type}.
	 * @param ctx the parse tree
	 */
	void exitGeneric_type(@NotNull WorkflowParser.Generic_typeContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#breakStatement}.
	 * @param ctx the parse tree
	 */
	void enterBreakStatement(@NotNull WorkflowParser.BreakStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#breakStatement}.
	 * @param ctx the parse tree
	 */
	void exitBreakStatement(@NotNull WorkflowParser.BreakStatementContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#unary_expression_operator}.
	 * @param ctx the parse tree
	 */
	void enterUnary_expression_operator(@NotNull WorkflowParser.Unary_expression_operatorContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#unary_expression_operator}.
	 * @param ctx the parse tree
	 */
	void exitUnary_expression_operator(@NotNull WorkflowParser.Unary_expression_operatorContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#argument_expression_list}.
	 * @param ctx the parse tree
	 */
	void enterArgument_expression_list(@NotNull WorkflowParser.Argument_expression_listContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#argument_expression_list}.
	 * @param ctx the parse tree
	 */
	void exitArgument_expression_list(@NotNull WorkflowParser.Argument_expression_listContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#inclusive_or_expression}.
	 * @param ctx the parse tree
	 */
	void enterInclusive_or_expression(@NotNull WorkflowParser.Inclusive_or_expressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#inclusive_or_expression}.
	 * @param ctx the parse tree
	 */
	void exitInclusive_or_expression(@NotNull WorkflowParser.Inclusive_or_expressionContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#translation}.
	 * @param ctx the parse tree
	 */
	void enterTranslation(@NotNull WorkflowParser.TranslationContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#translation}.
	 * @param ctx the parse tree
	 */
	void exitTranslation(@NotNull WorkflowParser.TranslationContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#forStatement}.
	 * @param ctx the parse tree
	 */
	void enterForStatement(@NotNull WorkflowParser.ForStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#forStatement}.
	 * @param ctx the parse tree
	 */
	void exitForStatement(@NotNull WorkflowParser.ForStatementContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#doWhileStatement}.
	 * @param ctx the parse tree
	 */
	void enterDoWhileStatement(@NotNull WorkflowParser.DoWhileStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#doWhileStatement}.
	 * @param ctx the parse tree
	 */
	void exitDoWhileStatement(@NotNull WorkflowParser.DoWhileStatementContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#before}.
	 * @param ctx the parse tree
	 */
	void enterBefore(@NotNull WorkflowParser.BeforeContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#before}.
	 * @param ctx the parse tree
	 */
	void exitBefore(@NotNull WorkflowParser.BeforeContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#forEachStatement}.
	 * @param ctx the parse tree
	 */
	void enterForEachStatement(@NotNull WorkflowParser.ForEachStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#forEachStatement}.
	 * @param ctx the parse tree
	 */
	void exitForEachStatement(@NotNull WorkflowParser.ForEachStatementContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#constant_expression}.
	 * @param ctx the parse tree
	 */
	void enterConstant_expression(@NotNull WorkflowParser.Constant_expressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#constant_expression}.
	 * @param ctx the parse tree
	 */
	void exitConstant_expression(@NotNull WorkflowParser.Constant_expressionContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#state}.
	 * @param ctx the parse tree
	 */
	void enterState(@NotNull WorkflowParser.StateContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#state}.
	 * @param ctx the parse tree
	 */
	void exitState(@NotNull WorkflowParser.StateContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#attribute}.
	 * @param ctx the parse tree
	 */
	void enterAttribute(@NotNull WorkflowParser.AttributeContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#attribute}.
	 * @param ctx the parse tree
	 */
	void exitAttribute(@NotNull WorkflowParser.AttributeContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#shift_expression_operator}.
	 * @param ctx the parse tree
	 */
	void enterShift_expression_operator(@NotNull WorkflowParser.Shift_expression_operatorContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#shift_expression_operator}.
	 * @param ctx the parse tree
	 */
	void exitShift_expression_operator(@NotNull WorkflowParser.Shift_expression_operatorContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#relational_expression}.
	 * @param ctx the parse tree
	 */
	void enterRelational_expression(@NotNull WorkflowParser.Relational_expressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#relational_expression}.
	 * @param ctx the parse tree
	 */
	void exitRelational_expression(@NotNull WorkflowParser.Relational_expressionContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#multiplicative_expression_operator}.
	 * @param ctx the parse tree
	 */
	void enterMultiplicative_expression_operator(@NotNull WorkflowParser.Multiplicative_expression_operatorContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#multiplicative_expression_operator}.
	 * @param ctx the parse tree
	 */
	void exitMultiplicative_expression_operator(@NotNull WorkflowParser.Multiplicative_expression_operatorContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#creator}.
	 * @param ctx the parse tree
	 */
	void enterCreator(@NotNull WorkflowParser.CreatorContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#creator}.
	 * @param ctx the parse tree
	 */
	void exitCreator(@NotNull WorkflowParser.CreatorContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#postfix_part_function}.
	 * @param ctx the parse tree
	 */
	void enterPostfix_part_function(@NotNull WorkflowParser.Postfix_part_functionContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#postfix_part_function}.
	 * @param ctx the parse tree
	 */
	void exitPostfix_part_function(@NotNull WorkflowParser.Postfix_part_functionContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#relational_expression_operator}.
	 * @param ctx the parse tree
	 */
	void enterRelational_expression_operator(@NotNull WorkflowParser.Relational_expression_operatorContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#relational_expression_operator}.
	 * @param ctx the parse tree
	 */
	void exitRelational_expression_operator(@NotNull WorkflowParser.Relational_expression_operatorContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#postfix_part_index}.
	 * @param ctx the parse tree
	 */
	void enterPostfix_part_index(@NotNull WorkflowParser.Postfix_part_indexContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#postfix_part_index}.
	 * @param ctx the parse tree
	 */
	void exitPostfix_part_index(@NotNull WorkflowParser.Postfix_part_indexContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#postfix_expression}.
	 * @param ctx the parse tree
	 */
	void enterPostfix_expression(@NotNull WorkflowParser.Postfix_expressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#postfix_expression}.
	 * @param ctx the parse tree
	 */
	void exitPostfix_expression(@NotNull WorkflowParser.Postfix_expressionContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#long_name}.
	 * @param ctx the parse tree
	 */
	void enterLong_name(@NotNull WorkflowParser.Long_nameContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#long_name}.
	 * @param ctx the parse tree
	 */
	void exitLong_name(@NotNull WorkflowParser.Long_nameContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#assignment_operator}.
	 * @param ctx the parse tree
	 */
	void enterAssignment_operator(@NotNull WorkflowParser.Assignment_operatorContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#assignment_operator}.
	 * @param ctx the parse tree
	 */
	void exitAssignment_operator(@NotNull WorkflowParser.Assignment_operatorContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#caseExpression}.
	 * @param ctx the parse tree
	 */
	void enterCaseExpression(@NotNull WorkflowParser.CaseExpressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#caseExpression}.
	 * @param ctx the parse tree
	 */
	void exitCaseExpression(@NotNull WorkflowParser.CaseExpressionContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#postfix_part_increase}.
	 * @param ctx the parse tree
	 */
	void enterPostfix_part_increase(@NotNull WorkflowParser.Postfix_part_increaseContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#postfix_part_increase}.
	 * @param ctx the parse tree
	 */
	void exitPostfix_part_increase(@NotNull WorkflowParser.Postfix_part_increaseContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#unary_expression}.
	 * @param ctx the parse tree
	 */
	void enterUnary_expression(@NotNull WorkflowParser.Unary_expressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#unary_expression}.
	 * @param ctx the parse tree
	 */
	void exitUnary_expression(@NotNull WorkflowParser.Unary_expressionContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#parallel}.
	 * @param ctx the parse tree
	 */
	void enterParallel(@NotNull WorkflowParser.ParallelContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#parallel}.
	 * @param ctx the parse tree
	 */
	void exitParallel(@NotNull WorkflowParser.ParallelContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#constant}.
	 * @param ctx the parse tree
	 */
	void enterConstant(@NotNull WorkflowParser.ConstantContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#constant}.
	 * @param ctx the parse tree
	 */
	void exitConstant(@NotNull WorkflowParser.ConstantContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#option_name}.
	 * @param ctx the parse tree
	 */
	void enterOption_name(@NotNull WorkflowParser.Option_nameContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#option_name}.
	 * @param ctx the parse tree
	 */
	void exitOption_name(@NotNull WorkflowParser.Option_nameContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#expression_statement}.
	 * @param ctx the parse tree
	 */
	void enterExpression_statement(@NotNull WorkflowParser.Expression_statementContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#expression_statement}.
	 * @param ctx the parse tree
	 */
	void exitExpression_statement(@NotNull WorkflowParser.Expression_statementContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#continueStatement}.
	 * @param ctx the parse tree
	 */
	void enterContinueStatement(@NotNull WorkflowParser.ContinueStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#continueStatement}.
	 * @param ctx the parse tree
	 */
	void exitContinueStatement(@NotNull WorkflowParser.ContinueStatementContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#ifStatement}.
	 * @param ctx the parse tree
	 */
	void enterIfStatement(@NotNull WorkflowParser.IfStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#ifStatement}.
	 * @param ctx the parse tree
	 */
	void exitIfStatement(@NotNull WorkflowParser.IfStatementContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#attribute_name}.
	 * @param ctx the parse tree
	 */
	void enterAttribute_name(@NotNull WorkflowParser.Attribute_nameContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#attribute_name}.
	 * @param ctx the parse tree
	 */
	void exitAttribute_name(@NotNull WorkflowParser.Attribute_nameContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#field}.
	 * @param ctx the parse tree
	 */
	void enterField(@NotNull WorkflowParser.FieldContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#field}.
	 * @param ctx the parse tree
	 */
	void exitField(@NotNull WorkflowParser.FieldContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#unit}.
	 * @param ctx the parse tree
	 */
	void enterUnit(@NotNull WorkflowParser.UnitContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#unit}.
	 * @param ctx the parse tree
	 */
	void exitUnit(@NotNull WorkflowParser.UnitContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#switchStatement}.
	 * @param ctx the parse tree
	 */
	void enterSwitchStatement(@NotNull WorkflowParser.SwitchStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#switchStatement}.
	 * @param ctx the parse tree
	 */
	void exitSwitchStatement(@NotNull WorkflowParser.SwitchStatementContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#conditional_expression}.
	 * @param ctx the parse tree
	 */
	void enterConditional_expression(@NotNull WorkflowParser.Conditional_expressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#conditional_expression}.
	 * @param ctx the parse tree
	 */
	void exitConditional_expression(@NotNull WorkflowParser.Conditional_expressionContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#and_expression}.
	 * @param ctx the parse tree
	 */
	void enterAnd_expression(@NotNull WorkflowParser.And_expressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#and_expression}.
	 * @param ctx the parse tree
	 */
	void exitAnd_expression(@NotNull WorkflowParser.And_expressionContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#primary_expression}.
	 * @param ctx the parse tree
	 */
	void enterPrimary_expression(@NotNull WorkflowParser.Primary_expressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#primary_expression}.
	 * @param ctx the parse tree
	 */
	void exitPrimary_expression(@NotNull WorkflowParser.Primary_expressionContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#whileStatement}.
	 * @param ctx the parse tree
	 */
	void enterWhileStatement(@NotNull WorkflowParser.WhileStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#whileStatement}.
	 * @param ctx the parse tree
	 */
	void exitWhileStatement(@NotNull WorkflowParser.WhileStatementContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#option_value}.
	 * @param ctx the parse tree
	 */
	void enterOption_value(@NotNull WorkflowParser.Option_valueContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#option_value}.
	 * @param ctx the parse tree
	 */
	void exitOption_value(@NotNull WorkflowParser.Option_valueContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#gotoStatement}.
	 * @param ctx the parse tree
	 */
	void enterGotoStatement(@NotNull WorkflowParser.GotoStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#gotoStatement}.
	 * @param ctx the parse tree
	 */
	void exitGotoStatement(@NotNull WorkflowParser.GotoStatementContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#additive_expression_operator}.
	 * @param ctx the parse tree
	 */
	void enterAdditive_expression_operator(@NotNull WorkflowParser.Additive_expression_operatorContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#additive_expression_operator}.
	 * @param ctx the parse tree
	 */
	void exitAdditive_expression_operator(@NotNull WorkflowParser.Additive_expression_operatorContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#postfix_part_long_name}.
	 * @param ctx the parse tree
	 */
	void enterPostfix_part_long_name(@NotNull WorkflowParser.Postfix_part_long_nameContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#postfix_part_long_name}.
	 * @param ctx the parse tree
	 */
	void exitPostfix_part_long_name(@NotNull WorkflowParser.Postfix_part_long_nameContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#unary_expression_one_char}.
	 * @param ctx the parse tree
	 */
	void enterUnary_expression_one_char(@NotNull WorkflowParser.Unary_expression_one_charContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#unary_expression_one_char}.
	 * @param ctx the parse tree
	 */
	void exitUnary_expression_one_char(@NotNull WorkflowParser.Unary_expression_one_charContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#user}.
	 * @param ctx the parse tree
	 */
	void enterUser(@NotNull WorkflowParser.UserContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#user}.
	 * @param ctx the parse tree
	 */
	void exitUser(@NotNull WorkflowParser.UserContext ctx);

	/**
	 * Enter a parse tree produced by {@link WorkflowParser#variable}.
	 * @param ctx the parse tree
	 */
	void enterVariable(@NotNull WorkflowParser.VariableContext ctx);
	/**
	 * Exit a parse tree produced by {@link WorkflowParser#variable}.
	 * @param ctx the parse tree
	 */
	void exitVariable(@NotNull WorkflowParser.VariableContext ctx);
}