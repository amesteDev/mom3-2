using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace records.Models
{
	public class Borrower
	{
		public int BorrowerId { get; set; }
		public string BorrowerName { get; set; }
		public int CollectionId { get; set;  }
		[ForeignKey("CollectionTitle")]   
		public string Title { get; set; }
		[DataType(DataType.Date)]
        public DateTime BorrowDate { get; set; }
	}
}