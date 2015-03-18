/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

grammar DataModel;

program:
           using*
           
           namespace?
           
           (model | mapping) *
;
using:
         'using' long_name ';'         
;
namespace: 'namespace' long_name ';'?;

model :
      attribute *
      'class' ID '{' 
        (field | model)*
      '}'
      ;
field:
        attribute *
        ID '('
            filed_define 
        ')'';'
;

long_name:
             ID ('.' ID)*
;

split_tag:
             STRING
;
mapping:
       ID '.' 'map' '('ID',' ID ','long_name ','ID  ',' relation (','ID)+  (',' split_tag)? ')' ';'
;
attribute:
        '[' ID '(' STRING (',' STRING)* ')' ']'
    ;

relation:
            'OneToOne'|'OneToMany'|'ManyToOne'|'ManyToMany'
        ;

filed_define:        
        system_type ',' db_type (',' is_null (',' is_pk)?)?
;

system_type:
               long_name
           ;
db_type: 
           STRING
;

is_null: 
           BOOL;

is_pk:BOOL;

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
    :  '"' ( ESC_SEQ | ~('\\'|'"') )* '"'
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
