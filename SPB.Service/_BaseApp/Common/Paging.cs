using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseApp.DTO
{
    public class Pager
    {
        public int pageNo { get; set; }
        public int pageSize { get; set; }
        public int rowCount { get; set; }
        public string sortColumn { get; set; }
        public string sortDirection { get; set; }
        public string searchText { get; set; }
    }

    public class PagedList<T>
    {
        public Pager pager { get; set; }
        public List<T> list { get; set; }
    }

    public class Pager<IF> where IF : new()
    {
        public int pageNo { get; set; }
        public int pageSize { get; set; }
        public int rowCount { get; set; }
        public string sortColumn { get; set; }
        public string sortDirection { get; set; }
        public string searchText { get; set; }
        public IF filter { get; set; }

        public Pager() { }

        public Pager(int pn, int ps, string sc, string sd, string st)
        {
            pageNo = pn;
            pageSize = ps;
            sortColumn = sc;
            sortDirection = sd;
            searchText = st;
            filter = new IF();
        }
    }

    public class PagedList<T, IF> where IF : new()
    {
        public object xtra { get; set; }
        public Pager<IF> pager { get; set; }
        public List<T> list { get; set; }
        public object perm { get; set; }

        public PagedList<T, IF> SetPerm(object perm)
        {
            this.perm = perm;
            return this;
        }
    }
}



namespace BaseApp.DAL
{
    internal class Pager<IF> where IF : new()
    {
        public int CurrentPage;
        public int PageSize;
        public int RowCount;
        public string SortColumn;
        public string SortDirection;
        public string SearchText;
        public IF Filter { get; set; }

        public Pager(DTO.Pager<IF> pager)
        {
            CurrentPage = pager.pageNo;
            PageSize = pager.pageSize;
            RowCount = pager.rowCount;
            SortColumn = pager.sortColumn;
            SortDirection = pager.sortDirection;
            SearchText = pager.searchText;
            Filter = pager.filter;
        }

        public DTO.Pager<IF> ToDTO<T>()
        {
            return new DTO.Pager<IF>
            {
                pageNo = CurrentPage,
                pageSize = PageSize,
                rowCount = RowCount,
                sortColumn = SortColumn,
                sortDirection = SortDirection,
                searchText = SearchText,
                filter = Filter
            };
        }
    }

    internal class Pager
    {
        public int CurrentPage;
        public int PageSize;
        public int RowCount;
        public string SortColumn;
        public string SortDirection;
        public string SearchText;

        public Pager(DTO.Pager pager)
        {
            CurrentPage = pager.pageNo;
            PageSize = pager.pageSize;
            RowCount = pager.rowCount;
            SortColumn = pager.sortColumn;
            SortDirection = pager.sortDirection;
            SearchText = pager.searchText;
        }

        public DTO.Pager ToDTO<T>()
        {
            return new DTO.Pager
            {
                pageNo = CurrentPage,
                pageSize = PageSize,
                rowCount = RowCount,
                sortColumn = SortColumn,
                sortDirection = SortDirection,
                searchText = SearchText,
            };
        }

        public DTO.Pager ToDTO()
        {
            return new DTO.Pager
            {
                pageNo = CurrentPage,
                pageSize = PageSize,
                rowCount = RowCount,
                sortColumn = SortColumn,
                sortDirection = SortDirection,
                searchText = SearchText,
            };
        }
    }

    internal class PagedList<T, IF> : List<T> where IF : new()
    {
        public Pager<IF> Paginator { get; set; }

        public PagedList(DTO.Pager<IF> pagerData) : base()
        {
            Paginator = new Pager<IF>(pagerData);
        }
    }

    internal class PagedList<T> : List<T>
    {
        public Pager Paginator { get; set; }

        public PagedList(DTO.Pager pagerData) : base()
        {
            Paginator = new Pager(pagerData);
        }
    }
}
