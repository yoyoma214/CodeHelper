// Generated from D:\workspace\20140311\ToolBag\ParseTool\src\parsetool\datamodel\DataModel.g4 by ANTLR 4.1
package parsetool.datamodel;
import org.antlr.v4.runtime.misc.NotNull;
import org.antlr.v4.runtime.tree.ParseTreeListener;

/**
 * This interface defines a complete listener for a parse tree produced by
 * {@link DataModelParser}.
 */
public interface DataModelListener extends ParseTreeListener {
	/**
	 * Enter a parse tree produced by {@link DataModelParser#db_type}.
	 * @param ctx the parse tree
	 */
	void enterDb_type(@NotNull DataModelParser.Db_typeContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataModelParser#db_type}.
	 * @param ctx the parse tree
	 */
	void exitDb_type(@NotNull DataModelParser.Db_typeContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataModelParser#using}.
	 * @param ctx the parse tree
	 */
	void enterUsing(@NotNull DataModelParser.UsingContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataModelParser#using}.
	 * @param ctx the parse tree
	 */
	void exitUsing(@NotNull DataModelParser.UsingContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataModelParser#model}.
	 * @param ctx the parse tree
	 */
	void enterModel(@NotNull DataModelParser.ModelContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataModelParser#model}.
	 * @param ctx the parse tree
	 */
	void exitModel(@NotNull DataModelParser.ModelContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataModelParser#relation}.
	 * @param ctx the parse tree
	 */
	void enterRelation(@NotNull DataModelParser.RelationContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataModelParser#relation}.
	 * @param ctx the parse tree
	 */
	void exitRelation(@NotNull DataModelParser.RelationContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataModelParser#attribute}.
	 * @param ctx the parse tree
	 */
	void enterAttribute(@NotNull DataModelParser.AttributeContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataModelParser#attribute}.
	 * @param ctx the parse tree
	 */
	void exitAttribute(@NotNull DataModelParser.AttributeContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataModelParser#split_tag}.
	 * @param ctx the parse tree
	 */
	void enterSplit_tag(@NotNull DataModelParser.Split_tagContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataModelParser#split_tag}.
	 * @param ctx the parse tree
	 */
	void exitSplit_tag(@NotNull DataModelParser.Split_tagContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataModelParser#mapping}.
	 * @param ctx the parse tree
	 */
	void enterMapping(@NotNull DataModelParser.MappingContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataModelParser#mapping}.
	 * @param ctx the parse tree
	 */
	void exitMapping(@NotNull DataModelParser.MappingContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataModelParser#namespace}.
	 * @param ctx the parse tree
	 */
	void enterNamespace(@NotNull DataModelParser.NamespaceContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataModelParser#namespace}.
	 * @param ctx the parse tree
	 */
	void exitNamespace(@NotNull DataModelParser.NamespaceContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataModelParser#field}.
	 * @param ctx the parse tree
	 */
	void enterField(@NotNull DataModelParser.FieldContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataModelParser#field}.
	 * @param ctx the parse tree
	 */
	void exitField(@NotNull DataModelParser.FieldContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataModelParser#system_type}.
	 * @param ctx the parse tree
	 */
	void enterSystem_type(@NotNull DataModelParser.System_typeContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataModelParser#system_type}.
	 * @param ctx the parse tree
	 */
	void exitSystem_type(@NotNull DataModelParser.System_typeContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataModelParser#is_pk}.
	 * @param ctx the parse tree
	 */
	void enterIs_pk(@NotNull DataModelParser.Is_pkContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataModelParser#is_pk}.
	 * @param ctx the parse tree
	 */
	void exitIs_pk(@NotNull DataModelParser.Is_pkContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataModelParser#long_name}.
	 * @param ctx the parse tree
	 */
	void enterLong_name(@NotNull DataModelParser.Long_nameContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataModelParser#long_name}.
	 * @param ctx the parse tree
	 */
	void exitLong_name(@NotNull DataModelParser.Long_nameContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataModelParser#program}.
	 * @param ctx the parse tree
	 */
	void enterProgram(@NotNull DataModelParser.ProgramContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataModelParser#program}.
	 * @param ctx the parse tree
	 */
	void exitProgram(@NotNull DataModelParser.ProgramContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataModelParser#is_null}.
	 * @param ctx the parse tree
	 */
	void enterIs_null(@NotNull DataModelParser.Is_nullContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataModelParser#is_null}.
	 * @param ctx the parse tree
	 */
	void exitIs_null(@NotNull DataModelParser.Is_nullContext ctx);

	/**
	 * Enter a parse tree produced by {@link DataModelParser#filed_define}.
	 * @param ctx the parse tree
	 */
	void enterFiled_define(@NotNull DataModelParser.Filed_defineContext ctx);
	/**
	 * Exit a parse tree produced by {@link DataModelParser#filed_define}.
	 * @param ctx the parse tree
	 */
	void exitFiled_define(@NotNull DataModelParser.Filed_defineContext ctx);
}