using System;
using System.Threading;

namespace BethanysPieShop.Services.Base
{
    public abstract class ExternalApiBase
    {
        private Timer _timer;

        public ExternalApiBase(object transferableЩbject, long timeOut)
        {
            TimerCallback tm = new TimerCallback(Initialization);
            _timer = new Timer(tm, transferableЩbject, 0, timeOut);
        }

        protected abstract void Initialization(object obj);
        

    }
}