﻿namespace Applicant.Application.Common.DataHelpers
{
    public abstract class BaseSearchModel
    {
        private int _pageNumber = 1;
        private int _pageSize = 10;
        public int PageNumber
        {
            get => _pageNumber;
            set { _pageNumber = value <= 0 ? 1 : value; }
        }
        public int PageSize
        {
            get => _pageSize;
            set { _pageSize = value <= 0 ? 10 : value; }
        }
    }
}
