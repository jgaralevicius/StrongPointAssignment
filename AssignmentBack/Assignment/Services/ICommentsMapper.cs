namespace Assignment.Services
{
    public interface ICommentsMapper
    {
        /// <summary>
        /// Given energy
        /// </summary>
        /// <param name="energy">kinetic energy of an object</param>
        /// <returns>Comment about what would happen if object with certain kinetic energy hits the earth</returns>
        public string GetComment(decimal energy);
    }
}
