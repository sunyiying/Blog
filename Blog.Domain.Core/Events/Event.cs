﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain.Core.Events
{
    public abstract class Event : Message,INotification
    {
        public DateTime Timestamp { get; private set; }

        public Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}
