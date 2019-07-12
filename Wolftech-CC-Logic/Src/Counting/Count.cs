namespace Wolftech_CC_Logic.Src.Counting
{
    public class Count : EntityCounting
    {

        private ICounting reader = null;
        public Count(ICounting reader) : base()
        {
            this.reader = reader;
        }

        public int GetNumberOfDescendants(News item)
        {
            return reader.GetNumberOfDescendants(item);
        }


    }
}
