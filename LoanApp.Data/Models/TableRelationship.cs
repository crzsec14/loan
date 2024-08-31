namespace LoanApp.Data.Models
{
	public class TableRelationship
	{
		public int Id { get; set; }
		public int ChildTableId { get; set; }
		public int ParentTableId { get; set; }
	}
}
