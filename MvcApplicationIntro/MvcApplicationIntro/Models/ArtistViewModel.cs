using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcApplicationIntro.Models
{
	[Table("Artist")]
	public class ArtistViewModel
	{
		[Key]
		public virtual int ArtistId { get; set; }
		public virtual string Name { get; set; }
	}
}