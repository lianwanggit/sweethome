using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcApplicationIntro.Models
{
	[Table("Album")]
	public class AlbumViewModel
	{
		[Key]
		public virtual int AlbumId { get; set; }
		public virtual int GenreId { get; set; }
		public virtual int ArtistId { get; set; }
		public virtual string Title { get; set; }
		public virtual decimal Price { get; set; }
		public virtual GenreViewModel Genre { get; set; }
		public virtual ArtistViewModel Artist { get; set; }
	}
}