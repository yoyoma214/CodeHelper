// Generated from D:\workspace\20140311\ToolBag\ParseTool\src\parsetool\xmlmodel\XmlModel.g4 by ANTLR 4.1
package parsetool.xmlmodel;
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.misc.*;
import org.antlr.v4.runtime.tree.*;
import java.util.List;
import java.util.Iterator;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class XmlModelParser extends Parser {
	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		T__15=1, T__14=2, T__13=3, T__12=4, T__11=5, T__10=6, T__9=7, T__8=8, 
		T__7=9, T__6=10, T__5=11, T__4=12, T__3=13, T__2=14, T__1=15, T__0=16, 
		BOOL=17, ID=18, INT=19, FLOAT=20, COMMENT=21, CODE=22, WS=23, STRING=24, 
		CHAR=25;
	public static final String[] tokenNames = {
		"<INVALID>", "'rank'", "'using'", "'.'", "'field_group'", "'List'", "'<'", 
		"'='", "';'", "'attr'", "'{'", "'>'", "'namespace'", "'attr_group'", "'order'", 
		"'}'", "'class'", "BOOL", "ID", "INT", "FLOAT", "COMMENT", "CODE", "WS", 
		"STRING", "CHAR"
	};
	public static final int
		RULE_program = 0, RULE_using = 1, RULE_namespace = 2, RULE_element = 3, 
		RULE_attr_group_constraint = 4, RULE_attr_group = 5, RULE_field_group = 6, 
		RULE_group_cons_order = 7, RULE_clz_cons_rank = 8, RULE_field = 9, RULE_attribute = 10, 
		RULE_default_value = 11, RULE_generic = 12, RULE_long_name = 13;
	public static final String[] ruleNames = {
		"program", "using", "namespace", "element", "attr_group_constraint", "attr_group", 
		"field_group", "group_cons_order", "clz_cons_rank", "field", "attribute", 
		"default_value", "generic", "long_name"
	};

	@Override
	public String getGrammarFileName() { return "XmlModel.g4"; }

	@Override
	public String[] getTokenNames() { return tokenNames; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public ATN getATN() { return _ATN; }

	public XmlModelParser(TokenStream input) {
		super(input);
		_interp = new ParserATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}
	public static class ProgramContext extends ParserRuleContext {
		public List<ElementContext> element() {
			return getRuleContexts(ElementContext.class);
		}
		public ElementContext element(int i) {
			return getRuleContext(ElementContext.class,i);
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
		public ProgramContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_program; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof XmlModelListener ) ((XmlModelListener)listener).enterProgram(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof XmlModelListener ) ((XmlModelListener)listener).exitProgram(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof XmlModelVisitor ) return ((XmlModelVisitor<? extends T>)visitor).visitProgram(this);
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
			setState(31);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==2) {
				{
				{
				setState(28); using();
				}
				}
				setState(33);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(35);
			_la = _input.LA(1);
			if (_la==12) {
				{
				setState(34); namespace();
				}
			}

			setState(40);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==16) {
				{
				{
				setState(37); element();
				}
				}
				setState(42);
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
			if ( listener instanceof XmlModelListener ) ((XmlModelListener)listener).enterUsing(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof XmlModelListener ) ((XmlModelListener)listener).exitUsing(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof XmlModelVisitor ) return ((XmlModelVisitor<? extends T>)visitor).visitUsing(this);
			else return visitor.visitChildren(this);
		}
	}

	public final UsingContext using() throws RecognitionException {
		UsingContext _localctx = new UsingContext(_ctx, getState());
		enterRule(_localctx, 2, RULE_using);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(43); match(2);
			setState(44); long_name();
			setState(45); match(8);
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
			if ( listener instanceof XmlModelListener ) ((XmlModelListener)listener).enterNamespace(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof XmlModelListener ) ((XmlModelListener)listener).exitNamespace(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof XmlModelVisitor ) return ((XmlModelVisitor<? extends T>)visitor).visitNamespace(this);
			else return visitor.visitChildren(this);
		}
	}

	public final NamespaceContext namespace() throws RecognitionException {
		NamespaceContext _localctx = new NamespaceContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_namespace);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(47); match(12);
			setState(48); long_name();
			setState(49); match(8);
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

	public static class ElementContext extends ParserRuleContext {
		public Attr_groupContext attr_group(int i) {
			return getRuleContext(Attr_groupContext.class,i);
		}
		public List<AttributeContext> attribute() {
			return getRuleContexts(AttributeContext.class);
		}
		public FieldContext field(int i) {
			return getRuleContext(FieldContext.class,i);
		}
		public TerminalNode ID() { return getToken(XmlModelParser.ID, 0); }
		public AttributeContext attribute(int i) {
			return getRuleContext(AttributeContext.class,i);
		}
		public List<FieldContext> field() {
			return getRuleContexts(FieldContext.class);
		}
		public List<Field_groupContext> field_group() {
			return getRuleContexts(Field_groupContext.class);
		}
		public List<Attr_groupContext> attr_group() {
			return getRuleContexts(Attr_groupContext.class);
		}
		public Field_groupContext field_group(int i) {
			return getRuleContext(Field_groupContext.class,i);
		}
		public ElementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_element; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof XmlModelListener ) ((XmlModelListener)listener).enterElement(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof XmlModelListener ) ((XmlModelListener)listener).exitElement(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof XmlModelVisitor ) return ((XmlModelVisitor<? extends T>)visitor).visitElement(this);
			else return visitor.visitChildren(this);
		}
	}

	public final ElementContext element() throws RecognitionException {
		ElementContext _localctx = new ElementContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_element);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(51); match(16);
			setState(52); match(ID);
			setState(53); match(10);
			setState(60);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << 4) | (1L << 5) | (1L << 9) | (1L << 13) | (1L << ID))) != 0)) {
				{
				setState(58);
				switch (_input.LA(1)) {
				case 13:
					{
					setState(54); attr_group();
					}
					break;
				case 4:
					{
					setState(55); field_group();
					}
					break;
				case 9:
					{
					setState(56); attribute();
					}
					break;
				case 5:
				case ID:
					{
					setState(57); field();
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				}
				setState(62);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(63); match(15);
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

	public static class Attr_group_constraintContext extends ParserRuleContext {
		public Attr_group_constraintContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_attr_group_constraint; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof XmlModelListener ) ((XmlModelListener)listener).enterAttr_group_constraint(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof XmlModelListener ) ((XmlModelListener)listener).exitAttr_group_constraint(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof XmlModelVisitor ) return ((XmlModelVisitor<? extends T>)visitor).visitAttr_group_constraint(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Attr_group_constraintContext attr_group_constraint() throws RecognitionException {
		Attr_group_constraintContext _localctx = new Attr_group_constraintContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_attr_group_constraint);
		try {
			enterOuterAlt(_localctx, 1);
			{
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

	public static class Attr_groupContext extends ParserRuleContext {
		public Group_cons_orderContext group_cons_order() {
			return getRuleContext(Group_cons_orderContext.class,0);
		}
		public List<AttributeContext> attribute() {
			return getRuleContexts(AttributeContext.class);
		}
		public AttributeContext attribute(int i) {
			return getRuleContext(AttributeContext.class,i);
		}
		public Attr_groupContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_attr_group; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof XmlModelListener ) ((XmlModelListener)listener).enterAttr_group(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof XmlModelListener ) ((XmlModelListener)listener).exitAttr_group(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof XmlModelVisitor ) return ((XmlModelVisitor<? extends T>)visitor).visitAttr_group(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Attr_groupContext attr_group() throws RecognitionException {
		Attr_groupContext _localctx = new Attr_groupContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_attr_group);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(67); match(13);
			setState(68); match(10);
			setState(70);
			_la = _input.LA(1);
			if (_la==14) {
				{
				setState(69); group_cons_order();
				}
			}

			setState(75);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==9) {
				{
				{
				setState(72); attribute();
				}
				}
				setState(77);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(78); match(15);
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

	public static class Field_groupContext extends ParserRuleContext {
		public Group_cons_orderContext group_cons_order() {
			return getRuleContext(Group_cons_orderContext.class,0);
		}
		public FieldContext field(int i) {
			return getRuleContext(FieldContext.class,i);
		}
		public List<FieldContext> field() {
			return getRuleContexts(FieldContext.class);
		}
		public Field_groupContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_field_group; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof XmlModelListener ) ((XmlModelListener)listener).enterField_group(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof XmlModelListener ) ((XmlModelListener)listener).exitField_group(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof XmlModelVisitor ) return ((XmlModelVisitor<? extends T>)visitor).visitField_group(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Field_groupContext field_group() throws RecognitionException {
		Field_groupContext _localctx = new Field_groupContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_field_group);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(80); match(4);
			setState(81); match(10);
			setState(83);
			_la = _input.LA(1);
			if (_la==14) {
				{
				setState(82); group_cons_order();
				}
			}

			setState(88);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==5 || _la==ID) {
				{
				{
				setState(85); field();
				}
				}
				setState(90);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(91); match(15);
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

	public static class Group_cons_orderContext extends ParserRuleContext {
		public TerminalNode BOOL() { return getToken(XmlModelParser.BOOL, 0); }
		public Group_cons_orderContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_group_cons_order; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof XmlModelListener ) ((XmlModelListener)listener).enterGroup_cons_order(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof XmlModelListener ) ((XmlModelListener)listener).exitGroup_cons_order(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof XmlModelVisitor ) return ((XmlModelVisitor<? extends T>)visitor).visitGroup_cons_order(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Group_cons_orderContext group_cons_order() throws RecognitionException {
		Group_cons_orderContext _localctx = new Group_cons_orderContext(_ctx, getState());
		enterRule(_localctx, 14, RULE_group_cons_order);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(93); match(14);
			setState(94); match(7);
			setState(95); match(BOOL);
			setState(96); match(8);
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

	public static class Clz_cons_rankContext extends ParserRuleContext {
		public TerminalNode BOOL() { return getToken(XmlModelParser.BOOL, 0); }
		public Clz_cons_rankContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_clz_cons_rank; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof XmlModelListener ) ((XmlModelListener)listener).enterClz_cons_rank(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof XmlModelListener ) ((XmlModelListener)listener).exitClz_cons_rank(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof XmlModelVisitor ) return ((XmlModelVisitor<? extends T>)visitor).visitClz_cons_rank(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Clz_cons_rankContext clz_cons_rank() throws RecognitionException {
		Clz_cons_rankContext _localctx = new Clz_cons_rankContext(_ctx, getState());
		enterRule(_localctx, 16, RULE_clz_cons_rank);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(98); match(1);
			setState(99); match(7);
			setState(100); match(BOOL);
			setState(101); match(8);
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
		public TerminalNode ID() { return getToken(XmlModelParser.ID, 0); }
		public Default_valueContext default_value() {
			return getRuleContext(Default_valueContext.class,0);
		}
		public Long_nameContext long_name() {
			return getRuleContext(Long_nameContext.class,0);
		}
		public GenericContext generic() {
			return getRuleContext(GenericContext.class,0);
		}
		public FieldContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_field; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof XmlModelListener ) ((XmlModelListener)listener).enterField(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof XmlModelListener ) ((XmlModelListener)listener).exitField(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof XmlModelVisitor ) return ((XmlModelVisitor<? extends T>)visitor).visitField(this);
			else return visitor.visitChildren(this);
		}
	}

	public final FieldContext field() throws RecognitionException {
		FieldContext _localctx = new FieldContext(_ctx, getState());
		enterRule(_localctx, 18, RULE_field);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(105);
			switch (_input.LA(1)) {
			case 5:
				{
				setState(103); generic();
				}
				break;
			case ID:
				{
				setState(104); long_name();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(107); match(ID);
			setState(109);
			_la = _input.LA(1);
			if (_la==7) {
				{
				setState(108); default_value();
				}
			}

			setState(111); match(8);
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
		public TerminalNode ID() { return getToken(XmlModelParser.ID, 0); }
		public Default_valueContext default_value() {
			return getRuleContext(Default_valueContext.class,0);
		}
		public Long_nameContext long_name() {
			return getRuleContext(Long_nameContext.class,0);
		}
		public GenericContext generic() {
			return getRuleContext(GenericContext.class,0);
		}
		public AttributeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_attribute; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof XmlModelListener ) ((XmlModelListener)listener).enterAttribute(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof XmlModelListener ) ((XmlModelListener)listener).exitAttribute(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof XmlModelVisitor ) return ((XmlModelVisitor<? extends T>)visitor).visitAttribute(this);
			else return visitor.visitChildren(this);
		}
	}

	public final AttributeContext attribute() throws RecognitionException {
		AttributeContext _localctx = new AttributeContext(_ctx, getState());
		enterRule(_localctx, 20, RULE_attribute);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(113); match(9);
			setState(116);
			switch (_input.LA(1)) {
			case 5:
				{
				setState(114); generic();
				}
				break;
			case ID:
				{
				setState(115); long_name();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(118); match(ID);
			setState(120);
			_la = _input.LA(1);
			if (_la==7) {
				{
				setState(119); default_value();
				}
			}

			setState(122); match(8);
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

	public static class Default_valueContext extends ParserRuleContext {
		public TerminalNode BOOL() { return getToken(XmlModelParser.BOOL, 0); }
		public TerminalNode FLOAT() { return getToken(XmlModelParser.FLOAT, 0); }
		public TerminalNode INT() { return getToken(XmlModelParser.INT, 0); }
		public TerminalNode STRING() { return getToken(XmlModelParser.STRING, 0); }
		public TerminalNode CHAR() { return getToken(XmlModelParser.CHAR, 0); }
		public Default_valueContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_default_value; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof XmlModelListener ) ((XmlModelListener)listener).enterDefault_value(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof XmlModelListener ) ((XmlModelListener)listener).exitDefault_value(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof XmlModelVisitor ) return ((XmlModelVisitor<? extends T>)visitor).visitDefault_value(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Default_valueContext default_value() throws RecognitionException {
		Default_valueContext _localctx = new Default_valueContext(_ctx, getState());
		enterRule(_localctx, 22, RULE_default_value);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(124); match(7);
			setState(125);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << BOOL) | (1L << INT) | (1L << FLOAT) | (1L << STRING) | (1L << CHAR))) != 0)) ) {
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

	public static class GenericContext extends ParserRuleContext {
		public Long_nameContext long_name() {
			return getRuleContext(Long_nameContext.class,0);
		}
		public GenericContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_generic; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof XmlModelListener ) ((XmlModelListener)listener).enterGeneric(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof XmlModelListener ) ((XmlModelListener)listener).exitGeneric(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof XmlModelVisitor ) return ((XmlModelVisitor<? extends T>)visitor).visitGeneric(this);
			else return visitor.visitChildren(this);
		}
	}

	public final GenericContext generic() throws RecognitionException {
		GenericContext _localctx = new GenericContext(_ctx, getState());
		enterRule(_localctx, 24, RULE_generic);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(127); match(5);
			setState(128); match(6);
			setState(129); long_name();
			setState(130); match(11);
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
		public List<TerminalNode> ID() { return getTokens(XmlModelParser.ID); }
		public TerminalNode ID(int i) {
			return getToken(XmlModelParser.ID, i);
		}
		public Long_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_long_name; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof XmlModelListener ) ((XmlModelListener)listener).enterLong_name(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof XmlModelListener ) ((XmlModelListener)listener).exitLong_name(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof XmlModelVisitor ) return ((XmlModelVisitor<? extends T>)visitor).visitLong_name(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Long_nameContext long_name() throws RecognitionException {
		Long_nameContext _localctx = new Long_nameContext(_ctx, getState());
		enterRule(_localctx, 26, RULE_long_name);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(132); match(ID);
			setState(137);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==3) {
				{
				{
				setState(133); match(3);
				setState(134); match(ID);
				}
				}
				setState(139);
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

	public static final String _serializedATN =
		"\3\uacf5\uee8c\u4f5d\u8b0d\u4a45\u78bd\u1b2f\u3378\3\33\u008f\4\2\t\2"+
		"\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13"+
		"\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\3\2\7\2 \n\2\f\2\16\2#\13\2"+
		"\3\2\5\2&\n\2\3\2\7\2)\n\2\f\2\16\2,\13\2\3\3\3\3\3\3\3\3\3\4\3\4\3\4"+
		"\3\4\3\5\3\5\3\5\3\5\3\5\3\5\3\5\7\5=\n\5\f\5\16\5@\13\5\3\5\3\5\3\6\3"+
		"\6\3\7\3\7\3\7\5\7I\n\7\3\7\7\7L\n\7\f\7\16\7O\13\7\3\7\3\7\3\b\3\b\3"+
		"\b\5\bV\n\b\3\b\7\bY\n\b\f\b\16\b\\\13\b\3\b\3\b\3\t\3\t\3\t\3\t\3\t\3"+
		"\n\3\n\3\n\3\n\3\n\3\13\3\13\5\13l\n\13\3\13\3\13\5\13p\n\13\3\13\3\13"+
		"\3\f\3\f\3\f\5\fw\n\f\3\f\3\f\5\f{\n\f\3\f\3\f\3\r\3\r\3\r\3\16\3\16\3"+
		"\16\3\16\3\16\3\17\3\17\3\17\7\17\u008a\n\17\f\17\16\17\u008d\13\17\3"+
		"\17\2\20\2\4\6\b\n\f\16\20\22\24\26\30\32\34\2\3\5\2\23\23\25\26\32\33"+
		"\u0090\2!\3\2\2\2\4-\3\2\2\2\6\61\3\2\2\2\b\65\3\2\2\2\nC\3\2\2\2\fE\3"+
		"\2\2\2\16R\3\2\2\2\20_\3\2\2\2\22d\3\2\2\2\24k\3\2\2\2\26s\3\2\2\2\30"+
		"~\3\2\2\2\32\u0081\3\2\2\2\34\u0086\3\2\2\2\36 \5\4\3\2\37\36\3\2\2\2"+
		" #\3\2\2\2!\37\3\2\2\2!\"\3\2\2\2\"%\3\2\2\2#!\3\2\2\2$&\5\6\4\2%$\3\2"+
		"\2\2%&\3\2\2\2&*\3\2\2\2\')\5\b\5\2(\'\3\2\2\2),\3\2\2\2*(\3\2\2\2*+\3"+
		"\2\2\2+\3\3\2\2\2,*\3\2\2\2-.\7\4\2\2./\5\34\17\2/\60\7\n\2\2\60\5\3\2"+
		"\2\2\61\62\7\16\2\2\62\63\5\34\17\2\63\64\7\n\2\2\64\7\3\2\2\2\65\66\7"+
		"\22\2\2\66\67\7\24\2\2\67>\7\f\2\28=\5\f\7\29=\5\16\b\2:=\5\26\f\2;=\5"+
		"\24\13\2<8\3\2\2\2<9\3\2\2\2<:\3\2\2\2<;\3\2\2\2=@\3\2\2\2><\3\2\2\2>"+
		"?\3\2\2\2?A\3\2\2\2@>\3\2\2\2AB\7\21\2\2B\t\3\2\2\2CD\3\2\2\2D\13\3\2"+
		"\2\2EF\7\17\2\2FH\7\f\2\2GI\5\20\t\2HG\3\2\2\2HI\3\2\2\2IM\3\2\2\2JL\5"+
		"\26\f\2KJ\3\2\2\2LO\3\2\2\2MK\3\2\2\2MN\3\2\2\2NP\3\2\2\2OM\3\2\2\2PQ"+
		"\7\21\2\2Q\r\3\2\2\2RS\7\6\2\2SU\7\f\2\2TV\5\20\t\2UT\3\2\2\2UV\3\2\2"+
		"\2VZ\3\2\2\2WY\5\24\13\2XW\3\2\2\2Y\\\3\2\2\2ZX\3\2\2\2Z[\3\2\2\2[]\3"+
		"\2\2\2\\Z\3\2\2\2]^\7\21\2\2^\17\3\2\2\2_`\7\20\2\2`a\7\t\2\2ab\7\23\2"+
		"\2bc\7\n\2\2c\21\3\2\2\2de\7\3\2\2ef\7\t\2\2fg\7\23\2\2gh\7\n\2\2h\23"+
		"\3\2\2\2il\5\32\16\2jl\5\34\17\2ki\3\2\2\2kj\3\2\2\2lm\3\2\2\2mo\7\24"+
		"\2\2np\5\30\r\2on\3\2\2\2op\3\2\2\2pq\3\2\2\2qr\7\n\2\2r\25\3\2\2\2sv"+
		"\7\13\2\2tw\5\32\16\2uw\5\34\17\2vt\3\2\2\2vu\3\2\2\2wx\3\2\2\2xz\7\24"+
		"\2\2y{\5\30\r\2zy\3\2\2\2z{\3\2\2\2{|\3\2\2\2|}\7\n\2\2}\27\3\2\2\2~\177"+
		"\7\t\2\2\177\u0080\t\2\2\2\u0080\31\3\2\2\2\u0081\u0082\7\7\2\2\u0082"+
		"\u0083\7\b\2\2\u0083\u0084\5\34\17\2\u0084\u0085\7\r\2\2\u0085\33\3\2"+
		"\2\2\u0086\u008b\7\24\2\2\u0087\u0088\7\5\2\2\u0088\u008a\7\24\2\2\u0089"+
		"\u0087\3\2\2\2\u008a\u008d\3\2\2\2\u008b\u0089\3\2\2\2\u008b\u008c\3\2"+
		"\2\2\u008c\35\3\2\2\2\u008d\u008b\3\2\2\2\20!%*<>HMUZkovz\u008b";
	public static final ATN _ATN =
		ATNSimulator.deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}