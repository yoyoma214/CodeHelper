/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.error;

import org.antlr.v4.runtime.DefaultErrorStrategy;
import org.antlr.v4.runtime.FailedPredicateException;
import org.antlr.v4.runtime.InputMismatchException;
import org.antlr.v4.runtime.NoViableAltException;
import org.antlr.v4.runtime.Parser;
import org.antlr.v4.runtime.RecognitionException;
import org.antlr.v4.runtime.Token;
import org.antlr.v4.runtime.misc.IntervalSet;
import org.antlr.v4.runtime.misc.NotNull;
import org.antlr.v4.runtime.misc.Nullable;

/**
 *
 * @author Administrator
 */
public class ErrorStrategy extends DefaultErrorStrategy {

     @Override
    protected void beginErrorCondition(@NotNull Parser parser) {
        super.beginErrorCondition(parser);
    }
 @Override
    public boolean inErrorRecoveryMode(Parser parser) {
        return super.inErrorRecoveryMode(parser);
    }
 @Override
    protected void endErrorCondition(@NotNull Parser parser) {
        super.endErrorCondition(parser);
    }
 @Override
    public void reportMatch(Parser parser) {
        super.reportMatch(parser);
    }
 @Override
    public void reportError(Parser parser, RecognitionException re) {
        super.reportError(parser, re);
    }
 @Override
    public void recover(Parser parser, RecognitionException re) {
        super.recover(parser, re);
    }
 @Override
    public void sync(Parser parser) throws RecognitionException {
        super.sync(parser);
    }
 @Override
    protected void reportNoViableAlternative(@NotNull Parser parser, @NotNull NoViableAltException nvae) {
        super.reportNoViableAlternative(parser, nvae);
    }
 @Override
    protected void reportInputMismatch(@NotNull Parser parser, @NotNull InputMismatchException ime) {
        super.reportInputMismatch(parser, ime);
    }
 @Override
    protected void reportFailedPredicate(@NotNull Parser parser, @NotNull FailedPredicateException fpe) {
        super.reportFailedPredicate(parser, fpe);
    }
 @Override
    protected void reportUnwantedToken(@NotNull Parser parser) {
        super.reportUnwantedToken(parser);
    }
 @Override
    protected void reportMissingToken(@NotNull Parser parser) {
        super.reportMissingToken(parser);;
    }
 @Override
    public Token recoverInline(Parser parser) throws RecognitionException {
        return super.recoverInline(parser);
    }
 @Override
    protected boolean singleTokenInsertion(@NotNull Parser parser) {
        return super.singleTokenInsertion(parser);
    }
 @Override
    @Nullable
    protected Token singleTokenDeletion(@NotNull Parser parser) {
        return super.singleTokenDeletion(parser);
    }
 @Override
    @NotNull
    protected Token getMissingSymbol(@NotNull Parser parser) {
        return super.getMissingSymbol(parser);
    }
 @Override
    @NotNull
    protected IntervalSet getExpectedTokens(@NotNull Parser parser) {
        return super.getErrorRecoverySet(parser);                
    }
 @Override
    protected String getTokenErrorDisplay(Token token) {
        return super.getTokenErrorDisplay(token);
    }
 @Override
    protected String getSymbolText(@NotNull Token token) {
        return super.getSymbolText(token);
    }
 @Override
    protected int getSymbolType(@NotNull Token token) {
        return super.getSymbolType(token);
    }
 @Override
    @NotNull
    protected String escapeWSAndQuote(@NotNull String string) {
        return super.escapeWSAndQuote(string);
    }
 @Override
    @NotNull
    protected IntervalSet getErrorRecoverySet(@NotNull Parser parser) {
        return super.getErrorRecoverySet(parser);
    }
 @Override
    protected void consumeUntil(@NotNull Parser parser, @NotNull IntervalSet is) {
       super.consumeUntil(parser, is);
    }
}
