﻿namespace Mini_Blog_Application.Helper
{
    public class QueryObject
    {
        public string? Title { get; set; } = null;
        public string? Author { get; set; } = null;

        public string? SortBy { get; set; } = null;

        public bool IsDescending { get; set; } = false;
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;


    }
}
