/**
 *  Copyright (C) 2007 Knight Rider Consulting, Inc.
 *  support@knightrider.com
 *  http://www.knightrider.com
 *  
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  any later version.
 *  
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *  
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see http://www.gnu.org/licenses/
 **/
using System;
using System.Collections.Generic;
using Spring.Context;

namespace edu.uwec.cs.cs355.group4.et.events {
    /// <summary>
    ///     Event registry used to register and subscribe to events 
    ///     within the application.
    /// </summary>
    internal class EventRegistry : IApplicationContextAware {
        private IApplicationContext context;
        private IList<Object> publishQueue = new List<Object>();
        private IList<Object> subscribeQueue = new List<Object>();

        /// <summary>
        ///     Appliction context cannot be referenced until
        ///     it is fully configured so the registry 
        ///     queue's up publishers and subsribers until
        ///     the context is available.
        /// </summary>
        IApplicationContext IApplicationContextAware.ApplicationContext {
            get { return context; }
            set {
                context = value;

                foreach (Object publisher in publishQueue) {
                    context.PublishEvents(publisher);
                }
                publishQueue.Clear();

                foreach (Object subscriber in subscribeQueue) {
                    context.Subscribe(subscriber);
                }
                subscribeQueue.Clear();
            }
        }

        public IList<object> Publishers {
            set {
                foreach (object source in value) {
                    PublishEvents(source);
                }
            }
        }

        public IList<object> Subscribers {
            set {
                foreach (object source in value) {
                    Subscribe(source);
                }
            }
        }

        public void PublishEvent(object sender, ApplicationEventArgs e) {
            context.PublishEvent(sender, e);
        }

        public void PublishEvents(object sourceObject) {
            if (context == null) {
                publishQueue.Add(sourceObject);
            } else {
                context.PublishEvents(sourceObject);
            }
        }

        public void Subscribe(object subscriber) {
            if (context == null) {
                subscribeQueue.Add(subscriber);
            } else {
                context.Subscribe(subscriber);
            }
        }

        public void Subscribe(object subscriber, Type targetSourceType) {
            context.Subscribe(subscriber, targetSourceType);
        }
    }
}