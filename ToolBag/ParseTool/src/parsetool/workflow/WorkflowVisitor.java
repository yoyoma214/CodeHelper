// Generated from D:\workspace\20140311\ToolBag\ParseTool\src\parsetool\workflow\Workflow.g4 by ANTLR 4.1
package parsetool.workflow;
import org.antlr.v4.runtime.misc.NotNull;
import org.antlr.v4.runtime.tree.ParseTreeVisitor;

/**
 * This interface defines a complete generic visitor for a parse tree produced
 * by {@link WorkflowParser}.
 *
 * @param <T> The return type of the visit operation. Use {@link Void} for
 * operations with no return type.
 */
public interface WorkflowVisitor<T> extends ParseTreeVisitor<T> {
	/**
	 * Visit a parse tree produced by {@link WorkflowParser#expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitExpression(@NotNull WorkflowParser.ExpressionContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#equality_expression_operator}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitEquality_expression_operator(@NotNull WorkflowParser.Equality_expression_operatorContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#assignment_expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAssignment_expression(@NotNull WorkflowParser.Assignment_expressionContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#multiplicative_expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitMultiplicative_expression(@NotNull WorkflowParser.Multiplicative_expressionContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#after}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAfter(@NotNull WorkflowParser.AfterContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#cast_expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitCast_expression(@NotNull WorkflowParser.Cast_expressionContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#equality_expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitEquality_expression(@NotNull WorkflowParser.Equality_expressionContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#clz_name}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitClz_name(@NotNull WorkflowParser.Clz_nameContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#nameSpace}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitNameSpace(@NotNull WorkflowParser.NameSpaceContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#postfix_part_empty_function}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitPostfix_part_empty_function(@NotNull WorkflowParser.Postfix_part_empty_functionContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#action}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAction(@NotNull WorkflowParser.ActionContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#role}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitRole(@NotNull WorkflowParser.RoleContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#postfix_part_decrease}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitPostfix_part_decrease(@NotNull WorkflowParser.Postfix_part_decreaseContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#postfix_part}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitPostfix_part(@NotNull WorkflowParser.Postfix_partContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#ref_workflow}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitRef_workflow(@NotNull WorkflowParser.Ref_workflowContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#option}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitOption(@NotNull WorkflowParser.OptionContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#form}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitForm(@NotNull WorkflowParser.FormContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#translation_statement}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitTranslation_statement(@NotNull WorkflowParser.Translation_statementContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#init}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitInit(@NotNull WorkflowParser.InitContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#execute_line}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitExecute_line(@NotNull WorkflowParser.Execute_lineContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#exclusive_or_expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitExclusive_or_expression(@NotNull WorkflowParser.Exclusive_or_expressionContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#unary_expression_two_char}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitUnary_expression_two_char(@NotNull WorkflowParser.Unary_expression_two_charContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#declare_statement}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitDeclare_statement(@NotNull WorkflowParser.Declare_statementContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#declare}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitDeclare(@NotNull WorkflowParser.DeclareContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#long_name2}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitLong_name2(@NotNull WorkflowParser.Long_name2Context ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#attribute_value}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAttribute_value(@NotNull WorkflowParser.Attribute_valueContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#statement}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitStatement(@NotNull WorkflowParser.StatementContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#logical_and_expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitLogical_and_expression(@NotNull WorkflowParser.Logical_and_expressionContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#node}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitNode(@NotNull WorkflowParser.NodeContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#variable_name}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitVariable_name(@NotNull WorkflowParser.Variable_nameContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#additive_expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAdditive_expression(@NotNull WorkflowParser.Additive_expressionContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#option_list}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitOption_list(@NotNull WorkflowParser.Option_listContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#lvalue}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitLvalue(@NotNull WorkflowParser.LvalueContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#unary_operator}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitUnary_operator(@NotNull WorkflowParser.Unary_operatorContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#shift_expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitShift_expression(@NotNull WorkflowParser.Shift_expressionContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#program}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitProgram(@NotNull WorkflowParser.ProgramContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#logical_or_expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitLogical_or_expression(@NotNull WorkflowParser.Logical_or_expressionContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#clz}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitClz(@NotNull WorkflowParser.ClzContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#generic_type}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitGeneric_type(@NotNull WorkflowParser.Generic_typeContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#breakStatement}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitBreakStatement(@NotNull WorkflowParser.BreakStatementContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#unary_expression_operator}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitUnary_expression_operator(@NotNull WorkflowParser.Unary_expression_operatorContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#argument_expression_list}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitArgument_expression_list(@NotNull WorkflowParser.Argument_expression_listContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#inclusive_or_expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitInclusive_or_expression(@NotNull WorkflowParser.Inclusive_or_expressionContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#translation}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitTranslation(@NotNull WorkflowParser.TranslationContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#forStatement}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitForStatement(@NotNull WorkflowParser.ForStatementContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#doWhileStatement}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitDoWhileStatement(@NotNull WorkflowParser.DoWhileStatementContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#before}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitBefore(@NotNull WorkflowParser.BeforeContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#forEachStatement}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitForEachStatement(@NotNull WorkflowParser.ForEachStatementContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#constant_expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitConstant_expression(@NotNull WorkflowParser.Constant_expressionContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#state}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitState(@NotNull WorkflowParser.StateContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#attribute}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAttribute(@NotNull WorkflowParser.AttributeContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#shift_expression_operator}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitShift_expression_operator(@NotNull WorkflowParser.Shift_expression_operatorContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#relational_expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitRelational_expression(@NotNull WorkflowParser.Relational_expressionContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#multiplicative_expression_operator}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitMultiplicative_expression_operator(@NotNull WorkflowParser.Multiplicative_expression_operatorContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#creator}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitCreator(@NotNull WorkflowParser.CreatorContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#postfix_part_function}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitPostfix_part_function(@NotNull WorkflowParser.Postfix_part_functionContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#relational_expression_operator}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitRelational_expression_operator(@NotNull WorkflowParser.Relational_expression_operatorContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#postfix_part_index}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitPostfix_part_index(@NotNull WorkflowParser.Postfix_part_indexContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#postfix_expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitPostfix_expression(@NotNull WorkflowParser.Postfix_expressionContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#long_name}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitLong_name(@NotNull WorkflowParser.Long_nameContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#assignment_operator}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAssignment_operator(@NotNull WorkflowParser.Assignment_operatorContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#caseExpression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitCaseExpression(@NotNull WorkflowParser.CaseExpressionContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#postfix_part_increase}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitPostfix_part_increase(@NotNull WorkflowParser.Postfix_part_increaseContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#unary_expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitUnary_expression(@NotNull WorkflowParser.Unary_expressionContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#parallel}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitParallel(@NotNull WorkflowParser.ParallelContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#constant}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitConstant(@NotNull WorkflowParser.ConstantContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#option_name}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitOption_name(@NotNull WorkflowParser.Option_nameContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#expression_statement}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitExpression_statement(@NotNull WorkflowParser.Expression_statementContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#continueStatement}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitContinueStatement(@NotNull WorkflowParser.ContinueStatementContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#ifStatement}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitIfStatement(@NotNull WorkflowParser.IfStatementContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#attribute_name}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAttribute_name(@NotNull WorkflowParser.Attribute_nameContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#field}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitField(@NotNull WorkflowParser.FieldContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#unit}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitUnit(@NotNull WorkflowParser.UnitContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#switchStatement}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitSwitchStatement(@NotNull WorkflowParser.SwitchStatementContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#conditional_expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitConditional_expression(@NotNull WorkflowParser.Conditional_expressionContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#and_expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAnd_expression(@NotNull WorkflowParser.And_expressionContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#primary_expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitPrimary_expression(@NotNull WorkflowParser.Primary_expressionContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#whileStatement}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitWhileStatement(@NotNull WorkflowParser.WhileStatementContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#option_value}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitOption_value(@NotNull WorkflowParser.Option_valueContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#gotoStatement}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitGotoStatement(@NotNull WorkflowParser.GotoStatementContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#additive_expression_operator}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAdditive_expression_operator(@NotNull WorkflowParser.Additive_expression_operatorContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#postfix_part_long_name}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitPostfix_part_long_name(@NotNull WorkflowParser.Postfix_part_long_nameContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#unary_expression_one_char}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitUnary_expression_one_char(@NotNull WorkflowParser.Unary_expression_one_charContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#user}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitUser(@NotNull WorkflowParser.UserContext ctx);

	/**
	 * Visit a parse tree produced by {@link WorkflowParser#variable}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitVariable(@NotNull WorkflowParser.VariableContext ctx);
}