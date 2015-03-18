// Generated from D:\workspace\20140311\ToolBag\ParseTool\src\parsetool\xmlmodel\XmlModel.g4 by ANTLR 4.1
package parsetool.xmlmodel;
import org.antlr.v4.runtime.misc.NotNull;
import org.antlr.v4.runtime.tree.ParseTreeVisitor;

/**
 * This interface defines a complete generic visitor for a parse tree produced
 * by {@link XmlModelParser}.
 *
 * @param <T> The return type of the visit operation. Use {@link Void} for
 * operations with no return type.
 */
public interface XmlModelVisitor<T> extends ParseTreeVisitor<T> {
	/**
	 * Visit a parse tree produced by {@link XmlModelParser#generic}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitGeneric(@NotNull XmlModelParser.GenericContext ctx);

	/**
	 * Visit a parse tree produced by {@link XmlModelParser#element}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitElement(@NotNull XmlModelParser.ElementContext ctx);

	/**
	 * Visit a parse tree produced by {@link XmlModelParser#using}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitUsing(@NotNull XmlModelParser.UsingContext ctx);

	/**
	 * Visit a parse tree produced by {@link XmlModelParser#clz_cons_rank}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitClz_cons_rank(@NotNull XmlModelParser.Clz_cons_rankContext ctx);

	/**
	 * Visit a parse tree produced by {@link XmlModelParser#attribute}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAttribute(@NotNull XmlModelParser.AttributeContext ctx);

	/**
	 * Visit a parse tree produced by {@link XmlModelParser#namespace}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitNamespace(@NotNull XmlModelParser.NamespaceContext ctx);

	/**
	 * Visit a parse tree produced by {@link XmlModelParser#attr_group_constraint}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAttr_group_constraint(@NotNull XmlModelParser.Attr_group_constraintContext ctx);

	/**
	 * Visit a parse tree produced by {@link XmlModelParser#field}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitField(@NotNull XmlModelParser.FieldContext ctx);

	/**
	 * Visit a parse tree produced by {@link XmlModelParser#attr_group}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAttr_group(@NotNull XmlModelParser.Attr_groupContext ctx);

	/**
	 * Visit a parse tree produced by {@link XmlModelParser#group_cons_order}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitGroup_cons_order(@NotNull XmlModelParser.Group_cons_orderContext ctx);

	/**
	 * Visit a parse tree produced by {@link XmlModelParser#long_name}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitLong_name(@NotNull XmlModelParser.Long_nameContext ctx);

	/**
	 * Visit a parse tree produced by {@link XmlModelParser#program}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitProgram(@NotNull XmlModelParser.ProgramContext ctx);

	/**
	 * Visit a parse tree produced by {@link XmlModelParser#default_value}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitDefault_value(@NotNull XmlModelParser.Default_valueContext ctx);

	/**
	 * Visit a parse tree produced by {@link XmlModelParser#field_group}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitField_group(@NotNull XmlModelParser.Field_groupContext ctx);
}