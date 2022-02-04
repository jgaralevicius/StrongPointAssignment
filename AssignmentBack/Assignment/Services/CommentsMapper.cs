namespace Assignment.Services
{
    public class CommentsMapper : ICommentsMapper
    {
        private static readonly SortedDictionary<decimal, string> Comments = new()
        {
            {0, "Nothing happens" },
            {1000, "Small Explosion" },
            {300000, "Big Explosion" },
            {1000000000, "Earth explodes" }
        };

        /// <summary>
        /// Map comments to kinetic energy threshold dictionary
        /// </summary>
        /// <param name="energy">Kinetic energy of an object (J)</param>
        /// <returns>Comment for given kinetic energy</returns>
        public string GetComment(decimal energy)
        {
            return Comments
                .Where(x=> energy>=x.Key)
                .Select(x=>x.Value)
                .LastOrDefault() ?? "Unknown";
        }
    }
}
