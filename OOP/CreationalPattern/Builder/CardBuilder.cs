namespace CreationalPattern.Builder
{
    public class CardBuilder
    {
        private Card _card;

        public CardBuilder()
        {
            _card = new Card();
        }

        #region Methods for Builder without method chaining
        //public void AddReceiverName(string name)
        //{
        //    _card.ReceiverName = name;
        //}

        //public void AddMessage(string message)
        //{
        //    _card.Message = message;
        //}

        //public void AddColor(string color)
        //{
        //    _card.Color = color;
        //}

        //public void AddDesign(string design)
        //{
        //    _card.DesignName = design;
        //}
        #endregion

        public CardBuilder AddReceiverName(string name)
        {
            _card.ReceiverName = name;
            return this;
        }

        public CardBuilder AddMessage(string message)
        {
            _card.Message = message;
            return this;
        }

        public CardBuilder AddColor(string color)
        {
            _card.Color = color;
            return this;
        }

        public CardBuilder AddDesign(string design)
        {
            _card.DesignName = design;
            return this;
        }

        public Card Build()
        {
            return _card;
        }
    }
}