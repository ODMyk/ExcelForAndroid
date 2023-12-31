grammar Grammar;

compileUnit : expression EOF;

expression :
	LPAREN expression RPAREN #ParenthesizedExpr
	| NOT expression #LogicalNotExpr
    | expression operatorToken=(MULTIPLY | DIVIDE) expression #MultiplicativeExpr
	| expression operatorToken=(ADD | SUBTRACT) expression #AdditiveExpr
	| expression operatorToken=(LESS | LESS_EQUAL | GREATER | GREATER_EQUAL) expression #RelationalExpr
	| expression operatorToken=(EQUAL | NOT_EQUAL) expression #EqualityExpr
	| expression AND expression #LogicalAndExpr
	| expression OR expression #LogicalOrExpr
	| NUMBER #NumberExpr
	| BOOLEAN #BooleanExpr
	| IDENTIFIER #IdentifierExpr
	; 

/*
 * Lexer Rules
 */

NUMBER : INT ('.' INT)?;
BOOLEAN : (TRUE | FALSE);
IDENTIFIER : [a-zA-Z]+[1-9][0-9]*;

INT : ('0'..'9')+;

TRUE : ('T' | 't')('R' | 'r')('U' | 'u')('E' | 'e');
FALSE : ('F' | 'f')'alse';
MULTIPLY : '*';
DIVIDE : '/';
SUBTRACT : '-';
ADD : '+';
LPAREN : '(';
RPAREN : ')';
LESS: '<';
GREATER: '>';
LESS_EQUAL: '<=';
GREATER_EQUAL: '>=';
EQUAL: '==';
NOT_EQUAL: '<>';
NOT: '!';
OR: '||';
AND: '&&';

WS : [ \t\r\n] -> channel(HIDDEN);

