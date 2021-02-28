using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace records.Models
{
	public class Artist
	{
		[Key]
        [Required(ErrorMessage = "Please set a name.")]
		public string Name { get; set; }

		[MinLength(3, ErrorMessage = "Use atleast 3 characters in country.")]
		public string Country { get; set; }

		public List<Collection> Collections { get; set; }
	}
}