/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

grammar ViewModel;

program: model *;

model:
         model_area ':'
         attribute*
         'class' model_name
         '{'
            field*
         '}'
         
         state
     ;
model_name:
              IDENTIFIER
          ;
model_area:
              IDENTIFIER
          ;
state :
          statement*
;

push:
        expression '==>' '{' state '}' 
;

pull:
        lvalue '<==' expression ';'
    ;
field:
         declare option_list? ';'
     ;

declare:
    type_name variable_name ( '=' expression )? 
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
              expression ';' |
              declare_statement |
              push |
              pull |
             ';'
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

     : '(' type_name ')' cast_expression

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
type_name: IDENTIFIER ('.' IDENTIFIER)* '?'?;

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



DECIMAL_LITERAL : ('0' | '1'..'9' '0'..'9'*) DECIMAL_LITERAL_Suffix? ;

fragment DECIMAL_LITERAL_Suffix: 'd' | 'D';

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