// Generated from D:\workspace\20140311\ToolBag\ParseTool\src\parsetool\dataview\DataView.g4 by ANTLR 4.1
package parsetool.dataview;
import org.antlr.v4.runtime.misc.NotNull;
import org.antlr.v4.runtime.tree.ParseTreeVisitor;

/**
 * This interface defines a complete generic visitor for a parse tree produced
 * by {@link DataViewParser}.
 *
 * @param <T> The return type of the visit operation. Use {@link Void} for
 * operations with no return type.
 */
public interface DataViewVisitor<T> extends ParseTreeVisitor<T> {
	/**
	 * Visit a parse tree produced by {@link DataViewParser#condition_clause_prior}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitCondition_clause_prior(@NotNull DataViewParser.Condition_clause_priorContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#inner_join}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitInner_join(@NotNull DataViewParser.Inner_joinContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#multiplicative_expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitMultiplicative_expression(@NotNull DataViewParser.Multiplicative_expressionContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#union_type}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitUnion_type(@NotNull DataViewParser.Union_typeContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#binary_prior}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitBinary_prior(@NotNull DataViewParser.Binary_priorContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#case_have_target_expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitCase_have_target_expression(@NotNull DataViewParser.Case_have_target_expressionContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#in_keyword}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitIn_keyword(@NotNull DataViewParser.In_keywordContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#value_list}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitValue_list(@NotNull DataViewParser.Value_listContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#result_expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitResult_expression(@NotNull DataViewParser.Result_expressionContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#case_else_expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitCase_else_expression(@NotNull DataViewParser.Case_else_expressionContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#case_clause_field}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitCase_clause_field(@NotNull DataViewParser.Case_clause_fieldContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#binary_compare}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitBinary_compare(@NotNull DataViewParser.Binary_compareContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#search_option}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitSearch_option(@NotNull DataViewParser.Search_optionContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#value}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitValue(@NotNull DataViewParser.ValueContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#parameter_name}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitParameter_name(@NotNull DataViewParser.Parameter_nameContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#compare_complex_prior}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitCompare_complex_prior(@NotNull DataViewParser.Compare_complex_priorContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#predication}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitPredication(@NotNull DataViewParser.PredicationContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#option}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitOption(@NotNull DataViewParser.OptionContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#condition_clause}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitCondition_clause(@NotNull DataViewParser.Condition_clauseContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#group_clause_full}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitGroup_clause_full(@NotNull DataViewParser.Group_clause_fullContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#select_clause}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitSelect_clause(@NotNull DataViewParser.Select_clauseContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#select}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitSelect(@NotNull DataViewParser.SelectContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#top_clause}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitTop_clause(@NotNull DataViewParser.Top_clauseContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#case_when_expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitCase_when_expression(@NotNull DataViewParser.Case_when_expressionContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#order_expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitOrder_expression(@NotNull DataViewParser.Order_expressionContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#table}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitTable(@NotNull DataViewParser.TableContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#select_alias}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitSelect_alias(@NotNull DataViewParser.Select_aliasContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#select_clause_full}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitSelect_clause_full(@NotNull DataViewParser.Select_clause_fullContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#option_list}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitOption_list(@NotNull DataViewParser.Option_listContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#option_expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitOption_expression(@NotNull DataViewParser.Option_expressionContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#from_clause}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitFrom_clause(@NotNull DataViewParser.From_clauseContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#unary_operator}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitUnary_operator(@NotNull DataViewParser.Unary_operatorContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#program}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitProgram(@NotNull DataViewParser.ProgramContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#table_field}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitTable_field(@NotNull DataViewParser.Table_fieldContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#condition_clause_full}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitCondition_clause_full(@NotNull DataViewParser.Condition_clause_fullContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#compare_complex}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitCompare_complex(@NotNull DataViewParser.Compare_complexContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#compare_complex_mix_and}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitCompare_complex_mix_and(@NotNull DataViewParser.Compare_complex_mix_andContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#binary_operater}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitBinary_operater(@NotNull DataViewParser.Binary_operaterContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#join_clause_full}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitJoin_clause_full(@NotNull DataViewParser.Join_clause_fullContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#having_clause_full}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitHaving_clause_full(@NotNull DataViewParser.Having_clause_fullContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#case_clause_prior}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitCase_clause_prior(@NotNull DataViewParser.Case_clause_priorContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#table_alias}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitTable_alias(@NotNull DataViewParser.Table_aliasContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#function_parameter}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitFunction_parameter(@NotNull DataViewParser.Function_parameterContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#parameter_options}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitParameter_options(@NotNull DataViewParser.Parameter_optionsContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#table_field_alias}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitTable_field_alias(@NotNull DataViewParser.Table_field_aliasContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#from_clause_full}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitFrom_clause_full(@NotNull DataViewParser.From_clause_fullContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#order_clause}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitOrder_clause(@NotNull DataViewParser.Order_clauseContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#binary}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitBinary(@NotNull DataViewParser.BinaryContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#in_expression_prior}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitIn_expression_prior(@NotNull DataViewParser.In_expression_priorContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#order_clause_full}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitOrder_clause_full(@NotNull DataViewParser.Order_clause_fullContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#join_on_clause}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitJoin_on_clause(@NotNull DataViewParser.Join_on_clauseContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#right_outer_join}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitRight_outer_join(@NotNull DataViewParser.Right_outer_joinContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#case_have_target_when_expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitCase_have_target_when_expression(@NotNull DataViewParser.Case_have_target_when_expressionContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#select_atom}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitSelect_atom(@NotNull DataViewParser.Select_atomContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#between_prior}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitBetween_prior(@NotNull DataViewParser.Between_priorContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#positive_expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitPositive_expression(@NotNull DataViewParser.Positive_expressionContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#parameter}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitParameter(@NotNull DataViewParser.ParameterContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#having_clause}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitHaving_clause(@NotNull DataViewParser.Having_clauseContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#long_name}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitLong_name(@NotNull DataViewParser.Long_nameContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#result_expression_prior}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitResult_expression_prior(@NotNull DataViewParser.Result_expression_priorContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#function_parameter_list}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitFunction_parameter_list(@NotNull DataViewParser.Function_parameter_listContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#binary_expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitBinary_expression(@NotNull DataViewParser.Binary_expressionContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#existed_compare}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitExisted_compare(@NotNull DataViewParser.Existed_compareContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#field_regular}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitField_regular(@NotNull DataViewParser.Field_regularContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#condition_option}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitCondition_option(@NotNull DataViewParser.Condition_optionContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#between}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitBetween(@NotNull DataViewParser.BetweenContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#all_join}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAll_join(@NotNull DataViewParser.All_joinContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#left_join}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitLeft_join(@NotNull DataViewParser.Left_joinContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#left_outer_join}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitLeft_outer_join(@NotNull DataViewParser.Left_outer_joinContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#existed_compare_prior}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitExisted_compare_prior(@NotNull DataViewParser.Existed_compare_priorContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#in_right_value}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitIn_right_value(@NotNull DataViewParser.In_right_valueContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#in_expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitIn_expression(@NotNull DataViewParser.In_expressionContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#option_name}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitOption_name(@NotNull DataViewParser.Option_nameContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#case_clause}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitCase_clause(@NotNull DataViewParser.Case_clauseContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#join}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitJoin(@NotNull DataViewParser.JoinContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#right_join}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitRight_join(@NotNull DataViewParser.Right_joinContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#binary_compare_prior}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitBinary_compare_prior(@NotNull DataViewParser.Binary_compare_priorContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#table_field_atom}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitTable_field_atom(@NotNull DataViewParser.Table_field_atomContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#function_field}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitFunction_field(@NotNull DataViewParser.Function_fieldContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#join_clause}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitJoin_clause(@NotNull DataViewParser.Join_clauseContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#case_expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitCase_expression(@NotNull DataViewParser.Case_expressionContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#select_list}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitSelect_list(@NotNull DataViewParser.Select_listContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#in_list}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitIn_list(@NotNull DataViewParser.In_listContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#option_value}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitOption_value(@NotNull DataViewParser.Option_valueContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#group_clause}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitGroup_clause(@NotNull DataViewParser.Group_clauseContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#compare_complex_mix_or}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitCompare_complex_mix_or(@NotNull DataViewParser.Compare_complex_mix_orContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataViewParser#all_field}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAll_field(@NotNull DataViewParser.All_fieldContext ctx);
}