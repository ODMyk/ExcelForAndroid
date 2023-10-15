using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Excel.Parsing;
class ThrowExceptionErrorListener : BaseErrorListener, IAntlrErrorListener<int>
{
    //BaseErrorListener implementation
    public override void SyntaxError(TextWriter writer, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
    {
        throw new ArgumentException("Invalid Expression: {0}", msg, e);
    }

    //IAntlrErrorListener<int> implementation
    public void SyntaxError(TextWriter writer, IRecognizer recognizer, int offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
    {
        throw new ArgumentException("Invalid Expression: {0}", msg, e);
    }
}
