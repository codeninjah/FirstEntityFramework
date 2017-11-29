namespace Fotboll.Models
{
	public class Player
	{
		public int PlayerId { get; set; }
		public int TeamId { get; set; }
		public virtual Team Team { get; set; }
		public string Name { get; set; }
		
	}
}