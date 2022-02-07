using ConcreteMC.MolangSharp.Parser.Expressions;
using ConcreteMC.MolangSharp.Parser.Tokenizer;

namespace ConcreteMC.MolangSharp.Parser.Parselet
{
	/// <summary>
	///		Implements the Ternary expression parser
	/// </summary>
	public class TernaryParselet : InfixParselet
	{
		/// <inheritdoc />
		public TernaryParselet() : base(Precedence.Conditional) { }

		/// <inheritdoc />
		public override IExpression Parse(MoLangParser parser, Token token, IExpression leftExpr)
		{
			if (parser.MatchToken(TokenType.Colon))
			{
				return new TernaryExpression(leftExpr, null, parser.ParseExpression(Precedence));
			}
			else
			{
				IExpression thenExpr = parser.ParseExpression(Precedence);

				if (!parser.MatchToken(TokenType.Colon))
				{
					return new TernaryExpression(leftExpr, thenExpr, null);
				}
				else
				{
					return new TernaryExpression(leftExpr, thenExpr, parser.ParseExpression(Precedence));
				}
			}
		}
	}
}