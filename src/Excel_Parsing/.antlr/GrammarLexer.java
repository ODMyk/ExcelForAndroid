// Generated from /home/dmyko/Documents/Programming/dotnet/ExcelForAndroid/src/Excel_Parsing/Grammar.g4 by ANTLR 4.13.1
import org.antlr.v4.runtime.Lexer;
import org.antlr.v4.runtime.CharStream;
import org.antlr.v4.runtime.Token;
import org.antlr.v4.runtime.TokenStream;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.misc.*;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast", "CheckReturnValue", "this-escape"})
public class GrammarLexer extends Lexer {
	static { RuntimeMetaData.checkVersion("4.13.1", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		NUMBER=1, BOOLEAN=2, IDENTIFIER=3, INT=4, TRUE=5, FALSE=6, MULTIPLY=7, 
		DIVIDE=8, SUBTRACT=9, ADD=10, LPAREN=11, RPAREN=12, LESS=13, GREATER=14, 
		LESS_EQUAL=15, GREATER_EQUAL=16, EQUAL=17, NOT_EQUAL=18, NOT=19, OR=20, 
		AND=21, WS=22;
	public static String[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static String[] modeNames = {
		"DEFAULT_MODE"
	};

	private static String[] makeRuleNames() {
		return new String[] {
			"NUMBER", "BOOLEAN", "IDENTIFIER", "INT", "TRUE", "FALSE", "MULTIPLY", 
			"DIVIDE", "SUBTRACT", "ADD", "LPAREN", "RPAREN", "LESS", "GREATER", "LESS_EQUAL", 
			"GREATER_EQUAL", "EQUAL", "NOT_EQUAL", "NOT", "OR", "AND", "WS"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, null, null, null, null, null, null, "'*'", "'/'", "'-'", "'+'", 
			"'('", "')'", "'<'", "'>'", "'<='", "'>='", "'=='", "'<>'", "'!'", "'||'", 
			"'&&'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, "NUMBER", "BOOLEAN", "IDENTIFIER", "INT", "TRUE", "FALSE", "MULTIPLY", 
			"DIVIDE", "SUBTRACT", "ADD", "LPAREN", "RPAREN", "LESS", "GREATER", "LESS_EQUAL", 
			"GREATER_EQUAL", "EQUAL", "NOT_EQUAL", "NOT", "OR", "AND", "WS"
		};
	}
	private static final String[] _SYMBOLIC_NAMES = makeSymbolicNames();
	public static final Vocabulary VOCABULARY = new VocabularyImpl(_LITERAL_NAMES, _SYMBOLIC_NAMES);

	/**
	 * @deprecated Use {@link #VOCABULARY} instead.
	 */
	@Deprecated
	public static final String[] tokenNames;
	static {
		tokenNames = new String[_SYMBOLIC_NAMES.length];
		for (int i = 0; i < tokenNames.length; i++) {
			tokenNames[i] = VOCABULARY.getLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = VOCABULARY.getSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}
	}

	@Override
	@Deprecated
	public String[] getTokenNames() {
		return tokenNames;
	}

	@Override

	public Vocabulary getVocabulary() {
		return VOCABULARY;
	}


	public GrammarLexer(CharStream input) {
		super(input);
		_interp = new LexerATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	@Override
	public String getGrammarFileName() { return "Grammar.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public String[] getChannelNames() { return channelNames; }

	@Override
	public String[] getModeNames() { return modeNames; }

	@Override
	public ATN getATN() { return _ATN; }

	public static final String _serializedATN =
		"\u0004\u0000\u0016z\u0006\uffff\uffff\u0002\u0000\u0007\u0000\u0002\u0001"+
		"\u0007\u0001\u0002\u0002\u0007\u0002\u0002\u0003\u0007\u0003\u0002\u0004"+
		"\u0007\u0004\u0002\u0005\u0007\u0005\u0002\u0006\u0007\u0006\u0002\u0007"+
		"\u0007\u0007\u0002\b\u0007\b\u0002\t\u0007\t\u0002\n\u0007\n\u0002\u000b"+
		"\u0007\u000b\u0002\f\u0007\f\u0002\r\u0007\r\u0002\u000e\u0007\u000e\u0002"+
		"\u000f\u0007\u000f\u0002\u0010\u0007\u0010\u0002\u0011\u0007\u0011\u0002"+
		"\u0012\u0007\u0012\u0002\u0013\u0007\u0013\u0002\u0014\u0007\u0014\u0002"+
		"\u0015\u0007\u0015\u0001\u0000\u0001\u0000\u0001\u0000\u0003\u00001\b"+
		"\u0000\u0001\u0001\u0001\u0001\u0003\u00015\b\u0001\u0001\u0002\u0004"+
		"\u00028\b\u0002\u000b\u0002\f\u00029\u0001\u0002\u0001\u0002\u0005\u0002"+
		">\b\u0002\n\u0002\f\u0002A\t\u0002\u0001\u0003\u0004\u0003D\b\u0003\u000b"+
		"\u0003\f\u0003E\u0001\u0004\u0001\u0004\u0001\u0004\u0001\u0004\u0001"+
		"\u0004\u0001\u0005\u0001\u0005\u0001\u0005\u0001\u0005\u0001\u0005\u0001"+
		"\u0005\u0001\u0006\u0001\u0006\u0001\u0007\u0001\u0007\u0001\b\u0001\b"+
		"\u0001\t\u0001\t\u0001\n\u0001\n\u0001\u000b\u0001\u000b\u0001\f\u0001"+
		"\f\u0001\r\u0001\r\u0001\u000e\u0001\u000e\u0001\u000e\u0001\u000f\u0001"+
		"\u000f\u0001\u000f\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0011\u0001"+
		"\u0011\u0001\u0011\u0001\u0012\u0001\u0012\u0001\u0013\u0001\u0013\u0001"+
		"\u0013\u0001\u0014\u0001\u0014\u0001\u0014\u0001\u0015\u0001\u0015\u0001"+
		"\u0015\u0001\u0015\u0000\u0000\u0016\u0001\u0001\u0003\u0002\u0005\u0003"+
		"\u0007\u0004\t\u0005\u000b\u0006\r\u0007\u000f\b\u0011\t\u0013\n\u0015"+
		"\u000b\u0017\f\u0019\r\u001b\u000e\u001d\u000f\u001f\u0010!\u0011#\u0012"+
		"%\u0013\'\u0014)\u0015+\u0016\u0001\u0000\u0006\u0002\u0000AZaz\u0001"+
		"\u000019\u0001\u000009\u0002\u0000TTtt\u0002\u0000FFff\u0003\u0000\t\n"+
		"\r\r  ~\u0000\u0001\u0001\u0000\u0000\u0000\u0000\u0003\u0001\u0000\u0000"+
		"\u0000\u0000\u0005\u0001\u0000\u0000\u0000\u0000\u0007\u0001\u0000\u0000"+
		"\u0000\u0000\t\u0001\u0000\u0000\u0000\u0000\u000b\u0001\u0000\u0000\u0000"+
		"\u0000\r\u0001\u0000\u0000\u0000\u0000\u000f\u0001\u0000\u0000\u0000\u0000"+
		"\u0011\u0001\u0000\u0000\u0000\u0000\u0013\u0001\u0000\u0000\u0000\u0000"+
		"\u0015\u0001\u0000\u0000\u0000\u0000\u0017\u0001\u0000\u0000\u0000\u0000"+
		"\u0019\u0001\u0000\u0000\u0000\u0000\u001b\u0001\u0000\u0000\u0000\u0000"+
		"\u001d\u0001\u0000\u0000\u0000\u0000\u001f\u0001\u0000\u0000\u0000\u0000"+
		"!\u0001\u0000\u0000\u0000\u0000#\u0001\u0000\u0000\u0000\u0000%\u0001"+
		"\u0000\u0000\u0000\u0000\'\u0001\u0000\u0000\u0000\u0000)\u0001\u0000"+
		"\u0000\u0000\u0000+\u0001\u0000\u0000\u0000\u0001-\u0001\u0000\u0000\u0000"+
		"\u00034\u0001\u0000\u0000\u0000\u00057\u0001\u0000\u0000\u0000\u0007C"+
		"\u0001\u0000\u0000\u0000\tG\u0001\u0000\u0000\u0000\u000bL\u0001\u0000"+
		"\u0000\u0000\rR\u0001\u0000\u0000\u0000\u000fT\u0001\u0000\u0000\u0000"+
		"\u0011V\u0001\u0000\u0000\u0000\u0013X\u0001\u0000\u0000\u0000\u0015Z"+
		"\u0001\u0000\u0000\u0000\u0017\\\u0001\u0000\u0000\u0000\u0019^\u0001"+
		"\u0000\u0000\u0000\u001b`\u0001\u0000\u0000\u0000\u001db\u0001\u0000\u0000"+
		"\u0000\u001fe\u0001\u0000\u0000\u0000!h\u0001\u0000\u0000\u0000#k\u0001"+
		"\u0000\u0000\u0000%n\u0001\u0000\u0000\u0000\'p\u0001\u0000\u0000\u0000"+
		")s\u0001\u0000\u0000\u0000+v\u0001\u0000\u0000\u0000-0\u0003\u0007\u0003"+
		"\u0000./\u0005.\u0000\u0000/1\u0003\u0007\u0003\u00000.\u0001\u0000\u0000"+
		"\u000001\u0001\u0000\u0000\u00001\u0002\u0001\u0000\u0000\u000025\u0003"+
		"\t\u0004\u000035\u0003\u000b\u0005\u000042\u0001\u0000\u0000\u000043\u0001"+
		"\u0000\u0000\u00005\u0004\u0001\u0000\u0000\u000068\u0007\u0000\u0000"+
		"\u000076\u0001\u0000\u0000\u000089\u0001\u0000\u0000\u000097\u0001\u0000"+
		"\u0000\u00009:\u0001\u0000\u0000\u0000:;\u0001\u0000\u0000\u0000;?\u0007"+
		"\u0001\u0000\u0000<>\u0007\u0002\u0000\u0000=<\u0001\u0000\u0000\u0000"+
		">A\u0001\u0000\u0000\u0000?=\u0001\u0000\u0000\u0000?@\u0001\u0000\u0000"+
		"\u0000@\u0006\u0001\u0000\u0000\u0000A?\u0001\u0000\u0000\u0000BD\u0002"+
		"09\u0000CB\u0001\u0000\u0000\u0000DE\u0001\u0000\u0000\u0000EC\u0001\u0000"+
		"\u0000\u0000EF\u0001\u0000\u0000\u0000F\b\u0001\u0000\u0000\u0000GH\u0007"+
		"\u0003\u0000\u0000HI\u0005r\u0000\u0000IJ\u0005u\u0000\u0000JK\u0005e"+
		"\u0000\u0000K\n\u0001\u0000\u0000\u0000LM\u0007\u0004\u0000\u0000MN\u0005"+
		"a\u0000\u0000NO\u0005l\u0000\u0000OP\u0005s\u0000\u0000PQ\u0005e\u0000"+
		"\u0000Q\f\u0001\u0000\u0000\u0000RS\u0005*\u0000\u0000S\u000e\u0001\u0000"+
		"\u0000\u0000TU\u0005/\u0000\u0000U\u0010\u0001\u0000\u0000\u0000VW\u0005"+
		"-\u0000\u0000W\u0012\u0001\u0000\u0000\u0000XY\u0005+\u0000\u0000Y\u0014"+
		"\u0001\u0000\u0000\u0000Z[\u0005(\u0000\u0000[\u0016\u0001\u0000\u0000"+
		"\u0000\\]\u0005)\u0000\u0000]\u0018\u0001\u0000\u0000\u0000^_\u0005<\u0000"+
		"\u0000_\u001a\u0001\u0000\u0000\u0000`a\u0005>\u0000\u0000a\u001c\u0001"+
		"\u0000\u0000\u0000bc\u0005<\u0000\u0000cd\u0005=\u0000\u0000d\u001e\u0001"+
		"\u0000\u0000\u0000ef\u0005>\u0000\u0000fg\u0005=\u0000\u0000g \u0001\u0000"+
		"\u0000\u0000hi\u0005=\u0000\u0000ij\u0005=\u0000\u0000j\"\u0001\u0000"+
		"\u0000\u0000kl\u0005<\u0000\u0000lm\u0005>\u0000\u0000m$\u0001\u0000\u0000"+
		"\u0000no\u0005!\u0000\u0000o&\u0001\u0000\u0000\u0000pq\u0005|\u0000\u0000"+
		"qr\u0005|\u0000\u0000r(\u0001\u0000\u0000\u0000st\u0005&\u0000\u0000t"+
		"u\u0005&\u0000\u0000u*\u0001\u0000\u0000\u0000vw\u0007\u0005\u0000\u0000"+
		"wx\u0001\u0000\u0000\u0000xy\u0006\u0015\u0000\u0000y,\u0001\u0000\u0000"+
		"\u0000\u0006\u0000049?E\u0001\u0000\u0001\u0000";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}