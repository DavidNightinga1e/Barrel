namespace Barrel.Game
{
	public struct ThrowInputResult
	{
		public float HorizontalVelocityNormalized;
		public float VerticalVelocityNormalized;

		public override string ToString()
		{
			return $"h: {HorizontalVelocityNormalized:0.00}; v: {VerticalVelocityNormalized:0.00}";
		}
	}
}