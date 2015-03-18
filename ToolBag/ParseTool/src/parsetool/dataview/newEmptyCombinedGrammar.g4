/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

grammar newEmptyCombinedGrammar;
table_field:
               
    binary_expression  | ID
           ;
p:
     table_field 
 |
     '(' p ')'
 ;

binary_expression:
                     multiplicative_expression ( ('+' | '-' | '&'| '^' | '|') multiplicative_expression )*                 
                 ;

multiplicative_expression: 
       (p) ('*' p | '/' p | '%' p)*
                         ;
BOOL     :     'true' | 'false';
    
ID  :     ('a'..'z'|'A'..'Z'|'_') ('a'..'z'|'A'..'Z'|'0'..'9'|'_')*
    ;

INT :     '0'..'9'+
    ;

FLOAT
    :   ('0'..'9')+ '.' ('0'..'9')* EXPONENT?
        |   '.' ('0'..'9')+ EXPONENT?
        |   ('0'..'9')+ EXPONENT
    ;

COMMENT
    :  ( '//' ~('\n'|'\r')* '\r'? '\n' 
        |   '/*'  .*? '*/') {skip();}
        
    ;
CODE:
        ('<<<'  .*?  '>>>')
    ;

WS  :   ( ' '
        | '\t'
        | '\r'
        | '\n'
        ) {skip();}
    ;

STRING
    :  '\'' ( ESC_SEQ | ~('\\'|'\'') )* '\''
    ;

CHAR:  '\'' ( ESC_SEQ | ~('\''|'\\') ) '\''
    ;

fragment
EXPONENT : ('e'|'E') ('+'|'-')? ('0'..'9')+ ;

fragment
HEX_DIGIT : ('0'..'9'|'a'..'f'|'A'..'F') ;

fragment
ESC_SEQ
    :   '\\' ('b'|'t'|'n'|'f'|'r'|'\"'|'\''|'\\')
    |   UNICODE_ESC
    |   OCTAL_ESC
    ;

fragment
OCTAL_ESC
    :   '\\' ('0'..'3') ('0'..'7') ('0'..'7')
    |   '\\' ('0'..'7') ('0'..'7')
    |   '\\' ('0'..'7')
    ;

fragment
UNICODE_ESC
    :   '\\' 'u' HEX_DIGIT HEX_DIGIT HEX_DIGIT HEX_DIGIT
    ;