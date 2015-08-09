using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcApplicationIntro.Models
{
	[Table("Genre")]
	public class GenreViewModel
	{
		[Key]
		public virtual int GenreId { get; set; }
		public virtual string Name { get; set; }
		public virtual string Description { get; set; }
		public virtual List<AlbumViewModel> Albums { get; set; } 
	}
}