namespace Wolftech_CC.Src.Counting
{
    public class Count : EntityCounting
    {
        public Count(ICounting count) : base(count)
        {

        }

        public int GetNumberOfDescendants(News item)
        {
            return 0;
        }


    }
}
