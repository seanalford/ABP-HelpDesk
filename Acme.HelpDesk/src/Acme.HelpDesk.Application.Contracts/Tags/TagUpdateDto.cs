using System;
using System.ComponentModel.DataAnnotations;

namespace Acme.HelpDesk.Tags
{
    public class TagUpdateDto
    {

        [Required]
        [StringLength(TagConsts.NameMaxLength)]
        public string Name { get; set; }

    }
}