namespace HomeworkPustok.Areas.Manage.ViewModels
{
    public class PaginationMV<T>
    {

        public List<T> Items { get; set; }
        public int PagesCount { get; set; }
        public int Page { get; set; }
        public string Search { get; set; } = null;
        public int PageItemCount { get; set; }
        public static PaginationMV<T> Create(IQueryable<T> query, int page,int size)
        {
            Console.WriteLine(query.Count());
            var items=query.Skip((page-1)*size).Take(size).ToList();
            var totalpage= (int)Math.Ceiling(query.Count() / (double)size);
            return new PaginationMV<T>()
            {
                Items = items,
                Page= page,
                PagesCount= totalpage,
                PageItemCount=size
            };
        }
    }
}
