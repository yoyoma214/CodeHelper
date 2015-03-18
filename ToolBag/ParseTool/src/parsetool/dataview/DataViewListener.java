// Generated from D:\workspace\20140311\ToolBag\ParseTool\src\parsetool\dataview\DataView.g4 by ANTLR 4.1
package parsetool.dataview;
import org.antlr.v4.runtime.misc.NotNull;
import org.antlr.v4.runtime.tree.ParseTreeListener;

/**
 * This interface defines a complete listener for a parse tree produced by
 * {@link DataViewParser}.
 */
public interface DataViewListener extends ParseTreeListener {
	/**
	 * Enter a parse tree produced by {@link DataViewParser#condition_clause_prior}.
	 * @param ctx the parse tree
	 */
	void enterCondition_clause_prior(@NotNull DataViewParser.Condition_clause_priorContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#condition_clause_prior}.
	 * @param ctx the parse tree
	 */
	void exitCondition_clause_prior(@NotNull DataViewParser.Condition_clause_priorContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#inner_join}.
	 * @param ctx the parse tree
	 */
	void enterInner_join(@NotNull DataViewParser.Inner_joinContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#inner_join}.
	 * @param ctx the parse tree
	 */
	void exitInner_join(@NotNull DataViewParser.Inner_joinContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#multiplicative_expression}.
	 * @param ctx the parse tree
	 */
	void enterMultiplicative_expression(@NotNull DataViewParser.Multiplicative_expressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#multiplicative_expression}.
	 * @param ctx the parse tree
	 */
	void exitMultiplicative_expression(@NotNull DataViewParser.Multiplicative_expressionContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#union_type}.
	 * @param ctx the parse tree
	 */
	void enterUnion_type(@NotNull DataViewParser.Union_typeContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#union_type}.
	 * @param ctx the parse tree
	 */
	void exitUnion_type(@NotNull DataViewParser.Union_typeContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#binary_prior}.
	 * @param ctx the parse tree
	 */
	void enterBinary_prior(@NotNull DataViewParser.Binary_priorContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#binary_prior}.
	 * @param ctx the parse tree
	 */
	void exitBinary_prior(@NotNull DataViewParser.Binary_priorContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#case_have_target_expression}.
	 * @param ctx the parse tree
	 */
	void enterCase_have_target_expression(@NotNull DataViewParser.Case_have_target_expressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#case_have_target_expression}.
	 * @param ctx the parse tree
	 */
	void exitCase_have_target_expression(@NotNull DataViewParser.Case_have_target_expressionContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#in_keyword}.
	 * @param ctx the parse tree
	 */
	void enterIn_keyword(@NotNull DataViewParser.In_keywordContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#in_keyword}.
	 * @param ctx the parse tree
	 */
	void exitIn_keyword(@NotNull DataViewParser.In_keywordContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#value_list}.
	 * @param ctx the parse tree
	 */
	void enterValue_list(@NotNull DataViewParser.Value_listContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#value_list}.
	 * @param ctx the parse tree
	 */
	void exitValue_list(@NotNull DataViewParser.Value_listContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#result_expression}.
	 * @param ctx the parse tree
	 */
	void enterResult_expression(@NotNull DataViewParser.Result_expressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#result_expression}.
	 * @param ctx the parse tree
	 */
	void exitResult_expression(@NotNull DataViewParser.Result_expressionContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#case_else_expression}.
	 * @param ctx the parse tree
	 */
	void enterCase_else_expression(@NotNull DataViewParser.Case_else_expressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#case_else_expression}.
	 * @param ctx the parse tree
	 */
	void exitCase_else_expression(@NotNull DataViewParser.Case_else_expressionContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#case_clause_field}.
	 * @param ctx the parse tree
	 */
	void enterCase_clause_field(@NotNull DataViewParser.Case_clause_fieldContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#case_clause_field}.
	 * @param ctx the parse tree
	 */
	void exitCase_clause_field(@NotNull DataViewParser.Case_clause_fieldContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#binary_compare}.
	 * @param ctx the parse tree
	 */
	void enterBinary_compare(@NotNull DataViewParser.Binary_compareContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#binary_compare}.
	 * @param ctx the parse tree
	 */
	void exitBinary_compare(@NotNull DataViewParser.Binary_compareContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#search_option}.
	 * @param ctx the parse tree
	 */
	void enterSearch_option(@NotNull DataViewParser.Search_optionContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#search_option}.
	 * @param ctx the parse tree
	 */
	void exitSearch_option(@NotNull DataViewParser.Search_optionContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#value}.
	 * @param ctx the parse tree
	 */
	void enterValue(@NotNull DataViewParser.ValueContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#value}.
	 * @param ctx the parse tree
	 */
	void exitValue(@NotNull DataViewParser.ValueContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#parameter_name}.
	 * @param ctx the parse tree
	 */
	void enterParameter_name(@NotNull DataViewParser.Parameter_nameContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#parameter_name}.
	 * @param ctx the parse tree
	 */
	void exitParameter_name(@NotNull DataViewParser.Parameter_nameContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#compare_complex_prior}.
	 * @param ctx the parse tree
	 */
	void enterCompare_complex_prior(@NotNull DataViewParser.Compare_complex_priorContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#compare_complex_prior}.
	 * @param ctx the parse tree
	 */
	void exitCompare_complex_prior(@NotNull DataViewParser.Compare_complex_priorContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#predication}.
	 * @param ctx the parse tree
	 */
	void enterPredication(@NotNull DataViewParser.PredicationContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#predication}.
	 * @param ctx the parse tree
	 */
	void exitPredication(@NotNull DataViewParser.PredicationContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#option}.
	 * @param ctx the parse tree
	 */
	void enterOption(@NotNull DataViewParser.OptionContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#option}.
	 * @param ctx the parse tree
	 */
	void exitOption(@NotNull DataViewParser.OptionContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#condition_clause}.
	 * @param ctx the parse tree
	 */
	void enterCondition_clause(@NotNull DataViewParser.Condition_clauseContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#condition_clause}.
	 * @param ctx the parse tree
	 */
	void exitCondition_clause(@NotNull DataViewParser.Condition_clauseContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#group_clause_full}.
	 * @param ctx the parse tree
	 */
	void enterGroup_clause_full(@NotNull DataViewParser.Group_clause_fullContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#group_clause_full}.
	 * @param ctx the parse tree
	 */
	void exitGroup_clause_full(@NotNull DataViewParser.Group_clause_fullContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#select_clause}.
	 * @param ctx the parse tree
	 */
	void enterSelect_clause(@NotNull DataViewParser.Select_clauseContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#select_clause}.
	 * @param ctx the parse tree
	 */
	void exitSelect_clause(@NotNull DataViewParser.Select_clauseContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#select}.
	 * @param ctx the parse tree
	 */
	void enterSelect(@NotNull DataViewParser.SelectContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#select}.
	 * @param ctx the parse tree
	 */
	void exitSelect(@NotNull DataViewParser.SelectContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#top_clause}.
	 * @param ctx the parse tree
	 */
	void enterTop_clause(@NotNull DataViewParser.Top_clauseContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#top_clause}.
	 * @param ctx the parse tree
	 */
	void exitTop_clause(@NotNull DataViewParser.Top_clauseContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#case_when_expression}.
	 * @param ctx the parse tree
	 */
	void enterCase_when_expression(@NotNull DataViewParser.Case_when_expressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#case_when_expression}.
	 * @param ctx the parse tree
	 */
	void exitCase_when_expression(@NotNull DataViewParser.Case_when_expressionContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#order_expression}.
	 * @param ctx the parse tree
	 */
	void enterOrder_expression(@NotNull DataViewParser.Order_expressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#order_expression}.
	 * @param ctx the parse tree
	 */
	void exitOrder_expression(@NotNull DataViewParser.Order_expressionContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#table}.
	 * @param ctx the parse tree
	 */
	void enterTable(@NotNull DataViewParser.TableContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#table}.
	 * @param ctx the parse tree
	 */
	void exitTable(@NotNull DataViewParser.TableContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#select_alias}.
	 * @param ctx the parse tree
	 */
	void enterSelect_alias(@NotNull DataViewParser.Select_aliasContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#select_alias}.
	 * @param ctx the parse tree
	 */
	void exitSelect_alias(@NotNull DataViewParser.Select_aliasContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#select_clause_full}.
	 * @param ctx the parse tree
	 */
	void enterSelect_clause_full(@NotNull DataViewParser.Select_clause_fullContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#select_clause_full}.
	 * @param ctx the parse tree
	 */
	void exitSelect_clause_full(@NotNull DataViewParser.Select_clause_fullContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#option_list}.
	 * @param ctx the parse tree
	 */
	void enterOption_list(@NotNull DataViewParser.Option_listContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#option_list}.
	 * @param ctx the parse tree
	 */
	void exitOption_list(@NotNull DataViewParser.Option_listContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#option_expression}.
	 * @param ctx the parse tree
	 */
	void enterOption_expression(@NotNull DataViewParser.Option_expressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#option_expression}.
	 * @param ctx the parse tree
	 */
	void exitOption_expression(@NotNull DataViewParser.Option_expressionContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#from_clause}.
	 * @param ctx the parse tree
	 */
	void enterFrom_clause(@NotNull DataViewParser.From_clauseContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#from_clause}.
	 * @param ctx the parse tree
	 */
	void exitFrom_clause(@NotNull DataViewParser.From_clauseContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#unary_operator}.
	 * @param ctx the parse tree
	 */
	void enterUnary_operator(@NotNull DataViewParser.Unary_operatorContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#unary_operator}.
	 * @param ctx the parse tree
	 */
	void exitUnary_operator(@NotNull DataViewParser.Unary_operatorContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#program}.
	 * @param ctx the parse tree
	 */
	void enterProgram(@NotNull DataViewParser.ProgramContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#program}.
	 * @param ctx the parse tree
	 */
	void exitProgram(@NotNull DataViewParser.ProgramContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#table_field}.
	 * @param ctx the parse tree
	 */
	void enterTable_field(@NotNull DataViewParser.Table_fieldContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#table_field}.
	 * @param ctx the parse tree
	 */
	void exitTable_field(@NotNull DataViewParser.Table_fieldContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#condition_clause_full}.
	 * @param ctx the parse tree
	 */
	void enterCondition_clause_full(@NotNull DataViewParser.Condition_clause_fullContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#condition_clause_full}.
	 * @param ctx the parse tree
	 */
	void exitCondition_clause_full(@NotNull DataViewParser.Condition_clause_fullContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#compare_complex}.
	 * @param ctx the parse tree
	 */
	void enterCompare_complex(@NotNull DataViewParser.Compare_complexContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#compare_complex}.
	 * @param ctx the parse tree
	 */
	void exitCompare_complex(@NotNull DataViewParser.Compare_complexContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#compare_complex_mix_and}.
	 * @param ctx the parse tree
	 */
	void enterCompare_complex_mix_and(@NotNull DataViewParser.Compare_complex_mix_andContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#compare_complex_mix_and}.
	 * @param ctx the parse tree
	 */
	void exitCompare_complex_mix_and(@NotNull DataViewParser.Compare_complex_mix_andContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#binary_operater}.
	 * @param ctx the parse tree
	 */
	void enterBinary_operater(@NotNull DataViewParser.Binary_operaterContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#binary_operater}.
	 * @param ctx the parse tree
	 */
	void exitBinary_operater(@NotNull DataViewParser.Binary_operaterContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#join_clause_full}.
	 * @param ctx the parse tree
	 */
	void enterJoin_clause_full(@NotNull DataViewParser.Join_clause_fullContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#join_clause_full}.
	 * @param ctx the parse tree
	 */
	void exitJoin_clause_full(@NotNull DataViewParser.Join_clause_fullContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#having_clause_full}.
	 * @param ctx the parse tree
	 */
	void enterHaving_clause_full(@NotNull DataViewParser.Having_clause_fullContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#having_clause_full}.
	 * @param ctx the parse tree
	 */
	void exitHaving_clause_full(@NotNull DataViewParser.Having_clause_fullContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#case_clause_prior}.
	 * @param ctx the parse tree
	 */
	void enterCase_clause_prior(@NotNull DataViewParser.Case_clause_priorContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#case_clause_prior}.
	 * @param ctx the parse tree
	 */
	void exitCase_clause_prior(@NotNull DataViewParser.Case_clause_priorContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#table_alias}.
	 * @param ctx the parse tree
	 */
	void enterTable_alias(@NotNull DataViewParser.Table_aliasContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#table_alias}.
	 * @param ctx the parse tree
	 */
	void exitTable_alias(@NotNull DataViewParser.Table_aliasContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#function_parameter}.
	 * @param ctx the parse tree
	 */
	void enterFunction_parameter(@NotNull DataViewParser.Function_parameterContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#function_parameter}.
	 * @param ctx the parse tree
	 */
	void exitFunction_parameter(@NotNull DataViewParser.Function_parameterContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#parameter_options}.
	 * @param ctx the parse tree
	 */
	void enterParameter_options(@NotNull DataViewParser.Parameter_optionsContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#parameter_options}.
	 * @param ctx the parse tree
	 */
	void exitParameter_options(@NotNull DataViewParser.Parameter_optionsContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#table_field_alias}.
	 * @param ctx the parse tree
	 */
	void enterTable_field_alias(@NotNull DataViewParser.Table_field_aliasContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#table_field_alias}.
	 * @param ctx the parse tree
	 */
	void exitTable_field_alias(@NotNull DataViewParser.Table_field_aliasContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#from_clause_full}.
	 * @param ctx the parse tree
	 */
	void enterFrom_clause_full(@NotNull DataViewParser.From_clause_fullContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#from_clause_full}.
	 * @param ctx the parse tree
	 */
	void exitFrom_clause_full(@NotNull DataViewParser.From_clause_fullContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#order_clause}.
	 * @param ctx the parse tree
	 */
	void enterOrder_clause(@NotNull DataViewParser.Order_clauseContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#order_clause}.
	 * @param ctx the parse tree
	 */
	void exitOrder_clause(@NotNull DataViewParser.Order_clauseContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#binary}.
	 * @param ctx the parse tree
	 */
	void enterBinary(@NotNull DataViewParser.BinaryContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#binary}.
	 * @param ctx the parse tree
	 */
	void exitBinary(@NotNull DataViewParser.BinaryContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#in_expression_prior}.
	 * @param ctx the parse tree
	 */
	void enterIn_expression_prior(@NotNull DataViewParser.In_expression_priorContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#in_expression_prior}.
	 * @param ctx the parse tree
	 */
	void exitIn_expression_prior(@NotNull DataViewParser.In_expression_priorContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#order_clause_full}.
	 * @param ctx the parse tree
	 */
	void enterOrder_clause_full(@NotNull DataViewParser.Order_clause_fullContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#order_clause_full}.
	 * @param ctx the parse tree
	 */
	void exitOrder_clause_full(@NotNull DataViewParser.Order_clause_fullContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#join_on_clause}.
	 * @param ctx the parse tree
	 */
	void enterJoin_on_clause(@NotNull DataViewParser.Join_on_clauseContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#join_on_clause}.
	 * @param ctx the parse tree
	 */
	void exitJoin_on_clause(@NotNull DataViewParser.Join_on_clauseContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#right_outer_join}.
	 * @param ctx the parse tree
	 */
	void enterRight_outer_join(@NotNull DataViewParser.Right_outer_joinContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#right_outer_join}.
	 * @param ctx the parse tree
	 */
	void exitRight_outer_join(@NotNull DataViewParser.Right_outer_joinContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#case_have_target_when_expression}.
	 * @param ctx the parse tree
	 */
	void enterCase_have_target_when_expression(@NotNull DataViewParser.Case_have_target_when_expressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#case_have_target_when_expression}.
	 * @param ctx the parse tree
	 */
	void exitCase_have_target_when_expression(@NotNull DataViewParser.Case_have_target_when_expressionContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#select_atom}.
	 * @param ctx the parse tree
	 */
	void enterSelect_atom(@NotNull DataViewParser.Select_atomContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#select_atom}.
	 * @param ctx the parse tree
	 */
	void exitSelect_atom(@NotNull DataViewParser.Select_atomContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#between_prior}.
	 * @param ctx the parse tree
	 */
	void enterBetween_prior(@NotNull DataViewParser.Between_priorContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#between_prior}.
	 * @param ctx the parse tree
	 */
	void exitBetween_prior(@NotNull DataViewParser.Between_priorContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#positive_expression}.
	 * @param ctx the parse tree
	 */
	void enterPositive_expression(@NotNull DataViewParser.Positive_expressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#positive_expression}.
	 * @param ctx the parse tree
	 */
	void exitPositive_expression(@NotNull DataViewParser.Positive_expressionContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#parameter}.
	 * @param ctx the parse tree
	 */
	void enterParameter(@NotNull DataViewParser.ParameterContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#parameter}.
	 * @param ctx the parse tree
	 */
	void exitParameter(@NotNull DataViewParser.ParameterContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#having_clause}.
	 * @param ctx the parse tree
	 */
	void enterHaving_clause(@NotNull DataViewParser.Having_clauseContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#having_clause}.
	 * @param ctx the parse tree
	 */
	void exitHaving_clause(@NotNull DataViewParser.Having_clauseContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#long_name}.
	 * @param ctx the parse tree
	 */
	void enterLong_name(@NotNull DataViewParser.Long_nameContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#long_name}.
	 * @param ctx the parse tree
	 */
	void exitLong_name(@NotNull DataViewParser.Long_nameContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#result_expression_prior}.
	 * @param ctx the parse tree
	 */
	void enterResult_expression_prior(@NotNull DataViewParser.Result_expression_priorContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#result_expression_prior}.
	 * @param ctx the parse tree
	 */
	void exitResult_expression_prior(@NotNull DataViewParser.Result_expression_priorContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#function_parameter_list}.
	 * @param ctx the parse tree
	 */
	void enterFunction_parameter_list(@NotNull DataViewParser.Function_parameter_listContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#function_parameter_list}.
	 * @param ctx the parse tree
	 */
	void exitFunction_parameter_list(@NotNull DataViewParser.Function_parameter_listContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#binary_expression}.
	 * @param ctx the parse tree
	 */
	void enterBinary_expression(@NotNull DataViewParser.Binary_expressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#binary_expression}.
	 * @param ctx the parse tree
	 */
	void exitBinary_expression(@NotNull DataViewParser.Binary_expressionContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#existed_compare}.
	 * @param ctx the parse tree
	 */
	void enterExisted_compare(@NotNull DataViewParser.Existed_compareContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#existed_compare}.
	 * @param ctx the parse tree
	 */
	void exitExisted_compare(@NotNull DataViewParser.Existed_compareContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#field_regular}.
	 * @param ctx the parse tree
	 */
	void enterField_regular(@NotNull DataViewParser.Field_regularContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#field_regular}.
	 * @param ctx the parse tree
	 */
	void exitField_regular(@NotNull DataViewParser.Field_regularContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#condition_option}.
	 * @param ctx the parse tree
	 */
	void enterCondition_option(@NotNull DataViewParser.Condition_optionContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#condition_option}.
	 * @param ctx the parse tree
	 */
	void exitCondition_option(@NotNull DataViewParser.Condition_optionContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#between}.
	 * @param ctx the parse tree
	 */
	void enterBetween(@NotNull DataViewParser.BetweenContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#between}.
	 * @param ctx the parse tree
	 */
	void exitBetween(@NotNull DataViewParser.BetweenContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#all_join}.
	 * @param ctx the parse tree
	 */
	void enterAll_join(@NotNull DataViewParser.All_joinContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#all_join}.
	 * @param ctx the parse tree
	 */
	void exitAll_join(@NotNull DataViewParser.All_joinContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#left_join}.
	 * @param ctx the parse tree
	 */
	void enterLeft_join(@NotNull DataViewParser.Left_joinContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#left_join}.
	 * @param ctx the parse tree
	 */
	void exitLeft_join(@NotNull DataViewParser.Left_joinContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#left_outer_join}.
	 * @param ctx the parse tree
	 */
	void enterLeft_outer_join(@NotNull DataViewParser.Left_outer_joinContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#left_outer_join}.
	 * @param ctx the parse tree
	 */
	void exitLeft_outer_join(@NotNull DataViewParser.Left_outer_joinContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#existed_compare_prior}.
	 * @param ctx the parse tree
	 */
	void enterExisted_compare_prior(@NotNull DataViewParser.Existed_compare_priorContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#existed_compare_prior}.
	 * @param ctx the parse tree
	 */
	void exitExisted_compare_prior(@NotNull DataViewParser.Existed_compare_priorContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#in_right_value}.
	 * @param ctx the parse tree
	 */
	void enterIn_right_value(@NotNull DataViewParser.In_right_valueContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#in_right_value}.
	 * @param ctx the parse tree
	 */
	void exitIn_right_value(@NotNull DataViewParser.In_right_valueContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#in_expression}.
	 * @param ctx the parse tree
	 */
	void enterIn_expression(@NotNull DataViewParser.In_expressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#in_expression}.
	 * @param ctx the parse tree
	 */
	void exitIn_expression(@NotNull DataViewParser.In_expressionContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#option_name}.
	 * @param ctx the parse tree
	 */
	void enterOption_name(@NotNull DataViewParser.Option_nameContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#option_name}.
	 * @param ctx the parse tree
	 */
	void exitOption_name(@NotNull DataViewParser.Option_nameContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#case_clause}.
	 * @param ctx the parse tree
	 */
	void enterCase_clause(@NotNull DataViewParser.Case_clauseContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#case_clause}.
	 * @param ctx the parse tree
	 */
	void exitCase_clause(@NotNull DataViewParser.Case_clauseContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#join}.
	 * @param ctx the parse tree
	 */
	void enterJoin(@NotNull DataViewParser.JoinContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#join}.
	 * @param ctx the parse tree
	 */
	void exitJoin(@NotNull DataViewParser.JoinContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#right_join}.
	 * @param ctx the parse tree
	 */
	void enterRight_join(@NotNull DataViewParser.Right_joinContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#right_join}.
	 * @param ctx the parse tree
	 */
	void exitRight_join(@NotNull DataViewParser.Right_joinContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#binary_compare_prior}.
	 * @param ctx the parse tree
	 */
	void enterBinary_compare_prior(@NotNull DataViewParser.Binary_compare_priorContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#binary_compare_prior}.
	 * @param ctx the parse tree
	 */
	void exitBinary_compare_prior(@NotNull DataViewParser.Binary_compare_priorContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#table_field_atom}.
	 * @param ctx the parse tree
	 */
	void enterTable_field_atom(@NotNull DataViewParser.Table_field_atomContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#table_field_atom}.
	 * @param ctx the parse tree
	 */
	void exitTable_field_atom(@NotNull DataViewParser.Table_field_atomContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#function_field}.
	 * @param ctx the parse tree
	 */
	void enterFunction_field(@NotNull DataViewParser.Function_fieldContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#function_field}.
	 * @param ctx the parse tree
	 */
	void exitFunction_field(@NotNull DataViewParser.Function_fieldContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#join_clause}.
	 * @param ctx the parse tree
	 */
	void enterJoin_clause(@NotNull DataViewParser.Join_clauseContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#join_clause}.
	 * @param ctx the parse tree
	 */
	void exitJoin_clause(@NotNull DataViewParser.Join_clauseContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#case_expression}.
	 * @param ctx the parse tree
	 */
	void enterCase_expression(@NotNull DataViewParser.Case_expressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#case_expression}.
	 * @param ctx the parse tree
	 */
	void exitCase_expression(@NotNull DataViewParser.Case_expressionContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#select_list}.
	 * @param ctx the parse tree
	 */
	void enterSelect_list(@NotNull DataViewParser.Select_listContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#select_list}.
	 * @param ctx the parse tree
	 */
	void exitSelect_list(@NotNull DataViewParser.Select_listContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#in_list}.
	 * @param ctx the parse tree
	 */
	void enterIn_list(@NotNull DataViewParser.In_listContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#in_list}.
	 * @param ctx the parse tree
	 */
	void exitIn_list(@NotNull DataViewParser.In_listContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#option_value}.
	 * @param ctx the parse tree
	 */
	void enterOption_value(@NotNull DataViewParser.Option_valueContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#option_value}.
	 * @param ctx the parse tree
	 */
	void exitOption_value(@NotNull DataViewParser.Option_valueContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#group_clause}.
	 * @param ctx the parse tree
	 */
	void enterGroup_clause(@NotNull DataViewParser.Group_clauseContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#group_clause}.
	 * @param ctx the parse tree
	 */
	void exitGroup_clause(@NotNull DataViewParser.Group_clauseContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#compare_complex_mix_or}.
	 * @param ctx the parse tree
	 */
	void enterCompare_complex_mix_or(@NotNull DataViewParser.Compare_complex_mix_orContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#compare_complex_mix_or}.
	 * @param ctx the parse tree
	 */
	void exitCompare_complex_mix_or(@NotNull DataViewParser.Compare_complex_mix_orContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataViewParser#all_field}.
	 * @param ctx the parse tree
	 */
	void enterAll_field(@NotNull DataViewParser.All_fieldContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataViewParser#all_field}.
	 * @param ctx the parse tree
	 */
	void exitAll_field(@NotNull DataViewParser.All_fieldContext ctx);
}