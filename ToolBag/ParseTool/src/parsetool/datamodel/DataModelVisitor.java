// Generated from D:\workspace\20140311\ToolBag\ParseTool\src\parsetool\datamodel\DataModel.g4 by ANTLR 4.1
package parsetool.datamodel;
import org.antlr.v4.runtime.misc.NotNull;
import org.antlr.v4.runtime.tree.ParseTreeVisitor;

/**
 * This interface defines a complete generic visitor for a parse tree produced
 * by {@link DataModelParser}.
 *
 * @param <T> The return type of the visit operation. Use {@link Void} for
 * operations with no return type.
 */
public interface DataModelVisitor<T> extends ParseTreeVisitor<T> {
	/**
	 * Visit a parse tree produced by {@link DataModelParser#db_type}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitDb_type(@NotNull DataModelParser.Db_typeContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataModelParser#using}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitUsing(@NotNull DataModelParser.UsingContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataModelParser#model}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitModel(@NotNull DataModelParser.ModelContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataModelParser#relation}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitRelation(@NotNull DataModelParser.RelationContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataModelParser#attribute}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAttribute(@NotNull DataModelParser.AttributeContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataModelParser#split_tag}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitSplit_tag(@NotNull DataModelParser.Split_tagContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataModelParser#mapping}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitMapping(@NotNull DataModelParser.MappingContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataModelParser#namespace}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitNamespace(@NotNull DataModelParser.NamespaceContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataModelParser#field}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitField(@NotNull DataModelParser.FieldContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataModelParser#system_type}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitSystem_type(@NotNull DataModelParser.System_typeContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataModelParser#is_pk}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitIs_pk(@NotNull DataModelParser.Is_pkContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataModelParser#long_name}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitLong_name(@NotNull DataModelParser.Long_nameContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataModelParser#program}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitProgram(@NotNull DataModelParser.ProgramContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataModelParser#is_null}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitIs_null(@NotNull DataModelParser.Is_nullContext ctx);

	/**
	 * Visit a parse tree produced by {@link DataModelParser#filed_define}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitFiled_define(@NotNull DataModelParser.Filed_defineContext ctx);
}