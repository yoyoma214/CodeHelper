/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

grammar Workflow;
nameSpace: 'namespace' long_name ';'?;

program: 
           nameSpace
           variable?
           init?
           unit*
       ;
unit :
         node | parallel
;
parallel:
            'parallel' IDENTIFIER ':'
            'begin'
              variable 
                (init|                
                action|
                translation|
                execute_line)*
            'end'
            
        ; 
execute_line:
        'line' IDENTIFIER ':' 
        unit*
    ;
clz:
       'class' clz_name
         '{'
            field*
         '}'
   ;
variable:
           (field | clz)* 
        ;
init: 'init' ':'
      '{'  state? '}'
    ;
ref_workflow:
      'ref_workflow' ':'
      STRING_LITERAL ';'?
;
node:
        'node' IDENTIFIER ':'
        variable 
        (ref_workflow |
         init|         
        form|
        action|
        translation)*
;
form:
        'form' ':' STRING_LITERAL ',' IDENTIFIER ';'?
;
translation:
             'translation' ':'
             translation_statement*
;
action:
          'action' ':'
          before?
          after?
      ;
before:
          'before' ':'
          '{' state? '}'
      ;
after:
         'after' ':'
         '{' state? '}'
     ;
role:
        'role' ':'
        STRING_LITERAL (',' STRING_LITERAL)*
    ;
user:
        'user' ':'
        STRING_LITERAL (',' STRING_LITERAL)*
    ;
clz_name:
              IDENTIFIER
          ;
state :
          statement*
;

ifStatement :'if' '(' expression ')' ( '{' state  '}' |  state ) ('else' (ifStatement? |'{'  state '}'))?           
            ;
switchStatement:
             'switch' '(' expression ')' '{' caseExpression* '}'
            ;
caseExpression:
                ( ( 'default' ) | ('case'  constant)) ':'
                    state?
                //('break' ';')?
              ;
whileStatement:
                  'while' '(' expression ')' '{' state? '}'
              ;
doWhileStatement:
                    'do' '{' state? '}' 'while' '(' expression ')' ';'
                ;
forStatement:
                'for' '(' declare_statement logical_or_expression ';' expression ')' '{' state? '}'
                ;
forEachStatement:
                'foreach' '(' generic_type IDENTIFIER 'in' expression ')' '{' state? '}'
                ;

translation_statement:
        expression '==>' IDENTIFIER ';'
;

field:
         declare option_list? ';'
     ;

declare:
    generic_type variable_name ( '=' expression )? 
;

variable_name:
            IDENTIFIER
        ;

option_list:
          '{' option * '}'
      ;
option:
          option_name '=' option_value ','?
;

option_name:
              IDENTIFIER 
           ;
option_value:
           STRING_LITERAL     
;
attribute:
           '[' attribute_name '(' attribute_value ')' ']'
;
attribute_name:
                  IDENTIFIER
              ;
attribute_value:
                   STRING_LITERAL
               ;
//state:IDENTIFIER ':' statement*;

statement :              
              declare_statement |
              expression_statement |
              ifStatement |
              switchStatement |
              whileStatement |
              doWhileStatement |
              forStatement |
              forEachStatement |
             gotoStatement |
             breakStatement |        
             continueStatement |
             ';'
;
expression_statement:
                        expression ';'
                    ;
gotoStatement:
        'goto' IDENTIFIER ';'
    ;
breakStatement:
         'break' ';'
     ;
continueStatement:
            'continue'
        ;
//assgin_statement: IDENTIFIER '=' expression;

declare_statement: declare ';';
                  
argument_expression_list

     :   assignment_expression (',' assignment_expression)*
     ;

additive_expression

     : (multiplicative_expression) (additive_expression_operator multiplicative_expression)*

     ;
additive_expression_operator:
                                ('+' | '-')
;
multiplicative_expression

     : (cast_expression) (multiplicative_expression_operator cast_expression)*
     ;

multiplicative_expression_operator:
                                      '*' | '/' |'%'
;
cast_expression

     : '(' generic_type ')' cast_expression

     | unary_expression
     ;

unary_expression

     : postfix_expression

     | unary_expression_two_char

     | unary_expression_one_char

     ;
unary_expression_one_char:
                        unary_operator cast_expression
;
unary_expression_two_char:
                        unary_expression_operator unary_expression
                    ;

unary_expression_operator:
                             '++' | '--'
                         ;

postfix_expression

     :   primary_expression

        (
            postfix_part
        )*

     ;
postfix_part:
        postfix_part_index

        |  postfix_part_empty_function

        |  postfix_part_function

        |  postfix_part_long_name

        //|   '*' IDENTIFIER

        |  postfix_part_increase

        |   postfix_part_decrease
            ;
postfix_part_index:
              '[' expression ']'   
             ;
postfix_part_empty_function:
                           '(' ')'
                      ;
postfix_part_function:
                    '(' argument_expression_list ')'
                ;
postfix_part_long_name:
                     '.' IDENTIFIER
                 ;
postfix_part_increase:
                    '++'
;
postfix_part_decrease:
                    '--'
;
unary_operator

     : '&'

     | '*'

     | '+'

     | '-'

     | '~'

     | '!'

     ;

primary_expression

     : IDENTIFIER

     | constant

     | '(' expression ')'
             
     |
       'new' creator
     ;
creator:          
          //long_name (postfix_part_empty_function|postfix_part_function)
           generic_type  '(' argument_expression_list? ')'
;
long_name2:
             IDENTIFIER (.IDENTIFIER)* 
;
constant

    :   HEX_LITERAL

    |   OCTAL_LITERAL
        
    |   DECIMAL_LITERAL

    |     CHARACTER_LITERAL

     |     STRING_LITERAL

    |   FLOATING_POINT_LITERAL
        
    |   BOOL_LITERAL

    ;
BOOL_LITERAL:
                'true' | 'false'
            ;
/////

expression

     : assignment_expression (',' assignment_expression)*
     
     ;

constant_expression

     : conditional_expression

     ;

assignment_expression

     : lvalue assignment_operator assignment_expression

     | conditional_expression

     ;   

lvalue

     :     IDENTIFIER ('.' IDENTIFIER)*

     ;

assignment_operator

     : '='

     | '*='

     | '/='

     | '%='

     | '+='

     | '-='

     | '<<='

     | '>>='

     | '&='

     | '^='

     | '|='

     ;


conditional_expression

     : logical_or_expression ('?' expression ':' conditional_expression)?

     ;

logical_or_expression

     : logical_and_expression ('||' logical_and_expression)*

     ;

logical_and_expression

     : inclusive_or_expression ('&&' inclusive_or_expression)*

     ;

inclusive_or_expression

     : exclusive_or_expression ('|' exclusive_or_expression)*

     ;

exclusive_or_expression

     : and_expression ('^' and_expression)*

     ;

and_expression

     : equality_expression ('&' equality_expression)*

     ;

equality_expression

     : relational_expression ( equality_expression_operator relational_expression)*

     ;
equality_expression_operator:
                                ('=='|'!=')
    ;
relational_expression

     : shift_expression (relational_expression_operator shift_expression)*
     ;
relational_expression_operator:
        ('<'|'>'|'<='|'>=')
;
shift_expression

     : additive_expression (shift_expression_operator additive_expression)*

     ;
shift_expression_operator:
        ('<<'|'>>')                     
;
long_name: IDENTIFIER ('.' IDENTIFIER)* '?'?;

generic_type:
           long_name |
           
           generic_type '<' generic_type (',' generic_type)* '>'
       ;


IDENTIFIER

     :     LETTER (LETTER|'0'..'9')*

     ;
    
fragment

LETTER

     :     '$'

     |     'A'..'Z'

     |     'a'..'z'

     |     '_'

     ;



CHARACTER_LITERAL

    :   '\'' ( EscapeSequence | ~('\''|'\\') ) '\''

    ;



STRING_LITERAL

    :  '"' ( EscapeSequence | ~('\\'|'"') )* '"'

    ;


HEX_LITERAL : '0' ('x'|'X') HexDigit+ IntegerTypeSuffix? ;

DECIMAL_LITERAL : ('0' | '1'..'9' '0'..'9'*) IntegerTypeSuffix? ;

OCTAL_LITERAL : '0' ('0'..'7')+ IntegerTypeSuffix? ;

fragment

HexDigit : ('0'..'9'|'a'..'f'|'A'..'F') ;

fragment

IntegerTypeSuffix

     :     ('u'|'U')? ('l'|'L')

     |     ('u'|'U')  ('l'|'L')?

     ;



FLOATING_POINT_LITERAL

    :   ('0'..'9')+ '.' ('0'..'9')* Exponent? FloatTypeSuffix?

    |   '.' ('0'..'9')+ Exponent? FloatTypeSuffix?

    |   ('0'..'9')+ Exponent FloatTypeSuffix?

    |   ('0'..'9')+ Exponent? FloatTypeSuffix

     ;

fragment

Exponent : ('e'|'E') ('+'|'-')? ('0'..'9')+ ;



fragment

FloatTypeSuffix : ('f'|'F'|'d'|'D') ;



fragment

EscapeSequence

    :   '\\' ('b'|'t'|'n'|'f'|'r'|'\"'|'\''|'\\')

    |   OctalEscape

    ;



fragment

OctalEscape

    :   '\\' ('0'..'3') ('0'..'7') ('0'..'7')

    |   '\\' ('0'..'7') ('0'..'7')

    |   '\\' ('0'..'7')

    ;



fragment

UnicodeEscape

    :   '\\' 'u' HexDigit HexDigit HexDigit HexDigit

    ;



WS  :  (' '|'\r'|'\t'|'\u000C'|'\n') {skip();}

    ;



COMMENT

    :   //'/*' ( options {greedy=false;} : . )* '*/' {skip();}
         '/*'  .*? '*/' {skip();}

    ;



LINE_COMMENT

    : //'//' ~('\n'|'\r')* '\r'? '\n' {skip();}
        '//' ~('\n'|'\r')* '\r'? '\n' {skip();}
    ;



// ignore #line info for now

LINE_COMMAND

    : '#' ~('\n'|'\r')* '\r'? '\n' {skip();}

    ;