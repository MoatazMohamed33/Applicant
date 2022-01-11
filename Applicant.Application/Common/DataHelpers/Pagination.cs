using System.Collections.Generic;
using System.Linq;

namespace Applicant.Application.Common.DataHelpers
{
    public class Pagination<T>
    {
        public Pagination()
        {
            Collection = new List<T>();
        }

        public Pagination(IList<T> source, in int queryPageNumber, in int queryPageSize) : base()
        {
            TotalCount = source.Count;
            TotalPages = TotalCount / queryPageSize;
            if (TotalCount % queryPageSize > 0)
                TotalPages++;
            PageSize = queryPageSize;
            PageNumber = queryPageNumber;
            Collection.AddRange(source.Skip(queryPageNumber * queryPageSize).Take(queryPageSize).ToList());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedList{T}"/> class.
        /// </summary>
        /// <param name="source">source</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="totalCount">Total count</param>
        public Pagination(IEnumerable<T> source, int pageIndex, int pageSize, int totalCount) : base()
        {
            TotalCount = totalCount;
            TotalPages = TotalCount / pageSize;
            if (TotalCount % pageSize > 0)
                TotalPages++;
            PageSize = pageSize;
            PageNumber = pageIndex;
            Collection = new List<T>();
            Collection.AddRange(source);
        }

        public Pagination(IQueryable<T> source, in int pageNumber, in int queryPageSize) : base()
        {
            TotalCount = source.Count();
            TotalPages = TotalCount / queryPageSize;
            if (TotalCount % queryPageSize > 0)
                TotalPages++;
            PageSize = queryPageSize;
            PageNumber = pageNumber;
            Collection = new List<T>();
            Collection.AddRange(source.Skip((pageNumber - 1) * queryPageSize).Take(queryPageSize).ToList());
        }

        public List<T> Collection { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
    }
}
