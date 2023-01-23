namespace CreationalPattern
{
    public class Log
    {
        private static Log _log;

        private Log()
        {

        }

        public static Log GetLogger()
        {
            //One threaded Singleton Pattern
            if (_log == null)
            {
                _log = new Log();
            }

            //If Multi-threaded Singleton Pattern
            //lock("lock")
            //{
            //    if (_log == null)
            //    {
            //        _log = new Log();
            //    }
            //}
            
            return _log;
        }
    }
}