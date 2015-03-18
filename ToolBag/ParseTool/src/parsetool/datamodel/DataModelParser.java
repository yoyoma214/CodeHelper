// Generated from D:\workspace\20140311\ToolBag\ParseTool\src\parsetool\datamodel\DataModel.g4 by ANTLR 4.1
package parsetool.datamodel;
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.misc.*;
import org.antlr.v4.runtime.tree.*;
import java.util.List;
import java.util.Iterator;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class DataModelParser extends Parser {
	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		T__16=1, T__15=2, T__14=3, T__13=4, T__12=5, T__11=6, T__10=7, T__9=8, 
		T__8=9, T__7=10, T__6=11, T__5=12, T__4=13, T__3=14, T__2=15, T__1=16, 
		T__0=17, BOOL=18, ID=19, INT=20, FLOAT=21, COMMENT=22, CODE=23, WS=24, 
		STRING=25, CHAR=26;
	public static final String[] tokenNames = {
		"<INVALID>", "'using'", "']'", "'.'", "')'", "','", "'['", "'('", "'map'", 
		"'ManyToMany'", "';'", "'{'", "'ManyToOne'", "'namespace'", "'OneToMany'", 
		"'OneToOne'", "'}'", "'class'", "BOOL", "ID", "INT", "FLOAT", "COMMENT", 
		"CODE", "WS", "STRING", "CHAR"
	};
	public static final int
		RULE_program = 0, RULE_using = 1, RULE_namespace = 2, RULE_model = 3, 
		RULE_field = 4, RULE_long_name = 5, RULE_split_tag = 6, RULE_mapping = 7, 
		RULE_attribute = 8, RULE_relation = 9, RULE_filed_define = 10, RULE_system_type = 11, 
		RULE_db_type = 12, RULE_is_null = 13, RULE_is_pk = 14;
	public static final String[] ruleNames = {
		"program", "using", "namespace", "model", "field", "long_name", "split_tag", 
		"mapping", "attribute", "relation", "filed_define", "system_type", "db_type", 
		"is_null", "is_pk"
	};

	@Override
	public String getGrammarFileName() { return "DataModel.g4"; }

	@Override
	public String[] getTokenNames() { return tokenNames; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public ATN getATN() { return _ATN; }

	public DataModelParser(TokenStream input) {
		super(input);
		_interp = new ParserATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}
	public static class ProgramContext extends ParserRuleContext {
		public List<MappingContext> mapping() {
			return getRuleContexts(MappingContext.class);
		}
		public MappingContext mapping(int i) {
			return getRuleContext(MappingContext.class,i);
		}
		public NamespaceContext namespace() {
			return getRuleContext(NamespaceContext.class,0);
		}
		public UsingContext using(int i) {
			return getRuleContext(UsingContext.class,i);
		}
		public List<UsingContext> using() {
			return getRuleContexts(UsingContext.class);
		}
		public ModelContext model(int i) {
			return getRuleContext(ModelContext.class,i);
		}
		public List<ModelContext> model() {
			return getRuleContexts(ModelContext.class);
		}
		public ProgramContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_program; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof DataModelListener ) ((DataModelListener)listener).enterProgram(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof DataModelListener ) ((DataModelListener)listener).exitProgram(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof DataModelVisitor ) return ((DataModelVisitor<? extends T>)visitor).visitProgram(this);
			else return visitor.visitChildren(this);
		}
	}

	public final ProgramContext program() throws RecognitionException {
		ProgramContext _localctx = new ProgramContext(_ctx, getState());
		enterRule(_localctx, 0, RULE_program);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(33);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==1) {
				{
				{
				setState(30); using();
				}
				}
				setState(35);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(37);
			_la = _input.LA(1);
			if (_la==13) {
				{
				setState(36); namespace();
				}
			}

			setState(43);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << 6) | (1L << 17) | (1L << ID))) != 0)) {
				{
				setState(41);
				switch (_input.LA(1)) {
				case 6:
				case 17:
					{
					setState(39); model();
					}
					break;
				case ID:
					{
					setState(40); mapping();
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				}
				setState(45);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class UsingContext extends ParserRuleContext {
		public Long_nameContext long_name() {
			return getRuleContext(Long_nameContext.class,0);
		}
		public UsingContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_using; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof DataModelListener ) ((DataModelListener)listener).enterUsing(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof DataModelListener ) ((DataModelListener)listener).exitUsing(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof DataModelVisitor ) return ((DataModelVisitor<? extends T>)visitor).visitUsing(this);
			else return visitor.visitChildren(this);
		}
	}

	public final UsingContext using() throws RecognitionException {
		UsingContext _localctx = new UsingContext(_ctx, getState());
		enterRule(_localctx, 2, RULE_using);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(46); match(1);
			setState(47); long_name();
			setState(48); match(10);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class NamespaceContext extends ParserRuleContext {
		public Long_nameContext long_name() {
			return getRuleContext(Long_nameContext.class,0);
		}
		public NamespaceContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_namespace; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof DataModelListener ) ((DataModelListener)listener).enterNamespace(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof DataModelListener ) ((DataModelListener)listener).exitNamespace(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof DataModelVisitor ) return ((DataModelVisitor<? extends T>)visitor).visitNamespace(this);
			else return visitor.visitChildren(this);
		}
	}

	public final NamespaceContext namespace() throws RecognitionException {
		NamespaceContext _localctx = new NamespaceContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_namespace);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(50); match(13);
			setState(51); long_name();
			setState(53);
			_la = _input.LA(1);
			if (_la==10) {
				{
				setState(52); match(10);
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ModelContext extends ParserRuleContext {
		public List<AttributeContext> attribute() {
			return getRuleContexts(AttributeContext.class);
		}
		public FieldContext field(int i) {
			return getRuleContext(FieldContext.class,i);
		}
		public TerminalNode ID() { return getToken(DataModelParser.ID, 0); }
		public AttributeContext attribute(int i) {
			return getRuleContext(AttributeContext.class,i);
		}
		public List<FieldContext> field() {
			return getRuleContexts(FieldContext.class);
		}
		public ModelContext model(int i) {
			return getRuleContext(ModelContext.class,i);
		}
		public List<ModelContext> model() {
			return getRuleContexts(ModelContext.class);
		}
		public ModelContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_model; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof DataModelListener ) ((DataModelListener)listener).enterModel(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof DataModelListener ) ((DataModelListener)listener).exitModel(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof DataModelVisitor ) return ((DataModelVisitor<? extends T>)visitor).visitModel(this);
			else return visitor.visitChildren(this);
		}
	}

	public final ModelContext model() throws RecognitionException {
		ModelContext _localctx = new ModelContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_model);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(58);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==6) {
				{
				{
				setState(55); attribute();
				}
				}
				setState(60);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(61); match(17);
			setState(62); match(ID);
			setState(63); match(11);
			setState(71);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << 6) | (1L << 17) | (1L << ID))) != 0)) {
				{
				setState(69);
				switch ( getInterpreter().adaptivePredict(_input,7,_ctx) ) {
				case 1:
					{
					setState(64); field();
					setState(66);
					_la = _input.LA(1);
					if (_la==5) {
						{
						setState(65); match(5);
						}
					}

					}
					break;

				case 2:
					{
					setState(68); model();
					}
					break;
				}
				}
				setState(73);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(74); match(16);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class FieldContext extends ParserRuleContext {
		public Filed_defineContext filed_define() {
			return getRuleContext(Filed_defineContext.class,0);
		}
		public List<AttributeContext> attribute() {
			return getRuleContexts(AttributeContext.class);
		}
		public TerminalNode ID() { return getToken(DataModelParser.ID, 0); }
		public AttributeContext attribute(int i) {
			return getRuleContext(AttributeContext.class,i);
		}
		public FieldContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_field; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof DataModelListener ) ((DataModelListener)listener).enterField(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof DataModelListener ) ((DataModelListener)listener).exitField(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof DataModelVisitor ) return ((DataModelVisitor<? extends T>)visitor).visitField(this);
			else return visitor.visitChildren(this);
		}
	}

	public final FieldContext field() throws RecognitionException {
		FieldContext _localctx = new FieldContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_field);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(79);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==6) {
				{
				{
				setState(76); attribute();
				}
				}
				setState(81);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(82); match(ID);
			setState(83); match(7);
			setState(84); filed_define();
			setState(85); match(4);
			setState(86); match(10);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Long_nameContext extends ParserRuleContext {
		public List<TerminalNode> ID() { return getTokens(DataModelParser.ID); }
		public TerminalNode ID(int i) {
			return getToken(DataModelParser.ID, i);
		}
		public Long_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_long_name; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof DataModelListener ) ((DataModelListener)listener).enterLong_name(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof DataModelListener ) ((DataModelListener)listener).exitLong_name(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof DataModelVisitor ) return ((DataModelVisitor<? extends T>)visitor).visitLong_name(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Long_nameContext long_name() throws RecognitionException {
		Long_nameContext _localctx = new Long_nameContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_long_name);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(88); match(ID);
			setState(93);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==3) {
				{
				{
				setState(89); match(3);
				setState(90); match(ID);
				}
				}
				setState(95);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Split_tagContext extends ParserRuleContext {
		public TerminalNode STRING() { return getToken(DataModelParser.STRING, 0); }
		public Split_tagContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_split_tag; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof DataModelListener ) ((DataModelListener)listener).enterSplit_tag(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof DataModelListener ) ((DataModelListener)listener).exitSplit_tag(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof DataModelVisitor ) return ((DataModelVisitor<? extends T>)visitor).visitSplit_tag(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Split_tagContext split_tag() throws RecognitionException {
		Split_tagContext _localctx = new Split_tagContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_split_tag);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(96); match(STRING);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class MappingContext extends ParserRuleContext {
		public RelationContext relation() {
			return getRuleContext(RelationContext.class,0);
		}
		public List<TerminalNode> ID() { return getTokens(DataModelParser.ID); }
		public Long_nameContext long_name() {
			return getRuleContext(Long_nameContext.class,0);
		}
		public Split_tagContext split_tag() {
			return getRuleContext(Split_tagContext.class,0);
		}
		public TerminalNode ID(int i) {
			return getToken(DataModelParser.ID, i);
		}
		public MappingContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_mapping; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof DataModelListener ) ((DataModelListener)listener).enterMapping(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof DataModelListener ) ((DataModelListener)listener).exitMapping(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof DataModelVisitor ) return ((DataModelVisitor<? extends T>)visitor).visitMapping(this);
			else return visitor.visitChildren(this);
		}
	}

	public final MappingContext mapping() throws RecognitionException {
		MappingContext _localctx = new MappingContext(_ctx, getState());
		enterRule(_localctx, 14, RULE_mapping);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(98); match(ID);
			setState(99); match(3);
			setState(100); match(8);
			setState(101); match(7);
			setState(102); match(ID);
			setState(103); match(5);
			setState(104); match(ID);
			setState(105); match(5);
			setState(106); long_name();
			setState(107); match(5);
			setState(108); match(ID);
			setState(109); match(5);
			setState(110); relation();
			setState(113); 
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,11,_ctx);
			do {
				switch (_alt) {
				case 1:
					{
					{
					setState(111); match(5);
					setState(112); match(ID);
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(115); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,11,_ctx);
			} while ( _alt!=2 && _alt!=-1 );
			setState(119);
			_la = _input.LA(1);
			if (_la==5) {
				{
				setState(117); match(5);
				setState(118); split_tag();
				}
			}

			setState(121); match(4);
			setState(122); match(10);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class AttributeContext extends ParserRuleContext {
		public TerminalNode STRING(int i) {
			return getToken(DataModelParser.STRING, i);
		}
		public TerminalNode ID() { return getToken(DataModelParser.ID, 0); }
		public List<TerminalNode> STRING() { return getTokens(DataModelParser.STRING); }
		public AttributeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_attribute; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof DataModelListener ) ((DataModelListener)listener).enterAttribute(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof DataModelListener ) ((DataModelListener)listener).exitAttribute(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof DataModelVisitor ) return ((DataModelVisitor<? extends T>)visitor).visitAttribute(this);
			else return visitor.visitChildren(this);
		}
	}

	public final AttributeContext attribute() throws RecognitionException {
		AttributeContext _localctx = new AttributeContext(_ctx, getState());
		enterRule(_localctx, 16, RULE_attribute);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(124); match(6);
			setState(125); match(ID);
			setState(126); match(7);
			setState(127); match(STRING);
			setState(132);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==5) {
				{
				{
				setState(128); match(5);
				setState(129); match(STRING);
				}
				}
				setState(134);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(135); match(4);
			setState(136); match(2);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class RelationContext extends ParserRuleContext {
		public RelationContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_relation; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof DataModelListener ) ((DataModelListener)listener).enterRelation(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof DataModelListener ) ((DataModelListener)listener).exitRelation(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof DataModelVisitor ) return ((DataModelVisitor<? extends T>)visitor).visitRelation(this);
			else return visitor.visitChildren(this);
		}
	}

	public final RelationContext relation() throws RecognitionException {
		RelationContext _localctx = new RelationContext(_ctx, getState());
		enterRule(_localctx, 18, RULE_relation);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(138);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << 9) | (1L << 12) | (1L << 14) | (1L << 15))) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			consume();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Filed_defineContext extends ParserRuleContext {
		public Is_nullContext is_null() {
			return getRuleContext(Is_nullContext.class,0);
		}
		public Db_typeContext db_type() {
			return getRuleContext(Db_typeContext.class,0);
		}
		public System_typeContext system_type() {
			return getRuleContext(System_typeContext.class,0);
		}
		public Is_pkContext is_pk() {
			return getRuleContext(Is_pkContext.class,0);
		}
		public Filed_defineContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_filed_define; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof DataModelListener ) ((DataModelListener)listener).enterFiled_define(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof DataModelListener ) ((DataModelListener)listener).exitFiled_define(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof DataModelVisitor ) return ((DataModelVisitor<? extends T>)visitor).visitFiled_define(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Filed_defineContext filed_define() throws RecognitionException {
		Filed_defineContext _localctx = new Filed_defineContext(_ctx, getState());
		enterRule(_localctx, 20, RULE_filed_define);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(140); system_type();
			setState(141); match(5);
			setState(142); db_type();
			setState(149);
			_la = _input.LA(1);
			if (_la==5) {
				{
				setState(143); match(5);
				setState(144); is_null();
				setState(147);
				_la = _input.LA(1);
				if (_la==5) {
					{
					setState(145); match(5);
					setState(146); is_pk();
					}
				}

				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class System_typeContext extends ParserRuleContext {
		public Long_nameContext long_name() {
			return getRuleContext(Long_nameContext.class,0);
		}
		public System_typeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_system_type; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof DataModelListener ) ((DataModelListener)listener).enterSystem_type(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof DataModelListener ) ((DataModelListener)listener).exitSystem_type(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof DataModelVisitor ) return ((DataModelVisitor<? extends T>)visitor).visitSystem_type(this);
			else return visitor.visitChildren(this);
		}
	}

	public final System_typeContext system_type() throws RecognitionException {
		System_typeContext _localctx = new System_typeContext(_ctx, getState());
		enterRule(_localctx, 22, RULE_system_type);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(151); long_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Db_typeContext extends ParserRuleContext {
		public TerminalNode STRING() { return getToken(DataModelParser.STRING, 0); }
		public Db_typeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_db_type; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof DataModelListener ) ((DataModelListener)listener).enterDb_type(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof DataModelListener ) ((DataModelListener)listener).exitDb_type(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof DataModelVisitor ) return ((DataModelVisitor<? extends T>)visitor).visitDb_type(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Db_typeContext db_type() throws RecognitionException {
		Db_typeContext _localctx = new Db_typeContext(_ctx, getState());
		enterRule(_localctx, 24, RULE_db_type);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(153); match(STRING);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Is_nullContext extends ParserRuleContext {
		public TerminalNode BOOL() { return getToken(DataModelParser.BOOL, 0); }
		public Is_nullContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_is_null; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof DataModelListener ) ((DataModelListener)listener).enterIs_null(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof DataModelListener ) ((DataModelListener)listener).exitIs_null(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof DataModelVisitor ) return ((DataModelVisitor<? extends T>)visitor).visitIs_null(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Is_nullContext is_null() throws RecognitionException {
		Is_nullContext _localctx = new Is_nullContext(_ctx, getState());
		enterRule(_localctx, 26, RULE_is_null);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(155); match(BOOL);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Is_pkContext extends ParserRuleContext {
		public TerminalNode BOOL() { return getToken(DataModelParser.BOOL, 0); }
		public Is_pkContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_is_pk; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof DataModelListener ) ((DataModelListener)listener).enterIs_pk(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof DataModelListener ) ((DataModelListener)listener).exitIs_pk(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof DataModelVisitor ) return ((DataModelVisitor<? extends T>)visitor).visitIs_pk(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Is_pkContext is_pk() throws RecognitionException {
		Is_pkContext _localctx = new Is_pkContext(_ctx, getState());
		enterRule(_localctx, 28, RULE_is_pk);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(157); match(BOOL);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static final String _serializedATN =
		"\3\uacf5\uee8c\u4f5d\u8b0d\u4a45\u78bd\u1b2f\u3378\3\34\u00a2\4\2\t\2"+
		"\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13"+
		"\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\3\2\7\2\"\n\2\f\2"+
		"\16\2%\13\2\3\2\5\2(\n\2\3\2\3\2\7\2,\n\2\f\2\16\2/\13\2\3\3\3\3\3\3\3"+
		"\3\3\4\3\4\3\4\5\48\n\4\3\5\7\5;\n\5\f\5\16\5>\13\5\3\5\3\5\3\5\3\5\3"+
		"\5\5\5E\n\5\3\5\7\5H\n\5\f\5\16\5K\13\5\3\5\3\5\3\6\7\6P\n\6\f\6\16\6"+
		"S\13\6\3\6\3\6\3\6\3\6\3\6\3\6\3\7\3\7\3\7\7\7^\n\7\f\7\16\7a\13\7\3\b"+
		"\3\b\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\t\6\tt"+
		"\n\t\r\t\16\tu\3\t\3\t\5\tz\n\t\3\t\3\t\3\t\3\n\3\n\3\n\3\n\3\n\3\n\7"+
		"\n\u0085\n\n\f\n\16\n\u0088\13\n\3\n\3\n\3\n\3\13\3\13\3\f\3\f\3\f\3\f"+
		"\3\f\3\f\3\f\5\f\u0096\n\f\5\f\u0098\n\f\3\r\3\r\3\16\3\16\3\17\3\17\3"+
		"\20\3\20\3\20\2\21\2\4\6\b\n\f\16\20\22\24\26\30\32\34\36\2\3\5\2\13\13"+
		"\16\16\20\21\u00a2\2#\3\2\2\2\4\60\3\2\2\2\6\64\3\2\2\2\b<\3\2\2\2\nQ"+
		"\3\2\2\2\fZ\3\2\2\2\16b\3\2\2\2\20d\3\2\2\2\22~\3\2\2\2\24\u008c\3\2\2"+
		"\2\26\u008e\3\2\2\2\30\u0099\3\2\2\2\32\u009b\3\2\2\2\34\u009d\3\2\2\2"+
		"\36\u009f\3\2\2\2 \"\5\4\3\2! \3\2\2\2\"%\3\2\2\2#!\3\2\2\2#$\3\2\2\2"+
		"$\'\3\2\2\2%#\3\2\2\2&(\5\6\4\2\'&\3\2\2\2\'(\3\2\2\2(-\3\2\2\2),\5\b"+
		"\5\2*,\5\20\t\2+)\3\2\2\2+*\3\2\2\2,/\3\2\2\2-+\3\2\2\2-.\3\2\2\2.\3\3"+
		"\2\2\2/-\3\2\2\2\60\61\7\3\2\2\61\62\5\f\7\2\62\63\7\f\2\2\63\5\3\2\2"+
		"\2\64\65\7\17\2\2\65\67\5\f\7\2\668\7\f\2\2\67\66\3\2\2\2\678\3\2\2\2"+
		"8\7\3\2\2\29;\5\22\n\2:9\3\2\2\2;>\3\2\2\2<:\3\2\2\2<=\3\2\2\2=?\3\2\2"+
		"\2><\3\2\2\2?@\7\23\2\2@A\7\25\2\2AI\7\r\2\2BD\5\n\6\2CE\7\7\2\2DC\3\2"+
		"\2\2DE\3\2\2\2EH\3\2\2\2FH\5\b\5\2GB\3\2\2\2GF\3\2\2\2HK\3\2\2\2IG\3\2"+
		"\2\2IJ\3\2\2\2JL\3\2\2\2KI\3\2\2\2LM\7\22\2\2M\t\3\2\2\2NP\5\22\n\2ON"+
		"\3\2\2\2PS\3\2\2\2QO\3\2\2\2QR\3\2\2\2RT\3\2\2\2SQ\3\2\2\2TU\7\25\2\2"+
		"UV\7\t\2\2VW\5\26\f\2WX\7\6\2\2XY\7\f\2\2Y\13\3\2\2\2Z_\7\25\2\2[\\\7"+
		"\5\2\2\\^\7\25\2\2][\3\2\2\2^a\3\2\2\2_]\3\2\2\2_`\3\2\2\2`\r\3\2\2\2"+
		"a_\3\2\2\2bc\7\33\2\2c\17\3\2\2\2de\7\25\2\2ef\7\5\2\2fg\7\n\2\2gh\7\t"+
		"\2\2hi\7\25\2\2ij\7\7\2\2jk\7\25\2\2kl\7\7\2\2lm\5\f\7\2mn\7\7\2\2no\7"+
		"\25\2\2op\7\7\2\2ps\5\24\13\2qr\7\7\2\2rt\7\25\2\2sq\3\2\2\2tu\3\2\2\2"+
		"us\3\2\2\2uv\3\2\2\2vy\3\2\2\2wx\7\7\2\2xz\5\16\b\2yw\3\2\2\2yz\3\2\2"+
		"\2z{\3\2\2\2{|\7\6\2\2|}\7\f\2\2}\21\3\2\2\2~\177\7\b\2\2\177\u0080\7"+
		"\25\2\2\u0080\u0081\7\t\2\2\u0081\u0086\7\33\2\2\u0082\u0083\7\7\2\2\u0083"+
		"\u0085\7\33\2\2\u0084\u0082\3\2\2\2\u0085\u0088\3\2\2\2\u0086\u0084\3"+
		"\2\2\2\u0086\u0087\3\2\2\2\u0087\u0089\3\2\2\2\u0088\u0086\3\2\2\2\u0089"+
		"\u008a\7\6\2\2\u008a\u008b\7\4\2\2\u008b\23\3\2\2\2\u008c\u008d\t\2\2"+
		"\2\u008d\25\3\2\2\2\u008e\u008f\5\30\r\2\u008f\u0090\7\7\2\2\u0090\u0097"+
		"\5\32\16\2\u0091\u0092\7\7\2\2\u0092\u0095\5\34\17\2\u0093\u0094\7\7\2"+
		"\2\u0094\u0096\5\36\20\2\u0095\u0093\3\2\2\2\u0095\u0096\3\2\2\2\u0096"+
		"\u0098\3\2\2\2\u0097\u0091\3\2\2\2\u0097\u0098\3\2\2\2\u0098\27\3\2\2"+
		"\2\u0099\u009a\5\f\7\2\u009a\31\3\2\2\2\u009b\u009c\7\33\2\2\u009c\33"+
		"\3\2\2\2\u009d\u009e\7\24\2\2\u009e\35\3\2\2\2\u009f\u00a0\7\24\2\2\u00a0"+
		"\37\3\2\2\2\22#\'+-\67<DGIQ_uy\u0086\u0095\u0097";
	public static final ATN _ATN =
		ATNSimulator.deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}