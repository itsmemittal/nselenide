namespace NSelenide
{
    public class PageObject
    {
        protected string Url { get; set; }
        
        protected static DOM I
        {
            get
            {
                return new DOM();
            }
        }

        public void Open()
        {
            I.Open(Url);
        }

    }
}
