using System.Collections.Generic;

namespace Application.DTO.Models
{
    public sealed class PagingResult<T>
    {
        public int Total { get; set; }

        public List<T> Rows { get; set; }
    }
}
