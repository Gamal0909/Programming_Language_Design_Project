
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF               =  0, // (EOF)
        SYMBOL_ERROR             =  1, // (Error)
        SYMBOL_WHITESPACE        =  2, // Whitespace
        SYMBOL_MINUS             =  3, // '-'
        SYMBOL_LPAREN            =  4, // '('
        SYMBOL_RPAREN            =  5, // ')'
        SYMBOL_TIMES             =  6, // '*'
        SYMBOL_DIV               =  7, // '/'
        SYMBOL_COLON             =  8, // ':'
        SYMBOL_PLUS              =  9, // '+'
        SYMBOL_LT                = 10, // '<'
        SYMBOL_LTEQ              = 11, // '<='
        SYMBOL_LTGT              = 12, // '<>'
        SYMBOL_EQ                = 13, // '='
        SYMBOL_EQEQ              = 14, // '=='
        SYMBOL_GT                = 15, // '>'
        SYMBOL_GTEQ              = 16, // '>='
        SYMBOL_BREAK             = 17, // break
        SYMBOL_CASE              = 18, // case
        SYMBOL_CHAR              = 19, // Char
        SYMBOL_DEFAULT           = 20, // Default
        SYMBOL_DO                = 21, // do
        SYMBOL_ELSE              = 22, // else
        SYMBOL_FLOAT             = 23, // Float
        SYMBOL_FOR               = 24, // for
        SYMBOL_IDENTIFIER        = 25, // Identifier
        SYMBOL_IF                = 26, // if
        SYMBOL_INRANGELPAREN     = 27, // 'in range ('
        SYMBOL_INTEGER           = 28, // Integer
        SYMBOL_STRING            = 29, // String
        SYMBOL_SWITCH            = 30, // switch
        SYMBOL_VARNAME           = 31, // Varname
        SYMBOL_WHILE             = 32, // while
        SYMBOL_ADDEXP            = 33, // <Add Exp>
        SYMBOL_CASES             = 34, // <Cases>
        SYMBOL_DECLARATIONANDASS = 35, // <Declaration and ass>
        SYMBOL_DEFAULT2          = 36, // <Default>
        SYMBOL_DOWHILE           = 37, // <DoWhile>
        SYMBOL_EXPRESSION        = 38, // <Expression>
        SYMBOL_FORLOOP           = 39, // <ForLoop>
        SYMBOL_IFSTAT            = 40, // <IFStat>
        SYMBOL_MULTEXP           = 41, // <Mult Exp>
        SYMBOL_NEGATEEXP         = 42, // <Negate Exp>
        SYMBOL_PROGRAM           = 43, // <Program>
        SYMBOL_STATEMENT         = 44, // <Statement>
        SYMBOL_STATEMENTLIST     = 45, // <StatementList>
        SYMBOL_SWITCHCASE        = 46, // <SwitchCase>
        SYMBOL_VALUE             = 47, // <Value>
        SYMBOL_WHILE2            = 48  // <While>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAM                                  =  0, // <Program> ::= <StatementList>
        RULE_STATEMENTLIST                            =  1, // <StatementList> ::= 
        RULE_STATEMENTLIST2                           =  2, // <StatementList> ::= <StatementList> <Statement>
        RULE_STATEMENTLIST3                           =  3, // <StatementList> ::= <Statement>
        RULE_STATEMENT                                =  4, // <Statement> ::= <Declaration and ass>
        RULE_STATEMENT2                               =  5, // <Statement> ::= <IFStat>
        RULE_STATEMENT3                               =  6, // <Statement> ::= <SwitchCase>
        RULE_STATEMENT4                               =  7, // <Statement> ::= <ForLoop>
        RULE_STATEMENT5                               =  8, // <Statement> ::= <While>
        RULE_STATEMENT6                               =  9, // <Statement> ::= <DoWhile>
        RULE_DECLARATIONANDASS_VARNAME_EQ             = 10, // <Declaration and ass> ::= Varname '=' <Expression>
        RULE_IFSTAT_IF_COLON                          = 11, // <IFStat> ::= if <Expression> ':' <StatementList>
        RULE_IFSTAT_IF_COLON_ELSE_COLON               = 12, // <IFStat> ::= if <Expression> ':' <StatementList> else ':' <StatementList>
        RULE_SWITCHCASE_SWITCH_COLON                  = 13, // <SwitchCase> ::= switch <Expression> ':' <Cases> <Default>
        RULE_CASES_CASE_COLON_BREAK                   = 14, // <Cases> ::= case <Expression> ':' <StatementList> break
        RULE_CASES_CASE_COLON_BREAK2                  = 15, // <Cases> ::= <Cases> case <Expression> ':' <StatementList> break
        RULE_DEFAULT_DEFAULT_COLON_BREAK              = 16, // <Default> ::= Default ':' <StatementList> break
        RULE_FORLOOP_FOR_VARNAME_INRANGELPAREN_RPAREN = 17, // <ForLoop> ::= for Varname 'in range (' <Negate Exp> ')' <StatementList>
        RULE_WHILE_WHILE_COLON                        = 18, // <While> ::= while <Expression> ':' <StatementList>
        RULE_DOWHILE_DO_COLON_WHILE                   = 19, // <DoWhile> ::= do <StatementList> ':' while <Expression>
        RULE_EXPRESSION_GT                            = 20, // <Expression> ::= <Expression> '>' <Add Exp>
        RULE_EXPRESSION_LT                            = 21, // <Expression> ::= <Expression> '<' <Add Exp>
        RULE_EXPRESSION_LTEQ                          = 22, // <Expression> ::= <Expression> '<=' <Add Exp>
        RULE_EXPRESSION_GTEQ                          = 23, // <Expression> ::= <Expression> '>=' <Add Exp>
        RULE_EXPRESSION_EQEQ                          = 24, // <Expression> ::= <Expression> '==' <Add Exp>
        RULE_EXPRESSION_LTGT                          = 25, // <Expression> ::= <Expression> '<>' <Add Exp>
        RULE_EXPRESSION                               = 26, // <Expression> ::= <Add Exp>
        RULE_EXPRESSION2                              = 27, // <Expression> ::= <Declaration and ass>
        RULE_ADDEXP_PLUS                              = 28, // <Add Exp> ::= <Add Exp> '+' <Mult Exp>
        RULE_ADDEXP_MINUS                             = 29, // <Add Exp> ::= <Add Exp> '-' <Mult Exp>
        RULE_ADDEXP                                   = 30, // <Add Exp> ::= <Mult Exp>
        RULE_MULTEXP_TIMES                            = 31, // <Mult Exp> ::= <Mult Exp> '*' <Negate Exp>
        RULE_MULTEXP_DIV                              = 32, // <Mult Exp> ::= <Mult Exp> '/' <Negate Exp>
        RULE_MULTEXP                                  = 33, // <Mult Exp> ::= <Negate Exp>
        RULE_NEGATEEXP_MINUS                          = 34, // <Negate Exp> ::= '-' <Value>
        RULE_NEGATEEXP                                = 35, // <Negate Exp> ::= <Value>
        RULE_VALUE_IDENTIFIER                         = 36, // <Value> ::= Identifier
        RULE_VALUE_INTEGER                            = 37, // <Value> ::= Integer
        RULE_VALUE_STRING                             = 38, // <Value> ::= String
        RULE_VALUE_CHAR                               = 39, // <Value> ::= Char
        RULE_VALUE_FLOAT                              = 40, // <Value> ::= Float
        RULE_VALUE_LPAREN_RPAREN                      = 41  // <Value> ::= '(' <Expression> ')'
    };

    public class MyParser
    {
        private LALRParser parser;

        public MyParser(string filename)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COLON :
                //':'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LTEQ :
                //'<='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LTGT :
                //'<>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQEQ :
                //'=='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GTEQ :
                //'>='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BREAK :
                //break
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASE :
                //case
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CHAR :
                //Char
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DEFAULT :
                //Default
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DO :
                //do
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //else
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FLOAT :
                //Float
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR :
                //for
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IDENTIFIER :
                //Identifier
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INRANGELPAREN :
                //'in range ('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INTEGER :
                //Integer
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRING :
                //String
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCH :
                //switch
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VARNAME :
                //Varname
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE :
                //while
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ADDEXP :
                //<Add Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASES :
                //<Cases>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DECLARATIONANDASS :
                //<Declaration and ass>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DEFAULT2 :
                //<Default>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DOWHILE :
                //<DoWhile>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPRESSION :
                //<Expression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FORLOOP :
                //<ForLoop>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IFSTAT :
                //<IFStat>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MULTEXP :
                //<Mult Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NEGATEEXP :
                //<Negate Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM :
                //<Program>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATEMENT :
                //<Statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATEMENTLIST :
                //<StatementList>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCHCASE :
                //<SwitchCase>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VALUE :
                //<Value>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE2 :
                //<While>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAM :
                //<Program> ::= <StatementList>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENTLIST :
                //<StatementList> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENTLIST2 :
                //<StatementList> ::= <StatementList> <Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENTLIST3 :
                //<StatementList> ::= <Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT :
                //<Statement> ::= <Declaration and ass>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT2 :
                //<Statement> ::= <IFStat>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT3 :
                //<Statement> ::= <SwitchCase>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT4 :
                //<Statement> ::= <ForLoop>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT5 :
                //<Statement> ::= <While>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT6 :
                //<Statement> ::= <DoWhile>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DECLARATIONANDASS_VARNAME_EQ :
                //<Declaration and ass> ::= Varname '=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IFSTAT_IF_COLON :
                //<IFStat> ::= if <Expression> ':' <StatementList>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IFSTAT_IF_COLON_ELSE_COLON :
                //<IFStat> ::= if <Expression> ':' <StatementList> else ':' <StatementList>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SWITCHCASE_SWITCH_COLON :
                //<SwitchCase> ::= switch <Expression> ':' <Cases> <Default>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASES_CASE_COLON_BREAK :
                //<Cases> ::= case <Expression> ':' <StatementList> break
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASES_CASE_COLON_BREAK2 :
                //<Cases> ::= <Cases> case <Expression> ':' <StatementList> break
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DEFAULT_DEFAULT_COLON_BREAK :
                //<Default> ::= Default ':' <StatementList> break
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FORLOOP_FOR_VARNAME_INRANGELPAREN_RPAREN :
                //<ForLoop> ::= for Varname 'in range (' <Negate Exp> ')' <StatementList>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WHILE_WHILE_COLON :
                //<While> ::= while <Expression> ':' <StatementList>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DOWHILE_DO_COLON_WHILE :
                //<DoWhile> ::= do <StatementList> ':' while <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_GT :
                //<Expression> ::= <Expression> '>' <Add Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_LT :
                //<Expression> ::= <Expression> '<' <Add Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_LTEQ :
                //<Expression> ::= <Expression> '<=' <Add Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_GTEQ :
                //<Expression> ::= <Expression> '>=' <Add Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_EQEQ :
                //<Expression> ::= <Expression> '==' <Add Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_LTGT :
                //<Expression> ::= <Expression> '<>' <Add Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION :
                //<Expression> ::= <Add Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION2 :
                //<Expression> ::= <Declaration and ass>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ADDEXP_PLUS :
                //<Add Exp> ::= <Add Exp> '+' <Mult Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ADDEXP_MINUS :
                //<Add Exp> ::= <Add Exp> '-' <Mult Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ADDEXP :
                //<Add Exp> ::= <Mult Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULTEXP_TIMES :
                //<Mult Exp> ::= <Mult Exp> '*' <Negate Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULTEXP_DIV :
                //<Mult Exp> ::= <Mult Exp> '/' <Negate Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULTEXP :
                //<Mult Exp> ::= <Negate Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NEGATEEXP_MINUS :
                //<Negate Exp> ::= '-' <Value>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NEGATEEXP :
                //<Negate Exp> ::= <Value>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE_IDENTIFIER :
                //<Value> ::= Identifier
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE_INTEGER :
                //<Value> ::= Integer
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE_STRING :
                //<Value> ::= String
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE_CHAR :
                //<Value> ::= Char
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE_FLOAT :
                //<Value> ::= Float
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE_LPAREN_RPAREN :
                //<Value> ::= '(' <Expression> ')'
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '"+args.UnexpectedToken.ToString()+"'";
            //todo: Report message to UI?
        }

    }
}
