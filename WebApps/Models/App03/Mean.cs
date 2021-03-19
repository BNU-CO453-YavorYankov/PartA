namespace WebApps.Models.App03
{
    /// <summary>
    /// This model keeps the mean of the student grades
    /// </summary>
    public class Mean
    {
        public double MeanResult { get; set; }
        public int MaxMark { get; set; }
        public int MinMark { get; set; }

        public string Message { get; set; }
    }
}
