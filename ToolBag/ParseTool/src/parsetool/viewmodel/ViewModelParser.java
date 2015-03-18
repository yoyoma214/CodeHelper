// Generated from D:\workspace\20140311\ToolBag\ParseTool\src\parsetool\viewmodel\ViewModel.g4 by ANTLR 4.1
package parsetool.viewmodel;
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.misc.*;
import org.antlr.v4.runtime.tree.*;
import java.util.List;
import java.util.Iterator;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class ViewModelParser extends Parser {
	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		T__46=1, T__45=2, T__44=3, T__43=4, T__42=5, T__41=6, T__40=7, T__39=8, 
		T__38=9, T__37=10, T__36=11, T__35=12, T__34=13, T__33=14, T__32=15, T__31=16, 
		T__30=17, T__29=18, T__28=19, T__27=20, T__26=21, T__25=22, T__24=23, 
		T__23=24, T__22=25, T__21=26, T__20=27, T__19=28, T__18=29, T__17=30, 
		T__16=31, T__15=32, T__14=33, T__13=34, T__12=35, T__11=36, T__10=37, 
		T__9=38, T__8=39, T__7=40, T__6=41, T__5=42, T__4=43, T__3=44, T__2=45, 
		T__1=46, T__0=47, BOOL_LITERAL=48, IDENTIFIER=49, CHARACTER_LITERAL=50, 
		STRING_LITERAL=51, HEX_LITERAL=52, DECIMAL_LITERAL=53, OCTAL_LITERAL=54, 
		FLOATING_POINT_LITERAL=55, WS=56, COMMENT=57, LINE_COMMENT=58, LINE_COMMAND=59;
	public static final String[] tokenNames = {
		"<INVALID>", "']'", "'<<='", "'&'", "'-='", "','", "'*'", "'-'", "'<=='", 
		"'['", "':'", "'==>'", "'('", "'&='", "'--'", "'<'", "'!='", "'<='", "'?'", 
		"'<<'", "'>>='", "'{'", "'+='", "'^='", "'}'", "'++'", "'>>'", "'%'", 
		"'^'", "'*='", "'.'", "')'", "'+'", "'='", "';'", "'&&'", "'||'", "'>'", 
		"'%='", "'/='", "'|='", "'/'", "'=='", "'~'", "'class'", "'>='", "'|'", 
		"'!'", "BOOL_LITERAL", "IDENTIFIER", "CHARACTER_LITERAL", "STRING_LITERAL", 
		"HEX_LITERAL", "DECIMAL_LITERAL", "OCTAL_LITERAL", "FLOATING_POINT_LITERAL", 
		"WS", "COMMENT", "LINE_COMMENT", "LINE_COMMAND"
	};
	public static final int
		RULE_program = 0, RULE_model = 1, RULE_model_name = 2, RULE_model_area = 3, 
		RULE_state = 4, RULE_push = 5, RULE_pull = 6, RULE_field = 7, RULE_declare = 8, 
		RULE_variable_name = 9, RULE_option_list = 10, RULE_option = 11, RULE_option_name = 12, 
		RULE_option_value = 13, RULE_attribute = 14, RULE_attribute_name = 15, 
		RULE_attribute_value = 16, RULE_statement = 17, RULE_declare_statement = 18, 
		RULE_argument_expression_list = 19, RULE_additive_expression = 20, RULE_additive_expression_operator = 21, 
		RULE_multiplicative_expression = 22, RULE_multiplicative_expression_operator = 23, 
		RULE_cast_expression = 24, RULE_unary_expression = 25, RULE_unary_expression_one_char = 26, 
		RULE_unary_expression_two_char = 27, RULE_unary_expression_operator = 28, 
		RULE_postfix_expression = 29, RULE_postfix_part = 30, RULE_postfix_part_index = 31, 
		RULE_postfix_part_empty_function = 32, RULE_postfix_part_function = 33, 
		RULE_postfix_part_long_name = 34, RULE_postfix_part_increase = 35, RULE_postfix_part_decrease = 36, 
		RULE_unary_operator = 37, RULE_primary_expression = 38, RULE_constant = 39, 
		RULE_expression = 40, RULE_constant_expression = 41, RULE_assignment_expression = 42, 
		RULE_lvalue = 43, RULE_assignment_operator = 44, RULE_conditional_expression = 45, 
		RULE_logical_or_expression = 46, RULE_logical_and_expression = 47, RULE_inclusive_or_expression = 48, 
		RULE_exclusive_or_expression = 49, RULE_and_expression = 50, RULE_equality_expression = 51, 
		RULE_equality_expression_operator = 52, RULE_relational_expression = 53, 
		RULE_relational_expression_operator = 54, RULE_shift_expression = 55, 
		RULE_shift_expression_operator = 56, RULE_type_name = 57;
	public static final String[] ruleNames = {
		"program", "model", "model_name", "model_area", "state", "push", "pull", 
		"field", "declare", "variable_name", "option_list", "option", "option_name", 
		"option_value", "attribute", "attribute_name", "attribute_value", "statement", 
		"declare_statement", "argument_expression_list", "additive_expression", 
		"additive_expression_operator", "multiplicative_expression", "multiplicative_expression_operator", 
		"cast_expression", "unary_expression", "unary_expression_one_char", "unary_expression_two_char", 
		"unary_expression_operator", "postfix_expression", "postfix_part", "postfix_part_index", 
		"postfix_part_empty_function", "postfix_part_function", "postfix_part_long_name", 
		"postfix_part_increase", "postfix_part_decrease", "unary_operator", "primary_expression", 
		"constant", "expression", "constant_expression", "assignment_expression", 
		"lvalue", "assignment_operator", "conditional_expression", "logical_or_expression", 
		"logical_and_expression", "inclusive_or_expression", "exclusive_or_expression", 
		"and_expression", "equality_expression", "equality_expression_operator", 
		"relational_expression", "relational_expression_operator", "shift_expression", 
		"shift_expression_operator", "type_name"
	};

	@Override
	public String getGrammarFileName() { return "ViewModel.g4"; }

	@Override
	public String[] getTokenNames() { return tokenNames; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public ATN getATN() { return _ATN; }

	public ViewModelParser(TokenStream input) {
		super(input);
		_interp = new ParserATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}
	public static class ProgramContext extends ParserRuleContext {
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
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterProgram(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitProgram(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitProgram(this);
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
			setState(119);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==IDENTIFIER) {
				{
				{
				setState(116); model();
				}
				}
				setState(121);
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

	public static class ModelContext extends ParserRuleContext {
		public List<AttributeContext> attribute() {
			return getRuleContexts(AttributeContext.class);
		}
		public FieldContext field(int i) {
			return getRuleContext(FieldContext.class,i);
		}
		public AttributeContext attribute(int i) {
			return getRuleContext(AttributeContext.class,i);
		}
		public Model_areaContext model_area() {
			return getRuleContext(Model_areaContext.class,0);
		}
		public List<FieldContext> field() {
			return getRuleContexts(FieldContext.class);
		}
		public StateContext state() {
			return getRuleContext(StateContext.class,0);
		}
		public Model_nameContext model_name() {
			return getRuleContext(Model_nameContext.class,0);
		}
		public ModelContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_model; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterModel(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitModel(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitModel(this);
			else return visitor.visitChildren(this);
		}
	}

	public final ModelContext model() throws RecognitionException {
		ModelContext _localctx = new ModelContext(_ctx, getState());
		enterRule(_localctx, 2, RULE_model);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(122); model_area();
			setState(123); match(10);
			setState(127);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==9) {
				{
				{
				setState(124); attribute();
				}
				}
				setState(129);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(130); match(44);
			setState(131); model_name();
			setState(132); match(21);
			setState(136);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==IDENTIFIER) {
				{
				{
				setState(133); field();
				}
				}
				setState(138);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(139); match(24);
			setState(140); state();
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

	public static class Model_nameContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(ViewModelParser.IDENTIFIER, 0); }
		public Model_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_model_name; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterModel_name(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitModel_name(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitModel_name(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Model_nameContext model_name() throws RecognitionException {
		Model_nameContext _localctx = new Model_nameContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_model_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(142); match(IDENTIFIER);
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

	public static class Model_areaContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(ViewModelParser.IDENTIFIER, 0); }
		public Model_areaContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_model_area; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterModel_area(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitModel_area(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitModel_area(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Model_areaContext model_area() throws RecognitionException {
		Model_areaContext _localctx = new Model_areaContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_model_area);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(144); match(IDENTIFIER);
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

	public static class StateContext extends ParserRuleContext {
		public List<StatementContext> statement() {
			return getRuleContexts(StatementContext.class);
		}
		public StatementContext statement(int i) {
			return getRuleContext(StatementContext.class,i);
		}
		public StateContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_state; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterState(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitState(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitState(this);
			else return visitor.visitChildren(this);
		}
	}

	public final StateContext state() throws RecognitionException {
		StateContext _localctx = new StateContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_state);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(149);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,3,_ctx);
			while ( _alt!=2 && _alt!=-1 ) {
				if ( _alt==1 ) {
					{
					{
					setState(146); statement();
					}
					} 
				}
				setState(151);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,3,_ctx);
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

	public static class PushContext extends ParserRuleContext {
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public StateContext state() {
			return getRuleContext(StateContext.class,0);
		}
		public PushContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_push; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterPush(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitPush(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitPush(this);
			else return visitor.visitChildren(this);
		}
	}

	public final PushContext push() throws RecognitionException {
		PushContext _localctx = new PushContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_push);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(152); expression();
			setState(153); match(11);
			setState(154); match(21);
			setState(155); state();
			setState(156); match(24);
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

	public static class PullContext extends ParserRuleContext {
		public LvalueContext lvalue() {
			return getRuleContext(LvalueContext.class,0);
		}
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public PullContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_pull; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterPull(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitPull(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitPull(this);
			else return visitor.visitChildren(this);
		}
	}

	public final PullContext pull() throws RecognitionException {
		PullContext _localctx = new PullContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_pull);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(158); lvalue();
			setState(159); match(8);
			setState(160); expression();
			setState(161); match(34);
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
		public DeclareContext declare() {
			return getRuleContext(DeclareContext.class,0);
		}
		public Option_listContext option_list() {
			return getRuleContext(Option_listContext.class,0);
		}
		public FieldContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_field; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterField(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitField(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitField(this);
			else return visitor.visitChildren(this);
		}
	}

	public final FieldContext field() throws RecognitionException {
		FieldContext _localctx = new FieldContext(_ctx, getState());
		enterRule(_localctx, 14, RULE_field);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(163); declare();
			setState(165);
			_la = _input.LA(1);
			if (_la==21) {
				{
				setState(164); option_list();
				}
			}

			setState(167); match(34);
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

	public static class DeclareContext extends ParserRuleContext {
		public Type_nameContext type_name() {
			return getRuleContext(Type_nameContext.class,0);
		}
		public Variable_nameContext variable_name() {
			return getRuleContext(Variable_nameContext.class,0);
		}
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public DeclareContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_declare; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterDeclare(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitDeclare(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitDeclare(this);
			else return visitor.visitChildren(this);
		}
	}

	public final DeclareContext declare() throws RecognitionException {
		DeclareContext _localctx = new DeclareContext(_ctx, getState());
		enterRule(_localctx, 16, RULE_declare);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(169); type_name();
			setState(170); variable_name();
			setState(173);
			_la = _input.LA(1);
			if (_la==33) {
				{
				setState(171); match(33);
				setState(172); expression();
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

	public static class Variable_nameContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(ViewModelParser.IDENTIFIER, 0); }
		public Variable_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_variable_name; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterVariable_name(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitVariable_name(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitVariable_name(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Variable_nameContext variable_name() throws RecognitionException {
		Variable_nameContext _localctx = new Variable_nameContext(_ctx, getState());
		enterRule(_localctx, 18, RULE_variable_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(175); match(IDENTIFIER);
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

	public static class Option_listContext extends ParserRuleContext {
		public List<OptionContext> option() {
			return getRuleContexts(OptionContext.class);
		}
		public OptionContext option(int i) {
			return getRuleContext(OptionContext.class,i);
		}
		public Option_listContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_option_list; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterOption_list(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitOption_list(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitOption_list(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Option_listContext option_list() throws RecognitionException {
		Option_listContext _localctx = new Option_listContext(_ctx, getState());
		enterRule(_localctx, 20, RULE_option_list);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(177); match(21);
			setState(181);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==IDENTIFIER) {
				{
				{
				setState(178); option();
				}
				}
				setState(183);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(184); match(24);
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

	public static class OptionContext extends ParserRuleContext {
		public Option_valueContext option_value() {
			return getRuleContext(Option_valueContext.class,0);
		}
		public Option_nameContext option_name() {
			return getRuleContext(Option_nameContext.class,0);
		}
		public OptionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_option; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterOption(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitOption(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitOption(this);
			else return visitor.visitChildren(this);
		}
	}

	public final OptionContext option() throws RecognitionException {
		OptionContext _localctx = new OptionContext(_ctx, getState());
		enterRule(_localctx, 22, RULE_option);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(186); option_name();
			setState(187); match(33);
			setState(188); option_value();
			setState(190);
			_la = _input.LA(1);
			if (_la==5) {
				{
				setState(189); match(5);
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

	public static class Option_nameContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(ViewModelParser.IDENTIFIER, 0); }
		public Option_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_option_name; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterOption_name(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitOption_name(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitOption_name(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Option_nameContext option_name() throws RecognitionException {
		Option_nameContext _localctx = new Option_nameContext(_ctx, getState());
		enterRule(_localctx, 24, RULE_option_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(192); match(IDENTIFIER);
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

	public static class Option_valueContext extends ParserRuleContext {
		public TerminalNode STRING_LITERAL() { return getToken(ViewModelParser.STRING_LITERAL, 0); }
		public Option_valueContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_option_value; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterOption_value(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitOption_value(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitOption_value(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Option_valueContext option_value() throws RecognitionException {
		Option_valueContext _localctx = new Option_valueContext(_ctx, getState());
		enterRule(_localctx, 26, RULE_option_value);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(194); match(STRING_LITERAL);
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
		public Attribute_valueContext attribute_value() {
			return getRuleContext(Attribute_valueContext.class,0);
		}
		public Attribute_nameContext attribute_name() {
			return getRuleContext(Attribute_nameContext.class,0);
		}
		public AttributeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_attribute; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterAttribute(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitAttribute(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitAttribute(this);
			else return visitor.visitChildren(this);
		}
	}

	public final AttributeContext attribute() throws RecognitionException {
		AttributeContext _localctx = new AttributeContext(_ctx, getState());
		enterRule(_localctx, 28, RULE_attribute);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(196); match(9);
			setState(197); attribute_name();
			setState(198); match(12);
			setState(199); attribute_value();
			setState(200); match(31);
			setState(201); match(1);
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

	public static class Attribute_nameContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(ViewModelParser.IDENTIFIER, 0); }
		public Attribute_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_attribute_name; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterAttribute_name(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitAttribute_name(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitAttribute_name(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Attribute_nameContext attribute_name() throws RecognitionException {
		Attribute_nameContext _localctx = new Attribute_nameContext(_ctx, getState());
		enterRule(_localctx, 30, RULE_attribute_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(203); match(IDENTIFIER);
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

	public static class Attribute_valueContext extends ParserRuleContext {
		public TerminalNode STRING_LITERAL() { return getToken(ViewModelParser.STRING_LITERAL, 0); }
		public Attribute_valueContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_attribute_value; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterAttribute_value(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitAttribute_value(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitAttribute_value(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Attribute_valueContext attribute_value() throws RecognitionException {
		Attribute_valueContext _localctx = new Attribute_valueContext(_ctx, getState());
		enterRule(_localctx, 32, RULE_attribute_value);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(205); match(STRING_LITERAL);
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

	public static class StatementContext extends ParserRuleContext {
		public PushContext push() {
			return getRuleContext(PushContext.class,0);
		}
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public PullContext pull() {
			return getRuleContext(PullContext.class,0);
		}
		public Declare_statementContext declare_statement() {
			return getRuleContext(Declare_statementContext.class,0);
		}
		public StatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_statement; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterStatement(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitStatement(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitStatement(this);
			else return visitor.visitChildren(this);
		}
	}

	public final StatementContext statement() throws RecognitionException {
		StatementContext _localctx = new StatementContext(_ctx, getState());
		enterRule(_localctx, 34, RULE_statement);
		try {
			setState(214);
			switch ( getInterpreter().adaptivePredict(_input,8,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(207); expression();
				setState(208); match(34);
				}
				break;

			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(210); declare_statement();
				}
				break;

			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(211); push();
				}
				break;

			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(212); pull();
				}
				break;

			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(213); match(34);
				}
				break;
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

	public static class Declare_statementContext extends ParserRuleContext {
		public DeclareContext declare() {
			return getRuleContext(DeclareContext.class,0);
		}
		public Declare_statementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_declare_statement; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterDeclare_statement(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitDeclare_statement(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitDeclare_statement(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Declare_statementContext declare_statement() throws RecognitionException {
		Declare_statementContext _localctx = new Declare_statementContext(_ctx, getState());
		enterRule(_localctx, 36, RULE_declare_statement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(216); declare();
			setState(217); match(34);
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

	public static class Argument_expression_listContext extends ParserRuleContext {
		public List<Assignment_expressionContext> assignment_expression() {
			return getRuleContexts(Assignment_expressionContext.class);
		}
		public Assignment_expressionContext assignment_expression(int i) {
			return getRuleContext(Assignment_expressionContext.class,i);
		}
		public Argument_expression_listContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_argument_expression_list; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterArgument_expression_list(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitArgument_expression_list(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitArgument_expression_list(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Argument_expression_listContext argument_expression_list() throws RecognitionException {
		Argument_expression_listContext _localctx = new Argument_expression_listContext(_ctx, getState());
		enterRule(_localctx, 38, RULE_argument_expression_list);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(219); assignment_expression();
			setState(224);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==5) {
				{
				{
				setState(220); match(5);
				setState(221); assignment_expression();
				}
				}
				setState(226);
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

	public static class Additive_expressionContext extends ParserRuleContext {
		public Multiplicative_expressionContext multiplicative_expression(int i) {
			return getRuleContext(Multiplicative_expressionContext.class,i);
		}
		public Additive_expression_operatorContext additive_expression_operator(int i) {
			return getRuleContext(Additive_expression_operatorContext.class,i);
		}
		public List<Additive_expression_operatorContext> additive_expression_operator() {
			return getRuleContexts(Additive_expression_operatorContext.class);
		}
		public List<Multiplicative_expressionContext> multiplicative_expression() {
			return getRuleContexts(Multiplicative_expressionContext.class);
		}
		public Additive_expressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_additive_expression; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterAdditive_expression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitAdditive_expression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitAdditive_expression(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Additive_expressionContext additive_expression() throws RecognitionException {
		Additive_expressionContext _localctx = new Additive_expressionContext(_ctx, getState());
		enterRule(_localctx, 40, RULE_additive_expression);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			{
			setState(227); multiplicative_expression();
			}
			setState(233);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==7 || _la==32) {
				{
				{
				setState(228); additive_expression_operator();
				setState(229); multiplicative_expression();
				}
				}
				setState(235);
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

	public static class Additive_expression_operatorContext extends ParserRuleContext {
		public Additive_expression_operatorContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_additive_expression_operator; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterAdditive_expression_operator(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitAdditive_expression_operator(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitAdditive_expression_operator(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Additive_expression_operatorContext additive_expression_operator() throws RecognitionException {
		Additive_expression_operatorContext _localctx = new Additive_expression_operatorContext(_ctx, getState());
		enterRule(_localctx, 42, RULE_additive_expression_operator);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(236);
			_la = _input.LA(1);
			if ( !(_la==7 || _la==32) ) {
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

	public static class Multiplicative_expressionContext extends ParserRuleContext {
		public List<Multiplicative_expression_operatorContext> multiplicative_expression_operator() {
			return getRuleContexts(Multiplicative_expression_operatorContext.class);
		}
		public List<Cast_expressionContext> cast_expression() {
			return getRuleContexts(Cast_expressionContext.class);
		}
		public Multiplicative_expression_operatorContext multiplicative_expression_operator(int i) {
			return getRuleContext(Multiplicative_expression_operatorContext.class,i);
		}
		public Cast_expressionContext cast_expression(int i) {
			return getRuleContext(Cast_expressionContext.class,i);
		}
		public Multiplicative_expressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_multiplicative_expression; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterMultiplicative_expression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitMultiplicative_expression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitMultiplicative_expression(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Multiplicative_expressionContext multiplicative_expression() throws RecognitionException {
		Multiplicative_expressionContext _localctx = new Multiplicative_expressionContext(_ctx, getState());
		enterRule(_localctx, 44, RULE_multiplicative_expression);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			{
			setState(238); cast_expression();
			}
			setState(244);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << 6) | (1L << 27) | (1L << 41))) != 0)) {
				{
				{
				setState(239); multiplicative_expression_operator();
				setState(240); cast_expression();
				}
				}
				setState(246);
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

	public static class Multiplicative_expression_operatorContext extends ParserRuleContext {
		public Multiplicative_expression_operatorContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_multiplicative_expression_operator; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterMultiplicative_expression_operator(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitMultiplicative_expression_operator(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitMultiplicative_expression_operator(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Multiplicative_expression_operatorContext multiplicative_expression_operator() throws RecognitionException {
		Multiplicative_expression_operatorContext _localctx = new Multiplicative_expression_operatorContext(_ctx, getState());
		enterRule(_localctx, 46, RULE_multiplicative_expression_operator);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(247);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << 6) | (1L << 27) | (1L << 41))) != 0)) ) {
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

	public static class Cast_expressionContext extends ParserRuleContext {
		public Cast_expressionContext cast_expression() {
			return getRuleContext(Cast_expressionContext.class,0);
		}
		public Unary_expressionContext unary_expression() {
			return getRuleContext(Unary_expressionContext.class,0);
		}
		public Type_nameContext type_name() {
			return getRuleContext(Type_nameContext.class,0);
		}
		public Cast_expressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_cast_expression; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterCast_expression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitCast_expression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitCast_expression(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Cast_expressionContext cast_expression() throws RecognitionException {
		Cast_expressionContext _localctx = new Cast_expressionContext(_ctx, getState());
		enterRule(_localctx, 48, RULE_cast_expression);
		try {
			setState(255);
			switch ( getInterpreter().adaptivePredict(_input,12,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(249); match(12);
				setState(250); type_name();
				setState(251); match(31);
				setState(252); cast_expression();
				}
				break;

			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(254); unary_expression();
				}
				break;
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

	public static class Unary_expressionContext extends ParserRuleContext {
		public Unary_expression_two_charContext unary_expression_two_char() {
			return getRuleContext(Unary_expression_two_charContext.class,0);
		}
		public Unary_expression_one_charContext unary_expression_one_char() {
			return getRuleContext(Unary_expression_one_charContext.class,0);
		}
		public Postfix_expressionContext postfix_expression() {
			return getRuleContext(Postfix_expressionContext.class,0);
		}
		public Unary_expressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_unary_expression; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterUnary_expression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitUnary_expression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitUnary_expression(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Unary_expressionContext unary_expression() throws RecognitionException {
		Unary_expressionContext _localctx = new Unary_expressionContext(_ctx, getState());
		enterRule(_localctx, 50, RULE_unary_expression);
		try {
			setState(260);
			switch (_input.LA(1)) {
			case 12:
			case BOOL_LITERAL:
			case IDENTIFIER:
			case CHARACTER_LITERAL:
			case STRING_LITERAL:
			case HEX_LITERAL:
			case DECIMAL_LITERAL:
			case OCTAL_LITERAL:
			case FLOATING_POINT_LITERAL:
				enterOuterAlt(_localctx, 1);
				{
				setState(257); postfix_expression();
				}
				break;
			case 14:
			case 25:
				enterOuterAlt(_localctx, 2);
				{
				setState(258); unary_expression_two_char();
				}
				break;
			case 3:
			case 6:
			case 7:
			case 32:
			case 43:
			case 47:
				enterOuterAlt(_localctx, 3);
				{
				setState(259); unary_expression_one_char();
				}
				break;
			default:
				throw new NoViableAltException(this);
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

	public static class Unary_expression_one_charContext extends ParserRuleContext {
		public Cast_expressionContext cast_expression() {
			return getRuleContext(Cast_expressionContext.class,0);
		}
		public Unary_operatorContext unary_operator() {
			return getRuleContext(Unary_operatorContext.class,0);
		}
		public Unary_expression_one_charContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_unary_expression_one_char; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterUnary_expression_one_char(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitUnary_expression_one_char(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitUnary_expression_one_char(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Unary_expression_one_charContext unary_expression_one_char() throws RecognitionException {
		Unary_expression_one_charContext _localctx = new Unary_expression_one_charContext(_ctx, getState());
		enterRule(_localctx, 52, RULE_unary_expression_one_char);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(262); unary_operator();
			setState(263); cast_expression();
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

	public static class Unary_expression_two_charContext extends ParserRuleContext {
		public Unary_expression_operatorContext unary_expression_operator() {
			return getRuleContext(Unary_expression_operatorContext.class,0);
		}
		public Unary_expressionContext unary_expression() {
			return getRuleContext(Unary_expressionContext.class,0);
		}
		public Unary_expression_two_charContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_unary_expression_two_char; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterUnary_expression_two_char(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitUnary_expression_two_char(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitUnary_expression_two_char(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Unary_expression_two_charContext unary_expression_two_char() throws RecognitionException {
		Unary_expression_two_charContext _localctx = new Unary_expression_two_charContext(_ctx, getState());
		enterRule(_localctx, 54, RULE_unary_expression_two_char);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(265); unary_expression_operator();
			setState(266); unary_expression();
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

	public static class Unary_expression_operatorContext extends ParserRuleContext {
		public Unary_expression_operatorContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_unary_expression_operator; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterUnary_expression_operator(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitUnary_expression_operator(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitUnary_expression_operator(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Unary_expression_operatorContext unary_expression_operator() throws RecognitionException {
		Unary_expression_operatorContext _localctx = new Unary_expression_operatorContext(_ctx, getState());
		enterRule(_localctx, 56, RULE_unary_expression_operator);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(268);
			_la = _input.LA(1);
			if ( !(_la==14 || _la==25) ) {
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

	public static class Postfix_expressionContext extends ParserRuleContext {
		public List<Postfix_partContext> postfix_part() {
			return getRuleContexts(Postfix_partContext.class);
		}
		public Postfix_partContext postfix_part(int i) {
			return getRuleContext(Postfix_partContext.class,i);
		}
		public Primary_expressionContext primary_expression() {
			return getRuleContext(Primary_expressionContext.class,0);
		}
		public Postfix_expressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_postfix_expression; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterPostfix_expression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitPostfix_expression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitPostfix_expression(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Postfix_expressionContext postfix_expression() throws RecognitionException {
		Postfix_expressionContext _localctx = new Postfix_expressionContext(_ctx, getState());
		enterRule(_localctx, 58, RULE_postfix_expression);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(270); primary_expression();
			setState(274);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << 9) | (1L << 12) | (1L << 14) | (1L << 25) | (1L << 30))) != 0)) {
				{
				{
				setState(271); postfix_part();
				}
				}
				setState(276);
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

	public static class Postfix_partContext extends ParserRuleContext {
		public Postfix_part_decreaseContext postfix_part_decrease() {
			return getRuleContext(Postfix_part_decreaseContext.class,0);
		}
		public Postfix_part_long_nameContext postfix_part_long_name() {
			return getRuleContext(Postfix_part_long_nameContext.class,0);
		}
		public Postfix_part_increaseContext postfix_part_increase() {
			return getRuleContext(Postfix_part_increaseContext.class,0);
		}
		public Postfix_part_functionContext postfix_part_function() {
			return getRuleContext(Postfix_part_functionContext.class,0);
		}
		public Postfix_part_empty_functionContext postfix_part_empty_function() {
			return getRuleContext(Postfix_part_empty_functionContext.class,0);
		}
		public Postfix_part_indexContext postfix_part_index() {
			return getRuleContext(Postfix_part_indexContext.class,0);
		}
		public Postfix_partContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_postfix_part; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterPostfix_part(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitPostfix_part(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitPostfix_part(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Postfix_partContext postfix_part() throws RecognitionException {
		Postfix_partContext _localctx = new Postfix_partContext(_ctx, getState());
		enterRule(_localctx, 60, RULE_postfix_part);
		try {
			setState(283);
			switch ( getInterpreter().adaptivePredict(_input,15,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(277); postfix_part_index();
				}
				break;

			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(278); postfix_part_empty_function();
				}
				break;

			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(279); postfix_part_function();
				}
				break;

			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(280); postfix_part_long_name();
				}
				break;

			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(281); postfix_part_increase();
				}
				break;

			case 6:
				enterOuterAlt(_localctx, 6);
				{
				setState(282); postfix_part_decrease();
				}
				break;
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

	public static class Postfix_part_indexContext extends ParserRuleContext {
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public Postfix_part_indexContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_postfix_part_index; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterPostfix_part_index(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitPostfix_part_index(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitPostfix_part_index(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Postfix_part_indexContext postfix_part_index() throws RecognitionException {
		Postfix_part_indexContext _localctx = new Postfix_part_indexContext(_ctx, getState());
		enterRule(_localctx, 62, RULE_postfix_part_index);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(285); match(9);
			setState(286); expression();
			setState(287); match(1);
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

	public static class Postfix_part_empty_functionContext extends ParserRuleContext {
		public Postfix_part_empty_functionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_postfix_part_empty_function; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterPostfix_part_empty_function(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitPostfix_part_empty_function(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitPostfix_part_empty_function(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Postfix_part_empty_functionContext postfix_part_empty_function() throws RecognitionException {
		Postfix_part_empty_functionContext _localctx = new Postfix_part_empty_functionContext(_ctx, getState());
		enterRule(_localctx, 64, RULE_postfix_part_empty_function);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(289); match(12);
			setState(290); match(31);
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

	public static class Postfix_part_functionContext extends ParserRuleContext {
		public Argument_expression_listContext argument_expression_list() {
			return getRuleContext(Argument_expression_listContext.class,0);
		}
		public Postfix_part_functionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_postfix_part_function; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterPostfix_part_function(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitPostfix_part_function(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitPostfix_part_function(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Postfix_part_functionContext postfix_part_function() throws RecognitionException {
		Postfix_part_functionContext _localctx = new Postfix_part_functionContext(_ctx, getState());
		enterRule(_localctx, 66, RULE_postfix_part_function);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(292); match(12);
			setState(293); argument_expression_list();
			setState(294); match(31);
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

	public static class Postfix_part_long_nameContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(ViewModelParser.IDENTIFIER, 0); }
		public Postfix_part_long_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_postfix_part_long_name; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterPostfix_part_long_name(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitPostfix_part_long_name(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitPostfix_part_long_name(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Postfix_part_long_nameContext postfix_part_long_name() throws RecognitionException {
		Postfix_part_long_nameContext _localctx = new Postfix_part_long_nameContext(_ctx, getState());
		enterRule(_localctx, 68, RULE_postfix_part_long_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(296); match(30);
			setState(297); match(IDENTIFIER);
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

	public static class Postfix_part_increaseContext extends ParserRuleContext {
		public Postfix_part_increaseContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_postfix_part_increase; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterPostfix_part_increase(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitPostfix_part_increase(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitPostfix_part_increase(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Postfix_part_increaseContext postfix_part_increase() throws RecognitionException {
		Postfix_part_increaseContext _localctx = new Postfix_part_increaseContext(_ctx, getState());
		enterRule(_localctx, 70, RULE_postfix_part_increase);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(299); match(25);
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

	public static class Postfix_part_decreaseContext extends ParserRuleContext {
		public Postfix_part_decreaseContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_postfix_part_decrease; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterPostfix_part_decrease(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitPostfix_part_decrease(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitPostfix_part_decrease(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Postfix_part_decreaseContext postfix_part_decrease() throws RecognitionException {
		Postfix_part_decreaseContext _localctx = new Postfix_part_decreaseContext(_ctx, getState());
		enterRule(_localctx, 72, RULE_postfix_part_decrease);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(301); match(14);
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

	public static class Unary_operatorContext extends ParserRuleContext {
		public Unary_operatorContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_unary_operator; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterUnary_operator(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitUnary_operator(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitUnary_operator(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Unary_operatorContext unary_operator() throws RecognitionException {
		Unary_operatorContext _localctx = new Unary_operatorContext(_ctx, getState());
		enterRule(_localctx, 74, RULE_unary_operator);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(303);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << 3) | (1L << 6) | (1L << 7) | (1L << 32) | (1L << 43) | (1L << 47))) != 0)) ) {
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

	public static class Primary_expressionContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(ViewModelParser.IDENTIFIER, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public ConstantContext constant() {
			return getRuleContext(ConstantContext.class,0);
		}
		public Primary_expressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_primary_expression; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterPrimary_expression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitPrimary_expression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitPrimary_expression(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Primary_expressionContext primary_expression() throws RecognitionException {
		Primary_expressionContext _localctx = new Primary_expressionContext(_ctx, getState());
		enterRule(_localctx, 76, RULE_primary_expression);
		try {
			setState(311);
			switch (_input.LA(1)) {
			case IDENTIFIER:
				enterOuterAlt(_localctx, 1);
				{
				setState(305); match(IDENTIFIER);
				}
				break;
			case BOOL_LITERAL:
			case CHARACTER_LITERAL:
			case STRING_LITERAL:
			case HEX_LITERAL:
			case DECIMAL_LITERAL:
			case OCTAL_LITERAL:
			case FLOATING_POINT_LITERAL:
				enterOuterAlt(_localctx, 2);
				{
				setState(306); constant();
				}
				break;
			case 12:
				enterOuterAlt(_localctx, 3);
				{
				setState(307); match(12);
				setState(308); expression();
				setState(309); match(31);
				}
				break;
			default:
				throw new NoViableAltException(this);
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

	public static class ConstantContext extends ParserRuleContext {
		public TerminalNode OCTAL_LITERAL() { return getToken(ViewModelParser.OCTAL_LITERAL, 0); }
		public TerminalNode STRING_LITERAL() { return getToken(ViewModelParser.STRING_LITERAL, 0); }
		public TerminalNode DECIMAL_LITERAL() { return getToken(ViewModelParser.DECIMAL_LITERAL, 0); }
		public TerminalNode FLOATING_POINT_LITERAL() { return getToken(ViewModelParser.FLOATING_POINT_LITERAL, 0); }
		public TerminalNode CHARACTER_LITERAL() { return getToken(ViewModelParser.CHARACTER_LITERAL, 0); }
		public TerminalNode BOOL_LITERAL() { return getToken(ViewModelParser.BOOL_LITERAL, 0); }
		public TerminalNode HEX_LITERAL() { return getToken(ViewModelParser.HEX_LITERAL, 0); }
		public ConstantContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_constant; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterConstant(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitConstant(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitConstant(this);
			else return visitor.visitChildren(this);
		}
	}

	public final ConstantContext constant() throws RecognitionException {
		ConstantContext _localctx = new ConstantContext(_ctx, getState());
		enterRule(_localctx, 78, RULE_constant);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(313);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << BOOL_LITERAL) | (1L << CHARACTER_LITERAL) | (1L << STRING_LITERAL) | (1L << HEX_LITERAL) | (1L << DECIMAL_LITERAL) | (1L << OCTAL_LITERAL) | (1L << FLOATING_POINT_LITERAL))) != 0)) ) {
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

	public static class ExpressionContext extends ParserRuleContext {
		public List<Assignment_expressionContext> assignment_expression() {
			return getRuleContexts(Assignment_expressionContext.class);
		}
		public Assignment_expressionContext assignment_expression(int i) {
			return getRuleContext(Assignment_expressionContext.class,i);
		}
		public ExpressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_expression; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitExpression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitExpression(this);
			else return visitor.visitChildren(this);
		}
	}

	public final ExpressionContext expression() throws RecognitionException {
		ExpressionContext _localctx = new ExpressionContext(_ctx, getState());
		enterRule(_localctx, 80, RULE_expression);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(315); assignment_expression();
			setState(320);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==5) {
				{
				{
				setState(316); match(5);
				setState(317); assignment_expression();
				}
				}
				setState(322);
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

	public static class Constant_expressionContext extends ParserRuleContext {
		public Conditional_expressionContext conditional_expression() {
			return getRuleContext(Conditional_expressionContext.class,0);
		}
		public Constant_expressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_constant_expression; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterConstant_expression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitConstant_expression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitConstant_expression(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Constant_expressionContext constant_expression() throws RecognitionException {
		Constant_expressionContext _localctx = new Constant_expressionContext(_ctx, getState());
		enterRule(_localctx, 82, RULE_constant_expression);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(323); conditional_expression();
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

	public static class Assignment_expressionContext extends ParserRuleContext {
		public Assignment_expressionContext assignment_expression() {
			return getRuleContext(Assignment_expressionContext.class,0);
		}
		public LvalueContext lvalue() {
			return getRuleContext(LvalueContext.class,0);
		}
		public Assignment_operatorContext assignment_operator() {
			return getRuleContext(Assignment_operatorContext.class,0);
		}
		public Conditional_expressionContext conditional_expression() {
			return getRuleContext(Conditional_expressionContext.class,0);
		}
		public Assignment_expressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_assignment_expression; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterAssignment_expression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitAssignment_expression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitAssignment_expression(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Assignment_expressionContext assignment_expression() throws RecognitionException {
		Assignment_expressionContext _localctx = new Assignment_expressionContext(_ctx, getState());
		enterRule(_localctx, 84, RULE_assignment_expression);
		try {
			setState(330);
			switch ( getInterpreter().adaptivePredict(_input,18,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(325); lvalue();
				setState(326); assignment_operator();
				setState(327); assignment_expression();
				}
				break;

			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(329); conditional_expression();
				}
				break;
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

	public static class LvalueContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER(int i) {
			return getToken(ViewModelParser.IDENTIFIER, i);
		}
		public List<TerminalNode> IDENTIFIER() { return getTokens(ViewModelParser.IDENTIFIER); }
		public LvalueContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_lvalue; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterLvalue(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitLvalue(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitLvalue(this);
			else return visitor.visitChildren(this);
		}
	}

	public final LvalueContext lvalue() throws RecognitionException {
		LvalueContext _localctx = new LvalueContext(_ctx, getState());
		enterRule(_localctx, 86, RULE_lvalue);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(332); match(IDENTIFIER);
			setState(337);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==30) {
				{
				{
				setState(333); match(30);
				setState(334); match(IDENTIFIER);
				}
				}
				setState(339);
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

	public static class Assignment_operatorContext extends ParserRuleContext {
		public Assignment_operatorContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_assignment_operator; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterAssignment_operator(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitAssignment_operator(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitAssignment_operator(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Assignment_operatorContext assignment_operator() throws RecognitionException {
		Assignment_operatorContext _localctx = new Assignment_operatorContext(_ctx, getState());
		enterRule(_localctx, 88, RULE_assignment_operator);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(340);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << 2) | (1L << 4) | (1L << 13) | (1L << 20) | (1L << 22) | (1L << 23) | (1L << 29) | (1L << 33) | (1L << 38) | (1L << 39) | (1L << 40))) != 0)) ) {
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

	public static class Conditional_expressionContext extends ParserRuleContext {
		public Logical_or_expressionContext logical_or_expression() {
			return getRuleContext(Logical_or_expressionContext.class,0);
		}
		public Conditional_expressionContext conditional_expression() {
			return getRuleContext(Conditional_expressionContext.class,0);
		}
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public Conditional_expressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_conditional_expression; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterConditional_expression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitConditional_expression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitConditional_expression(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Conditional_expressionContext conditional_expression() throws RecognitionException {
		Conditional_expressionContext _localctx = new Conditional_expressionContext(_ctx, getState());
		enterRule(_localctx, 90, RULE_conditional_expression);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(342); logical_or_expression();
			setState(348);
			_la = _input.LA(1);
			if (_la==18) {
				{
				setState(343); match(18);
				setState(344); expression();
				setState(345); match(10);
				setState(346); conditional_expression();
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

	public static class Logical_or_expressionContext extends ParserRuleContext {
		public List<Logical_and_expressionContext> logical_and_expression() {
			return getRuleContexts(Logical_and_expressionContext.class);
		}
		public Logical_and_expressionContext logical_and_expression(int i) {
			return getRuleContext(Logical_and_expressionContext.class,i);
		}
		public Logical_or_expressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_logical_or_expression; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterLogical_or_expression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitLogical_or_expression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitLogical_or_expression(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Logical_or_expressionContext logical_or_expression() throws RecognitionException {
		Logical_or_expressionContext _localctx = new Logical_or_expressionContext(_ctx, getState());
		enterRule(_localctx, 92, RULE_logical_or_expression);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(350); logical_and_expression();
			setState(355);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==36) {
				{
				{
				setState(351); match(36);
				setState(352); logical_and_expression();
				}
				}
				setState(357);
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

	public static class Logical_and_expressionContext extends ParserRuleContext {
		public List<Inclusive_or_expressionContext> inclusive_or_expression() {
			return getRuleContexts(Inclusive_or_expressionContext.class);
		}
		public Inclusive_or_expressionContext inclusive_or_expression(int i) {
			return getRuleContext(Inclusive_or_expressionContext.class,i);
		}
		public Logical_and_expressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_logical_and_expression; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterLogical_and_expression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitLogical_and_expression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitLogical_and_expression(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Logical_and_expressionContext logical_and_expression() throws RecognitionException {
		Logical_and_expressionContext _localctx = new Logical_and_expressionContext(_ctx, getState());
		enterRule(_localctx, 94, RULE_logical_and_expression);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(358); inclusive_or_expression();
			setState(363);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==35) {
				{
				{
				setState(359); match(35);
				setState(360); inclusive_or_expression();
				}
				}
				setState(365);
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

	public static class Inclusive_or_expressionContext extends ParserRuleContext {
		public Exclusive_or_expressionContext exclusive_or_expression(int i) {
			return getRuleContext(Exclusive_or_expressionContext.class,i);
		}
		public List<Exclusive_or_expressionContext> exclusive_or_expression() {
			return getRuleContexts(Exclusive_or_expressionContext.class);
		}
		public Inclusive_or_expressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_inclusive_or_expression; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterInclusive_or_expression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitInclusive_or_expression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitInclusive_or_expression(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Inclusive_or_expressionContext inclusive_or_expression() throws RecognitionException {
		Inclusive_or_expressionContext _localctx = new Inclusive_or_expressionContext(_ctx, getState());
		enterRule(_localctx, 96, RULE_inclusive_or_expression);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(366); exclusive_or_expression();
			setState(371);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==46) {
				{
				{
				setState(367); match(46);
				setState(368); exclusive_or_expression();
				}
				}
				setState(373);
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

	public static class Exclusive_or_expressionContext extends ParserRuleContext {
		public And_expressionContext and_expression(int i) {
			return getRuleContext(And_expressionContext.class,i);
		}
		public List<And_expressionContext> and_expression() {
			return getRuleContexts(And_expressionContext.class);
		}
		public Exclusive_or_expressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_exclusive_or_expression; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterExclusive_or_expression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitExclusive_or_expression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitExclusive_or_expression(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Exclusive_or_expressionContext exclusive_or_expression() throws RecognitionException {
		Exclusive_or_expressionContext _localctx = new Exclusive_or_expressionContext(_ctx, getState());
		enterRule(_localctx, 98, RULE_exclusive_or_expression);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(374); and_expression();
			setState(379);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==28) {
				{
				{
				setState(375); match(28);
				setState(376); and_expression();
				}
				}
				setState(381);
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

	public static class And_expressionContext extends ParserRuleContext {
		public Equality_expressionContext equality_expression(int i) {
			return getRuleContext(Equality_expressionContext.class,i);
		}
		public List<Equality_expressionContext> equality_expression() {
			return getRuleContexts(Equality_expressionContext.class);
		}
		public And_expressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_and_expression; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterAnd_expression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitAnd_expression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitAnd_expression(this);
			else return visitor.visitChildren(this);
		}
	}

	public final And_expressionContext and_expression() throws RecognitionException {
		And_expressionContext _localctx = new And_expressionContext(_ctx, getState());
		enterRule(_localctx, 100, RULE_and_expression);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(382); equality_expression();
			setState(387);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==3) {
				{
				{
				setState(383); match(3);
				setState(384); equality_expression();
				}
				}
				setState(389);
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

	public static class Equality_expressionContext extends ParserRuleContext {
		public List<Equality_expression_operatorContext> equality_expression_operator() {
			return getRuleContexts(Equality_expression_operatorContext.class);
		}
		public List<Relational_expressionContext> relational_expression() {
			return getRuleContexts(Relational_expressionContext.class);
		}
		public Relational_expressionContext relational_expression(int i) {
			return getRuleContext(Relational_expressionContext.class,i);
		}
		public Equality_expression_operatorContext equality_expression_operator(int i) {
			return getRuleContext(Equality_expression_operatorContext.class,i);
		}
		public Equality_expressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_equality_expression; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterEquality_expression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitEquality_expression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitEquality_expression(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Equality_expressionContext equality_expression() throws RecognitionException {
		Equality_expressionContext _localctx = new Equality_expressionContext(_ctx, getState());
		enterRule(_localctx, 102, RULE_equality_expression);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(390); relational_expression();
			setState(396);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==16 || _la==42) {
				{
				{
				setState(391); equality_expression_operator();
				setState(392); relational_expression();
				}
				}
				setState(398);
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

	public static class Equality_expression_operatorContext extends ParserRuleContext {
		public Equality_expression_operatorContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_equality_expression_operator; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterEquality_expression_operator(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitEquality_expression_operator(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitEquality_expression_operator(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Equality_expression_operatorContext equality_expression_operator() throws RecognitionException {
		Equality_expression_operatorContext _localctx = new Equality_expression_operatorContext(_ctx, getState());
		enterRule(_localctx, 104, RULE_equality_expression_operator);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(399);
			_la = _input.LA(1);
			if ( !(_la==16 || _la==42) ) {
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

	public static class Relational_expressionContext extends ParserRuleContext {
		public List<Shift_expressionContext> shift_expression() {
			return getRuleContexts(Shift_expressionContext.class);
		}
		public Relational_expression_operatorContext relational_expression_operator(int i) {
			return getRuleContext(Relational_expression_operatorContext.class,i);
		}
		public List<Relational_expression_operatorContext> relational_expression_operator() {
			return getRuleContexts(Relational_expression_operatorContext.class);
		}
		public Shift_expressionContext shift_expression(int i) {
			return getRuleContext(Shift_expressionContext.class,i);
		}
		public Relational_expressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_relational_expression; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterRelational_expression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitRelational_expression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitRelational_expression(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Relational_expressionContext relational_expression() throws RecognitionException {
		Relational_expressionContext _localctx = new Relational_expressionContext(_ctx, getState());
		enterRule(_localctx, 106, RULE_relational_expression);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(401); shift_expression();
			setState(407);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << 15) | (1L << 17) | (1L << 37) | (1L << 45))) != 0)) {
				{
				{
				setState(402); relational_expression_operator();
				setState(403); shift_expression();
				}
				}
				setState(409);
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

	public static class Relational_expression_operatorContext extends ParserRuleContext {
		public Relational_expression_operatorContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_relational_expression_operator; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterRelational_expression_operator(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitRelational_expression_operator(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitRelational_expression_operator(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Relational_expression_operatorContext relational_expression_operator() throws RecognitionException {
		Relational_expression_operatorContext _localctx = new Relational_expression_operatorContext(_ctx, getState());
		enterRule(_localctx, 108, RULE_relational_expression_operator);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(410);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << 15) | (1L << 17) | (1L << 37) | (1L << 45))) != 0)) ) {
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

	public static class Shift_expressionContext extends ParserRuleContext {
		public List<Shift_expression_operatorContext> shift_expression_operator() {
			return getRuleContexts(Shift_expression_operatorContext.class);
		}
		public Additive_expressionContext additive_expression(int i) {
			return getRuleContext(Additive_expressionContext.class,i);
		}
		public Shift_expression_operatorContext shift_expression_operator(int i) {
			return getRuleContext(Shift_expression_operatorContext.class,i);
		}
		public List<Additive_expressionContext> additive_expression() {
			return getRuleContexts(Additive_expressionContext.class);
		}
		public Shift_expressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_shift_expression; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterShift_expression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitShift_expression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitShift_expression(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Shift_expressionContext shift_expression() throws RecognitionException {
		Shift_expressionContext _localctx = new Shift_expressionContext(_ctx, getState());
		enterRule(_localctx, 110, RULE_shift_expression);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(412); additive_expression();
			setState(418);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==19 || _la==26) {
				{
				{
				setState(413); shift_expression_operator();
				setState(414); additive_expression();
				}
				}
				setState(420);
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

	public static class Shift_expression_operatorContext extends ParserRuleContext {
		public Shift_expression_operatorContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_shift_expression_operator; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterShift_expression_operator(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitShift_expression_operator(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitShift_expression_operator(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Shift_expression_operatorContext shift_expression_operator() throws RecognitionException {
		Shift_expression_operatorContext _localctx = new Shift_expression_operatorContext(_ctx, getState());
		enterRule(_localctx, 112, RULE_shift_expression_operator);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(421);
			_la = _input.LA(1);
			if ( !(_la==19 || _la==26) ) {
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

	public static class Type_nameContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER(int i) {
			return getToken(ViewModelParser.IDENTIFIER, i);
		}
		public List<TerminalNode> IDENTIFIER() { return getTokens(ViewModelParser.IDENTIFIER); }
		public Type_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_type_name; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).enterType_name(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ViewModelListener ) ((ViewModelListener)listener).exitType_name(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof ViewModelVisitor ) return ((ViewModelVisitor<? extends T>)visitor).visitType_name(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Type_nameContext type_name() throws RecognitionException {
		Type_nameContext _localctx = new Type_nameContext(_ctx, getState());
		enterRule(_localctx, 114, RULE_type_name);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(423); match(IDENTIFIER);
			setState(428);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==30) {
				{
				{
				setState(424); match(30);
				setState(425); match(IDENTIFIER);
				}
				}
				setState(430);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(432);
			_la = _input.LA(1);
			if (_la==18) {
				{
				setState(431); match(18);
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

	public static final String _serializedATN =
		"\3\uacf5\uee8c\u4f5d\u8b0d\u4a45\u78bd\u1b2f\u3378\3=\u01b5\4\2\t\2\4"+
		"\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13\t"+
		"\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t \4!"+
		"\t!\4\"\t\"\4#\t#\4$\t$\4%\t%\4&\t&\4\'\t\'\4(\t(\4)\t)\4*\t*\4+\t+\4"+
		",\t,\4-\t-\4.\t.\4/\t/\4\60\t\60\4\61\t\61\4\62\t\62\4\63\t\63\4\64\t"+
		"\64\4\65\t\65\4\66\t\66\4\67\t\67\48\t8\49\t9\4:\t:\4;\t;\3\2\7\2x\n\2"+
		"\f\2\16\2{\13\2\3\3\3\3\3\3\7\3\u0080\n\3\f\3\16\3\u0083\13\3\3\3\3\3"+
		"\3\3\3\3\7\3\u0089\n\3\f\3\16\3\u008c\13\3\3\3\3\3\3\3\3\4\3\4\3\5\3\5"+
		"\3\6\7\6\u0096\n\6\f\6\16\6\u0099\13\6\3\7\3\7\3\7\3\7\3\7\3\7\3\b\3\b"+
		"\3\b\3\b\3\b\3\t\3\t\5\t\u00a8\n\t\3\t\3\t\3\n\3\n\3\n\3\n\5\n\u00b0\n"+
		"\n\3\13\3\13\3\f\3\f\7\f\u00b6\n\f\f\f\16\f\u00b9\13\f\3\f\3\f\3\r\3\r"+
		"\3\r\3\r\5\r\u00c1\n\r\3\16\3\16\3\17\3\17\3\20\3\20\3\20\3\20\3\20\3"+
		"\20\3\20\3\21\3\21\3\22\3\22\3\23\3\23\3\23\3\23\3\23\3\23\3\23\5\23\u00d9"+
		"\n\23\3\24\3\24\3\24\3\25\3\25\3\25\7\25\u00e1\n\25\f\25\16\25\u00e4\13"+
		"\25\3\26\3\26\3\26\3\26\7\26\u00ea\n\26\f\26\16\26\u00ed\13\26\3\27\3"+
		"\27\3\30\3\30\3\30\3\30\7\30\u00f5\n\30\f\30\16\30\u00f8\13\30\3\31\3"+
		"\31\3\32\3\32\3\32\3\32\3\32\3\32\5\32\u0102\n\32\3\33\3\33\3\33\5\33"+
		"\u0107\n\33\3\34\3\34\3\34\3\35\3\35\3\35\3\36\3\36\3\37\3\37\7\37\u0113"+
		"\n\37\f\37\16\37\u0116\13\37\3 \3 \3 \3 \3 \3 \5 \u011e\n \3!\3!\3!\3"+
		"!\3\"\3\"\3\"\3#\3#\3#\3#\3$\3$\3$\3%\3%\3&\3&\3\'\3\'\3(\3(\3(\3(\3("+
		"\3(\5(\u013a\n(\3)\3)\3*\3*\3*\7*\u0141\n*\f*\16*\u0144\13*\3+\3+\3,\3"+
		",\3,\3,\3,\5,\u014d\n,\3-\3-\3-\7-\u0152\n-\f-\16-\u0155\13-\3.\3.\3/"+
		"\3/\3/\3/\3/\3/\5/\u015f\n/\3\60\3\60\3\60\7\60\u0164\n\60\f\60\16\60"+
		"\u0167\13\60\3\61\3\61\3\61\7\61\u016c\n\61\f\61\16\61\u016f\13\61\3\62"+
		"\3\62\3\62\7\62\u0174\n\62\f\62\16\62\u0177\13\62\3\63\3\63\3\63\7\63"+
		"\u017c\n\63\f\63\16\63\u017f\13\63\3\64\3\64\3\64\7\64\u0184\n\64\f\64"+
		"\16\64\u0187\13\64\3\65\3\65\3\65\3\65\7\65\u018d\n\65\f\65\16\65\u0190"+
		"\13\65\3\66\3\66\3\67\3\67\3\67\3\67\7\67\u0198\n\67\f\67\16\67\u019b"+
		"\13\67\38\38\39\39\39\39\79\u01a3\n9\f9\169\u01a6\139\3:\3:\3;\3;\3;\7"+
		";\u01ad\n;\f;\16;\u01b0\13;\3;\5;\u01b3\n;\3;\2<\2\4\6\b\n\f\16\20\22"+
		"\24\26\30\32\34\36 \"$&(*,.\60\62\64\668:<>@BDFHJLNPRTVXZ\\^`bdfhjlnp"+
		"rt\2\13\4\2\t\t\"\"\5\2\b\b\35\35++\4\2\20\20\33\33\7\2\5\5\b\t\"\"--"+
		"\61\61\4\2\62\62\649\n\2\4\4\6\6\17\17\26\26\30\31\37\37##(*\4\2\22\22"+
		",,\6\2\21\21\23\23\'\'//\4\2\25\25\34\34\u01a2\2y\3\2\2\2\4|\3\2\2\2\6"+
		"\u0090\3\2\2\2\b\u0092\3\2\2\2\n\u0097\3\2\2\2\f\u009a\3\2\2\2\16\u00a0"+
		"\3\2\2\2\20\u00a5\3\2\2\2\22\u00ab\3\2\2\2\24\u00b1\3\2\2\2\26\u00b3\3"+
		"\2\2\2\30\u00bc\3\2\2\2\32\u00c2\3\2\2\2\34\u00c4\3\2\2\2\36\u00c6\3\2"+
		"\2\2 \u00cd\3\2\2\2\"\u00cf\3\2\2\2$\u00d8\3\2\2\2&\u00da\3\2\2\2(\u00dd"+
		"\3\2\2\2*\u00e5\3\2\2\2,\u00ee\3\2\2\2.\u00f0\3\2\2\2\60\u00f9\3\2\2\2"+
		"\62\u0101\3\2\2\2\64\u0106\3\2\2\2\66\u0108\3\2\2\28\u010b\3\2\2\2:\u010e"+
		"\3\2\2\2<\u0110\3\2\2\2>\u011d\3\2\2\2@\u011f\3\2\2\2B\u0123\3\2\2\2D"+
		"\u0126\3\2\2\2F\u012a\3\2\2\2H\u012d\3\2\2\2J\u012f\3\2\2\2L\u0131\3\2"+
		"\2\2N\u0139\3\2\2\2P\u013b\3\2\2\2R\u013d\3\2\2\2T\u0145\3\2\2\2V\u014c"+
		"\3\2\2\2X\u014e\3\2\2\2Z\u0156\3\2\2\2\\\u0158\3\2\2\2^\u0160\3\2\2\2"+
		"`\u0168\3\2\2\2b\u0170\3\2\2\2d\u0178\3\2\2\2f\u0180\3\2\2\2h\u0188\3"+
		"\2\2\2j\u0191\3\2\2\2l\u0193\3\2\2\2n\u019c\3\2\2\2p\u019e\3\2\2\2r\u01a7"+
		"\3\2\2\2t\u01a9\3\2\2\2vx\5\4\3\2wv\3\2\2\2x{\3\2\2\2yw\3\2\2\2yz\3\2"+
		"\2\2z\3\3\2\2\2{y\3\2\2\2|}\5\b\5\2}\u0081\7\f\2\2~\u0080\5\36\20\2\177"+
		"~\3\2\2\2\u0080\u0083\3\2\2\2\u0081\177\3\2\2\2\u0081\u0082\3\2\2\2\u0082"+
		"\u0084\3\2\2\2\u0083\u0081\3\2\2\2\u0084\u0085\7.\2\2\u0085\u0086\5\6"+
		"\4\2\u0086\u008a\7\27\2\2\u0087\u0089\5\20\t\2\u0088\u0087\3\2\2\2\u0089"+
		"\u008c\3\2\2\2\u008a\u0088\3\2\2\2\u008a\u008b\3\2\2\2\u008b\u008d\3\2"+
		"\2\2\u008c\u008a\3\2\2\2\u008d\u008e\7\32\2\2\u008e\u008f\5\n\6\2\u008f"+
		"\5\3\2\2\2\u0090\u0091\7\63\2\2\u0091\7\3\2\2\2\u0092\u0093\7\63\2\2\u0093"+
		"\t\3\2\2\2\u0094\u0096\5$\23\2\u0095\u0094\3\2\2\2\u0096\u0099\3\2\2\2"+
		"\u0097\u0095\3\2\2\2\u0097\u0098\3\2\2\2\u0098\13\3\2\2\2\u0099\u0097"+
		"\3\2\2\2\u009a\u009b\5R*\2\u009b\u009c\7\r\2\2\u009c\u009d\7\27\2\2\u009d"+
		"\u009e\5\n\6\2\u009e\u009f\7\32\2\2\u009f\r\3\2\2\2\u00a0\u00a1\5X-\2"+
		"\u00a1\u00a2\7\n\2\2\u00a2\u00a3\5R*\2\u00a3\u00a4\7$\2\2\u00a4\17\3\2"+
		"\2\2\u00a5\u00a7\5\22\n\2\u00a6\u00a8\5\26\f\2\u00a7\u00a6\3\2\2\2\u00a7"+
		"\u00a8\3\2\2\2\u00a8\u00a9\3\2\2\2\u00a9\u00aa\7$\2\2\u00aa\21\3\2\2\2"+
		"\u00ab\u00ac\5t;\2\u00ac\u00af\5\24\13\2\u00ad\u00ae\7#\2\2\u00ae\u00b0"+
		"\5R*\2\u00af\u00ad\3\2\2\2\u00af\u00b0\3\2\2\2\u00b0\23\3\2\2\2\u00b1"+
		"\u00b2\7\63\2\2\u00b2\25\3\2\2\2\u00b3\u00b7\7\27\2\2\u00b4\u00b6\5\30"+
		"\r\2\u00b5\u00b4\3\2\2\2\u00b6\u00b9\3\2\2\2\u00b7\u00b5\3\2\2\2\u00b7"+
		"\u00b8\3\2\2\2\u00b8\u00ba\3\2\2\2\u00b9\u00b7\3\2\2\2\u00ba\u00bb\7\32"+
		"\2\2\u00bb\27\3\2\2\2\u00bc\u00bd\5\32\16\2\u00bd\u00be\7#\2\2\u00be\u00c0"+
		"\5\34\17\2\u00bf\u00c1\7\7\2\2\u00c0\u00bf\3\2\2\2\u00c0\u00c1\3\2\2\2"+
		"\u00c1\31\3\2\2\2\u00c2\u00c3\7\63\2\2\u00c3\33\3\2\2\2\u00c4\u00c5\7"+
		"\65\2\2\u00c5\35\3\2\2\2\u00c6\u00c7\7\13\2\2\u00c7\u00c8\5 \21\2\u00c8"+
		"\u00c9\7\16\2\2\u00c9\u00ca\5\"\22\2\u00ca\u00cb\7!\2\2\u00cb\u00cc\7"+
		"\3\2\2\u00cc\37\3\2\2\2\u00cd\u00ce\7\63\2\2\u00ce!\3\2\2\2\u00cf\u00d0"+
		"\7\65\2\2\u00d0#\3\2\2\2\u00d1\u00d2\5R*\2\u00d2\u00d3\7$\2\2\u00d3\u00d9"+
		"\3\2\2\2\u00d4\u00d9\5&\24\2\u00d5\u00d9\5\f\7\2\u00d6\u00d9\5\16\b\2"+
		"\u00d7\u00d9\7$\2\2\u00d8\u00d1\3\2\2\2\u00d8\u00d4\3\2\2\2\u00d8\u00d5"+
		"\3\2\2\2\u00d8\u00d6\3\2\2\2\u00d8\u00d7\3\2\2\2\u00d9%\3\2\2\2\u00da"+
		"\u00db\5\22\n\2\u00db\u00dc\7$\2\2\u00dc\'\3\2\2\2\u00dd\u00e2\5V,\2\u00de"+
		"\u00df\7\7\2\2\u00df\u00e1\5V,\2\u00e0\u00de\3\2\2\2\u00e1\u00e4\3\2\2"+
		"\2\u00e2\u00e0\3\2\2\2\u00e2\u00e3\3\2\2\2\u00e3)\3\2\2\2\u00e4\u00e2"+
		"\3\2\2\2\u00e5\u00eb\5.\30\2\u00e6\u00e7\5,\27\2\u00e7\u00e8\5.\30\2\u00e8"+
		"\u00ea\3\2\2\2\u00e9\u00e6\3\2\2\2\u00ea\u00ed\3\2\2\2\u00eb\u00e9\3\2"+
		"\2\2\u00eb\u00ec\3\2\2\2\u00ec+\3\2\2\2\u00ed\u00eb\3\2\2\2\u00ee\u00ef"+
		"\t\2\2\2\u00ef-\3\2\2\2\u00f0\u00f6\5\62\32\2\u00f1\u00f2\5\60\31\2\u00f2"+
		"\u00f3\5\62\32\2\u00f3\u00f5\3\2\2\2\u00f4\u00f1\3\2\2\2\u00f5\u00f8\3"+
		"\2\2\2\u00f6\u00f4\3\2\2\2\u00f6\u00f7\3\2\2\2\u00f7/\3\2\2\2\u00f8\u00f6"+
		"\3\2\2\2\u00f9\u00fa\t\3\2\2\u00fa\61\3\2\2\2\u00fb\u00fc\7\16\2\2\u00fc"+
		"\u00fd\5t;\2\u00fd\u00fe\7!\2\2\u00fe\u00ff\5\62\32\2\u00ff\u0102\3\2"+
		"\2\2\u0100\u0102\5\64\33\2\u0101\u00fb\3\2\2\2\u0101\u0100\3\2\2\2\u0102"+
		"\63\3\2\2\2\u0103\u0107\5<\37\2\u0104\u0107\58\35\2\u0105\u0107\5\66\34"+
		"\2\u0106\u0103\3\2\2\2\u0106\u0104\3\2\2\2\u0106\u0105\3\2\2\2\u0107\65"+
		"\3\2\2\2\u0108\u0109\5L\'\2\u0109\u010a\5\62\32\2\u010a\67\3\2\2\2\u010b"+
		"\u010c\5:\36\2\u010c\u010d\5\64\33\2\u010d9\3\2\2\2\u010e\u010f\t\4\2"+
		"\2\u010f;\3\2\2\2\u0110\u0114\5N(\2\u0111\u0113\5> \2\u0112\u0111\3\2"+
		"\2\2\u0113\u0116\3\2\2\2\u0114\u0112\3\2\2\2\u0114\u0115\3\2\2\2\u0115"+
		"=\3\2\2\2\u0116\u0114\3\2\2\2\u0117\u011e\5@!\2\u0118\u011e\5B\"\2\u0119"+
		"\u011e\5D#\2\u011a\u011e\5F$\2\u011b\u011e\5H%\2\u011c\u011e\5J&\2\u011d"+
		"\u0117\3\2\2\2\u011d\u0118\3\2\2\2\u011d\u0119\3\2\2\2\u011d\u011a\3\2"+
		"\2\2\u011d\u011b\3\2\2\2\u011d\u011c\3\2\2\2\u011e?\3\2\2\2\u011f\u0120"+
		"\7\13\2\2\u0120\u0121\5R*\2\u0121\u0122\7\3\2\2\u0122A\3\2\2\2\u0123\u0124"+
		"\7\16\2\2\u0124\u0125\7!\2\2\u0125C\3\2\2\2\u0126\u0127\7\16\2\2\u0127"+
		"\u0128\5(\25\2\u0128\u0129\7!\2\2\u0129E\3\2\2\2\u012a\u012b\7 \2\2\u012b"+
		"\u012c\7\63\2\2\u012cG\3\2\2\2\u012d\u012e\7\33\2\2\u012eI\3\2\2\2\u012f"+
		"\u0130\7\20\2\2\u0130K\3\2\2\2\u0131\u0132\t\5\2\2\u0132M\3\2\2\2\u0133"+
		"\u013a\7\63\2\2\u0134\u013a\5P)\2\u0135\u0136\7\16\2\2\u0136\u0137\5R"+
		"*\2\u0137\u0138\7!\2\2\u0138\u013a\3\2\2\2\u0139\u0133\3\2\2\2\u0139\u0134"+
		"\3\2\2\2\u0139\u0135\3\2\2\2\u013aO\3\2\2\2\u013b\u013c\t\6\2\2\u013c"+
		"Q\3\2\2\2\u013d\u0142\5V,\2\u013e\u013f\7\7\2\2\u013f\u0141\5V,\2\u0140"+
		"\u013e\3\2\2\2\u0141\u0144\3\2\2\2\u0142\u0140\3\2\2\2\u0142\u0143\3\2"+
		"\2\2\u0143S\3\2\2\2\u0144\u0142\3\2\2\2\u0145\u0146\5\\/\2\u0146U\3\2"+
		"\2\2\u0147\u0148\5X-\2\u0148\u0149\5Z.\2\u0149\u014a\5V,\2\u014a\u014d"+
		"\3\2\2\2\u014b\u014d\5\\/\2\u014c\u0147\3\2\2\2\u014c\u014b\3\2\2\2\u014d"+
		"W\3\2\2\2\u014e\u0153\7\63\2\2\u014f\u0150\7 \2\2\u0150\u0152\7\63\2\2"+
		"\u0151\u014f\3\2\2\2\u0152\u0155\3\2\2\2\u0153\u0151\3\2\2\2\u0153\u0154"+
		"\3\2\2\2\u0154Y\3\2\2\2\u0155\u0153\3\2\2\2\u0156\u0157\t\7\2\2\u0157"+
		"[\3\2\2\2\u0158\u015e\5^\60\2\u0159\u015a\7\24\2\2\u015a\u015b\5R*\2\u015b"+
		"\u015c\7\f\2\2\u015c\u015d\5\\/\2\u015d\u015f\3\2\2\2\u015e\u0159\3\2"+
		"\2\2\u015e\u015f\3\2\2\2\u015f]\3\2\2\2\u0160\u0165\5`\61\2\u0161\u0162"+
		"\7&\2\2\u0162\u0164\5`\61\2\u0163\u0161\3\2\2\2\u0164\u0167\3\2\2\2\u0165"+
		"\u0163\3\2\2\2\u0165\u0166\3\2\2\2\u0166_\3\2\2\2\u0167\u0165\3\2\2\2"+
		"\u0168\u016d\5b\62\2\u0169\u016a\7%\2\2\u016a\u016c\5b\62\2\u016b\u0169"+
		"\3\2\2\2\u016c\u016f\3\2\2\2\u016d\u016b\3\2\2\2\u016d\u016e\3\2\2\2\u016e"+
		"a\3\2\2\2\u016f\u016d\3\2\2\2\u0170\u0175\5d\63\2\u0171\u0172\7\60\2\2"+
		"\u0172\u0174\5d\63\2\u0173\u0171\3\2\2\2\u0174\u0177\3\2\2\2\u0175\u0173"+
		"\3\2\2\2\u0175\u0176\3\2\2\2\u0176c\3\2\2\2\u0177\u0175\3\2\2\2\u0178"+
		"\u017d\5f\64\2\u0179\u017a\7\36\2\2\u017a\u017c\5f\64\2\u017b\u0179\3"+
		"\2\2\2\u017c\u017f\3\2\2\2\u017d\u017b\3\2\2\2\u017d\u017e\3\2\2\2\u017e"+
		"e\3\2\2\2\u017f\u017d\3\2\2\2\u0180\u0185\5h\65\2\u0181\u0182\7\5\2\2"+
		"\u0182\u0184\5h\65\2\u0183\u0181\3\2\2\2\u0184\u0187\3\2\2\2\u0185\u0183"+
		"\3\2\2\2\u0185\u0186\3\2\2\2\u0186g\3\2\2\2\u0187\u0185\3\2\2\2\u0188"+
		"\u018e\5l\67\2\u0189\u018a\5j\66\2\u018a\u018b\5l\67\2\u018b\u018d\3\2"+
		"\2\2\u018c\u0189\3\2\2\2\u018d\u0190\3\2\2\2\u018e\u018c\3\2\2\2\u018e"+
		"\u018f\3\2\2\2\u018fi\3\2\2\2\u0190\u018e\3\2\2\2\u0191\u0192\t\b\2\2"+
		"\u0192k\3\2\2\2\u0193\u0199\5p9\2\u0194\u0195\5n8\2\u0195\u0196\5p9\2"+
		"\u0196\u0198\3\2\2\2\u0197\u0194\3\2\2\2\u0198\u019b\3\2\2\2\u0199\u0197"+
		"\3\2\2\2\u0199\u019a\3\2\2\2\u019am\3\2\2\2\u019b\u0199\3\2\2\2\u019c"+
		"\u019d\t\t\2\2\u019do\3\2\2\2\u019e\u01a4\5*\26\2\u019f\u01a0\5r:\2\u01a0"+
		"\u01a1\5*\26\2\u01a1\u01a3\3\2\2\2\u01a2\u019f\3\2\2\2\u01a3\u01a6\3\2"+
		"\2\2\u01a4\u01a2\3\2\2\2\u01a4\u01a5\3\2\2\2\u01a5q\3\2\2\2\u01a6\u01a4"+
		"\3\2\2\2\u01a7\u01a8\t\n\2\2\u01a8s\3\2\2\2\u01a9\u01ae\7\63\2\2\u01aa"+
		"\u01ab\7 \2\2\u01ab\u01ad\7\63\2\2\u01ac\u01aa\3\2\2\2\u01ad\u01b0\3\2"+
		"\2\2\u01ae\u01ac\3\2\2\2\u01ae\u01af\3\2\2\2\u01af\u01b2\3\2\2\2\u01b0"+
		"\u01ae\3\2\2\2\u01b1\u01b3\7\24\2\2\u01b2\u01b1\3\2\2\2\u01b2\u01b3\3"+
		"\2\2\2\u01b3u\3\2\2\2!y\u0081\u008a\u0097\u00a7\u00af\u00b7\u00c0\u00d8"+
		"\u00e2\u00eb\u00f6\u0101\u0106\u0114\u011d\u0139\u0142\u014c\u0153\u015e"+
		"\u0165\u016d\u0175\u017d\u0185\u018e\u0199\u01a4\u01ae\u01b2";
	public static final ATN _ATN =
		ATNSimulator.deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}