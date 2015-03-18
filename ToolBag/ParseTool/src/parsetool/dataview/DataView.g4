/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

grammar DataView;

program:
           search_option? select;

select:
                select_atom ( union_type select_atom)*
            ;
union_type:
              'union' |  'union' 'all' |'except' | 'intersect'
            ;

select_atom:             
          select_clause_full ( from_clause_full join_clause_full? (condition_clause_full)? group_clause_full? order_clause_full? )?
          
      |
          '(' select ')'
      ;
search_option:
               option_expression
            ;
order_clause_full:
                      'order' 'by' order_clause
;
order_clause:
               order_expression ( ',' order_expression)*
            ;
order_expression:
                    field_regular ('asc'|'desc')?
                ;
select_alias:
                '(' select ')' ('as')? ID
            ;
group_clause_full:
                 'group' 'by'   group_clause
;
group_clause:
               field_regular (',' field_regular)*  having_clause_full?
            ;
having_clause_full:
    'having' having_clause
;
having_clause:
                 condition_clause
;
join_clause_full:
                    join_clause+;

join_clause:
              all_join table_alias 'on' join_on_clause
;
join_on_clause:
                  condition_clause
;
all_join:
            join | inner_join | left_join | left_outer_join | right_join | right_outer_join
        ;
join:
        'join'
    ;
inner_join:
              'inner' 'join'
          ;
left_join:
             'left' 'join'
         ;
left_outer_join:
                   'left' 'outer' 'join'
               ;
right_join:
              'right' 'join'
          ;
right_outer_join:
              'right' 'outer' 'join'
          ;
select_clause_full:
                      'select' top_clause? select_clause
                  ;
top_clause:
       'top' value 
   ;
select_clause: 
      table_field_alias (',' table_field_alias) *
             ;

table_field_alias:
       table_field (('as')? ID)?              
;

//table_field_prior1:
//                     '(' table_field ')'
//                 |
//                     table_field
//                ;

table_field:
                 table_field_atom
             |
                 binary_expression
             ;
table_field_atom:
               (value | all_field | (table '.' '*') | field_regular | case_clause_field | function_field) 
     
           |
               //'(' binary_expression ')'
               '(' binary_expression ')'
           //|
            //    ('~' | '+' | '-' ) table_field                    
           ;

case_clause_field:
                     case_clause_prior 
                 ;
case_clause_prior:
                     '(' case_clause ')'
                 |
                     case_clause
                 ;
case_clause:
               case_have_target_expression
           |
               case_expression
           ;
case_have_target_expression:
                           'case' table_field case_have_target_when_expression+ case_else_expression? 'end'
                      ;
case_have_target_when_expression:
                                     'when' value 'then' result_expression_prior
                                ;
case_expression:
              'case' case_when_expression+ case_else_expression? 'end'
          ;

case_when_expression:
                              'when' condition_clause_prior 'then' result_expression_prior
                          ;
result_expression_prior:
                           '(' result_expression ')'
                       |
                           result_expression
;
result_expression:
                     value
                     //(value | select)
      ;

case_else_expression:
                   'else' result_expression_prior
               ;

condition_clause_prior:
                          '(' condition_clause ')'
                      |
                          condition_clause
;

field_regular:
         long_name
     ;
all_field:
             '*'
         ;
table_alias:
               table ('as'? ID)?
           |
               table
           ;
table:        
    long_name 
;
from_clause_full:
                     'from' from_clause
                ;
from_clause:
          (
           select_alias 
           |
           (table_alias ',')* table_alias)             
           ;
condition_clause_full:
                          'where'  condition_clause
                     ;
condition_clause:
                      compare_complex_mix_or
                        //(('and' | 'or')  compare_complex_prior )*                          
                      ;
existed_compare_prior:
                         '(' existed_compare ')'
                     |
                         existed_compare
                     ;
existed_compare:
                  ( 'exists' | 'not' 'exists')
                  '(' select ')'
               ;

//compare_complex_mix_prior:
//                              compare_complex_prior (('and' | 'or')  compare_complex_prior)*
//                         ;
compare_complex_mix_or:
                             compare_complex_mix_and ('or'  compare_complex_mix_and)*
                         ;

compare_complex_mix_and:
                             compare_complex_prior ('and'  compare_complex_prior)*
                         ;
//compare_complex_mix:
//                   compare_complex (('and' | 'or')  compare_complex)*            
//               ;
compare_complex_prior:
                         '(' compare_complex_mix_or ')' search_option?
                     |
                         compare_complex                     
                     ;

compare_complex:
          ( between_prior | binary_prior | in_expression_prior | existed_compare_prior)
                ;
in_expression_prior:
                  '(' in_expression  ')'
                   |
                  in_expression
                   ;
in_expression:
    table_field in_keyword in_right_value
  ;
in_keyword:
      'not' 'in' | 'in'
;
in_right_value:
              parameter | '(' in_list ')'
           ;

in_list:
       (select_list | value_list) 
    ;
select_list:
               select
           ;
value_list:
              value ( ',' value)* 
    ;
between_prior:
                 '(' between ')' condition_option ? 
             |
                 between
;
between:
        long_name   'between' value 'and' value
       ;
binary_prior:
                '(' binary ')'
            |
                binary
            ;
binary:
           binary_compare_prior
      ;
binary_compare_prior:
                        '(' binary_compare ')' condition_option? search_option?
                    |
                        binary_compare
                    ;
binary_compare:
                  table_field binary_operater (table_field | predication)
    ;

predication:
               ('any' | 'some' | 'all' ) '(' select ')'
           ;

binary_operater:
                  '<>' | '>' | '<' | '>=' | '<=' |'=' | '!=' | '!>' | '!<' | 'like' 
               ;

value:
        BOOL| INT | FLOAT | CHAR | STRING | OPTION_STRING | parameter | '(' select_list ')'//add select_list
     |
        '(' value ')'
     ;

parameter:
            parameter_name  parameter_options?
    ;
parameter_name:
                  '$' ID
              ;
parameter_options:
          option_expression           
;
option_expression:
                    '{' option_list  '}'
                ;
option_list:
          option  (',' option)*                  
                          ;
option:
    option_name '=' option_value
;
option_name:
               parameter_name
           |
              STRING    
              ;
option_value:
       STRING     
;
condition_option:
          ( '#' | '?')
      ;
long_name:
             ID ('.' ID)*
;
function_field:
            ID'(' function_parameter_list? ')'
        ;
function_parameter_list:
                      function_parameter (',' function_parameter)*     
                       ;
function_parameter:
                      table_field
                  ;
//op begin
binary_expression:
                     multiplicative_expression ( ('+' | '-' | '&'| '^' | '|') multiplicative_expression )*                 
                 ;

multiplicative_expression: 
       (positive_expression) ('*' positive_expression | '/' positive_expression | '%' positive_expression)*

     ;

positive_expression:
                    ('+' | '-')? unary_operator           
                   ;

unary_operator
     :          
         ('~')? table_field_atom
     ;

//op end


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
OPTION_STRING:
          '[' ( ESC_SEQ | ~('['|']') )* ']'
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