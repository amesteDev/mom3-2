using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace records.Models
{
	public class Collection
	{
		public int CollectionId { get; set; }
		[Required(ErrorMessage = "Please set title of record!")]

		public string Title { get; set; }
		[InverseProperty("Name")]
		[Required]
		public string ArtistName { get; set; }
		public Artist Artist { get; set; }
	}
}