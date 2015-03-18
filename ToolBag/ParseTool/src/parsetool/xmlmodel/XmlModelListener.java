// Generated from D:\workspace\20140311\ToolBag\ParseTool\src\parsetool\xmlmodel\XmlModel.g4 by ANTLR 4.1
package parsetool.xmlmodel;
import org.antlr.v4.runtime.misc.NotNull;
import org.antlr.v4.runtime.tree.ParseTreeListener;

/**
 * This interface defines a complete listener for a parse tree produced by
 * {@link XmlModelParser}.
 */
public interface XmlModelListener extends ParseTreeListener {
	/**
	 * Enter a parse tree produced by {@link XmlModelParser#generic}.
	 * @param ctx the parse tree
	 */
	void enterGeneric(@NotNull XmlModelParser.GenericContext ctx);
	/**
	 * Exit a parse tree produced by {@link XmlModelParser#generic}.
	 * @param ctx the parse tree
	 */
	void exitGeneric(@NotNull XmlModelParser.GenericContext ctx);

	/**
	 * Enter a parse tree produced by {@link XmlModelParser#element}.
	 * @param ctx the parse tree
	 */
	void enterElement(@NotNull XmlModelParser.ElementContext ctx);
	/**
	 * Exit a parse tree produced by {@link XmlModelParser#element}.
	 * @param ctx the parse tree
	 */
	void exitElement(@NotNull XmlModelParser.ElementContext ctx);

	/**
	 * Enter a parse tree produced by {@link XmlModelParser#using}.
	 * @param ctx the parse tree
	 */
	void enterUsing(@NotNull XmlModelParser.UsingContext ctx);
	/**
	 * Exit a parse tree produced by {@link XmlModelParser#using}.
	 * @param ctx the parse tree
	 */
	void exitUsing(@NotNull XmlModelParser.UsingContext ctx);

	/**
	 * Enter a parse tree produced by {@link XmlModelParser#clz_cons_rank}.
	 * @param ctx the parse tree
	 */
	void enterClz_cons_rank(@NotNull XmlModelParser.Clz_cons_rankContext ctx);
	/**
	 * Exit a parse tree produced by {@link XmlModelParser#clz_cons_rank}.
	 * @param ctx the parse tree
	 */
	void exitClz_cons_rank(@NotNull XmlModelParser.Clz_cons_rankContext ctx);

	/**
	 * Enter a parse tree produced by {@link XmlModelParser#attribute}.
	 * @param ctx the parse tree
	 */
	void enterAttribute(@NotNull XmlModelParser.AttributeContext ctx);
	/**
	 * Exit a parse tree produced by {@link XmlModelParser#attribute}.
	 * @param ctx the parse tree
	 */
	void exitAttribute(@NotNull XmlModelParser.AttributeContext ctx);

	/**
	 * Enter a parse tree produced by {@link XmlModelParser#namespace}.
	 * @param ctx the parse tree
	 */
	void enterNamespace(@NotNull XmlModelParser.NamespaceContext ctx);
	/**
	 * Exit a parse tree produced by {@link XmlModelParser#namespace}.
	 * @param ctx the parse tree
	 */
	void exitNamespace(@NotNull XmlModelParser.NamespaceContext ctx);

	/**
	 * Enter a parse tree produced by {@link XmlModelParser#attr_group_constraint}.
	 * @param ctx the parse tree
	 */
	void enterAttr_group_constraint(@NotNull XmlModelParser.Attr_group_constraintContext ctx);
	/**
	 * Exit a parse tree produced by {@link XmlModelParser#attr_group_constraint}.
	 * @param ctx the parse tree
	 */
	void exitAttr_group_constraint(@NotNull XmlModelParser.Attr_group_constraintContext ctx);

	/**
	 * Enter a parse tree produced by {@link XmlModelParser#field}.
	 * @param ctx the parse tree
	 */
	void enterField(@NotNull XmlModelParser.FieldContext ctx);
	/**
	 * Exit a parse tree produced by {@link XmlModelParser#field}.
	 * @param ctx the parse tree
	 */
	void exitField(@NotNull XmlModelParser.FieldContext ctx);

	/**
	 * Enter a parse tree produced by {@link XmlModelParser#attr_group}.
	 * @param ctx the parse tree
	 */
	void enterAttr_group(@NotNull XmlModelParser.Attr_groupContext ctx);
	/**
	 * Exit a parse tree produced by {@link XmlModelParser#attr_group}.
	 * @param ctx the parse tree
	 */
	void exitAttr_group(@NotNull XmlModelParser.Attr_groupContext ctx);

	/**
	 * Enter a parse tree produced by {@link XmlModelParser#group_cons_order}.
	 * @param ctx the parse tree
	 */
	void enterGroup_cons_order(@NotNull XmlModelParser.Group_cons_orderContext ctx);
	/**
	 * Exit a parse tree produced by {@link XmlModelParser#group_cons_order}.
	 * @param ctx the parse tree
	 */
	void exitGroup_cons_order(@NotNull XmlModelParser.Group_cons_orderContext ctx);

	/**
	 * Enter a parse tree produced by {@link XmlModelParser#long_name}.
	 * @param ctx the parse tree
	 */
	void enterLong_name(@NotNull XmlModelParser.Long_nameContext ctx);
	/**
	 * Exit a parse tree produced by {@link XmlModelParser#long_name}.
	 * @param ctx the parse tree
	 */
	void exitLong_name(@NotNull XmlModelParser.Long_nameContext ctx);

	/**
	 * Enter a parse tree produced by {@link XmlModelParser#program}.
	 * @param ctx the parse tree
	 */
	void enterProgram(@NotNull XmlModelParser.ProgramContext ctx);
	/**
	 * Exit a parse tree produced by {@link XmlModelParser#program}.
	 * @param ctx the parse tree
	 */
	void exitProgram(@NotNull XmlModelParser.ProgramContext ctx);

	/**
	 * Enter a parse tree produced by {@link XmlModelParser#default_value}.
	 * @param ctx the parse tree
	 */
	void enterDefault_value(@NotNull XmlModelParser.Default_valueContext ctx);
	/**
	 * Exit a parse tree produced by {@link XmlModelParser#default_value}.
	 * @param ctx the parse tree
	 */
	void exitDefault_value(@NotNull XmlModelParser.Default_valueContext ctx);

	/**
	 * Enter a parse tree produced by {@link XmlModelParser#field_group}.
	 * @param ctx the parse tree
	 */
	void enterField_group(@NotNull XmlModelParser.Field_groupContext ctx);
	/**
	 * Exit a parse tree produced by {@link XmlModelParser#field_group}.
	 * @param ctx the parse tree
	 */
	void exitField_group(@NotNull XmlModelParser.Field_groupContext ctx);
}