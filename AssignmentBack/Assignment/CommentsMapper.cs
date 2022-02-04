namespace Assignment
{
    public static class CommentsMapper
    {
        private static readonly SortedDictionary<decimal, string> Comments = new()
        {
            {0, "Nothing happens" },
            {1000, "Small Explosion" },
            {300000, "Big Explosion" },
            {1000000000, "Earth explodes" }
        };

        public static string GetComment(decimal energy)
        {
            return Comments
                .Where(x=> energy>=x.Key)
                .Select(x=>x.Value)
                .LastOrDefault() ?? "Unknown";
        }
    }
}
